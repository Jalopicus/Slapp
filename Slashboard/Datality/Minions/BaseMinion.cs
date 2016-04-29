using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
namespace Datality.Minions {
    public abstract class BaseMinion {
        public void Save(Pro p) {
            if (p == null) return;
            using (var ag = new AshleyGraham()) {
         //       ag.Pros.Attach(p);
                ag.Entry(p).State = EntityState.Modified;
                try {
                    ag.SaveChanges();
                }
                catch (DbUpdateException ex) {
                    Console.Error.WriteLine(ex.InnerException);
                }
            }
        }
        public void Save(Blend b) {
            if (b == null) return;
            using (var ag = new AshleyGraham()) {
                ag.Blends.Attach(b);
                try {
                    ag.SaveChanges();
                }
                catch (DbUpdateException ex) {
                    Console.Error.WriteLine(ex.InnerException);
                }
            }
        }
        public void Save(Raw r) {
            if (r == null) return;
            using (var ag = new AshleyGraham()) {
                ag.Raws.Attach(r);
                try {
                    ag.SaveChanges();
                }
                catch (DbUpdateException ex) {
                    Console.Error.WriteLine(ex.InnerException);
                }
            }
        }
    }
}