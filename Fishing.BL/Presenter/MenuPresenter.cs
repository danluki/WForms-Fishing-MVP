using Fishing.BL.Controller;
using Fishing.BL.Model.Game;
using Fishing.BL.Model.Hooks;
using Fishing.BL.Model.Items;
using Fishing.BL.Presenter;
using Fishing.BL.Resources.Images;
using Fishing.View.Menu;
using System;
using System.Windows.Forms;

namespace Fishing.Presenter {

    public class MenuPresenter : BasePresenter {
        private readonly IMenu view;

        public MenuPresenter(IMenu view) {
            this.view = view;
            view.Presenter = this;
            view.ExitButtonClick += View_ExitButtonClick;
            view.MenuLoad += Menu_Load;
            GameLoader.GetLoader().Initiallize("Рыболов");
        }

        private void View_ExitButtonClick(object sender, EventArgs e) {
            GameLoader.GetLoader().SavePlayer();
            Application.Exit();
        }

        private void Menu_Load(object sender, EventArgs e) {
            view.LowerLValue = Game.GetGame().Player.Nickname;

            Item.Reels.Add(new Reel("Hydra", 0, 6, 3, 100000, Images.Hydra));
            Item.Reels.Add(new Reel("SYBERIA_LT_2", 0, 4, 6, 200000, Images.Syberia_LT_2));
            Item.Reels.Add(new Reel("Quest_Reel", 0, 2, 6, 400000, Images.Quest_Reel));
            Item.Reels.Add(new Reel("SYBERIA 4", 0, 5, 8, 600000, Images.Syberia_HD_4));
            Item.Reels.Add(new Reel("Zymix", 0, 7, 9, 400000, Images.Zymix));
            Item.Reels.Add(new Reel("Syberia 1", 0, 4, 4, 300000, Images.Syberia_HD_1));
            Item.Reels.Add(new Reel("TBR 4000", 0, 1, 5, 450000, Images.TBR_4000));

            Item.Fishinglines.Add(new Fishingline("Indiana 4000", 4000, 500, Images.indiana));
            Item.Fishinglines.Add(new Fishingline("Quest_fishers 90000", 90000, 200000, Images.Quest_Fishers));
            Item.Fishinglines.Add(new Fishingline("Colorado 30000", 30000, 100000, Images.Colorado));
            Item.Fishinglines.Add(new Fishingline("Atlantic", 1000000, 1000000, Images.Atlantic));

            Item.Rods.Add(new Rod("Titanium", RodType.Spinning, 0, 40000, 300000, Images.Titanium));
            Item.Rods.Add(new Rod("Achilles", RodType.Spinning, 0, 5000, 3000, Images.Achilles_233));
            Item.Rods.Add(new Rod("Yellow super Carp", RodType.Feeder, 0, 100000, 600000, Images.Yellow_SuperCarp));
            Item.Rods.Add(new Rod("Hearty Rose Jigging", RodType.Spinning, 0, 95000, 700000, Images.SuperFisher_950));
            Item.Rods.Add(new Rod("Vesta 276", RodType.Feeder, 0, 7000, 15000, Images.Vesta_276));

            Item.Hooks.Add(new FeederHook("Фидер 1", 20, 800, HooksImg.Fider));
            Item.Hooks.Add(new FeederHook("Фидер 2", 10, 1800, HooksImg.Fider_2));
            Item.Hooks.Add(new FeederHook("Фидер 3", 5, 2800, HooksImg.Fider_3));
            Item.Hooks.Add(new FloatsHook("Bait Holder", 25, 800, HooksImg.BaitHolder));
            Item.Hooks.Add(new FloatsHook("Barracuda", 20, 1500, HooksImg.Barracuda));
            Item.Hooks.Add(new FloatsHook("Takara 2002", 12, 2500, HooksImg.Takara_2002));
            Item.Hooks.Add(new FloatsHook("Worm_X_Strong", 7, 5000, HooksImg.Worm_X_Strong));

            GameLoader.GetLoader().IntializeLures();
            GameLoader.GetLoader().SetFeedUps();
            GameLoader.GetLoader().SetAllFishesName();
        }

        public override void Run() {
            view.Open();
        }

        public override void End() {
            view.Down();
        }
    }
}