using Fishing.BL.Model.Items;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Fishing.BL.Model.FeedingUp {

    [Serializable]
    public class Basic : Item {
        public Dictionary<Type, int> WorkingFishes { get; set; }

        public Basic(string name, int price, Bitmap picture, Dictionary<Type, int> workingFishes) : base(name, price, picture) {
            WorkingFishes = workingFishes ?? throw new ArgumentException("Список рыб должен содержать как миниум 1 рыбу.");
        }

        public void AddBasicToFeedUp(Feedup feedup) {
            foreach (var w in WorkingFishes) {
                if (feedup.WorkingFishes.ContainsKey(w.Key)) {
                    feedup.WorkingFishes[w.Key] += w.Value;
                }
                else {
                    feedup.WorkingFishes.Add(w.Key, w.Value);
                }
            }
        }

        public override string ToString() {
            return Name;
        }
    }
}