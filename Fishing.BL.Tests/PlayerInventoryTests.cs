using Fishing.BL.Model.Game;
using Fishing.BL.Model.Items;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Tests {
    [TestClass]
    public class PlayerInventoryTests {
        [TestMethod]
        public void GetAssemblyTest() {
            Player player = new Player();
            Rod r = new Rod("t", RodType.Spinning, 1, 1, 1, null);
            Assembly a = new Assembly(r);
            player.Inventory.Assemblies.Add(a.UniqueIdentifer, a);
            for (int i = 0; i < player.Inventory.Assemblies.Count; i++) {
                Assert.AreEqual(player.Inventory.Assemblies.Values.ElementAt(i), player.Inventory.GetAssembly(a.UniqueIdentifer));
            }
        }
    }
}
