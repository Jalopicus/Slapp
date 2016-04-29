using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
namespace Datality.Minions {
    [ImplementPropertyChanged]
    public class SaneMinion : BaseMinion {
        public int ProFocus {
            get { return _proFocus; }
            set {
                _proFocus = value;
                this.ProFetch(_proFocus);
            }
        }
        public int BlendFocus {
            get { return _blendFocus; }
            set {
                _blendFocus = value;
                this.BlendFetch(_blendFocus);
            }
        }
        public int BrandFocus {
            get { return _brandFocus; }
            set {
                _brandFocus = value;
                this.BrandFetch(_brandFocus);
            }
        }
        [AlsoNotifyFor("ProList", "Blend")]
        public string FilterText { get; set; }
        public Pro Pro {
            get { return _pro; }
            set {
                _pro = value;
                var pb = _pro.Blend;
                Blend = pb;
            }
        }
        public Blend Blend {
            get { return _blend; }
            set {
                _blend = value;
                if (value != null) {
                    BlendFocus = value.Id;
                }
                if (value?.Formulinoes != null)
                    _formulinoes = new ObservableCollection<Formulino>(value.Formulinoes.ToList());
            }
        }
        public Brand Brand {
            get { return _brand; }
            set { _brand = value; }
        }
        [DependsOn("Blend")]
        public Formulino Formulino { get; set; }
        [DependsOn("Pro")]
        public ObservableCollection<Moniker> Clones => _clones;
        [DependsOn("Blend")]
        public ObservableCollection<Formulino> Formulinos => _formulinoes;
        [DependsOn("FilterText")]
        public ObservableCollection<Moniker> ProList {
            get {
                var ret = new List<Moniker>();
                if (FilterText != null) {
                    ret = _proList.AsEnumerable().Where(x => x.Name.Contains(FilterText)).ToList();
                    return new ObservableCollection<Moniker>(ret);
                }
                else {
                    return _proList;
                }
            }
        }
        public ObservableCollection<Moniker> Changelings => _changelings;
        
        public SaneMinion() {
            //will retrieve previously loaded record for default nav
            ProFocus = 1;
            Formulino = new Formulino();
            HeadCount();
        }

        private void HeadCount() {
            using (var ag = new AshleyGraham()) {
                _changelings = new ObservableCollection<Moniker>();
                if (ag.Blends.Any()) {
                    var bllist = ag.Blends.ToList();
                    foreach (var x in bllist) {
                        _changelings.Add(new Moniker(x.Id, x.Name));
                    }
                }
                _proList = new ObservableCollection<Moniker>();
                var prlist = ag.Pros.ToList();
                if (ag.Pros.Any()) {
                    if ((ag.Pros.Any(x => x.Name.Contains(FilterText)) && FilterText.Length > 0))
                        prlist = prlist.Where(a => a.Name.Contains(FilterText)).ToList();
                    foreach (var x in prlist) {
                        _proList.Add(new Moniker(x.Id, x.Name));
                    }
                }
                _clones = new ObservableCollection<Moniker>();
                var clns = ag.Pros.Where(x => x.BlendId == _pro.BlendId).ToList();
                if (clns != null) {
                    foreach (var x in clns) {
                        _clones.Add(new Moniker(x.Id, x.Name));
                    }
                }
            }
        }
        public void ProFetch(int id) {
            using (var ag = new AshleyGraham()) {
                Pro = ag.Pros.FirstOrDefault(x => x.Id == id);
                if (Pro != null) Blend = ag.Blends.FirstOrDefault(x => x.Id == Pro.BlendId);
            }
        }
        public void BlendFetch(int id) {
            using (var ag = new AshleyGraham()) Blend = ag.Blends.FirstOrDefault(x => x.Id == id);
        }
        public void BrandFetch(int id) {
            using (var ag = new AshleyGraham()) Brand = ag.Brands.FirstOrDefault(x => x.Id == id);
        }
        public void AddFormulino() {
            var fm = Formulino;
            using (var ag = new AshleyGraham()) {
                ag.Formulinoes.Attach(fm);
                ag.Entry(fm).State = EntityState.Added;
                Blend?.Formulinoes.Add(fm);
                var x = ag.Blends.Find(Blend?.Id);
                ag.Entry(x).CurrentValues.SetValues(Blend);
                ag.SaveChanges();
            }
        }
        public void Save() {
            Pro.BlendId = Blend.Id;
            Pro.Blend = Blend;
            using (var ag = new AshleyGraham()) {
                var x = ag.Pros.FirstOrDefault(a => a.Id == Pro.Id);
                var y = ag.Blends.FirstOrDefault(b => b.Id == Blend.Id);
                ag.Entry(x).CurrentValues.SetValues(Pro);
                ag.Entry(y).CurrentValues.SetValues(Blend);
                ag.Entry(x).State = EntityState.Modified;
                ag.Entry(y).State = EntityState.Modified;
                ag.SaveChanges();
            }
        }
        private int _proFocus;
        private int _brandFocus;
        private int _blendFocus;
        private Pro _pro;
        private Blend _blend;
        private Brand _brand;
        private Formulino _formulino;
        private ObservableCollection<Moniker> _clones;
        private ObservableCollection<Moniker> _spawn;
        private ObservableCollection<Moniker> _changelings;
        private ObservableCollection<Formulino> _formulinoes;
        private ObservableCollection<Moniker> _proList;
    }
}