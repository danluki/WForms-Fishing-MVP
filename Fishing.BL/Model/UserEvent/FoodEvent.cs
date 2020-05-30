using Fishing.BL.Model.Eating;
using Fishing.BL.Model.Game;
using System;

namespace Fishing.BL.Model.UserEvent {

    [Serializable]
    internal class FoodEvent : BaseEvent {

        public FoodEvent(Food food) : base(Game.Game.GetGame().Player.Nickname + " Съел " + food.Name, 8) {
        }
    }
}