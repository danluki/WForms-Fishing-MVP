using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using Fishing.BL.Model.Baits;
using Fishing.BL.Model.FeedingUp;
using Fishing.BL.Model.Hooks;

namespace Fishing.BL.Model.Items {

    [Serializable]
    public abstract class Item {
        public static BindingList<Road> Roads = new BindingList<Road>();
        public static BindingList<Reel> Reels = new BindingList<Reel>();
        public static BindingList<FLine> FLines = new BindingList<FLine>();
        public static BindingList<Lure> Lures = new BindingList<Lure>();
        public static BindingList<Bait> Baits = new BindingList<Bait>();
        public static BindingList<BaseHook> Hooks = new BindingList<BaseHook>();
        public static BindingList<FeedUp> FeedUps = new BindingList<FeedUp>();
        public static BindingList<Aroma> Aromas = new BindingList<Aroma>();
        public static BindingList<Basic> Basics = new BindingList<Basic>();
        public string Name { get; }
        public int Price { get; }
        public Bitmap Picture { get;}

        protected Item(string name, int price, Bitmap picture) {
            Name = name;
            Price = price;
            Picture = picture;
        }

        public static Item GetItemByName(string name)
        {
            var items = new List<Item>();
            items.AddRange(Roads);
            items.AddRange(Reels);
            items.AddRange(FLines);
            items.AddRange(Lures);
            items.AddRange(Baits);
            items.AddRange(Hooks);
            items.AddRange(Aromas);
            items.AddRange(Basics);
            return items.SingleOrDefault(i => i.Name.Equals(name));
        }
        public static Item SelectItemType(Item item) {
            switch (item)
            {
                case Road road:
                    return road;
                case Reel reel:
                    return reel;
                case FLine line:
                    return line;
                case BaseHook bs:
                    return bs;
                case Aroma ar:
                    return ar;
                case Basic ba:
                    return ba;
                default:
                    return item;
            }
        }
    }
}