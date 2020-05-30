using BrightIdeasSoftware;
using Fishing.BL.Model.Baits;
using Fishing.BL.Model.FeedingUp;
using Fishing.BL.Model.Game;
using Fishing.BL.Model.Game.Inventory;
using Fishing.BL.Model.Hooks;
using Fishing.BL.Model.Inventory;
using Fishing.BL.Model.Items;
using Fishing.BL.Presenter;
using Fishing.BL.Resources.Messages;
using Fishing.BL.View;
using Fishing.View.GUI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fishing.Presenter {

    public sealed class InventoryPresenter : BasePresenter {

        #region private field

        private readonly Player _player = Game.GetGame().Player;
        private readonly Inventory _inventory = new Inventory();

        private readonly IInventory _view;
        private readonly IGUIPresenter _gui;

        private int _index = 1;

        #endregion


        #region public events

        public Action<IEnumerable<Rod>> ProduceRods;
        public Action<IEnumerable<Fishingline>> ProduceFishinglines;
        public Action<IEnumerable<Reel>> ProduceReels;
        public Action<IEnumerable<FishBait>> ProduceLures;
        public Action<IEnumerable<Bait>> ProduceBaits;
        public Action<IEnumerable<BaseHook>> ProduceHooks;
        public Action<IEnumerable<Basic>> ProduceBasics;
        public Action<IEnumerable<Aroma>> ProduceAromas;
        public Action<IEnumerable<Assembly>> ProduceAssemblies;

        public Action GetRods;

        #endregion 

        public InventoryPresenter(IInventory view, IGUIPresenter gui) {
            _view = view;
            _gui = gui;
            view.Presenter = this;

            
            view.InventoryLoaded += View_InventoryLoaded;
            view.ViewItemActivate += View_ViewItemActivate;
            view.ViewItemDoubleClick += View_ViewItemDoubleClick;
            view.ViewAssemblyItemDoubleClick += View_ViewAssemblyItemDoubleClick;
            view.CloseButtonClick += View_CloseButtonClick;
            view.MakeOutClick += View_MakeOutClick;

            view.Open();
        }

        private void View_MakeOutClick(object sender, EventArgs e) {
            if (_view.Assembly_P != null) {
                if (!_view.Assembly_P.IsEquiped) {
                    if (_view.Assembly_P.Fline != null) {
                        _player.Inventory.Fishinglines.Add(_view.Assembly_P.Fline.UniqueIdentifer,
                                                           _view.Assembly_P.Fline);
                        _view.Assembly_P.Fline = null;
                        ProduceFishinglines?.Invoke(_player.Inventory.Fishinglines.Values);
                    }
                    if (_view.Hook_P != null) {
                        _player.Inventory.Hooks.Add(_view.Assembly_P.Hook.UniqueIdentifer,
                                                   _view.Assembly_P.Hook);
                        _view.Assembly_P.Hook = null;
                        ProduceHooks?.Invoke(_player.Inventory.Hooks.Values);
                    }
                    if (_view.Assembly_P.Rod?.RodType == RodType.Spinning) {
                        if (_view.Assembly_P.FishBait != null) {
                            _player.Inventory.Lures.Add(((Lure)_view.Assembly_P.FishBait).UniqueIdentifer,
                                                        (Lure)_view.Assembly_P.FishBait);
                            _view.Assembly_P.FishBait = null;
                            ProduceLures?.Invoke(_player.Inventory.Lures.Values);
                        }
                    }
                    else {
                        if (_view.Assembly_P.FishBait != null) {
                            _player.Inventory.Baits.Add(((Bait)_view.Assembly_P.FishBait).UniqueIdentifer,
                                                        (Bait)_view.Assembly_P.FishBait);
                            _view.Assembly_P.FishBait = null;
                            ProduceBaits?.Invoke(_player.Inventory.Baits.Values);
                        }
                    }

                    if (_player.EquipedRod.Assembly.Reel != null) {
                        _player.Inventory.Reels.Add(_view.Assembly_P.Reel.UniqueIdentifer, _view.Assembly_P.Reel);
                        _view.Assembly_P.Reel = null;
                        ProduceReels?.Invoke(_player.Inventory.Reels.Values);
                    }
                    _view.ShowAssembly(_view.Assembly_P);
                }
            }
        }

        private void View_CloseButtonClick(object sender, EventArgs e) {
            End();
        }

        private void View_ViewItemDoubleClick(Item item) {
            if (_view.Assembly_P != null) {
                if (!_view.Assembly_P.IsEquiped) {
                    switch (item) {
                        case Reel reel:
                        _view.Assembly_P.Reel = reel;
                        _player.Inventory.Reels.Remove(reel.UniqueIdentifer);
                        break;

                        case Fishingline fline:
                        _view.Assembly_P.Fline = fline;
                        _player.Inventory.Fishinglines.Remove(fline.UniqueIdentifer);
                        break;

                        case BaseHook hook:
                        _view.Assembly_P.Hook = hook;
                        _player.Inventory.Hooks.Remove(hook.UniqueIdentifer);
                        break;

                        case Bait bait:
                        _view.Assembly_P.FishBait = bait;
                        _view.Bait_P.Count -= 1;
                        break;

                        case Lure lure:
                        _view.Assembly_P.FishBait = lure;
                        _player.Inventory.Lures.Remove(lure.UniqueIdentifer);
                        break;

                    }
                    _view.ShowAssembly(_view.Assembly_P);
                }
            } 
        }

        private void View_ViewAssemblyItemDoubleClick(Assembly ass) {
            if (_view.Assembly_P == null) return;
            if (!_view.Assembly_P.IsEquiped) {
                if (_view.Assembly_P.IsFull()) {
                    _view.ShowAssembly(_view.Assembly_P);
                    _player.SetGameRoad(_view.Assembly_P, _index);
                    _player.SetEquipedRoad(_index);
                    _gui.AddRoadToGUI(_player.EquipedRod);
                    _view.Assembly_P.IsEquiped = true;
                    ProduceAssemblies?.Invoke(_player.Inventory.Assemblies.Values);
                }
                else {
                    MessageBox.Show(Messages.ASSEMBLY_NOT_FULL);
                }
            }
            else {
                MessageBox.Show(Messages.ROAD_ALREADY_EQUIPED);
            }
        }

        private void View_ViewItemActivate(InventoryItemType type, Guid guid) {
            switch (type) {

                case InventoryItemType.Bait:
                    _view.Bait_P = _player.Inventory.GetBait(guid);
                break;


                case InventoryItemType.Fishingline:
                    _view.FLine_P = _player.Inventory.GetFishline(guid);
                break;

                case InventoryItemType.Hook:
                    _view.Hook_P = _player.Inventory.GetHook(guid);
                break;

                case InventoryItemType.Lure:
                    _view.Lure_P = _player.Inventory.GetLure(guid);
                break;

                case InventoryItemType.Reel:
                    _view.Reel_P = _player.Inventory.GetReel(guid);
                break;

                case InventoryItemType.Rod:
                    _view.Rod_P = _player.Inventory.GetRod(guid);
                break;

                case InventoryItemType.Assembly:
                    _view.Assembly_P = _player.Inventory.GetAssembly(guid);
                    _view.ShowAssembly(_view.Assembly_P);
                break;
            }
        }

        private void View_InventoryLoaded() {
            //При загрузке отдает списки объектов View

            ProduceFishinglines?.Invoke(_player.Inventory.Fishinglines.Values);
            ProduceReels?.Invoke(_player.Inventory.Reels.Values);
            ProduceLures?.Invoke(_player.Inventory.Lures.Values);
            ProduceBaits?.Invoke(_player.Inventory.Baits.Values);
            ProduceHooks?.Invoke(_player.Inventory.Hooks.Values);
            ProduceBasics?.Invoke(_player.Inventory.Basics.Values);
            ProduceAromas?.Invoke(_player.Inventory.Aromas.Values);
            ProduceAssemblies?.Invoke(_player.Inventory.Assemblies.Values);
        }

        public override void Run() {
            _view.Open();
        }

        public override void End() {
            _view.Down();
        }
    }
}