using Fishing.AbstractFish;
using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Game;
using Fishing.BL.Resources.Images;
using Fishing.BL.Resources.Messages;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Fishing {

    [Serializable]
    public class Trout : Fish {

        private readonly static HashSet<PartsOfDay> activParts = new HashSet<PartsOfDay>()
        {
            PartsOfDay.Evening,
            PartsOfDay.Morning,
            PartsOfDay.Night
        };

        private readonly static string name = "Форель";
        private readonly static int price = 2;
        private readonly static int trophyWeight = 11000;
        private readonly static string description = Messages.TROUT_DESCRIPTION;
        private readonly static Bitmap bit = Images.forel;

        public Trout(int minD, int maxD, double maxSizeCoef, HashSet<FishBait> lu) : base(name, randomWeight.Next(500, Convert.ToInt32(15000 * maxSizeCoef)), Power.SetPower(4, 2), price, trophyWeight, activParts, description, bit) {
            MinDeep = minD;
            MaxDeep = maxD;
            MaxSizeCoef = maxSizeCoef;
            WorkingLures = lu;
        }
    }
}