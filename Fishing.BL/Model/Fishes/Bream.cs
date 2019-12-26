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
    public class Bream : Fish {

        private readonly static HashSet<PartsOfDay> activParts = new HashSet<PartsOfDay>()
        {
            PartsOfDay.Evening,
            PartsOfDay.Morning,
            PartsOfDay.Night,
            PartsOfDay.Day
        };

        private readonly static string name = "Лещ";
        private readonly static int price = 2;
        private readonly static int trophyWeight = 4000;
        private readonly static string description = Messages.BREAM_DESCRIPTION;
        private readonly static Bitmap bit = Images.lesh1;

        public Bream(int minD, int maxD, double maxSizeCoef, HashSet<FishBait> lu) : base(name, randomWeight.Next(150, Convert.ToInt32(4500 * maxSizeCoef)), Power.SetPower(8, 2), price, trophyWeight, activParts, description, bit) {
            MinDeep = minD;
            MaxDeep = maxD;
            MaxSizeCoef = maxSizeCoef;
            WorkingLures = lu;
        }
    }
}