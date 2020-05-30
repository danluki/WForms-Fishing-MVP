using Fishing.BL.Model.Items;
using System;
using System.Drawing;

namespace Fishing {

    [Serializable]
    public class Reel : Item {
        private string _name;
        private int _price;
        private int _wear;
        private int _power;
        private int _wearSpeed;

        public override Guid UniqueIdentifer { get; set; }

        public int Wear {
            get {
                return _wear;
            }
            set {
                if (value < 100 && value >= 0)
                    _wear = value;
                else
                    throw new ArgumentException("Износ должен быть больше нуля и меньше 100.");
            }
        }
        public int Power {
            get {
                return _power;
            }
            set {
                if (value > 0)
                    _power = value;
                else
                    throw new ArgumentException("Мощность должна быть больше нуля.");
            }
        }
        public override int Price {
            get {
                return _price;
            }
            protected internal set {
                if (value > 0)
                    _price = value;
                else
                    throw new ArgumentException("Цена должна быть больше нуля.");
            }
        }
        public override string Name {
            get {
                return _name;
            }
            protected internal set {
                if (value.Length > 0)
                    _name = value;
                else
                    throw new ArgumentException("Имя должно иметь хотя бы один символ.");
            }
        }
        public int WearSpeed {
            get {
                return _wearSpeed;
            }
            private set {
                if(value > 0) {
                    _wearSpeed = value;
                }

            }
        }
        public Reel(string name, int wear, int wearSpeed, int power, int price, Bitmap pic) : base(name, price, pic) {
            Power = power;
            Wear = wear;
            WearSpeed = wearSpeed;
        }

        public override bool Equals(object obj) {
            Reel reel = (Reel)obj;
            return Name.Equals(reel.Name)
                && reel.Wear == Wear
                && reel.Power == Power
                && reel.WearSpeed == WearSpeed
                && reel.GetHashCode() == GetHashCode();
        }
        public override int GetHashCode() {
            return (Power ^ Price ^ 15256) * Name.Length;
        }
        public override string ToString() {
            return Name;
        }
    }
}