using System;
using System.Drawing;

namespace Fishing.BL.Model.Lures {

    [Serializable]
    public class Jig : Lure {

        public Jig(string name, Size s, DeepType type, int price, Bitmap pic) : base(name, s, type, price, pic) {
        }
    }
}