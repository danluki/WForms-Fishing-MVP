using Fishing.BL.Model.Items;
using Fishing.View.GUI;
using Fishing.View.Inventory;
using System;
using System.Windows.Forms;
using Fishing.BL.Model.Game;
using Fishing.BL.Presenter;

namespace Fishing.Presenter {

    public class InventoryPresenter : BasePresenter {
        private readonly Player _player = Player.GetPlayer();
        private readonly IInventory _view;
        private readonly IGUIPresenter _gui;
        private int index = 1;

        public InventoryPresenter(IInventory view, IGUIPresenter gui) {
            _view = view;
            _gui = gui;
            view.Presenter = this;

            view.LureDoubleClick += View_LureDoubleClick;
            view.LureSelectedIndexChanged += View_LureSelectedIndexChanged;
            view.ReelDoubleClick += View_ReelDoubleClick;
            view.ReelSelectedIndexChanged += View_ReelSelectedIndexChanged;
            view.RoadDoubleClick += View_RoadDoubleClick;
            view.RoadSelectedIndexChanged += View_RoadSelectedIndexChanged;
            view.FLineDoubleClick += View_FLineDoubleClick;
            view.FLineSelectedIndexChanged += View_FLineSelectedIndexChanged;
            view.CloseButtonClick += View_CloseButtonClick;
            view.FetchButtonClick += View_FetchButtonClick;
            view.AssemblyDoubleClick += View_AssemblyDoubleClick;
            view.MakeOutClick += View_MakeOutClick;
            view.BaitDoubleClick += View_BaitDoubleClick;
            view.BaitSelectedIndexChanged += View_BaitSelectedIndexChanged;
            view.HookDoubleClick += View_HookDoubleClick;
            view.HookSelectedIndex += View_HookSelectedIndex;
            view.AssemblyBoxSelectedIndexChanged += View_AssemblyBoxSelectedIndexChanged;
            view.RoadButtonsClick += View_RoadButtonsClick;
            view.Open();
        }

        private void View_RoadButtonsClick(object sender, EventArgs e)
        {
            index = int.Parse((sender as Button)?.Text ?? throw new InvalidOperationException());
        }

        private void View_AssemblyBoxSelectedIndexChanged(object sender, EventArgs e) {
            _view.ShowAssembly(_view.Assembly_P);
        }
        private void View_HookSelectedIndex(object sender, EventArgs e) {
            _view.AddItemToRightView(_view.Hook_P);
        }

        private void View_HookDoubleClick(object sender, EventArgs e) {
            _view.Assembly_P.Hook = _view.Hook_P;
            _view.ShowAssembly(_view.Assembly_P);
            _player.HooksInv.Remove(_view.Hook_P);
        }

        private void View_BaitSelectedIndexChanged(object sender, EventArgs e) {
            _view.AddItemToRightView(_view.Bait_P);
        }

        private void View_BaitDoubleClick(object sender, EventArgs e) {
            _view.Assembly_P.FishBait = _view.Bait_P;
            _view.ShowAssembly(_view.Assembly_P);
            _view.Bait_P.Count -= 1;
        }

        private void View_MakeOutClick(object sender, EventArgs e) {
            try {
                if (_player.EquipedRoad.Assembly.FLine != null)
                    _player.FLineInv.Add(_view.Assembly_P.FLine);
                if (_player.EquipedRoad.Assembly.Road != null)
                    _player.RoadInv.Add(_view.Assembly_P.Road);
                if (_player.EquipedRoad.Assembly.FishBait != null)
                    _player.LureInv.Add((Lure)_view.Assembly_P.FishBait);
                if (_player.EquipedRoad.Assembly.Reel != null)
                    _player.ReelInv.Add(_view.Assembly_P.Reel);

                _player.Assemblies.Remove(_view.Assembly_P);
            }
            catch (NullReferenceException) { }
        }

        private void View_AssemblyDoubleClick(object sender, EventArgs e) {
            _view.ShowAssembly(_view.Assembly_P);
            _player.SetGameRoad(_view.Assembly_P, index);
            _player.SetEquipedRoad(index);
            _view.Assembly_P.IsEquiped = true;
            _gui.AddRoadToGUI(_player.EquipedRoad);
            _view.RoadWearValue = _view.Assembly_P.Road.Wear;
            _view.ReelWearValue = _view.Assembly_P.Reel.Wear;
        }

        private void View_FetchButtonClick(object sender, EventArgs e) {
            if (_view.Assembly_P == null) return;
            if (_view.FLine_P == null || _view.Road_P == null || _view.Reel_P == null) return;
            _view.Assembly_P.Road = _view.Road_P;
            _player.RoadInv.Remove(_view.Road_P);

            _view.Assembly_P.Reel = _view.Reel_P;
            _player.ReelInv.Remove(_view.Reel_P);

            _view.Assembly_P.FLine = _view.FLine_P;
            _player.FLineInv.Remove(_view.FLine_P);

            switch (_view.Assembly_P.Road.Type)
            {
                case RoadType.Spinning:
                    _view.Assembly_P.FishBait = _view.Lure_P;
                    _player.LureInv.Remove(_view.Lure_P);
                    break;
                case RoadType.Feeder:
                    _view.Assembly_P.FishBait = _view.Bait_P;
                    _view.Bait_P.Count -= 1;

                    _view.Assembly_P.Hook = _view.Hook_P;
                    _player.HooksInv.Remove(_view.Hook_P);
                    break;
            }
        }

        private void View_CloseButtonClick(object sender, EventArgs e) {
            End();
        }

        private void View_FLineSelectedIndexChanged(object sender, EventArgs e) {
            _view.AddItemToRightView(_view.FLine_P);
        }

        private void View_FLineDoubleClick(object sender, EventArgs e) {
            _view.Assembly_P.FLine = _view.FLine_P;
            _view.ShowAssembly(_view.Assembly_P);
            _player.FLineInv.Remove(_view.FLine_P);
        }

        private void View_RoadSelectedIndexChanged(object sender, EventArgs e) {
            _view.AddItemToRightView(_view.Road_P);
        }

        private void View_RoadDoubleClick(object sender, EventArgs e) {
            _view.RoadText = _view.Road_P.Name;
        }

        private void View_ReelSelectedIndexChanged(object sender, EventArgs e) {
            _view.AddItemToRightView(_view.Reel_P);
        }

        private void View_ReelDoubleClick(object sender, EventArgs e)
        {
            _view.Assembly_P.Reel = _view.Reel_P;
            _view.ShowAssembly(_view.Assembly_P);
            _player.ReelInv.Remove(_view.Reel_P);
        }

        private void View_LureSelectedIndexChanged(object sender, EventArgs e) {
            _view.AddItemToRightView(_view.Lure_P);
        }

        private void View_LureDoubleClick(object sender, EventArgs e) {
            _view.Assembly_P.FishBait = _view.Lure_P;
            _view.ShowAssembly(_view.Assembly_P);
            _player.LureInv.Remove(_view.Lure_P);
        }

        public override void Run() {
            _view.Open();
        }

        public override void End() {
            _view.Down();
        }
    }
}