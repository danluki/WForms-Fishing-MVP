using Fishing.AbstractFish;
using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Game;
using Fishing.BL.Resources.Images;
using Fishing.BL.Resources.Messages;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Fishing.BL.Model.Fishes {

    [Serializable]
    public class Perch : Fish {

        private readonly static HashSet<PartsOfDay> activParts = new HashSet<PartsOfDay>()
        {
            PartsOfDay.Evening,
            PartsOfDay.Morning,
            PartsOfDay.Day
        };

        private readonly static string name = "Окунь";
        private readonly static int price = 1;
        private readonly static string description = Messages.PERCH_DESCRIPTION;
        private readonly static Bitmap bit = Images.okyn;

        public Perch(int minD, int maxD, double maxSizeCoef, HashSet<FishBait> lu)
            : base(name, randomWeight.Next(200, Convert.ToInt32(1700 * maxSizeCoef)), Power.SetPower(3, 1), price, 1300, activParts, description, bit) {
            MinDeep = minD;
            MaxDeep = maxD;
            MaxSizeCoef = maxSizeCoef;
            WorkingLures = lu;
        }
    }
}