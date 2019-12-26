using Fishing.BL.Model.Items;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace Fishing.BL.Model.Eating {

    [Serializable]
    public class Food : Item {
        public static BindingList<Food> Foods = new BindingList<Food>();
        public int Productivity { get; set; }

        public Food(string name, int price, int productivity, Bitmap bit) : base(name, price, bit) {
            if (string.IsNullOrWhiteSpace(name)) {
                throw new ArgumentException("Wrong Name", nameof(name));
            }
            Productivity = productivity;
        }

        public static Food GetFoodByName(string name) {
            var food = Foods.SingleOrDefault(f => f.Name.Equals(name));
            return food;
        }

        public override string ToString() {
            return Name;
        }
    }
}