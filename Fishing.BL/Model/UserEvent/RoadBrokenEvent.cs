using Fishing.BL.Model.Game;
using System;

namespace Fishing.BL.Model.UserEvent {

    [Serializable]
    internal class RoadBrokenEvent : BaseEvent {

        private static readonly string text = Game.Game.GetGame().Player.NickName + " сломал удочку";
        public RoadBrokenEvent() : base(text, 0) {
        }
    }
}