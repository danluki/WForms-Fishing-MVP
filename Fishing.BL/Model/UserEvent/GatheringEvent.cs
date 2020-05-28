using Fishing.BL.Model.Game;
using System;

namespace Fishing.BL.Model.UserEvent {

    [Serializable]
    internal class GatheringEvent : BaseEvent {
        private static readonly string text = Game.Game.GetGame().Player.Nickname + " сход =(";

        public GatheringEvent() : base(text, 5) {
        }
    }
}