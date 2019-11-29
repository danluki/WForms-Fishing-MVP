using Fishing.View.GUI;
using System;
using Fishing.BL.Model.Game;
using Fishing.BL.View;

namespace Fishing.BL.Presenter {

    public class FPondPresenter : BasePresenter {
        private readonly IFPond view;
        private readonly IGUIPresenter gui;

        public FPondPresenter(IFPond view, IGUIPresenter gui) {
            this.view = view;
            view.Presenter = this;
            this.gui = gui;
            view.SellButtonClick += View_SellButtonClick;
            view.SelectedIndexChanged += View_SelectedIndexChanged;
        }

        private void View_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                view.RightImage = Player.GetPlayer().GetFishByIndex(view.SelectedIndex).Bitmap;

                view.DescriptionText = Player.GetPlayer().GetFishByIndex(view.SelectedIndex).Description;
            }
            catch (ArgumentOutOfRangeException) {
            }
            catch (NullReferenceException) {
            }
        }

        private void View_SellButtonClick(object sender, EventArgs e) {
            Player.GetPlayer().SellFish(Player.GetPlayer().GetFishByIndex(view.SelectedIndex));
            gui.MoneyLValue = Player.GetPlayer().Money;
            view.DescriptionText = " ";
            view.RightImage = null;
        }

        public override void Run()
        {
            view.Open();
        }

        public override void End()
        {
            view.Down();
        }
    }
}