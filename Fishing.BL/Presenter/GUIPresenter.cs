using Fishing.BL.Presenter;
using Fishing.View.GUI;

namespace Fishing.Presenter {

    public class GUIPresenter : BasePresenter {
        private readonly IGUIPresenter _view;

        public GUIPresenter(IGUIPresenter view) {
            this._view = view;
        }

        public override void Run() {
            _view.Open();
        }

        public override void End() {
            _view.Down();
        }
    }
}