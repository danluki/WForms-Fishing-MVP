using Fishing.BL.Presenter;
using Fishing.BL.Resources.Images;
using Fishing.Presenter;
using Fishing.View.FoodShop;
using Fishing.View.Menu;
using Fishing.View.ShopForm;
using Fishing.View.Trip;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fishing {

    public partial class Menu : Form, IMenu {

        public Menu() {
            InitializeComponent();
        }

        public string NickNameL { get => label2.Text; set => label2.Text = value; }
        public string LowerLValue { get => label2.Text; set => label2.Text = value; }
        public MenuPresenter Presenter { get; set; }

        public event EventHandler ExitButtonClick;

        public event EventHandler MenuLoad;

        private void SettingButton_Click(object sender, EventArgs e) {
            var settings = new SettingsForm();
            settings.Show();
        }

        private void MapButton_Click(object sender, EventArgs e) {
            Map map = new Map();
            map.Show();
        }

        private void ShopButton_Click(object sender, EventArgs e) {
            var presenter = new ShopPresenter(new ShopForm());
            presenter.Run();
        }

        private void CloseButton_Click(object sender, EventArgs e) {
            ExitButtonClick?.Invoke(this, EventArgs.Empty);
        }

        private void Menu_Load(object sender, EventArgs e) {
            MenuLoad?.Invoke(this, EventArgs.Empty);
        }

        private void Button1_Click(object sender, EventArgs e) {
            var form = new TripForm();
            form.Show();
        }

        private void Button_MouseEnter(object sender, EventArgs e) {
            var button = sender as Button;
            button.BackgroundImage = (Image)Images.ResourceManager.GetObject(button.Name.ToLower() + "2");
        }

        private void Button_MouseLeave(object sender, EventArgs e) {
            var button = sender as Button;
            button.BackgroundImage = (Image)Images.ResourceManager.GetObject(button.Name.ToLower() + "1");
        }

        private void FoodShopButton_Click(object sender, EventArgs e) {
            var form = new FoodShopForm();
            form.Show();
        }

        public void Open() {
            this.Show();
        }

        public void Down() {
            this.Close();
        }
    }
}