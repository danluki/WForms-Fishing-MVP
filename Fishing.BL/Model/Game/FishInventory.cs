using Fishing.AbstractFish;
using System;
using System.ComponentModel;

namespace Fishing.BL.Model.Game.Inventory {

    /// <summary>
    /// Класс описывает инвентарь рыбы
    /// </summary>
    /// 
    [Serializable]
    public sealed class FishInventory {
        #region props
        public BindingList<Fish> Fishes { get;} = new BindingList<Fish>();

        #endregion

        #region ctor
        public FishInventory() { }
        #endregion ctor

        #region public methods

        public void AddFish(Fish fish) {
            if (fish != null) {
                Fishes.Add(fish);
            }
        }

        public void RemoveFish(Fish fish) {
            Fishes.Remove(fish);
        }

        public Fish GetFishByIndex(int index) {
            try {
                return Fishes[index];
            }
            catch (ArgumentOutOfRangeException) { }

            return null;
        }

        #endregion
    }
}
