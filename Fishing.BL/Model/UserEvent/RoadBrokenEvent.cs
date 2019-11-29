using System;
using Fishing.BL.Model.Game;

namespace Fishing.BL.Model.UserEvent {

    [Serializable]
    internal class RoadBrokenEvent : BaseEvent {
        private static readonly string text = Player.GetPlayer().NickName + " сломал удочку";

        public RoadBrokenEvent() : base(text, 0) {
        }
    }
}