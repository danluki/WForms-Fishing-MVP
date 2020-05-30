using Fishing.BL.Model.Baits;
using System;
using System.Drawing;

namespace Fishing {

    [Serializable]
    public enum Size {
        XL,
        Small,
        Large,
    }

    [Serializable]
    public enum DeepType {
        Deep,
        Flying,
        Top,
        Jig,
    }

    [Serializable]
    public abstract class Lure : FishBait {
        public Size Size { get; set; }
        public DeepType DeepType { get; set; }

        public Lure(string name, Size size, DeepType dt, int price, Bitmap pic) : base(name, price, pic) {
            Size = size;
            DeepType = dt;
        }

        public override string ToString() {
            return this.Name;
        }
    }
}