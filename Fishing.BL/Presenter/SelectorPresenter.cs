using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Game;
using Fishing.View.GUI;
using Fishing.View.LureSelector.View;
using System;

namespace Fishing.BL.Presenter {

    public class SelectorPresenter<T> : BasePresenter where T : FishBait {
        private readonly ISelector<T> _view;
        private readonly IGUIPresenter _gui;

        public SelectorPresenter(ISelector<T> view, IGUIPresenter gui) {
            _view = view;
            _gui = gui;
            view.Presenter = this;
            view.LureListDoubleClick += View_LureListDoubleClick;
            view.LureListIndexChanged += View_LureListIndexChanged;
        }

        private void View_LureListIndexChanged(object sender, EventArgs e) {
            _view.Picture = _view.FishBait.Picture;
            switch (_view.FishBait) {
                case Lure l:
                _view.DeepBoxText = l.DeepType.ToString();
                _view.SizeBoxText = l.Size.ToString();
                break;

                case Bait b:
                _view.SizeBoxText = b.Count.ToString();
                _view.DeepBoxText = b.Name;
                break;
            }
        }

        private void View_LureListDoubleClick(object sender, EventArgs e) {
            try {
                Game.GetGame().Player.EquipedRod.Assembly.FishBait = _view.FishBait;
                _gui.BaitPicture = Game.GetGame().Player.EquipedRod.Assembly.FishBait.Picture;
                _view.Down();
            }
            catch (NullReferenceException) {
            }
        }

        public override void Run() {
            _view.Open();
        }

        public override void End() {
            _view.Down();
        }
    }
}