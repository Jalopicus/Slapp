using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data.Entity;
using Datality.ComplexTypes;
using PropertyChanged;

namespace Datality.Minions {
    [ImplementPropertyChanged]
    public class MainMinion : BaseMinion {
        public MainMinion() {
            CrapLoad();
            using (var dt = new AshleyGraham()) {
                Pro = dt.Pros.FirstOrDefault();
                Blend = Pro?.Blend;
            }
        }
        public Pro Pro { get; set; }
        public Blend Blend {get; set; }
        public Brand Brand { get; set; }
        public Formulino Formulino { get; set; }
        public List<Formulino> Formulinoes { get; set; }
        public List<string> Clones { get; set; }
        private ObservableCollection<Moniker> _proList;
        
        public void NavTo(int id) {
            if (id == 0) return;
            using (var dt = new AshleyGraham()) {
                Pro = dt?.Pros?.Find(id);
                Blend = Pro?.Blend;
            }
        }
        public void BlNavTo(int id) {
            if (id == 0) return;
            using (var dt = new AshleyGraham()) {
                Blend = dt?.Blends?.FirstOrDefault(x => x.Id == id);
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
            using (var dt = new AshleyGraham()) {
                Pro.Blend = Blend; //change nav
                dt.Entry(Pro).State = (Pro?.Id == default(int)) ? EntityState.Added : EntityState.Modified;
                dt.SaveChanges();
            }
        }
        public void AddFormulino() {
            if (Formulino == null) return;
            Blend.Formulinoes.Add(Formulino);
            //using (var dt = new AshleyGraham()) {
            //} 
        }
        /// <summary>
        /// Dummy data
        /// </summary>
        private void CrapLoad() {
           
        }
    }
}
