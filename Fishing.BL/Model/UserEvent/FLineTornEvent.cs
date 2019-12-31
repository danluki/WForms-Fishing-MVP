using Fishing.BL.Model.Game;
using System;

namespace Fishing.BL.Model.UserEvent {

    [Serializable]
    internal class FLineTornEvent : BaseEvent {
        private static readonly string text = Game.Game.GetGame().Player + " порвал леску";

        public FLineTornEvent() : base(text, 0) {
        }
    }
}