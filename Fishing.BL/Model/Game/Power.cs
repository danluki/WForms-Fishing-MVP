using System;

namespace Fishing.BL.Model.Game {

    [Serializable]
    public struct Power {
        public int X;
        public int Y;

        public static Power SetPower(int x, int y) {
            Power power = new Power { X = x, Y = y };

            return power;
        }
    }
}