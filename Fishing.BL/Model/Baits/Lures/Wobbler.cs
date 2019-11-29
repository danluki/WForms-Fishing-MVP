using System;
using System.Drawing;

namespace Fishing {

    [Serializable]
    public sealed class Wobbler : Lure {

        public Wobbler(string name, Size s, DeepType type, int price, Bitmap pic) : base(name, s, type, price, pic) {
        }
    }
}