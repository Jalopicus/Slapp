using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datality;

using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Testival {
    [TestClass]
    public class MinionTraining {
        private static string _connectionString = "data source=(LocalDb)\\MSSQLLocalDB;initial catalog = Datality.AshleyGraham; integrated security = True; MultipleActiveResultSets=True;App=EntityFramework";
        //static string _connectionString =
        //    "Data Source=BWALTERS-PC\\SQLEXPRESS;Initial Catalog=AshleyGrahamTest;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //  static string _liteString = "Data Source=BootyCheeks.sqlite";
        [TestMethod] public void FightPass() {
        //    var min = new SaneMinion();

        //    Debug.WriteLine("Clones");
        //    foreach (var x in min.Clones) {
        //        Debug.WriteLine(x.Name);
        //    }
        //    Debug.WriteLine(" ");
        //    Debug.WriteLine("Changelings");
        //    foreach (var x in min.Changelings) {
        //        Debug.WriteLine(x.Name);
        //    }
        //    for (var k = 1; k <= min.Clones.Count; k++) {
        //        min.ProFocus = k;
        //        Debug.WriteLine(" ");
        //        Debug.WriteLine(min.Pro.Name);
        //        Debug.WriteLine(min.Pro.Class);
        //        Debug.WriteLine(min.Pro.Description);
        //        Debug.WriteLine(min.Pro.BlendId);
        //    }
        //    HackDoor();
        //}
        //[TestMethod] public void EarlyPrelims() {
        //    var min = new SaneMinion();
        //    Debug.WriteLine("Clones");
        //    foreach (var x in min.Clones) {
        //        Debug.WriteLine(x.Name);
        //    }
        //    Debug.WriteLine(" ");
        //    Debug.WriteLine("Changelings");
        //    foreach (var x in min.Changelings) {
        //        Debug.WriteLine(x.Name);
        //    }
        //    for (var k = 1; k <= 5; k++) {
        //        min.ProFocus = k;
        //        min.Pro.Name = min.Pro.Name.ToUpper();
        //        min.BrandFocus = 3;
        //        min.BlendFocus = 3;
        //        min.Save();
        //    }
        //    for (var k = 1; k <= 5; k++) {
        //        min.ProFocus = k;
        //        Debug.WriteLine(min.Pro.Name);
        //        Debug.WriteLine(min.Blend.Name);
        //    }
        //    HackDoor();
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

