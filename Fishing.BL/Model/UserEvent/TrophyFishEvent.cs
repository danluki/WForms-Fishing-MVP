using Fishing.AbstractFish;
using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Game;
using Fishing.BL.Model.Lures;
using System;

namespace Fishing.BL.Model.UserEvent {

    [Serializable]
    public sealed class TrophyFishEvent : BaseEvent {
        private static FishBait lure;

        public TrophyFishEvent(Fish f, FishBait l) : base("Трофей! " + Game.Game.GetGame().Player.Nickname + " поймал " + f.ToString(), SelectIndex()) {
            lure = l;
        }

        private static int SelectIndex() {
            if (lure is Wobbler) {
                return 4;
            }
            if (lure is Shaker) {
                return 2;
            }
            if (lure is Pinwheel) {
                return 3;
            }
            if (lure is Jig) {
                return 6;
            }
            if (lure is Bait) {
                return 7;
            }
            return 1;
        }
    }
}