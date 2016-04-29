using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using Datality;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Datality.Minions;
//using System.Data.SQLite;
using System.Data.SqlClient;
using System.Configuration;
//using System.Data.Entity;
using System.Diagnostics;


namespace Hackcess {
    [TestClass]
    public class Transdata {
        //private static string _connectionString = "data source=(LocalDb)\\MSSQLLocalDB;initial catalog = Datality.AshleyGraham; integrated security = True; MultipleActiveResultSets=True;App=EntityFramework";
        //static string _connectionString =
        //    "Data Source=BWALTERS-PC\\SQLEXPRESS;Initial Catalog=AshleyGrahamTest;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private const string ConnectionString = "Data Source=BWALTERS-PC\\SQLEXPRESS;Initial Catalog = Datality; Integrated Security = True; Connect Timeout = 15; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //static string _liteString = "Data Source=BootyCheeks.sqlite";
        [TestMethod]
        public void AccdbLift() {
            string[] cmds = { "Select * From [Product Log]" };
            using (var conn = new SqlConnection(ConnectionString)) {
                conn.Open();
                foreach (var cm in cmds) {
                    using (var cmd = new SqlCommand { Connection = conn }) {
                        cmd.CommandText = cm;
                        var res = cmd.ExecuteReader();
                        while (res.Read()) {
                            var builder = "";
                            for (var k = 0; k < res.FieldCount; k++) {
                                builder = builder + res[k] + "  ";
                            }
                            Debug.WriteLine(builder);
                        }
                        res.Close();
                    }
                }
                conn.Close();
            }
        }
        [TestMethod]
        public void LtSobj() {
            using (var lts = new LTSqlDataContext()) {
                using (var ag = new AshleyGraham()) {
                    ag.Database.Delete();
                    ag.Database.Create();
                    var lsx = lts.Product_Logs.ToList();
                    foreach (var x in lsx) {
                        var pr = new Pro {
                            Name = x.Product_name,
                            Class = x.Product_class,
                            Id = x.PID,
                            Description = x.Product_description
                        };
                        ag.Pros.Add(pr);
                    }
                    ag.SaveChanges();
                }
            }
        }
    }
}