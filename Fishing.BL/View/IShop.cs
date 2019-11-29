using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Hooks;
using Fishing.BL.View;
using System;

namespace Fishing.View.Shop {

    public interface IShop : IView {

        event EventHandler FLineDoubleClick;

        event EventHandler RoadDoubleClick;

        event EventHandler ReelDoubleClick;

        event EventHandler ProductDoubleClick;

        event EventHandler LureDoubleClick;

        event EventHandler CloseButtonClick;

        event EventHandler BaitDoubleClick;

        event EventHandler HookDoubleClick;

        Road Road_P { get; set; }
        Reel Reel_P { get; set; }
        FLine FLine_P { get; set; }
        Lure Lure_P { get; set; }
        Bait Bait_P { get; set; }
        BaseHook Hook_P { get; set; }
        string MoneyL { get; set; }
        string LowerL { get; set; }
    }
}