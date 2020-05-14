using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Hooks;
using Fishing.BL.Model.Items;
using System;

namespace Fishing.BL.View {

    public interface IInventory : IView {

        event EventHandler AssemblyDoubleClick;

        event EventHandler CloseButtonClick;

        event EventHandler MakeOutClick;

        event EventHandler ViewsDoubleClick;

        event EventHandler ViewsSelectedIndexChanged;

        event EventHandler RoadButtonsClick;

        event EventHandler AssemblyBoxSelectedIndexChanged;

        Rod Road_P { get; set; }
        Reel Reel_P { get; set; }
        FLine FLine_P { get; set; }
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
        string AssembliesViewSelectedItemText { get; set; }
        string FlinesViewSelectedItemText { get; set; }
        string ReelsViewSelectedItemText { get; set; }
        string BaitsViewSelectedItemText { get; set; }
        string LuresViewSelectedItemText { get; set; }
        string HooksViewSelectedItemText { get; set; }

        int RoadWearValue { get; set; }
        int ReelWearMax { get; set; }
        int ReelWearValue { get; set; }

        void AddItemToRightView(Item item);

        void ShowAssembly(BL.Model.Game.Assembly assembly);
    }
}