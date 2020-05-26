using System;
using System.Collections.Generic;
using System.Linq;
using Fishing.BL.Model.Items;

namespace Fishing.BL.Model.Inventory {
    public class Inventory {
        public static Dictionary<Guid, Rod> RodInventory { get; set; } = new Dictionary<Guid, Rod>();

        public static Rod GetRod(Guid identifer) {
            return RodInventory.Where(a => a.Key == identifer).FirstOrDefault().Value;
        }
        public static bool DeleteRod(Guid identifer) {

            if (RodInventory.Remove(identifer)) {
                return true;
            }
            return false;
        }

        public static void AddItem<T>(T item) where T : Item {
            switch (item) {
                case Rod _:
                RodInventory.Add((item as Rod).UniqueIdentifer, item as Rod);
                break;
                default:

                break;
            }

        }

    }
}
