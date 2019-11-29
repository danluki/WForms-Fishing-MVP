using Fishing.BL.Model.Waters;
using System;

namespace Fishing.BL.Model.Trip {

    public enum Transport {
        Car = 2000,
        Train = 5000,
        Plane = 20000
    }

    public class TripToWater {
        public Water TripWater { get; set; }
        public int DaysCount { get; set; } = 1;
        public Transport TripTransport { get; set; } = Transport.Plane;
        public int Price { get; set; }
        public int HoursInTrip { get; set; } = 0;

        public void CountPrice() {
            if (TripWater.DailyPrice != 0) {
                Price = TripWater.DailyPrice * DaysCount + (int)TripTransport;
            }
            else {
                Price = 0;
            }
        }

        public void CountTime() {
            switch (TripTransport) {
                case Transport.Car:
                HoursInTrip = TripWater.KmFromNearestStation / 80;
                break;

                case Transport.Train:
                HoursInTrip = TripWater.KmFromNearestStation / 110;
                break;

                case Transport.Plane:
                HoursInTrip = TripWater.KmFromNearestStation / 900;
                break;
            }
        }

        public override string ToString() {
            return "Водоём: "
                + TripWater.Name + Environment.NewLine
                + "Цена: "
                + Price + Environment.NewLine
                + "Дни: "
                + DaysCount + Environment.NewLine
                + "Транспорт: "
                + TripTransport + Environment.NewLine
                + "Время: "
                + HoursInTrip + " ч.";
        }
    }
}