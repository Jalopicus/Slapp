using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Datality;

namespace Testival {
    [TestClass]
    public class TestivalofLights {
        [TestMethod] public void BumStructs() {
            var a = new LegacyRatings {};
            Assert.AreEqual(0, a.Hmis.F);
            a.Hmis.F = 3;
            Assert.AreEqual(3, a.Hmis.F);
            Assert.IsNull(a.Hmis.Sp);

            var b = new Blend {};

            using (var ag = new AshleyGraham()) {
                ag.Database.CreateIfNotExists();
                ag.Pros.Add(new Pro {Name="Testium", Description="Crapturd", Class="Buttholes"});
                ag.SaveChanges();
            }

            




        }
    }
}
