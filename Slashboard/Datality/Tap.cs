using System.Linq;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data.Entity.Infrastructure.Pluralization;
using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Data.OleDb;

namespace Datality {
    public static class EntityExtensions {
        public static void HackCess<T>(this DbSet<T> sett, OleDbCommand cmd) where T : Bass, new() {
            var ent = new T();
            var pluralizationService = DbConfiguration.DependencyResolver.GetService<IPluralizationService>();
            var cname = pluralizationService.Pluralize(typeof(T).Name);
            cmd.CommandText = "Select * FROM Datality_" + cname;
            var res = cmd.ExecuteReader();
            while (res.Read()) {
                ent = new T();
                var cols = Enumerable.Range(0, res.FieldCount).Select(res.GetName).ToList();
                foreach (var col in cols) {
                    if (res[col] == System.DBNull.Value) continue;
                    try {
                        ent.GetType().GetProperty(col).SetValue(ent, (res[col]));
                    }
                    catch (System.IndexOutOfRangeException e) {
                        Debug.WriteLine("Unmatched column " + col);
                    }
                    catch (System.ArgumentException e) {
                        Debug.WriteLine("System.DBNull skipped for " + col);
                    }
                }
                sett.Add(ent);
            }
            res.Close();
        }
    }
}

