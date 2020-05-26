using Fishing.BL.Model.Eating;
using Fishing.BL.Model.Game;
using Fishing.BL.Model.SoundPlayer;
using Fishing.BL.View;
using System;
using System.Linq;

namespace Fishing.BL.Presenter {

    public class FoodPresenter : BasePresenter {
        private readonly IFoodInventory view;
        private readonly Player player;
        private Food food;

        public FoodPresenter(IFoodInventory view) {
            this.view = view;
            view.Presenter = this;
            view.ListDoubleClick += View_ListDoubleClick;
            view.ListSelectedIndexChanged += View_ListSelectedIndexChanged;
            player = Game.GetGame().Player;
        }

        private void View_ListSelectedIndexChanged(object sender, EventArgs e) {
            food = Food.GetFoodByName(view.FoodsSelectedItem);
            //food = player.Inventory.Foods.First(f => f.Name.Equals(food.Name));
            view.ShowFood(food);
        }

        private void View_ListDoubleClick(object sender, EventArgs e) {
            try {
                if (player.Eat(food)) {
                    SoundsPlayer.PlayEatingSound();
                }
            }
            catch (NullReferenceException) { }
        }

        public override void Run() {
            view.Open();
        }

        public override void End() {
            view.Down();
        }
    }
}