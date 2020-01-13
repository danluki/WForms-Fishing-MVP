using Fishing.BL.Model.Game;
using Fishing.BL.Presenter;
using Fishing.View.Shop;
using System;

namespace Fishing.Presenter {

    public class ShopPresenter : BasePresenter {
        private readonly IShop view;
        private readonly Player player = Game.GetGame().Player;

        public ShopPresenter(IShop view) {
            this.view = view;
            view.Presenter = this;
            view.FLineDoubleClick += View_FLineDoubleClick;
            view.ReelDoubleClick += View_ReelDoubleClick;
            view.RoadDoubleClick += View_RoadDoubleClick;
            view.LureDoubleClick += View_LureDoubleClick;
            view.BaitDoubleClick += View_BaitDoubleClick;
            view.HookDoubleClick += View_HookDoubleClick;
            view.AromaDoubleClick += View_AromaDoubleClick;
            view.BasicDoubleClick += View_BasicDoubleClick;
        }

        private void View_BasicDoubleClick(object sender, EventArgs e) {
            if (!player.IsAbleToBuyItem(view.Basic_P)) return;
            player.BasicInventory.Add(view.Basic_P);
            player.Money -= view.Basic_P.Price;
            view.MoneyL = player.Money.ToString();
            view.LowerL = "Куплено...";
        }

        private void View_AromaDoubleClick(object sender, EventArgs e) {
            if (!player.IsAbleToBuyItem(view.Aroma_P)) return;
            player.AromaInventory.Add(view.Aroma_P);
            player.Money -= view.Aroma_P.Price;
            view.MoneyL = player.Money.ToString();
            view.LowerL = "Куплено...";
        }

        private void View_HookDoubleClick(object sender, EventArgs e) {
            if (!player.IsAbleToBuyItem(view.Hook_P)) return;
            player.HooksInventory.Add(view.Hook_P);
            player.Money -= view.Hook_P.Price;
            view.MoneyL = player.Money.ToString();
            view.LowerL = "Куплено...";
        }

        private void View_BaitDoubleClick(object sender, EventArgs e) {
            if (!player.IsAbleToBuyItem(view.Bait_P)) return;
            player.AddBait(view.Bait_P);
            player.Money -= view.Bait_P.Price;
            view.MoneyL = player.Money.ToString();
            view.LowerL = "Куплено...";
        }

        private void View_LureDoubleClick(object sender, EventArgs e) {
            if (!player.IsAbleToBuyItem(view.Lure_P)) return;
            player.LureInventory.Add(view.Lure_P);
            player.Money -= view.Lure_P.Price;
            view.MoneyL = player.Money.ToString();
            view.LowerL = "Куплено...";
        }

        private void View_RoadDoubleClick(object sender, EventArgs e) {
            if (!player.IsAbleToBuyItem(view.Road_P)) return;
            player.Assemblies.Add(new Assembly(view.Road_P));
            player.Money -= view.Road_P.Price;
            view.MoneyL = player.Money.ToString();
            view.LowerL = "Куплено...";
        }

        private void View_ReelDoubleClick(object sender, EventArgs e) {
            if (!player.IsAbleToBuyItem(view.Reel_P)) return;
            player.ReelInventory.Add(view.Reel_P);
            player.Money -= view.Reel_P.Price;
            view.MoneyL = player.Money.ToString();
            view.LowerL = "Куплено...";
        }

        private void View_FLineDoubleClick(object sender, EventArgs e) {
            if (!player.IsAbleToBuyItem(view.FLine_P)) return;
            player.FlineInventory.Add(view.FLine_P);
            player.Money -= view.FLine_P.Price;
            view.MoneyL = Game.GetGame().Player.Money.ToString();
            view.LowerL = "Куплено...";
        }

        public override void Run() {
            view.Open();
        }

        public override void End() {
            view.Down();
        }
    }
}