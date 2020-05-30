using System;
using Fishing.BL.Model;
using Fishing.Presenter;
using Fishing.View.ShopForm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fishing.BL.Tests {
    [TestClass]
    public class ShopTest {
        Shop shop = new Shop();
        [TestMethod]
        public void GetRoadTest() {

            for (int i = 0; i < shop.Rods.Count; i++) {
                Assert.AreEqual(shop.Rods[i], shop.GetRod(shop.Rods[i].Name));
            }
        }

        [TestMethod]
        public void GetBaitTest() {

            for (int i = 0; i < shop.Baits.Count; i++) {
                Assert.AreEqual(shop.Baits[i], shop.GetBait(shop.Baits[i].Name));
            }
        }

        [TestMethod]
        public void GetLureTest() {

            for (int i = 0; i < shop.Lures.Count; i++) {
                Assert.AreEqual(shop.Lures[i], shop.GetLure(shop.Lures[i].Name));
            }
        }
    }
}
