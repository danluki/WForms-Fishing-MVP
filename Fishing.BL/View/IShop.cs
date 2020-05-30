using Fishing.BL.Model;
using Fishing.BL.Model.Baits;
using Fishing.BL.Model.FeedingUp;
using Fishing.BL.Model.Hooks;
using Fishing.BL.Model.Items;
using Fishing.BL.View;
using Fishing.Presenter;
using System;

namespace Fishing.View.ShopForm {

    /// <summary>
    /// Интерфейс описовающий View для ShopPresenter.
    /// Является основопологающим для взаимодействия View и Presenter
    /// </summary>
    public interface IShop : IView<ShopPresenter> {

        #region events

        event Action<ShopItemType, string> ViewItemActivate;
        event Action<Item> ViewItemDoubleClick;
        
        event Action ShopLoaded;       
        event EventHandler CloseButtonClick;

        #endregion

        #region props
        Rod Rod_Prop { get; set; }
        Reel Reel_Prop { get; set; }
        Fishingline FLine_Prop { get; set; }
        Lure Lure_Prop { get; set; }
        Bait Bait_Prop { get; set; }
        BaseHook Hook_Prop { get; set; }
        Basic Basic_Prop { get; set; }
        Aroma Aroma_Prop { get; set; }
        string MoneyText { get; set; }
        string LowerText { get; set; }

        #endregion
    }
}