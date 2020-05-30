using Fishing.BL.Model.Game;
using Fishing.BL.Presenter;
using Fishing.BL.View;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fishing {

    public partial class FishPondForm : Form, IFPond {
        public Image RightImage { get => FishImage.BackgroundImage; set => FishImage.BackgroundImage = value; }
        public int SelectedIndex { get => FishList.SelectedIndex; set => throw new NotImplementedException(); }
        public string DescriptionText { get => fishDescription.Text; set => fishDescription.Text = value; }
        public FPondPresenter Presenter { get; set; }

        public FishPondForm() {
            InitializeComponent();
            FishList.DataSource = Game.GetGame().Player.FishInventory.Fishes;
            var pres = new FPondPresenter(this, UI.Gui);
            pres.Run();
        }

        public event EventHandler SelectedIndexChanged;

        public event EventHandler SellButtonClick;

        private void FishList_SelectedIndexChanged(object sender, EventArgs e) {
            SelectedIndexChanged?.Invoke(this, EventArgs.Empty);
        }

        private void FishesForm_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Space) {
                this.Close();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void SellButton_Click(object sender, EventArgs e) {
            SellButtonClick?.Invoke(sender, EventArgs.Empty);
        }

        private void FishesForm_Load(object sender, EventArgs e) {
        }

        public void Open() {
            Show();
        }

        public void Down() {
            Close();
        }
    }
}