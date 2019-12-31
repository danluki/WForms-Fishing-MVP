using Fishing.BL.Model.Game;
using Fishing.BL.Model.Trip;
using Fishing.BL.Model.Waters;
using System;
using System.Windows.Forms;

namespace Fishing.View.Trip {

    public partial class TripForm : Form {
        private TripToWater trip;

        public TripForm() {
            InitializeComponent();
            Game.GetGame().HoursInc += TripForm_HoursInc;
            trip = new TripToWater();
            timeLabel.Text = Game.GetGame().Time.ToString();
            watersBox.DataSource = Game.GetGame().Waters;
            trip.DaysCount = 1;
            moneyLabel.Text = "Деньги: " + Game.GetGame().Player.Money;
        }

        private void CloseButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void UpdateHours_Tick(object sender, EventArgs e) {
            timeLabel.Text = Game.GetGame().Time.ToString();
        }

        private void TripBox_MouseEnter(object sender, EventArgs e) {
            tripBox.Text = trip.ToString();
        }

        private void CarButton_Click(object sender, EventArgs e) {
            trip.TripTransport = Transport.Car;
            trip.CountPrice();
            trip.CountTime();
            tripBox.Text = trip.ToString();
        }

        private void TrainButton_Click(object sender, EventArgs e) {
            trip.TripTransport = Transport.Train;
            trip.CountPrice();
            trip.CountTime();
            tripBox.Text = trip.ToString();
        }

        private void PlaneButton_Click(object sender, EventArgs e) {
            trip.TripTransport = Transport.Plane;
            trip.CountPrice();
            trip.CountTime();
            tripBox.Text = trip.ToString();
        }

        private void DaysUpDown_SelectedItemChanged(object sender, EventArgs e) {
            int.TryParse(daysUpDown.Items[daysUpDown.SelectedIndex].ToString(), out var res);
            trip.DaysCount = res;
            trip.CountPrice();
            tripBox.Text = trip.ToString();
        }

        private void WatersBox_SelectedIndexChanged(object sender, EventArgs e) {
            trip = new TripToWater();
            var water = new WaterImplementation();
            trip.TripWater = water.GetLVL(Game.GetGame().Waters[watersBox.SelectedIndex]);
            mapBox.BackgroundImage = trip.TripWater.MapImage;
            trip.CountPrice();
            trip.CountTime();
            tripBox.Text = trip.ToString();
        }

        private void GoButton_Click(object sender, EventArgs e) {
            if (Game.GetGame().CurrentWater.Name != trip.TripWater.Name) {
                if (Game.GetGame().Player.Money >= trip.Price) {
                    Game.GetGame().CurrentWater = trip.TripWater;
                    Game.GetGame().Time.IncHours(trip.HoursInTrip);
                    int.TryParse(daysUpDown.Items[daysUpDown.SelectedIndex].ToString(), out var res);
                    Game.GetGame().Player.Money -= trip.Price;
                    timeLabel.Text = Game.GetGame().Time.ToString();
                    moneyLabel.Text = Game.GetGame().Player.Money.ToString();
                    if (trip.TripWater.Name != "Озеро") {
                        Game.GetGame().Player.HoursRemain = res * 24;
                    }
                    else {
                        Game.GetGame().Player.HoursRemain = 99999999;
                    }
                }
            }
            else {
                MessageBox.Show(@"Вы уже находитесь на текущем водоёме");
            }
        }

        private void TripForm_HoursInc(object sender, EventArgs e) {
            timeLabel.Text = Game.GetGame().Time.ToString();
        }
    }
}