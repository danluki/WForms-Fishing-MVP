using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fishing.AbstractFish;

namespace Fishing.BL.Model.FeedingUp {
    public class FeedUp : Item
    {
        public Dictionary<Type, int> WorkingFishes { get; set; }

        public FeedUp(string name, int price, Bitmap picture, Dictionary<Type, int> workingFishes) : base(name, price, picture)
        {
            WorkingFishes = workingFishes ?? throw new ArgumentException("Список рыб должен содержать как миниум 1 рыбу.");
        }

    }
}
