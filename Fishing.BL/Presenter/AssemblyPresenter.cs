using Fishing.View.Assembly;
using System;
using Fishing.BL.Model.Game;
using Fishing.BL.Presenter;

namespace Fishing.Presenter {

    public class AssemblyPresenter : BasePresenter {
        private readonly IAddAssembly _view;

        public AssemblyPresenter(IAddAssembly view) {
            _view = view;
            view.Presenter = this;
            view.AddAssemblyClick += View_AddAssemblyClick;
        }

        private void View_AddAssemblyClick(object sender, EventArgs e) {
            var name = _view.AssemblyName;
            Player.GetPlayer().Assemblies.Add(new Assembly(name));
            End();
        }

        public override void Run() {
            _view.Open();
        }

        public override void End() {
            _view.Down();
        }
    }
}