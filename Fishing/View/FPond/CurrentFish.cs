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
                Player.GetPlayer().AddFish(fish);
                Close();
                break;

                case Keys.F:
                if (PriceButton.Text.Length > 0) {
                    Player.GetPlayer().SellFish(fish);
                    UI.Gui.MoneyLabel.Text = Player.GetPlayer().Money.ToString();
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
            Player.GetPlayer().EquipedRoad.IsFishAttack = false;
        }
    }
}