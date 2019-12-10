using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Hooks;
using Fishing.BL.View;
using System;
using Fishing.BL.Model.Items;

namespace Fishing.View.Inventory {

    public interface IInventory : IView {

        event EventHandler FLineSelectedIndexChanged;

        event EventHandler RoadSelectedIndexChanged;

        event EventHandler ReelSelectedIndexChanged;

        event EventHandler LureSelectedIndexChanged;

        event EventHandler FLineDoubleClick;

        event EventHandler RoadDoubleClick;

        event EventHandler ReelDoubleClick;

        event EventHandler LureDoubleClick;

        event EventHandler AssemblyDoubleClick;

        event EventHandler CloseButtonClick;

        event EventHandler FetchButtonClick;

        event EventHandler MakeOutClick;

        event EventHandler BaitDoubleClick;

        event EventHandler BaitSelectedIndexChanged;

        event EventHandler HookDoubleClick;

        event EventHandler HookSelectedIndex;

        event EventHandler RoadButtonsClick;

        event EventHandler AssemblyBoxSelectedIndexChanged;
        Road Road_P { get; set; }
        Reel Reel_P { get; set; }
        FLine FLine_P { get; set; }
        Lure Lure_P { get; set; }
        Bait Bait_P { get; set; }
        BaseHook Hook_P { get; set; }
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

        void AddItemToRightView(Item item);

        void ShowAssembly(BL.Model.Game.Assembly ass);

    }
}