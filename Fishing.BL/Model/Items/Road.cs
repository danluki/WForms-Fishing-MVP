using System;
using System.ComponentModel;
using System.Drawing;

namespace Fishing {


    [Serializable]
    public abstract class Road : Item {
        public int Power { get; set; }
        public int Wear { get; set; }

        protected Road(string name, int wear, int power, int price, Bitmap pic) : base(name, price, pic) {
            Power = power;
            Wear = wear;
        }

        public override string ToString() {
            return Name;
        }
    }
}