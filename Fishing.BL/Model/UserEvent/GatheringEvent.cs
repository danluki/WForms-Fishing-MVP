using System;
using Fishing.BL.Model.Game;

namespace Fishing.BL.Model.UserEvent {

    [Serializable]
    internal class GatheringEvent : BaseEvent {
        private static readonly string text = Player.GetPlayer().NickName + " сход =(";

        public GatheringEvent() : base(text, 5) {
        }
    }
}