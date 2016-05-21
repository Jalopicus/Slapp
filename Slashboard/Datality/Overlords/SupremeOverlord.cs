using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datality.Smashley;
namespace Datality.Overlords {
    public class SupremeOverlord<T> : ISupremacy<T>, IOverlord where T : class, IVoyeur, new() {

        public SupremeOverlord() {
            Loading = true;
            using (var ag = new AshleyGraham()) {
                _population = ag.Set<T>().AsEnumerable().Where(x => x.Thing.Number < 50).ToList<T>();
            }
            Loading = false;
        }
       
        private bool _loading;
        public bool Loading {
            get { return _loading; }
            set { _loading = value; }
        }
        private List<T> _population;
        public List<T> Population {
            get { return _population; }
            set { _population = value; }
        }

        public void Dispose() {
            
        }
        //public void Savior(List<T> sycophants) {
        //    _ag.SaveChanges();
        //}
        //public void Smite(List<T> insolents) {
        //    _ag.SaveChanges();
        //}
    }
    internal interface ISupremacy<T> {
        List<T> Population { get; set; }
        bool Loading { get; }
    }
}
