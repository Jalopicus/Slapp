using System;
using System.Data.Entity.Validation;
using System.Data;
using System.Linq;
using Datality;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Datality.Minions;


namespace Testival {
    [TestClass]
    public class TestivalofLights {
        [TestMethod] public void BumStructs() {
            var blind = new Pro { Name = "Testium1", Description = "Crapturd1", Class = "Buttholes1", Blend = new Blend {}};
            using (var ag = new AshleyGraham()) {
                ag.Database.CreateIfNotExists();
                ag.Pros.Add(new Pro { Name = "Testium2", Description = "Crapturd2", Class = "Buttholes2", Blend=new Blend { }} );
                ag.SaveChanges();
            }
            using (var ag = new AshleyGraham()) {
                ag.Pros.Add(blind);
                ag.SaveChanges();
            }
        }
        [TestMethod] public void IsThisThingOn() {
            using (var dt = new Datality.AshleyGraham()) {
                var b = dt.GetValidationErrors();
                Assert.AreEqual(0, b.Count());
            }
        }
        [TestMethod] public void CourseLoad() {
            var Mm = new MainMinion();
            var n = Mm.Pro.Name;
        }
    }
}
