﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fishing.BL.Model.Items;

namespace Fishing.BL.Model.FeedingUp {
    public class Aroma : Item {
        public Dictionary<Type, int> WorkingFishes { get; set; }

        public Aroma(string name, int price, Bitmap picture, Dictionary<Type, int> workingFishes) : base(name, price, picture) {
            WorkingFishes = workingFishes ?? throw new ArgumentException("Список рыб должен содержать как миниум 1 рыбу.");
        }
        public void AddAromaToFeedUp(FeedUp feedup)
        {
            foreach (var w in WorkingFishes.Where(w => feedup.WorkingFishes.ContainsKey(w.Key)))
            {
                feedup.WorkingFishes.Add(w.Key, w.Value);
            }
        }

        public override string ToString() {
            return Name;
        }
    }
}
