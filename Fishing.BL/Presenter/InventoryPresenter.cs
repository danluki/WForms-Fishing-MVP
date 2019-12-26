using BrightIdeasSoftware;
using Fishing.BL.Model.Game;
using Fishing.BL.Model.Hooks;
using Fishing.BL.Model.Items;
using Fishing.BL.Presenter;
using Fishing.BL.Resources.Messages;
using Fishing.BL.View;
using Fishing.View.GUI;
using System;
using System.Windows.Forms;

namespace Fishing.Presenter {

    public class InventoryPresenter : BasePresenter {
        private readonly Player _player = Player.GetPlayer();

        private readonly IInventory _view;
        private readonly IGUIPresenter _gui;

        private int _index = 1;

        public InventoryPresenter(IInventory view, IGUIPresenter gui) {
            _view = view;
            _gui = gui;
            view.Presenter = this;

            view.CloseButtonClick += View_CloseButtonClick;
            view.AssemblyDoubleClick += View_AssemblyDoubleClick;
            view.MakeOutClick += View_MakeOutClick;
            view.ViewsDoubleClick += View_ViewsDoubleClick;
            view.ViewsSelectedIndexChanged += View_ViewsSelectedIndexChanged;
            view.AssemblyBoxSelectedIndexChanged += View_AssemblyBoxSelectedIndexChanged;
            view.RoadButtonsClick += View_RoadButtonsClick;
            view.Open();
        }

        #region RoadIndexClicks

        private void View_RoadButtonsClick(object sender, EventArgs e) {
            _index = int.Parse((sender as Button)?.Text ?? throw new InvalidOperationException());
        }

        #endregion RoadIndexClicks

        #region AssemblyClicks

        private void View_AssemblyBoxSelectedIndexChanged(object sender, EventArgs e) {
            _view.ShowAssembly(_view.Assembly_P);
        }

        private void View_AssemblyDoubleClick(object sender, EventArgs e) {
            if (_view.Assembly_P == null) return;
            if (!_view.Assembly_P.IsEquiped) {
                if (_view.Assembly_P.IsAssemblyFull()) {
                    _view.ShowAssembly(_view.Assembly_P);
                    _player.SetGameRoad(_view.Assembly_P, _index);
                    _player.SetEquipedRoad(_index);
                    _gui.AddRoadToGUI(_player.EquipedRoad);
                    _view.Assembly_P.IsEquiped = true;
                }
                else {
                    MessageBox.Show(Messages.ASSEMBLY_NOT_FULL);
                }
            }
            else {
                MessageBox.Show(Messages.ROAD_ALREADY_EQUIPED);
            }
        }

        #endregion AssemblyClicks

        #region HooksClicks

        private void View_ViewsSelectedIndexChanged(object sender, EventArgs e) {
            var senderTag = (sender as ObjectListView)?.Tag.ToString();
            switch (senderTag) {
                case "Reels":
                _view.Reel_P = (Reel)_player.GetItemByName(_view.ReelsViewSelectedItemText);
                _view.AddItemToRightView(_view.Reel_P);
                break;

                case "Flines":
                _view.FLine_P = (FLine)_player.GetItemByName(_view.FlinesViewSelectedItemText);
                _view.AddItemToRightView(_view.FLine_P);
                break;

                case "Lures":
                _view.Lure_P = (Lure)_player.GetItemByName(_view.LuresViewSelectedItemText);
                break;

                case "Baits":
                _view.Bait_P = _player.GetBaitByName(_view.BaitsViewSelectedItemText);
                break;

                case "Hooks":
                _view.Hook_P = (BaseHook)_player.GetItemByName(_view.HooksViewSelectedItemText);
                break;

                default:
                MessageBox.Show(Messages.NO_CURRENTTAG_FOUND);
                break;
            }
            _view.AddItemToRightView(_view.Item_P);
        }

        private void View_ViewsDoubleClick(object sender, EventArgs e) {
            if (_view.Assembly_P == null) return;
            var s = (sender as ObjectListView)?.Tag.ToString();
            if (!_view.Assembly_P.IsEquiped) {
                switch (s) {
                    case "Reels":
                    _view.Assembly_P.Reel = _view.Reel_P;
                    _view.ShowAssembly(_view.Assembly_P);
                    _player.ReelInv.Remove(_view.Reel_P);
                    break;

                    case "Flines":
                    _view.Assembly_P.FLine = _view.FLine_P;
                    _view.ShowAssembly(_view.Assembly_P);
                    _player.FLineInv.Remove(_view.FLine_P);
                    break;

                    case "Lures":
                    _view.Assembly_P.FishBait = _view.Lure_P;
                    _view.ShowAssembly(_view.Assembly_P);
                    _player.LureInv.Remove(_view.Lure_P);
                    break;

                    case "Baits":
                    _view.Assembly_P.FishBait = _view.Bait_P;
                    _view.ShowAssembly(_view.Assembly_P);
                    _view.Bait_P.Count -= 1;
                    break;

                    case "Hooks":
                    if (_view.Assembly_P.Road.Type == RoadType.Spinning) return;
                    _view.Assembly_P.Hook = _view.Hook_P;
                    _view.ShowAssembly(_view.Assembly_P);
                    _player.HooksInv.Remove(_view.Hook_P);
                    break;

                    default:
                    MessageBox.Show(Messages.NO_CURRENTTAG_FOUND);
                    break;
                }
            }
            else {
                MessageBox.Show(Messages.FIRST_UNEQUIP_ROAD);
            }
        }

        #endregion HooksClicks

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

        private void View_CloseButtonClick(object sender, EventArgs e) {
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