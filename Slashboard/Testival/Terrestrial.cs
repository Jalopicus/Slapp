using Datality.Hexicon;
using Datality.Smashley;
using Datality.Overlords;
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
        public void ConstructorSabotage() {
            var f = new ElderOverlord<Formulino>();
        }
    }
}
