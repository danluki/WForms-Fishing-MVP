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
    public class ArcticChar : Fish {

        private readonly static HashSet<PartsOfDay> activParts = new HashSet<PartsOfDay>()
        {
            PartsOfDay.Evening,
            PartsOfDay.Morning,
            PartsOfDay.Night
        };

        private readonly static string name = "Арктич. Голец";
        private readonly static int price = 2;
        private readonly static int trophyWeight = 16000;
        private readonly static string description = Messages.ARCTICCHAR_DESCRIPTION;
        private readonly static Bitmap bit = Images.golec;

        public ArcticChar(int minD, int maxD, double maxSizeCoef, HashSet<FishBait> lu) : base(
                              name,
                              randomWeight.Next(200,
                              Convert.ToInt32(20000 * maxSizeCoef)),
                              Power.SetPower(6, 2),
                              price, trophyWeight, 
                              activParts, 
                              description,
                              bit) {
            MinDeep = minD;
            MaxDeep = maxD;
            MaxSizeCoef = maxSizeCoef;
            WorkingLures = lu;
        }
    }
}