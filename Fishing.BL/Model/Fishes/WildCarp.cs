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
    internal class WildCarp : Fish {

        private readonly static HashSet<PartsOfDay> activParts = new HashSet<PartsOfDay>()
        {
            PartsOfDay.Night
        };

        private readonly static string name = "Сазан";
        private readonly static int price = 5;
        private readonly static int trophyWeight = 20000;
        private readonly static string description = Messages.WILDCARP_DESCRIPTION;
        private readonly static Bitmap bit = FishesImg.Carp;

        public WildCarp(int minD, int maxD, double maxSizeCoef, HashSet<FishBait> lu) : base(name, randomWeight.Next(500, Convert.ToInt32(30000 * maxSizeCoef)), Power.SetPower(10, 3), price, trophyWeight, activParts, description, bit) {
            MinDeep = minD;
            MaxDeep = maxD;
            MaxSizeCoef = maxSizeCoef;
            WorkingLures = lu;
        }
    }
}