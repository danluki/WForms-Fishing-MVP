using System;
using System.Drawing;

namespace Fishing.BL.Model.Hooks {

    [Serializable]
    public class FeederHook : BaseHook {

        public FeederHook(string name, int gatch, int price, Bitmap bit) : base(name, gatch, price, bit) {
        }
    }
}