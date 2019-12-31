using Fishing.BL.Model.Items;
using System;
using System.Drawing;

namespace Fishing.BL.Model.Hooks {

    [Serializable]
    public abstract class BaseHook : Item {
        public int GatheringChance { get; }

        public BaseHook(string name, int gatch, int price, Bitmap bit) : base(name, price, bit) {
            GatheringChance = gatch;
        }

        public override string ToString() {
            return Name;
        }
    }
}