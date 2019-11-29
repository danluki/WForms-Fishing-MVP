using System;
using Fishing.BL.Model.Game;

namespace Fishing.BL.Model.UserEvent {

    [Serializable]
    internal class FLineTornEvent : BaseEvent {
        private static readonly string text = Player.GetPlayer().NickName + " порвал леску";

        public FLineTornEvent() : base(text, 0) {
        }
    }
}