using Fishing.BL.Model;
using Fishing.BL.Model.Baits;
using Fishing.BL.Model.FeedingUp;
using Fishing.BL.Model.Game;
using Fishing.BL.Model.Hooks;
using Fishing.BL.Model.Items;
using Fishing.BL.Model.SoundPlayer;
using Fishing.BL.Presenter;
using Fishing.View.ShopForm;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fishing.Presenter {

    /// <summary>
    /// Реализует презентер для класса ShopForm, через интерфейс IShop.
    /// Работает с объектом модели Shop путем прямого вызова методов
    /// </summary>
    public class ShopPresenter : BasePresenter {

        #region private variables

        private readonly IShop view;
        private readonly Player player = Game.GetGame().Player;
        private readonly Shop shop = new Shop();

        #endregion private variables

        #region public events

        public Action<IEnumerable<Rod>> ProduceRods;
        public Action<IEnumerable<Fishingline>> ProduceFishinglines;
        public Action<IEnumerable<Reel>> ProduceReels;
        public Action<IEnumerable<FishBait>> ProduceLures;
        public Action<IEnumerable<Bait>> ProduceBaits;
        public Action<IEnumerable<BaseHook>> ProduceHooks;
        public Action<IEnumerable<Basic>> ProduceBasics;
        public Action<IEnumerable<Aroma>> ProduceAromas;

        public Action<int> ItemBought;

        #endregion public events

        #region ctor

        /// <summary>
        /// Конструктор ShopPresenter
        /// </summary>
        /// <param name="view">объект View</param>
        public ShopPresenter(IShop view) {

            #region Initialization

            this.view = view ?? throw new ArgumentException("Представление не может отсутствовать.");
            view.Presenter = this;

            #endregion Initialization

            #region events add

            view.ViewItemActivate += View_ViewItemActivate;
            view.ViewItemDoubleClick += View_ViewItemDoubleClick;
            view.ShopLoaded += View_ShopLoaded;
            view.CloseButtonClick += View_CloseButtonClick;

            #endregion events add
        }

        #endregion ctor

        #region viewslogic

        /// <summary>
        /// Событие возникает, когда пользователь выбирает какой либо объект в ObjectListView
        /// После чего устанавливает значение необходимому объекту
        /// </summary>
        /// <param name="type">Тип предмета который вызвал вызов события</param>
        /// <param name="input">Имя предмета который вызвал срабатывания</param>
        private void View_ViewItemActivate(ShopItemType type, string input) {
            switch (type) {
                case ShopItemType.Aroma:
                view.Aroma_Prop = shop.GetAroma(input);
                break;

                case ShopItemType.Bait:
                view.Bait_Prop = shop.GetBait(input);
                break;

                case ShopItemType.Basic:
                view.Basic_Prop = shop.GetBasic(input);
                break;

                case ShopItemType.Fline:
                view.FLine_Prop = shop.GetFishingline(input);
                break;

                case ShopItemType.Hook:
                view.Hook_Prop = shop.GetHook(input);
                break;

                case ShopItemType.Lure:
                view.Lure_Prop = shop.GetLure(input);
                break;

                case ShopItemType.Reel:
                view.Reel_Prop = shop.GetReel(input);
                break;

                case ShopItemType.Rod:
                view.Rod_Prop = shop.GetRod(input);
                break;
            }
        }

        /// <summary>
        /// Срабатывает при двойном нажатии пользователя по предмету.
        /// При возникновении покупает предмет и воспроизводит звук.
        /// </summary>
        /// <param name="item">Объект, который необходимо купить</param>
        private void View_ViewItemDoubleClick(Item item) {
            if (item == null) return;

            if (player.BuyItem(item)) {
                ItemBought.Invoke(player.Money);
                SoundsPlayer.PlayBuyingSound();
            }
            else {
                MessageBox.Show(string.Format("Недостаточно средств!. Не хватает {0} рублей",
                                item.Price - player.Money));
                //Need to play warning sound.
            }
        }

        #endregion viewslogic

        #region closebuttonclick event

        private void View_CloseButtonClick(object sender, EventArgs e) {
            view.Down();
        }

        #endregion closebuttonclick event

        #region load event

        private void View_ShopLoaded() {
            //При загрузке отдает списки объектов View
            ProduceRods?.Invoke(shop.Rods);
            ProduceFishinglines?.Invoke(shop.Fishinglines);
            ProduceReels?.Invoke(shop.Reels);
            ProduceLures?.Invoke(shop.Lures);
            ProduceBaits?.Invoke(shop.Baits);
            ProduceHooks?.Invoke(shop.Hooks);
            ProduceBasics?.Invoke(shop.Basics);
            ProduceAromas?.Invoke(shop.Aromas);

            view.MoneyText = string.Format($"Деньги: {player.Money} рублей.");
        }

        #endregion load event

        #region public methods

        public override void Run() {
            view.Open();
        }

        public override void End() {
            view.Down();
        }

        #endregion public methods
    }
}