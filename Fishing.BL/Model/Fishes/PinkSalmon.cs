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
    public class PinkSalmon : Fish {

        private static readonly HashSet<PartsOfDay> ActiveParts = new HashSet<PartsOfDay>()
        {
            PartsOfDay.Evening,
            PartsOfDay.Morning,
            PartsOfDay.Night
        };

        private static readonly string name = "Горбуша";
        private static readonly int price = 3;
        private static readonly int trophyWeight = 18000;
        private static readonly string description = Messages.PINKSALMON_DESCRIPTION;
        private static readonly Bitmap bit = Images.gorbusha;

        public PinkSalmon(int minD, int maxD, double maxSizeCoef, HashSet<FishBait> lu) : base(name, randomWeight.Next(500, Convert.ToInt32(20000 * maxSizeCoef)), Power.SetPower(7, 4), price, trophyWeight, ActiveParts, description, bit) {
            MinDeep = minD;
            MaxDeep = maxD;
            MaxSizeCoef = maxSizeCoef;
            WorkingLures = lu;
        }
    }
}