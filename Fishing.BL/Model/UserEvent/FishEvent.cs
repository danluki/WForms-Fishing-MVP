using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Lures;
using System;
using Fishing.AbstractFish;
using Fishing.BL.Model.Game;

namespace Fishing.BL.Model.UserEvent {

    [Serializable]
    internal class FishEvent : BaseEvent {

        public FishEvent(Fish f, FishBait l) : base(Player.GetPlayer().NickName + " поймал " + f.ToString(), SelectIndex(l)) {
        }

        private static int SelectIndex(FishBait l) {
            if (l is Wobbler) {
                return 4;
            }
            if (l is Shaker) {
                return 2;
            }
            if (l is Pinwheel) {
                return 3;
            }
            if (l is Jig) {
                return 6;
            }
            if (l is Bait) {
                return 7;
            }
            return 1;
        }
    }
}