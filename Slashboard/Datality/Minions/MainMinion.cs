using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data.Entity;
using Datality.ComplexTypes;
using PropertyChanged;

namespace Datality.Minions {
    [ImplementPropertyChanged]
    public class MainMinion {
        public MainMinion() {
            CrapLoad();
            using (var dt = new AshleyGraham()) {
                Pro = (dt.Pros.Any()) ? dt.Pros.Include(x=>x.Blend).FirstOrDefault() : dt.Pros.Add(new Pro());
                Blend = Pro?.Blend;
            }
        }
        public Pro Pro { get; set; }
        public Blend Blend { get; set; }
        public Brand Brand { get; set; }
        private ObservableCollection<Moniker> _proList;
        public ObservableCollection<Moniker> ProList {
            get {
                using (var ag = new AshleyGraham()) {
                    _proList = new ObservableCollection<Moniker>();
                    var ls = ag?.Pros?.Select(x=>new { x.Id, x.Name}).ToList();
                    foreach (var x in ls) {
                        _proList.Add(new Moniker(x.Id, x.Name));
                    }
                }

                return _proList;
            }
        }
        private ObservableCollection<Moniker> _blendList=new ObservableCollection<Moniker>();
        public ObservableCollection<Moniker> BlendList {
            get {
                using (var ag = new AshleyGraham()) {
                    _blendList = new ObservableCollection<Moniker>();
                    var ls = ag?.Blends?.Select(x => new { x.Id, x.Name}).ToList();
                    if (ls != null) {
                        foreach (var x in ls) {
                            _proList.Add(new Moniker(x.Id, x.Name));
                        }
                    }
                }
                return _blendList;
            }
        }
        public void NavTo(int id) {
            if (id == 0) return;
            using (var dt = new AshleyGraham()) {
                Pro = dt?.Pros?.Include(x=>x.Blend).FirstOrDefault(x => x.Id == id);
                Blend = Pro?.Blend;
            }
        }
        public void BlNavTo(int id) {
            if (id == 0) return;
            using (var dt = new AshleyGraham()) {
                Blend = dt.Blends.Include(x=>x.Pros).SingleOrDefault(x => x.Id == id);
                Pro.Blend = Blend;
            }
        }
        public void NewPro() {
            Pro = new Pro { };
            using (var ag = new AshleyGraham()) {
                ag.Pros.Add(Pro);
                ag.SaveChanges();
            }
        }
        public void NewBlend() {
            Blend = new Blend { };
            using (var ag = new AshleyGraham()) {
                ag.Blends.Add(Blend);
                ag.SaveChanges();
            }
        }
        public void Save() {
            Pro.Blend = Blend;
            using (var dt = new AshleyGraham()) {
                dt.Pros.Attach(Pro);
                dt.Blends.Attach(Blend);
                dt.Entry(Blend).State = Blend?.Id == default(int) ? EntityState.Added : EntityState.Modified;
                dt.Entry(Pro).State = Pro?.Id == default(int) ? EntityState.Added : EntityState.Modified;
                dt.SaveChanges();
            }
        }
        /// <summary>
        /// Dummy data
        /// </summary>
        private void CrapLoad() {
            using (var dt = new AshleyGraham()) {
                if (dt.Pros.Any()) return;
                var p = new Pro { Name = "Ashley Graham", Class = "Booty", Description = "Sports Illustrated" };
                var p2 = new Pro { Name = "Ruby Roxx", Class = "Volume", Description = "Indie" };
                var p3 = new Pro { Name = "Samantha Anderson", Class = "Mass", Description = "Underground" };
                var b = new Blend { Name = "Tricks" };
                var b2 = new Blend { Name = "Slats" };
                p.Blend = b; p2.Blend = b2; p3.Blend = b;
                dt.Pros.Add(p); dt.Pros.Add(p2); dt.Pros.Add(p3);
                dt.Blends.Add(b); dt.Blends.Add(b2);
                var r = new Raw { Name = "Feelium", Cas = "666", StockConcentration = "99" };
                var r2 = new Raw { Name = "Crapene", Cas = "555", StockConcentration = "60" };
                dt.Raws.Add(r); dt.Raws.Add(r2);
                dt.SaveChanges();
            }
        }
    }
}
