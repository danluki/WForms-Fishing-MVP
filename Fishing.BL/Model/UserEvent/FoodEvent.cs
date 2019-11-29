using Fishing.BL.Model.Eating;
using System;
using Fishing.BL.Model.Game;

namespace Fishing.BL.Model.UserEvent {

    [Serializable]
    internal class FoodEvent : BaseEvent {

        public FoodEvent(Food food) : base(Player.GetPlayer().NickName + " Съел " + food.Name, 8) {
        }
    }
}