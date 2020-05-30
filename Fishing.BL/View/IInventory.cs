using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Game;
using Fishing.BL.Model.Game.Inventory;
using Fishing.BL.Model.Hooks;
using Fishing.BL.Model.Items;
using Fishing.Presenter;
using System;

namespace Fishing.BL.View {

    public interface IInventory : IView<InventoryPresenter> {

        event Action InventoryLoaded;
        event Action<InventoryItemType, Guid> ViewItemActivate;
        event Action<Item> ViewItemDoubleClick;
        event Action<Assembly> ViewAssemblyItemDoubleClick;
        event EventHandler CloseButtonClick;
        event EventHandler MakeOutClick;

        Rod Rod_P { get; set; }
        Reel Reel_P { get; set; }
        Fishingline FLine_P { get; set; }
        Lure Lure_P { get; set; }
        Bait Bait_P { get; set; }
        BaseHook Hook_P { get; set; }
        Item Item_P { get; set; }
        BL.Model.Game.Assembly Assembly_P { get; set; }

        string RoadText { get; set; }
        string ReelText { get; set; }
        string FLineText { get; set; }
        string LureText { get; set; }
        string AssNumbText { get; set; }
        string HookBoxText { get; set; }

        int RoadWearValue { get; set; }
        int ReelWearMax { get; set; }
        int ReelWearValue { get; set; }

        void ShowItemInRightView(Item item);

        void ShowAssembly(BL.Model.Game.Assembly assembly);
    }
}