using Fishing.View.Shop;
using System;
using Fishing.BL.Model.Game;
using Fishing.BL.Presenter;

namespace Fishing.Presenter {

    public class ShopPresenter : BasePresenter {
        private readonly IShop view;
        private readonly Player player = Player.GetPlayer();

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
            Player.GetPlayer().BasicInventory.Add(view.Basic_P);
            Player.GetPlayer().Money -= view.Basic_P.Price;
            view.MoneyL = Player.GetPlayer().Money.ToString();
            view.LowerL = "Куплено...";
        }

        private void View_AromaDoubleClick(object sender, EventArgs e) {
            if (!player.IsAbleToBuyItem(view.Aroma_P)) return;
            Player.GetPlayer().AromaInventory.Add(view.Aroma_P);
            Player.GetPlayer().Money -= view.Aroma_P.Price;
            view.MoneyL = Player.GetPlayer().Money.ToString();
            view.LowerL = "Куплено...";
        }

        private void View_HookDoubleClick(object sender, EventArgs e) {
            if (!player.IsAbleToBuyItem(view.Hook_P)) return;
            Player.GetPlayer().HooksInv.Add(view.Hook_P);
            Player.GetPlayer().Money -= view.Hook_P.Price;
            view.MoneyL = Player.GetPlayer().Money.ToString();
            view.LowerL = "Куплено...";
        }

        private void View_BaitDoubleClick(object sender, EventArgs e) {
            if (!player.IsAbleToBuyItem(view.Bait_P)) return;
            Player.GetPlayer().AddBait(view.Bait_P);
            Player.GetPlayer().Money -= view.Bait_P.Price;
            view.MoneyL = Player.GetPlayer().Money.ToString();
            view.LowerL = "Куплено...";
        }

        private void View_LureDoubleClick(object sender, EventArgs e) {
            if (!player.IsAbleToBuyItem(view.Lure_P)) return;
            Player.GetPlayer().LureInv.Add(view.Lure_P);
            Player.GetPlayer().Money -= view.Lure_P.Price;
            view.MoneyL = Player.GetPlayer().Money.ToString();
            view.LowerL = "Куплено...";
        }

        private void View_RoadDoubleClick(object sender, EventArgs e) {
            if (!player.IsAbleToBuyItem(view.Road_P)) return;
            Player.GetPlayer().Assemblies.Add(new Assembly(view.Road_P));
            Player.GetPlayer().Money -= view.Road_P.Price;
            view.MoneyL = Player.GetPlayer().Money.ToString();
            view.LowerL = "Куплено...";
        }

        private void View_ReelDoubleClick(object sender, EventArgs e) {
            if (!player.IsAbleToBuyItem(view.Reel_P)) return;
            Player.GetPlayer().ReelInv.Add(view.Reel_P);
            Player.GetPlayer().Money -= view.Reel_P.Price;
            view.MoneyL = Player.GetPlayer().Money.ToString();
            view.LowerL = "Куплено...";
        }

        private void View_FLineDoubleClick(object sender, EventArgs e) {
            if (!player.IsAbleToBuyItem(view.FLine_P)) return;
            Player.GetPlayer().FLineInv.Add(view.FLine_P);
            Player.GetPlayer().Money -= view.FLine_P.Price;
            view.MoneyL = Player.GetPlayer().Money.ToString();
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