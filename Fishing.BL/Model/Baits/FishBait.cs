using Fishing.BL.Model.Items;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace Fishing.BL.Model.Baits {

    [Serializable]
    public abstract class FishBait : Item {
        public static BindingList<FishBait> FishBaits = new BindingList<FishBait>();

        public FishBait(string name, int price, Bitmap picture) : base(name, price, picture) {
        }

        public static FishBait GetFishBaitByName(string name) {
            return FishBaits.Where(b => b.Name == name).FirstOrDefault();
        }
    }
}