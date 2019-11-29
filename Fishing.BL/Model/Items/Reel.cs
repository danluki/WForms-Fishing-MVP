using System;
using System.Drawing;

namespace Fishing {

    [Serializable]
    public class Reel : Item {
        public int Power;
        public int Wear;
        public int WearSpeed;

        public Reel(string name, int wear, int wearSpeed, int power, int price, Bitmap pic) : base(name, price, pic) {
            Power = power;
            Wear = wear;
            WearSpeed = wearSpeed;
        }

        public override string ToString() {
            return Name;
        }
    }
}