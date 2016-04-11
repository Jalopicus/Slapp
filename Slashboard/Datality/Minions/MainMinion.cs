using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Datality.Minions {
    public class MainMinion :INotifyPropertyChanged {
        public MainMinion() {
            CrapLoad();
            using (var dt = new AshleyGraham()) {
                Pro = (dt.Pros.Count() > 0) ? dt.Pros.FirstOrDefault() : dt.Pros.Add(new Pro());
                Blend = Pro.Blend;
            }
        }
        public Pro Pro { get; set; }
        public Blend Blend { get; set; }
        public Brand Brand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPc(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void Nav(bool Up) {
            using (var dt = new AshleyGraham()) {
                var cnt = dt.Pros.Count();
                var prs = dt.Pros.ToList();
                var idx = prs.IndexOf(prs.Single(x => (x.Id == Pro.Id)));
                Pro = prs.ElementAt((idx + cnt + (Up ? 1 : -1)) % cnt);
                Blend = (Pro.Blend != null) ? Pro.Blend : dt.Blends.Add(new Blend { Name = Pro.Name });
                dt.Entry<Blend>(Blend).State = (Blend.Id == 0) ? EntityState.Added : EntityState.Modified;
                dt.Entry<Pro>(Pro).State = EntityState.Modified;
               // dt.Entry<Blend>(Blend).State = EntityState.Modified;
            }
            OnPc("Pro");
        }
        public void Save() {
            using (var dt = new AshleyGraham()) {
     
                dt.SaveChanges();
            }
        }
        private void CrapLoad() {
            using (var dt = new AshleyGraham()) {
                if (dt.Pros.Count() == 0) {
                    var p = new Pro { Name = "Test pro1", Class = "Butt", Description = "Slats" };
                    var p2 = new Pro { Name = "Test pro2", Class = "Gap", Description = "Slats" };
                    var p3 = new Pro { Name = "Test pro3", Class = "Shout", Description = "Slats" };
                    dt.Pros.Add(p); dt.Pros.Add(p2); dt.Pros.Add(p3);
                    var b = new Blend { Name = "HJBJ" };
                    var b2 = new Blend { Name = "AOA" };
                    dt.Blends.Add(b); dt.Blends.Add(b2);
                    var r = new Raw { Name = "Raw 1", Cas = "666", StockConcentration = "69" };
                    var r2 = new Raw { Name = "Raw 2", Cas = "555", StockConcentration = "60" };
                    dt.Raws.Add(r); dt.Raws.Add(r2);
                    dt.SaveChanges();
                }
            }
        }
    }
}
