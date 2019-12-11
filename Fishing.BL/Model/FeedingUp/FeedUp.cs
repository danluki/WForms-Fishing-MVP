using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fishing.AbstractFish;
using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Items;

namespace Fishing.BL.Model.FeedingUp {
    public class FeedUp
    {
        public Dictionary<Type, int> WorkingFishes { get; set; }
        public Basic Basic { get; set; }
        public Aroma Aroma { get; set; }
        public Bait Bait { get; set; }
        public string Name { get; set; }
        public FeedUp(Basic basic, Aroma aroma, Bait bait, Dictionary<Type, int> workingFishes)
        {
            WorkingFishes = workingFishes ?? throw new ArgumentException("Список рыб должен содержать как миниум 1 рыбу.");
            Aroma = aroma ?? throw new ArgumentException();
            Basic = basic ?? throw new ArgumentException();
            Bait = bait ?? throw new ArgumentException();
        }

        public bool Create()
        {
            if (Basic == null) return false;
            if (Aroma == null) return false;
            
            Aroma.AddAromaToFeedUp(this);
            Basic.AddBasicToFeedUp(this);

            Name = this.ToString();

            return true;
        }

        public override string ToString()
        {
            return Basic.Name + ", " + Aroma.Name + ", " + Bait.Name;
        }


    }
}
