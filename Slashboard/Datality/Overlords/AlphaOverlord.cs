using System.Collections.Generic;
using Datality.Properties;
using Datality.Smashley;
using Datality.Smashley.Extensions;
using PropertyChanged;
using System.Linq.Expressions;
using System.Reflection;
namespace Datality.Overlords {
    [ImplementPropertyChanged]
    public class AlphaOverlord : IOverlord {
        public AlphaOverlord() {
            try {
                _focusIndex= (int) Settings.Default["Last" + typeof (Pro).Name];
                Grip(_focusIndex);
            }
            catch {
                Grip(1);
            }
            //_inventory = ProOps.Minion.Inventory();
            _inventory = ProMinion.Inventory();
            BuildSpecList();
        }
        public List<Thing> SpecList { get { return _specList; } }
        private List<Thing> _specList = new List<Thing>();
        private void BuildSpecList() {
            foreach (var x in BlendMinion.LootItem.GetType().GetProperties()) {
                if(x.PropertyType==typeof(string)) _specList.Add(new Thing(_specList.Count, x.Name));
            }
        }
        //public Ops<Pro> ProOps { get; set; } = new Ops<Pro>();
        public Minion<Pro> ProMinion { get; set; } = new Minion<Pro> ();
        public Minion<Blend> BlendMinion { get; set; } = new Minion<Blend>();
        public Minion<Brand> BrandMinion { get; set; } = new Minion<Brand>();
        public string CityStateZip => BrandMinion.LootItem.CityStateZip();
        public  List<Thing> Inventory=>  _inventory; 
        private readonly List<Thing> _inventory;
        public List<Thing> Clones { get { return _clones; } }
        private List<Thing> _clones = new List<Thing>();

        public int FocusIndex {
            get {
                //      return ProOps.FocusIndex;
                return _focusIndex;
            }
            set {
                _focusIndex = value;
                Grip(_focusIndex);
            }
        }
        private int _focusIndex;
        public void Grip(int id) {
            ProMinion.Fetch(_focusIndex);
            BlendMinion.Fetch(ProMinion.LootItem.BlendId);
            BrandMinion.Fetch(ProMinion.LootItem.BrandId);
            _clones = ProMinion.LootItem.HasTheseClones();
        }
        public void Dispose() {
            Settings.Default["LastPro"] = _focusIndex;
            Settings.Default.Save();
        }
    }
    
}