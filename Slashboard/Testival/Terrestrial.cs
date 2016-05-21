using Datality.Hexicon;
using Datality.Smashley;
using Datality.Overlords;
using Datality.ResearchLab;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testival {
    [TestClass]
    public class TerrESTrial {
        [TestMethod]
        public void BasicExistance() {
            var p = new ElderOverlord<Pro>();
            var b = new ElderOverlord<Brand>();
            Assert.IsNotNull(p);
            Assert.IsNotNull(p.Ops);
            Assert.IsNotNull(p.Ops.Minion.LootItem);
            p.Ops.Minion.Fetch(99999);
            Assert.IsNotNull(p.Ops);
            Assert.IsNotNull(p.Ops.Minion);
            Assert.IsNull(p.Ops.Minion.LootItem);
            Assert.IsNotNull(p.Ops.FocusIndex);
        }
        [TestMethod]
        public void SplayBecauseIdgaf() {
            var nm = new Minion<Pro>();
            nm.Fetch(1);

        }
       [TestMethod]
        public void Abominate() {
            var x = new Mutant(1);
            x.Replicate();
            x.Mutate(2);
            x.Replicate();
            x.Mutate(3);
        }
        [TestMethod]
        public void Alpha() {
            var alph = new AlphaOverlord();
            alph.FocusIndex = 1;
        }
    }
}
