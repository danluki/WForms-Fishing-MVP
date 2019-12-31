using Fishing.BL.Resources.Images;
using System;
using System.Drawing;

namespace Fishing.BL.Model.Hooks {

    [Serializable]
    internal sealed class FloatsHook : BaseHook {

        public FloatsHook(string name, int gatch, int price, Bitmap bit) : base(name, gatch, price, bit) {
        }

        public static FloatsHook baitHolder = new FloatsHook("Bait Holder", 25, 800, HooksImg.BaitHolder);
        public static FloatsHook barakuda = new FloatsHook("Barracuda", 20, 1500, HooksImg.Barracuda);
        public static FloatsHook takara = new FloatsHook("Takara 2002", 12, 2500, HooksImg.Takara_2002);
        public static FloatsHook wormStrong = new FloatsHook("Worm_X_Strong", 7, 5000, HooksImg.Worm_X_Strong);
    }
}