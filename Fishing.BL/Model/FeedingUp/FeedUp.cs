using Fishing.BL.Model.Baits;
using System;
using System.Collections.Generic;

namespace Fishing.BL.Model.FeedingUp {
    
    [Serializable]
    public class FeedUp {
        private const int MaxFeedUpCount = 20;
        public Dictionary<Type, int> WorkingFishes { get; set; }
        public Basic Basic { get; set; }
        public Aroma Aroma { get; set; }
        public Bait Bait { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }

        public FeedUp(Basic basic, Aroma aroma, Bait bait, Dictionary<Type, int> workingFishes) {
            WorkingFishes = workingFishes ?? throw new ArgumentException("Список рыб должен содержать как миниум 1 рыбу.");
            Aroma = aroma ?? throw new ArgumentException();
            Basic = basic ?? throw new ArgumentException();
            Bait = bait ?? throw new ArgumentException();
        }
        public FeedUp() {

        }

        public bool Create() {
            if (Basic == null) return false;
            if (Aroma == null) return false;

            Basic.AddBasicToFeedUp(this);
            Aroma.AddAromaToFeedUp(this);
            Count = MaxFeedUpCount;
            Name = this.ToString();

            return true;
        }

        public override string ToString() {
            return Basic.Name + ", " + Aroma.Name + ", " + Bait.Name;
        }
    }
}