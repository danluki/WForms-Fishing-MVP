using System;
using System.Drawing;

namespace Fishing.BL.Model.Lures {

    [Serializable]
    public sealed class Pinwheel : Lure {

        public Pinwheel(string name, Size s, DeepType type, int price, Bitmap pic) : base(name, s, type, price, pic) {
        }
    }
}