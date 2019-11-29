using System;
using System.Drawing;

namespace Fishing.BL.Model.Items {

    [Serializable]
    public class Spinning : Road {

        public Spinning(string name, int wear, int power, int price, Bitmap pic) : base(name, wear, power, price, pic) {
        }
    }
}