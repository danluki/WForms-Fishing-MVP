using System;

namespace Fishing.BL.Model.UserEvent {

    [Serializable]
    public abstract class BaseEvent {
        public string Text { get; set; }
        public int Index { get; set; }

        public BaseEvent(string text, int index) {
            Text = text;
            Index = index;
        }
    }
}