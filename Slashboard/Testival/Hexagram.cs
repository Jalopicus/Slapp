//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Datality;
//using System.Data.OleDb;
//using System.Linq;
//using System.Text.RegularExpressions;
//using Datality.enums;
//using Datality.Hexicon;
//using Datality.Hexicon.enums;
//namespace Testival {
//    [TestClass]
//    public class Hexagram {
//        private static string _HackCess_String =
//            "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'C:\\Users\\Bwalters.COLLOID\\Desktop\\Live\\Product Dossier.accdb'";
//        [TestMethod]
//        public void LexiconExodus() {
//            var sw = new Stopwatch();
//            sw.Start();
//            Construction();
//            Verbosity();
//            Join();
//            sw.Stop();
//            Debug.WriteLine("Lexicon Exodus complete in {0}", sw.Elapsed);
//        }
//        public void Construction() {
//            var sw = new Stopwatch();
//            sw.Start();
//            using (var hx = new Hexicon()) {
//                hx.Database.Delete();
//                hx.Database.Create();
//            }
//            using (var con = new OleDbConnection(_HackCess_String)) {
//                con.Open();
//                using (var cmd = new OleDbCommand { Connection = con }) {
//                    cmd.CommandText =
//                        "SELECT ID, Hazard_code, Hazard_class, Hazard_category, Symbol, Signal_word, Hazard_statement FROM [Hazard Lexicon]";
//                    var rdr = cmd.ExecuteReader();
//                    if (rdr == null) return;
//                    var lst = new List<Hazard>();
//                    using (var hx = new Hexicon()) {
//                        while (rdr.Read()) {
//                            var nh = new Hazard();
//                            nh.Id = int.Parse(rdr["ID"].ToString());
//                            nh.Code = rdr["Hazard_code"].ToString();
//                            nh.Class = rdr["Hazard_class"].ToString();
//                            nh.Category = rdr["Hazard_category"].ToString();
//                            if (rdr["Symbol"].ToString() == "") {
//                                nh.Pictogram = Pictogram.None;
//                            } else {
//                                var tmp = rdr["Symbol"].ToString().Banish(" ");
//                                nh.Pictogram = (Pictogram)Enum.Parse(typeof(Pictogram), tmp);
//                            }
//                            nh.SignalWord = (SignalWord)Enum.Parse(typeof(SignalWord), rdr["Signal_word"].ToString());
//                            nh.Statement = rdr["Hazard_statement"].ToString();
//                            nh.DumpToDebug();
//                            lst.Add(nh);
//                        }
//                        hx.Hazards.AddRange(lst);
//                        hx.SaveChanges();
//                    } //hx
//                } //cmd
//                con.Close();
//            } //con
//            using (var hx = new Hexicon()) {
//                Assert.AreNotEqual(0, hx.Hazards.Count());
//            }
//            Debug.WriteLine("Hazards processed in {0}", sw.Elapsed);
//            sw.Stop();
//        }
//        public void Verbosity() {
//            var sw = new Stopwatch();
//            sw.Start();
//            using (var hx = new Hexicon()) {
//                Assert.AreNotEqual(0, hx.Hazards.Count());
//            }
//            using (var con = new OleDbConnection(_HackCess_String)) {
//                con.Open();
//                using (var cmd = new OleDbCommand { Connection = con }) {
//                    cmd.CommandText = "SELECT [Precautionary_code], [Precautionary_statement], [Precaution_type], [Sorter] FROM [Precautionary Lexicon]";
//                    var rdr = cmd.ExecuteReader();
//                    if (rdr == null) return;
//                    var lst = new List<CounterHazard>();
//                    using (var hx = new Hexicon()) {
//                        while (rdr.Read()) {
//                            var ch = new CounterHazard();
//                            ch.Code = rdr["Precautionary_code"].ToString();
//                            ch.Subtype = (Subtype)Enum.Parse(typeof(Subtype), rdr["Precaution_type"].ToString());
//                            ch.Statement = rdr["Precautionary_statement"].ToString();
//                            ch.Sort = int.Parse(rdr["Sorter"].ToString());
//                            ch.DumpToDebug();
//                            lst.Add(ch);
//                        }
//                        hx.CounterHazards.AddRange(lst);
//                        hx.SaveChanges();
//                    }//hx
//                }//cmd
//                con.Close();
//            }//con
//            using (var hx = new Hexicon()) {
                
//                Assert.AreNotEqual(0, hx.CounterHazards.Count());
//            }
//            sw.Stop();
//            Debug.WriteLine("Counterhazards processed in {0}", sw.Elapsed);
//        }
//        public void Join() {
//            var sw = new Stopwatch();
//            sw.Start();
//            using (var con = new OleDbConnection(_HackCess_String)) {
//                con.Open();
//                using (var cmd = new OleDbCommand { Connection = con }) {
//                    cmd.CommandText =
//                        "SELECT [ID], [PCodes] FROM [Hazard Lexicon]";
//                    var rdr = cmd.ExecuteReader();
//                    if (rdr == null) return;
//                    while (rdr.Read()) {
//                        var hid = int.Parse(rdr["ID"].ToString());
//                        var plist = rdr["PCodes"].ToString().Split(";"[0]);
//                        foreach (var p in plist) {
//                            using (var hx = new Hexicon()) {
//                                var hz = hx.Hazards.FirstOrDefault(a => a.Id == hid);
//                                var ch = hx.CounterHazards.FirstOrDefault(b => b.Code == p);
//                                hz?.Counters.Add(ch);
//                                hx.SaveChanges();
//                            }
//                        }
//                    }
//                    rdr.Close();
//                }
//                con.Close();
//            }
//            using (var hx = new Hexicon()) {
                
//                Assert.AreNotEqual(0, hx?.Hazards?.FirstOrDefault()?.Counters.Count());
//            }
//            sw.Stop();
//            Debug.WriteLine("Join() procedure complete in {0}", sw.Elapsed);
//        }
//        [TestMethod]
//        public void Posturing() {
//            using (var hx = new Hexicon()) {
                
//                var parm = hx.Hazards?.Where(x => (x.Code == "H101") || (x.Code=="H201")).ToList();
//                var rez = new HazardResolve(parm);
//                foreach (var hz in rez.CounterHazards) {
//                    Debug.WriteLine(hz);
//                }
//            }
            
//        }
//        [TestMethod]
//        public void Posing() {
//            var op = new Optics();
            

//        }
//    }
//}
