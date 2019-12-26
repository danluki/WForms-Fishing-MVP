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
    public class SilverCarp : Fish {

        private readonly static HashSet<PartsOfDay> activParts = new HashSet<PartsOfDay>()
        {
            PartsOfDay.Evening,
            PartsOfDay.Morning,
            PartsOfDay.Night,
            PartsOfDay.Day
        };

        private readonly static string name = "Карась Серебряный";
        private readonly static int price = 3;
        private readonly static int trophyWeight = 2700;
        private readonly static string description = Messages.SILVERCARP_DESCRIPTION;
        private readonly static Bitmap bit = Images.karass;

        public SilverCarp(int minD, int maxD, double maxSizeCoef, HashSet<FishBait> lu) : base(name, randomWeight.Next(50, Convert.ToInt32(3000 * maxSizeCoef)), Power.SetPower(6, 2), price, trophyWeight, activParts, description, bit) {
            MinDeep = minD;
            MaxDeep = maxD;
            MaxSizeCoef = maxSizeCoef;
            WorkingLures = lu;
        }
    }
}