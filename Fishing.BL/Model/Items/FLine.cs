using System;
using System.Drawing;

namespace Fishing {

    [Serializable]
    public class FLine : Item {
        public int Power;

        public FLine(string name, int power, int price, Bitmap pic) : base(name, price, pic) {
            Power = power;
        }

        public override string ToString() {
            return this.Name;
        }
    }
}