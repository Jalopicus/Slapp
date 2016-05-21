using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using PropertyChanged;
using System.Linq;
using Datality.Smashley;
namespace Datality.Overlords {
    /// <summary>
    /// Ops are performed by Minions as orchestrated by Overlords
    /// </summary>
    /// <typeparam name="T">Exhibitionist entity type</typeparam>
    [ImplementPropertyChanged]
    public class Ops<T> : IOps<T> where T : class, IVoyeur, new() {
        public Ops() {
            _minion = new Minion<T>();
            _focusIndex = Minion.LootItem.Thing.Number;
        }
        private Minion<T> _minion;
        public Minion<T> Minion {
            get { return _minion; }
            set {
                _minion = value;
            }
        }
        public int FocusIndex {
            get { return _focusIndex; }
            set {
                _focusIndex = value;
                Deploy(_focusIndex);
            }
        }
        private int _focusIndex;
        //public ObservableCollection<Thing> Inventory => new ObservableCollection<Thing>(Minion.Inventory());
        public void Deploy(int assignment) {
            Minion.Fetch(assignment);
        }
    }
}