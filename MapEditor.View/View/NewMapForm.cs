using MapEditor.BL;
using System;
using System.Windows.Forms;

namespace MapEditor.View.View {

    public partial class NewMapForm : Form {

        public NewMapForm() {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e) {
            if (waterNameBox.Text.Length > 0) {
                if (int.TryParse(pricePerDayBox.Text, out var res)) {
                    if (int.TryParse(housePriceBox.Text, out var r)) {
                        if (levelNumUpDown.Value >= 0) {
                            CurrentWater.MInfo.WaterName = waterNameBox.Text;
                            CurrentWater.MInfo.WaterInfoString =
                                $@"{waterNameBox.Text} {levelNumUpDown.Value} {pricePerDayBox.Text} {housePriceBox.Text}";
                            var waterForm = new WaterForm(waterNameBox.Text,
                                                          res,
                                                          r,
                                                          (int)levelNumUpDown.Value);
                            waterForm.Show();
                            Close();
                        }
                        else {
                            MessageBox.Show(Texts.MiniumLevel);
                        }
                    }
                    else {
                        MessageBox.Show(Texts.HousePriceNeedToBeNumber);
                    }
                }
                else {
                    MessageBox.Show(Texts.PricePerDayNeedToBeNumber);
                }
            }
            else {
                MessageBox.Show(Texts.EnterWaterName);
            }
        }
    }
}