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
    public class Pike : Fish {

        private readonly static HashSet<PartsOfDay> activParts = new HashSet<PartsOfDay>()
        {
            PartsOfDay.Evening,
            PartsOfDay.Morning,
            PartsOfDay.Day
        };

        private readonly static string name = "Щука";
        private readonly static int price = 1;
        private readonly static int trophyWeight = 8000;
        private readonly static string description = Messages.PIKE_DESCRIPTION;
        private readonly static Bitmap bit = Images.pike;

        public Pike(int minD, int maxD, double maxSizeCoef, HashSet<FishBait> lu)
            : base(name, randomWeight.Next(100, Convert.ToInt32(10000 * maxSizeCoef)), Power.SetPower(6, 3), price, trophyWeight, activParts, description, bit) {
            MinDeep = minD;
            MaxDeep = maxD;
            MaxSizeCoef = maxSizeCoef;
            WorkingLures = lu;
        }
    }
}