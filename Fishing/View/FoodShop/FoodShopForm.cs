using Fishing.BL.Model.Eating;
using Fishing.BL.Model.Game;
using Fishing.BL.Model.SoundPlayer;
using Fishing.Resources;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fishing.View.FoodShop {

    public partial class FoodShopForm : Form {

        public FoodShopForm() {
            InitializeComponent();
            moneyLabel.Text = "Деньги: " + Game.GetGame().Player.Money;
        }

        private void Button_MouseEnter(object sender, EventArgs e) {
            if (sender is PictureBox food) {
                food.Image = (Image)FoodButtons.ResourceManager.GetObject(food.Name.ToLower() + "_a");
                var f = Food.GetFoodByName((sender as PictureBox)?.Tag.ToString());
                foodDescriptionLabel.Text = f.Name + @" Цена: " + f.Price + @" Восполняет: " + f.Productivity + @"%";
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e) {
            if (sender is PictureBox food) {
                food.Image = (Image)FoodButtons.ResourceManager.GetObject(food.Name.ToLower() + "_d");
            }
        }

        private void Button_Click(object sender, EventArgs e) {
            var food = Food.GetFoodByName((sender as PictureBox)?.Tag.ToString());
            if (Game.GetGame().Player.Money >= food.Price) {
                Game.GetGame().Player.Money -= food.Price;
                moneyLabel.Text = "Деньги: " + Game.GetGame().Player.Money;
                //Game.GetGame().Player.Inventory.Foods.Add(food);
                SoundsPlayer.PlayBuyingSound();
            }
        }

        private void CloseBox_Click(object sender, EventArgs e) {
            Close();
        }
    }
}