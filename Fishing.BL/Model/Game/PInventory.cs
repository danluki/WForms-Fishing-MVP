using Fishing.AbstractFish;
using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Eating;
using Fishing.BL.Model.FeedingUp;
using Fishing.BL.Model.Hooks;
using Fishing.BL.Model.Items;
using Fishing.BL.Model.UserEvent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Game.Inventory {

    [Serializable]
    public enum InventoryItemType {
        Assembly,
        Rod,
        Reel,
        Fishingline,
        Bait,
        Lure,
        Hook
    }

    [Serializable]
    public sealed class PInventory {
        public Dictionary<Guid, Assembly> Assemblies { get; } = new Dictionary<Guid, Assembly>();
        public Dictionary<Guid, Rod> Rods { get; } = new Dictionary<Guid, Rod>();
        public Dictionary<Guid, Reel> Reels { get; } = new Dictionary<Guid, Reel>();
        public Dictionary<Guid, Fishingline> Fishinglines { get; } = new Dictionary<Guid, Fishingline>();
        public Dictionary<Guid, Bait> Baits { get; } = new Dictionary<Guid, Bait>();
        public Dictionary<Guid, Lure> Lures { get; } = new Dictionary<Guid, Lure>();
        public Dictionary<Guid, Aroma> Aromas { get; } = new Dictionary<Guid, Aroma>();
        public Dictionary<Guid, Basic> Basics { get; } = new Dictionary<Guid, Basic>();
        public Dictionary<Guid, Feedup> Feedups { get; } = new Dictionary<Guid, Feedup>();
        public Dictionary<Guid, Food> Foods { get; } = new Dictionary<Guid, Food>();
        public Dictionary<Guid, BaseHook> Hooks { get; } = new Dictionary<Guid, BaseHook>();

        public void AddItem<T>(T item) where T : Item {
            switch (item) {
                case Reel reel:
                    Reels.Add(reel.UniqueIdentifer, reel);
                break;

                case Rod rod:
                    Assembly ass = new Assembly(rod);
                    Assemblies.Add(ass.UniqueIdentifer, ass);
                break;

                case Fishingline fl:
                    Fishinglines.Add(fl.UniqueIdentifer, fl);
                break;

                case Bait bait:
                    Baits.Add(bait.UniqueIdentifer, bait);
                break;

                case Lure lure:
                    Lures.Add(lure.UniqueIdentifer, lure);
                break;

                case Aroma aroma:
                    Aromas.Add(aroma.UniqueIdentifer, aroma);
                break;

                case Basic basic:
                    Basics.Add(basic.UniqueIdentifer, basic);
                break;

                case Feedup feedup:
                    Feedups.Add(feedup.UniqueIdentifer, feedup);
                break;

                case Food food:
                    Foods.Add(food.UniqueIdentifer, food);
                break;

                case BaseHook hook:
                    Hooks.Add(hook.UniqueIdentifer, hook);
                break;
            }
        }

        public Assembly GetAssembly(Guid identifer) {
            Assembly assm = Assemblies.Where(ass => ass.Key == identifer).FirstOrDefault().Value;
            return assm;
        }

        public Rod GetRod(Guid identifer) {
            return Rods.Where(rod => rod.Key == identifer).FirstOrDefault().Value;
        }

        public Reel GetReel(Guid identifer) {
            return Reels.Where(reel => reel.Key == identifer).FirstOrDefault().Value;
        }

        public Fishingline GetFishline(Guid identifer) {
            return Fishinglines.Where(fl => fl.Key == identifer).FirstOrDefault().Value;
        }

        public Bait GetBait(Guid identifer) {
            return Baits.Where(bait => bait.Key == identifer).FirstOrDefault().Value;
        }
        public Lure GetLure(Guid identifer) {
            return Lures.Where(lure => lure.Key == identifer).FirstOrDefault().Value;
        }

        public BaseHook GetHook(Guid identifer) {
            return Hooks.Where(hook => hook.Key == identifer).FirstOrDefault().Value;
        }

        public Food GetFood(Guid identifer) {
            return Foods.Where(food => food.Key == identifer).FirstOrDefault().Value;
        }
    }
}
