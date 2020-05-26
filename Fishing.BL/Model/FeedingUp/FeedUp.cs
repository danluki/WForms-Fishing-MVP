using Fishing.BL.Model.Baits;
using System;
using System.Collections.Generic;

namespace Fishing.BL.Model.FeedingUp {
    
    [Serializable]
    public class Feedup {
        private const int MaxFeedUpCount = 20;
        public Dictionary<Type, int> WorkingFishes { get; set; }
        public Basic Basic { get; set; }
        public Aroma Aroma { get; set; }
        public Bait Bait { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public Guid UniqueIdentifer { get; }

        public Feedup(Basic basic, Aroma aroma, Bait bait, Dictionary<Type, int> workingFishes) {
            WorkingFishes = workingFishes ?? throw new ArgumentException("Список рыб должен содержать как миниум 1 рыбу.");
            Aroma = aroma ?? throw new ArgumentException("Прикормка должна содержать ароматизатор.");
            Basic = basic ?? throw new ArgumentException("Прикормка должна содержать основу.");
            Bait = bait ?? throw new ArgumentException("Прикормка должна содержать наживки.");

            UniqueIdentifer = Guid.NewGuid();
        }
        public Feedup() {

        }

        public bool Create() {
            if (Basic == null) return false;
            if (Aroma == null) return false;

            Basic.AddBasicToFeedUp(this);
            Aroma.AddAromaToFeedUp(this);
            Count = MaxFeedUpCount;
            Name = ToString();

            return true;
        }

        public override string ToString() {
            return string.Format($"{Basic.Name}, {Aroma.Name}, {Bait.Name}");
        }
    }
}