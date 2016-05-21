using System;
using Datality.Smashley;
using Datality.Hexicon;
namespace Datality.ResearchLab {
    /// <summary>
    /// Mutants are experimental objects that eat minions and wreck shit
    /// </summary>
    public class Mutant {
        public Mutant(int id) {
            Mutate(Properties.Settings.Default.LastPro);
        }
        public void Mutate(int id) {
            Pro.Fetch(id);
            var brandId = Pro.LootItem.BrandId;
            if (brandId != null) {
                Brand.Fetch(brandId);
            }
        }
        public void Replicate() {
            Pro.LootItem.DumpToDebug<Pro>();
            Brand.LootItem.DumpToDebug<Brand>();
        }
        public Minion<Pro> Pro { get; set; } = new Minion<Pro>();
        public Minion<Brand> Brand { get; set; } = new Minion<Brand>();
    }
}


