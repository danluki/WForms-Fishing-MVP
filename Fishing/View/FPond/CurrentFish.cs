using Fishing.AbstractFish;
using Fishing.BL.Model.Game;
using Fishing.BL.View;
using System.Windows.Forms;

namespace Fishing {

    public partial class CurrentFish : Form, ICurrentFishF {
        private readonly Fish fish;

        public CurrentFish(Fish fish) {
            InitializeComponent();
            this.fish = fish;
            SetCurrentFish(fish);
        }

        private void CurrentFish_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Space:
                Game.GetGame().Player.FishInventory.AddFish(fish);
                Close();
                break;

                case Keys.F:
                if (PriceButton.Text.Length > 0) {
                    Game.GetGame().Player.SellFish(fish);
                    UI.Gui.MoneyLabel.Text = Game.GetGame().Player.Money.ToString();
                    MessageBox.Show(@"Продано");
                    Close();
                }
                break;
            }
        }

        private void SetCurrentFish(Fish f) {
            FishImage.Image = f.Bitmap;
            NameLabel.Text = f.Name;
            WeightLabel.Text = f.Weight.ToString();
            PriceButton.Text = (f.Price * f.Weight).ToString();
            Show();
            Game.GetGame().Player.EquipedRod.IsFishAttack = false;
        }
    }
}