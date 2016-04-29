using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data;
using System.Linq;
using Datality;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Datality.Minions;
//using System.Data.SQLite;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;

namespace Testival {
    [TestClass]
    public class TestivalofLights {
        private static string _connectionString = "data source=(LocalDb)\\MSSQLLocalDB;initial catalog = Datality.AshleyGraham; integrated security = True; MultipleActiveResultSets=True;App=EntityFramework";
        static string _connectionString_testdb =
            "Data Source=BWALTERS-PC\\SQLEXPRESS;Initial Catalog=AshleyGrahamTest;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static string _liteString = "Data Source=BootyCheeks.sqlite";

        [TestMethod]
        public void ScrapLoad() {
            var p = new Pro { Name = "Joanna Jedrzejczyk", Class = "Champ", Description = "Muy Thai" };
            var p2 = new Pro { Name = "Paige VanZant", Class = "Contender", Description = "Brazilian Jiu-Jitsu" };
            var p3 = new Pro { Name = "Ronda Rousey", Class = "Contender", Description = "Judo" };
            var p4 = new Pro { Name = "Miesha Tate", Class = "Champ", Description = "Wrestling" };
            var p5 = new Pro { Name = "Gabi Garcia", Class = "Champ", Description = "Brazilian Jiu-Jitsu" };
            var b = new Blend { Name = "Striker" };
            var b2 = new Blend { Name = "Grappler" };
            var b3 = new Blend { Name = "Striker/Grappler" };
            var r = new Raw { Name = "Muy Thai", Cas = "666", StockConcentration = "99" };
            var r2 = new Raw { Name = "Brazillian Jiu-Jitsu", Cas = "555", StockConcentration = "60" };
            var r3 = new Raw { Name = "Judo", Cas = "444", StockConcentration = "40" };
            var r4 = new Raw { Name = "Boxing", Cas = "333", StockConcentration = "40" };
            var br = new Brand { Name = "Straweight" };
            var br2 = new Brand { Name = "Bantamweight" };
            var br3 = new Brand { Name = "Heavyweight" };

            using (var dt = new AshleyGraham()) {
                dt.Database.Delete();
                dt.Database.CreateIfNotExists();
                dt.Pros.AddRange(new List<Pro> { p, p2, p3, p4, p5 });
                dt.Blends.AddRange(new List<Blend> { b, b2, b3 });
                dt.Raws.AddRange(new List<Raw> { r, r2, r3, r4 });
                dt.Brands.AddRange(new List<Brand> { br, br2, br3 });
                dt.SaveChanges();
            }
            using (var ag = new AshleyGraham()) {
                Assert.AreEqual(5, ag.Pros.Count());
                Assert.AreEqual(3, ag.Brands.Count());
                Assert.AreEqual(4, ag.Raws.Count());
                Assert.AreEqual(3, ag.Blends.Count());
            }
        }
        [TestMethod]
        public void WeighIns() {
            using (var ag = new AshleyGraham()) {
                var p = ag.Pros.ToArray();
                var b = ag.Blends.ToArray();
                var br = ag.Brands.ToArray();
                p[0].IsCloneOf(b[0]);
                p[1].IsCloneOf(b[0]);
                b[2].IsChangelingTo(p[2]);
                b[2].IsChangelingTo(p[3]);
                p[4].IsCloneOf(b[1]);
                var sw = ag.Brands.FirstOrDefault(x => x.Name == "Straweight");
                sw.IsBrandOf(p[0]);
                sw.IsBrandOf(p[1]);
                var rr = ag.Pros.FirstOrDefault(x => x.Name == "Ronda Rousey");
                rr.IsBrandedBy(br[1]);
                var mt = ag.Pros.FirstOrDefault(x => x.Name == "Miesha Tate");
                mt.IsBrandedBy(br[1]);
                var hw = ag.Brands.FirstOrDefault(x => x.Name == "Heavyweight");
                hw.IsBrandOf(p[4]);
                for (int k = 0; k < p.Count(); k++) {
                    ag.Entry(p[k]).State = EntityState.Modified;
                }
                ag.SaveChanges();
            }
            using (var ag = new AshleyGraham()) {
                Assert.AreEqual("Joanna Jedrzejczyk",
                    ag.Pros.FirstOrDefault(x => (x.Class == "Champ") && (x.Brand.Name == "Straweight"))?.Name);
                Assert.AreEqual("Joanna Jedrzejczyk",
                    ag.Brands?.FirstOrDefault(x=>x.Name=="Straweight")?.Pros?.FirstOrDefault(x=>x.Class=="Champ")?.Name);
                Assert.AreEqual("Paige VanZant", ag.Brands?.FirstOrDefault(x=>x.Name=="Straweight")?.Pros?.FirstOrDefault(x=>x.Class=="Contender")?.Name);
            }
            HackDoor();
        }
        [TestMethod]
        public void FightStyles() {
            using (var ag = new AshleyGraham()) {
                var b = ag.Blends.ToArray();
                var r = ag.Raws.ToArray();
                var t = b[0].Formulate(r[0]);
                var u = b[0].Formulate(r[3]);
                var v = b[1].Formulate(r[1]);
                var w = b[1].Formulate(r[2]);
                var x = b[2].Formulate(r[1]);
                var y = b[2].Formulate(r[2]);
                var z = b[2].Formulate(r[3]);
                if (t != null) ag.Formulinoes.Add(t);
                if (u != null) ag.Formulinoes.Add(u);
                if (v != null) ag.Formulinoes.Add(v);
                if (w != null) ag.Formulinoes.Add(w);
                if (x != null) ag.Formulinoes.Add(x);
                if (y != null) ag.Formulinoes.Add(y);
                if (z != null) ag.Formulinoes.Add(z);
                for (int k = 0; k < b.Count(); k++) {
                    ag.Entry(b[k]).State = EntityState.Modified;
                }
                ag.SaveChanges();
            }
            HackDoor();
        }
        [TestMethod]
        public void HerbDean() {
            using (var ag = new AshleyGraham()) {
                var ps = ag.Pros.ToArray();
                foreach (var x in ps) {
                    Debug.WriteLine(x.Name + " " + x.Blend.Name + " " + x.Blend.Formulinoes.First().BlendId);
                }
            }
            using (var ag = new AshleyGraham()) {
                var bs = ag.Blends.ToArray();
                foreach (var x in bs) {
                    Debug.WriteLine(x.Name);
                    foreach (var y in x.Pros.ToArray()) {
                        Debug.WriteLine(y.Name);
                    }
                }
            }
            using (var ag = new AshleyGraham()) {
                var rs = ag.Raws.ToArray();
                foreach (var x in rs.ToArray()) {
                    Debug.WriteLine(x.Id);
                    foreach (var y in x.Formulinoes) {
                        if (y?.Blend?.Name != null) Debug.WriteLine(y?.Blend?.Name);
                    }
                }
            }
            using (var ag = new AshleyGraham()) {
                Assert.AreEqual("Bantamweight", ag.Pros?.FirstOrDefault(x => x.Name == "Ronda Rousey")?.Brand?.Name);
                Assert.AreEqual(1, ag.Brands.Find(3).Pros.Count());
                Assert.AreEqual(3, ag.Brands?.Find(2)?.Pros?.FirstOrDefault()?.Blend?.Formulinoes?.Count);
            }
            HackDoor();
        }
        [TestMethod] public void WipeTestDb() {
            using (var ag = new AshleyGraham()) {
                ag.Database.Delete();
            }
        }
        public void HackDoor() {
            string[] cmds = { "Select * From Pros", "Select * From Blends", "Select * From Formulinoes", "Select * From Raws", "Select * From Brands" };
            using (var conn = new SqlConnection(_connectionString)) {
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
    }
}

