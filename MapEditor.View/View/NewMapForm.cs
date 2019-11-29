using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapEditor.BL;

namespace MapEditor.View {
    public partial class NewMapForm : Form {
        public NewMapForm() {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e) {

            if (waterNameBox.Text.Length > 0)
            {
                if (int.TryParse(pricePerDayBox.Text, out var res))
                {
                    if (int.TryParse(housePriceBox.Text, out var r)) {
                        if (levelNumUpDown.Value >= 0)
                        {
                            CurrentWater.MInfo.WaterName = waterNameBox.Text;
                            CurrentWater.MInfo.WaterInfoString =
                                waterNameBox.Text + " " + pricePerDayBox.Text + " " + housePriceBox.Text;
                            var waterForm = new WaterForm(waterNameBox.Text,
                                                          res,
                                                          r,
                                                          (int)levelNumUpDown.Value);
                            waterForm.Show();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show(Texts.MiniumLevel);
                        }
                    }
                    else {
                        MessageBox.Show(Texts.HousePriceNeedToBeNumber);
                    }
                }
                else
                {
                    MessageBox.Show(Texts.PricePerDayNeedToBeNumber);
                }
            }
            else
            {
                MessageBox.Show(Texts.EnterWaterName);
            }

        }
    }
}
