using Fishing.BL.Model.UserEvent;
using System;
using System.Collections.Generic;

namespace Fishing.BL.Model.Game {

    [Serializable]
    public class Statistic {

        #region events

        [field: NonSerialized]
        public event Action EventHistoryUpdated;

        #endregion events

        #region props
        public Stack<BaseEvent> Events { get; set; } = new Stack<BaseEvent>();
        public int GatheringCount { get; set; }
        public int BrokensRoadsCount { get; set; }
        public int TornsFlinesCount { get; set; }
        public int TakenFishesCount { get; set; }

        #endregion props

        #region public methods
        public void AddEventToHistory(BaseEvent ev) {
            if (ev != null) {
                Events.Push(ev);
                EventHistoryUpdated?.Invoke();
            }
        }
        #endregion public methods

    }
}