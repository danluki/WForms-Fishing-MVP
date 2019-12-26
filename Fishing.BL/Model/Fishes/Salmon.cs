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
    public class Salmon : Fish {

        private readonly static HashSet<PartsOfDay> activParts = new HashSet<PartsOfDay>()
        {
            PartsOfDay.Evening,
            PartsOfDay.Morning,
            PartsOfDay.Night
        };

        private readonly static string name = "Сёмга";
        private readonly static int price = 6;
        private readonly static int trophyWeight = 25000;
        private readonly static string description = Messages.SALMON_DESCRIPTION;
        private readonly static Bitmap bit = Images.semga;

        public Salmon(int minD, int maxD, double maxSizeCoef, HashSet<FishBait> lu) : base(name, randomWeight.Next(500, Convert.ToInt32(30000 * maxSizeCoef)), Power.SetPower(6, 2), price, trophyWeight, activParts, description, bit) {
            MinDeep = minD;
            MaxDeep = maxD;
            MaxSizeCoef = maxSizeCoef;
            WorkingLures = lu;
        }
    }
}