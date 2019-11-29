using System;

namespace Fishing.BL.Model.Game {

    [Serializable]
    public struct Time {
        public int Hours;
        public PartsOfDay Part { get; set; }
        public DayOfWeek Day { get; set; }

        public override string ToString() {
            return Day + ", " + Part + ", " + Hours + ":00";
        }

        public void IncHours(int value) {
            int newDayHours = 0;
            if (Hours <= 24) {
                Hours += value;
                newDayHours = Hours - 24;
            }
            if (Hours > 24) {
                Hours = newDayHours;
                if (Day != DayOfWeek.Saturday) {
                    Day++;
                }
                else {
                    Day = DayOfWeek.Sunday;
                }
            }
            if (Hours >= 0 && Hours <= 4) {
                Part = PartsOfDay.Night;
            }
            if (Hours > 4 && Hours <= 10) {
                Part = PartsOfDay.Morning;
            }
            if (Hours > 10 && Hours <= 16) {
                Part = PartsOfDay.Day;
            }
            if (Hours > 16 && Hours <= 24) {
                Part = PartsOfDay.Evening;
            }
        }
    }
}