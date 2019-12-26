using System;
using System.Drawing;

namespace Fishing.BL.Model.Items {

    [Serializable]
    public class Road : Item {
        public int Power { get; set; }
        public int Wear { get; set; }
        public RoadType Type { get; set; }

        public Road(string name, RoadType type, int wear, int power, int price, Bitmap pic) : base(name, price, pic) {
            Power = power;
            Wear = wear;
            Type = type;
        }

        public override string ToString() {
            return Name;
        }
    }
}