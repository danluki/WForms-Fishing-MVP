using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Hooks;
using Fishing.BL.Model.Items;
using System;

namespace Fishing.BL.Model.Game {

    [Serializable]
    public class Assembly {
        public Rod Rod { get; set; }
        public Reel Reel { get; set; }
        public Fishingline Fline { get; set; }
        public FishBait FishBait { get; set; }
        public BaseHook Hook { get; set; }
        public Guid UniqueIdentifer { get; }

        public bool IsEquiped;

        public Assembly(Rod rod, Reel reel, Fishingline fLine, FishBait fb) {

            Rod = rod ?? throw new ArgumentNullException(nameof(rod));
            Reel = reel ?? throw new ArgumentNullException(nameof(reel));
            Fline = fLine ?? throw new ArgumentNullException(nameof(fLine));
            if (Rod.RodType == RodType.Spinning) {
                if (fb is Lure) {
                    FishBait = fb ?? throw new ArgumentNullException(nameof(fb));
                }
                else {
                    throw new ArgumentException("На спиннинг нельзя поставить наживку.");
                }
            }
            else {
                if (fb is Bait) {
                    FishBait = fb ?? throw new ArgumentNullException(nameof(fb));
                }
                else {
                    throw new ArgumentException("На удочку нельзя поставить приманку.");
                }
            }

            UniqueIdentifer = Guid.NewGuid();

        }

        public Assembly(Rod road) {
            if (road == null) return;
            Rod = road;
            Reel = null;
            Fline = null;
            FishBait = null;

            UniqueIdentifer = Guid.NewGuid();
        }

        public bool IsFull() {
            if (Rod == null || Reel == null || Fline == null || FishBait == null) {
                return false;
            }
            switch (Rod.RodType) {
                case RodType.Feeder when Hook != null:
                case RodType.Spinning:
                return true;

                case RodType.Float when Hook != null:
                return true;

                default:
                return false;
            }
        }

        public override bool Equals(object obj) {
            if ((obj == null) || GetType() != obj.GetType()) {
                return false;
            }
            else {
                Assembly ass = (Assembly)obj;
                return (Rod == ass.Rod) &&
                       (Reel == ass.Reel) &&
                       (Fline == ass.Fline) &&
                       (UniqueIdentifer == ass.UniqueIdentifer);
            }
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = IsEquiped.GetHashCode();
                hashCode = (hashCode * 397) ^ (Rod != null ? Rod.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Reel != null ? Reel.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Fline != null ? Fline.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FishBait != null ? FishBait.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Hook != null ? Hook.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString() {
            return Rod.Name;
        }
    }
}