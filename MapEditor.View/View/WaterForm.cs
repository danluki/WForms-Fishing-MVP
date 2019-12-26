using System;
using System.Drawing;
using System.Windows.Forms;

namespace MapEditor.View {

    public partial class WaterForm : Form {
        private bool _isLeftButtonPressed;
        protected internal string name;
        protected internal int housePrice;
        protected internal int dayPrice;
        protected internal int minLvl;
        protected internal PictureBox SelectedBox;

        public WaterForm(string waterName, int housePr, int perDayPrice, int minLevel) {
            InitializeComponent();
            name = waterName;
            housePrice = housePr;
            dayPrice = perDayPrice;
            minLvl = minLevel;

            Text += waterName;
            waterProperties.Text = name;
            minLevelLabel.Text += minLevel;
            pricePerDayLabel.Text += perDayPrice;
            housePriceLabel.Text += housePr;
        }

        private void CreateNewLocation_Click(object sender, EventArgs e) {
            var dia = new OpenFileDialog {
                Filter = "Joint Photographic Experts Group .jpg|*.jpg;|Portable Network Graphics .png| *.png |Bitmap Picture .bmp| *.bmp"
            };
            if (dia.ShowDialog() == DialogResult.OK) {
                mapPictureBox.Image = Image.FromFile(dia.FileName);
            }
        }

        private void CreateNewLocationButton_Click(object sender, EventArgs e) {
            var createLocForm = new CreateLocationForm(this);
            createLocForm.Show();
        }

        private void MapPictureBox_MouseMove(object sender, MouseEventArgs e) {
            if (SelectedBox == null) return;
            if (!_isLeftButtonPressed) return;
            SelectedBox.Top = PointToClient(Cursor.Position).Y - 12;
            SelectedBox.Left = PointToClient(Cursor.Position).X - 12;
        }

        private void MapPictureBox_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                _isLeftButtonPressed = true;
            }
        }

        private void MapPictureBox_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                _isLeftButtonPressed = false;
            }
        }

        private void DeleteLocationButton_Click(object sender, EventArgs e) {
            SelectedBox.Dispose();
            Controls.Remove(SelectedBox);
        }

        private void ChangeLocationButton_Click(object sender, EventArgs e) {
            if (SelectedBox == null) return;
            var changeLocForm = new ChangeLocationForm(SelectedBox);
            changeLocForm.Show();
        }
    }
}