using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Datality;
using System.Data.OleDb;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using Datality.Smashley;
namespace Testival {
    [TestClass]
    public class Haccess {
        private static string _target_String =
            "Data Source=BWALTERS-PC\\SQLEXPRESS;Initial Catalog = AshleyGrahamTest; Integrated Security = True; Connect Timeout = 15; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private static string _HackCess_String =
            "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'C:\\Users\\Bwalters.COLLOID\\Desktop\\Live\\Product Dossier.accdb'";
        [TestMethod]
        public void Tap() {
            using (var ag = new AshleyGraham()) {
                ag.Database.Delete();
                ag.Database.CreateIfNotExists();
            }
            string[] hacks = { "Datality_Blends", "Datality_Brands", "Datality_Pros", "Datality_Toxicities" };
            foreach (var hack in hacks) {
                var hacky = hack.Split("_"[0])[1];
                using (var x = new OleDbConnection(_HackCess_String)) {
                    x.Open();
                    using (var y = new SqlConnection(_target_String)) {
                        y.Open();
                        using (var xcmd = new OleDbCommand { Connection = x }) {
                            xcmd.CommandText = "SELECT * FROM " + hack;
                            var xread = xcmd.ExecuteReader();
                            var cols = Enumerable.Range(0, xread.FieldCount).Select(xread.GetName).ToList();
                            using (var ycmd = new SqlCommand { Connection = y }) {
                                //Identity insert on
                                ycmd.CommandText = "SET IDENTITY_INSERT " + hacky + " ON";
                                try {
                                    if(hacky!="Toxicities") ycmd.ExecuteNonQuery();
                                } catch (Exception) {
                                    Debug.WriteLine("Identity insert ON failed for " + hacky);
                                }
                                //Insert into
                                while (xread.Read()) {
                                    var build = "INSERT INTO " + hacky + "(";
                                    var col = cols.Where(cl => xread[cl] != System.DBNull.Value).ToArray();
                                    build += String.Join(", ", col);
                                    build += ") VALUES (";
                                    build += String.Join(",", col.Select(cl => "@" + cl));
                                    build += ");";
                                    ycmd.CommandText = build;
                                
                                    foreach (var c in col) {
                                        ycmd.Parameters.AddWithValue(c, xread[c]);
                                    }
                                    ycmd.ExecuteNonQuery();
                                    ycmd.Parameters.Clear();
                                }
                                //Identity insert off
                                ycmd.CommandText = "SET IDENTITY_INSERT " + hacky + " OFF";
                                try {
                                    ycmd.ExecuteNonQuery();
                                } catch (Exception) {
                                    Debug.WriteLine("Identity insert OFF failed for " + hacky);
                                }
                            }
                        }
                        y.Close();
                    }
                    x.Close();
                }
            }
        }
        [TestMethod] public void ConfirmHack() {
            using (var ag = new AshleyGraham()) {
                var pcount = ag.Pros.Count();
                var bcount = ag.Brands.Count();
                var rcount = ag.Raws.Count();
                var tcount = ag.Toxicities.Count();
                var blcount = ag.Blends.Count();
                Assert.AreNotEqual(0, pcount);
                Assert.AreNotEqual(0, bcount);
                Assert.AreNotEqual(0, rcount);
                Assert.AreNotEqual(0, tcount);
                Assert.AreNotEqual(0, blcount);

                var x = ag.Pros.FirstOrDefault(p => p.Name == "Citric acid");
                Assert.IsNotNull(x);
                var y = ag?.Pros?.FirstOrDefault(p => p.Name == "NC-233")?.Brand?.Name;
                Assert.AreEqual("National Colloid", y);
                var z = ag?.Pros?.FirstOrDefault(p => p.Name == "NC-233")?.BrandId;
                var z2 = ag?.Brands?.FirstOrDefault(b => b.Name == "National Colloid")?.Id;
                Assert.AreEqual(z, z2);
            }
        }
    }
}