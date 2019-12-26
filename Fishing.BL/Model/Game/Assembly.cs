using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Hooks;
using Fishing.BL.Model.Items;
using System;

namespace Fishing.BL.Model.Game {

    [Serializable]
    public class Assembly {
        public Road Road { get; set; }
        public Reel Reel { get; set; }
        public FLine FLine { get; set; }
        public FishBait FishBait { get; set; }
        public BaseHook Hook { get; set; }

        public bool IsEquiped;

        public Assembly(Road road, Reel reel, FLine fLine, FishBait fb) {
            Road = road;
            Reel = reel;
            FLine = fLine;
            FishBait = fb;
        }

        public Assembly(Road road) {
            if (road == null) return;
            Road = road;
            Reel = null;
            FLine = null;
            FishBait = null;
        }

        public bool IsAssemblyFull() {
            if (Road != null) {
                if (Reel != null) {
                    if (FLine != null) {
                        if (FishBait != null) {
                            switch (Road.Type) {
                                case RoadType.Feeder when Hook != null:
                                case RoadType.Spinning:
                                return true;

                                case RoadType.Float when Hook != null:
                                return true;

                                default:
                                throw new ArgumentOutOfRangeException();
                            }
                        }
                    }
                }
            }
            return false;
        }

        public override bool Equals(object obj) {
            if ((obj == null) || this.GetType() != obj.GetType()) {
                return false;
            }
            else {
                Assembly ass = (Assembly)obj;
                return (Road == ass.Road) &&
                       (Reel == ass.Reel) &&
                       (FLine == ass.FLine);
            }
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = IsEquiped.GetHashCode();
                hashCode = (hashCode * 397) ^ (Road != null ? Road.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Reel != null ? Reel.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FLine != null ? FLine.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FishBait != null ? FishBait.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Hook != null ? Hook.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString() {
            return Road.Name;
        }
    }
}