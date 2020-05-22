using BrightIdeasSoftware;
using Fishing.BL.Model;
using Fishing.BL.Model.Baits;
using Fishing.BL.Model.FeedingUp;
using Fishing.BL.Model.Hooks;
using Fishing.BL.Model.Items;
using Fishing.BL.Model.Lures;
using Fishing.Presenter;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fishing.View.ShopForm {

    /// <summary>
    /// Класс описывает View (MVP Pattern), взаимодействует с ShopPresenter.
    /// Является Active View так как знает как отобразить сложный объект Item.
    /// </summary>
    public partial class ShopForm : Form, IShop {

        #region public prop

        public Rod Rod_Prop { get; set; }
        public string MoneyText { get => MoneyBox.Text; set => MoneyBox.Text = value; }
        public string LowerText { get => LowerLabel.Text; set => LowerLabel.Text = value; }
        public ShopPresenter Presenter { get; set; }
        public Fishingline FLine_Prop { get; set; }
        public Reel Reel_Prop { get; set; }
        public Lure Lure_Prop { get; set; }
        public Bait Bait_Prop { get; set; }
        public BaseHook Hook_Prop { get; set; }
        public Basic Basic_Prop { get; set; }
        public Aroma Aroma_Prop { get; set; }

        #endregion public prop

        #region events

        public event Action ShopLoaded;

        public event Action<ShopItemType, string> ViewItemActivate;

        public event Action<Item> ViewItemDoubleClick;

        public event EventHandler CloseButtonClick;

        #endregion events

        #region ctor

        public ShopForm() {
            InitializeComponent();

            imgeColumn.ImageGetter = delegate (object lure) {
                switch (lure) {
                    case Jig _:
                    return "vibro.png";

                    case Pinwheel _:
                    return "vert.png";

                    case Shaker _:
                    return "spoon.png";

                    case Wobbler _:
                    return "vob.png";

                    default:
                    return null;
                }
            };
        }

        #endregion ctor

        #region private methods

        /// <summary>
        /// Метод показывает предмет в правой части экрана.
        /// </summary>
        /// <param name="item">Любой объект наследник от Item</param>
        private void ShowItemInRightView(Item item) {
            if (item == null) return;

            switch (item) {
                case Basic basic:
                ItemImageBox.BackgroundImage = basic.Picture;
                NameBox.Text = string.Format($"Основа: {basic.Name}");
                PowerBox.Text = string.Empty;
                LowerLabel.Text = string.Empty;
                PriceBox.Text = string.Format($"Цена {basic.Price} рублей.");

                break;

                case Aroma aroma:
                ItemImageBox.BackgroundImage = aroma.Picture;
                NameBox.Text = string.Format($"Ароматизатор: {aroma.Name}");
                PowerBox.Text = string.Empty;
                LowerLabel.Text = string.Empty;
                PriceBox.Text = string.Format($"Цена: {aroma.Price} рублей.");

                break;

                case Rod rod:
                ItemImageBox.BackgroundImage = rod.Picture;
                NameBox.Text = string.Format($"Удочка: {rod.Name}");
                PowerBox.Text = string.Format($"{rod.Power / 1000} кг. ");
                typeBox.Text = string.Format($"Тип: {rod.RodType}");
                LowerLabel.Text = string.Empty;
                PriceBox.Text = string.Format($"Цена: {rod.Price} рублей.");

                break;

                case Reel reel:
                ItemImageBox.BackgroundImage = reel.Picture;
                NameBox.Text = string.Format($"Катушка: {reel.Name}");
                PowerBox.Text = string.Format($"Мощность: {reel.Power}");
                typeBox.Text = string.Empty;
                LowerLabel.Text = string.Empty;
                PriceBox.Text = string.Format($"{reel.Price} рублей.");

                break;

                case Fishingline fline:
                ItemImageBox.BackgroundImage = fline.Picture;
                NameBox.Text = string.Format($"Леска: {fline.Name}");
                PowerBox.Text = string.Format($"Прочность: {fline.Power / 1000} кг.");
                typeBox.Text = string.Empty;
                LowerLabel.Text = string.Empty;
                PriceBox.Text = string.Format($"Цена: {fline.Price} рублей.");

                break;

                case Lure lure:
                ItemImageBox.BackgroundImage = lure.Picture;
                NameBox.Text = string.Format($"Приманка: {lure.Name}");
                PowerBox.Text = string.Format($"Глуб. проводки: {lure.DeepType}");
                typeBox.Text = string.Format($"Размер: {lure.Size}");
                LowerLabel.Text = string.Empty;
                PriceBox.Text = string.Format($"Цена: {lure.Price} рублей.");

                break;

                case Bait bait:
                ItemImageBox.BackgroundImage = bait.Picture;
                NameBox.Text = string.Format($"Наживка: {bait.Name}");
                PowerBox.Text = string.Format($"Кол-во: {bait.Count}");
                typeBox.Text = string.Empty;
                LowerLabel.Text = string.Empty;
                PriceBox.Text = string.Format($"Цена: {bait.Price} рублей.");

                break;

                case BaseHook bh:
                ItemImageBox.BackgroundImage = bh.Picture;
                NameBox.Text = string.Format($"Наживка: {bh.Name}");
                PowerBox.Text = string.Format($"Шанс схода: {bh.GatheringChance}");
                typeBox.Text = string.Empty;
                LowerLabel.Text = string.Empty;
                PriceBox.Text = string.Format($"Цена: {bh.Price} рублей.");
                break;

                default:
                ItemImageBox.BackgroundImage = item.Picture;
                NameBox.Text = string.Format($"Предмет: {item.Name}");
                PriceBox.Text = string.Format($"Цена: {item.Price} рублей.");
                break;
            }
        }

        #endregion private methods

        #region public methods

        public void Open() {
            Show();
        }

        public void Down() {
            Close();
        }

        #endregion public methods

        #region ProduceItems

        //Методы устанавливают входные коллекции нужным ObjectListView

        private void ProduceRods(IEnumerable<Rod> rods) {
            RodsView.SetObjects(rods);
        }

        private void ProduceFishinglines(IEnumerable<Fishingline> fishinglines) {
            FishinglinesView.SetObjects(fishinglines);
        }

        private void ProduceReels(IEnumerable<Reel> reels) {
            ReelsView.SetObjects(reels);
        }

        private void ProduceLures(IEnumerable<FishBait> lures) {
            LuresView.SetObjects(lures);
        }

        private void ProduceBaits(IEnumerable<Bait> baits) {
            BaitsView.SetObjects(baits);
        }

        private void ProduceHooks(IEnumerable<BaseHook> hooks) {
            HooksView.SetObjects(hooks);
        }

        private void ProduceAromas(IEnumerable<Aroma> aromas) {
            aromaView.SetObjects(aromas);
        }

        private void ProduceBasics(IEnumerable<Basic> basics) {
            BasicsView.SetObjects(basics);
        }

        #endregion ProduceItems

        #region ItemBought event

        /// <summary>
        /// Происходит при покупке игроком предмета
        /// </summary>
        /// <param name="moneyOver">То, сколько денег осталось у игрока</param>
        private void ItemBought(int moneyOver) {
            LowerText = "Куплено...";
            MoneyText = string.Format($"Деньги: {moneyOver} рублей.");
        }

        #endregion ItemBought event

        #region load event

        private void ShopForm_Load(object sender, EventArgs e) {
            this.Presenter.ProduceRods += ProduceRods;
            this.Presenter.ProduceFishinglines += ProduceFishinglines;
            this.Presenter.ProduceReels += ProduceReels;
            this.Presenter.ProduceLures += ProduceLures;
            this.Presenter.ItemBought += ItemBought;
            this.Presenter.ProduceBaits += ProduceBaits;
            this.Presenter.ProduceHooks += ProduceHooks;
            this.Presenter.ProduceAromas += ProduceAromas;
            this.Presenter.ProduceBasics += ProduceBasics;

            ShopLoaded.Invoke();
        }

        #endregion load event

        #region viewlogic clicks

        //Нажатия по списку удочек

        private void RodListView_MouseDoubleClick(object sender, MouseEventArgs e) {
            ViewItemDoubleClick?.Invoke(Rod_Prop);
        }

        private void RodListView_MouseClick(object sender, MouseEventArgs e) {
            ViewItemActivate?.Invoke(ShopItemType.Rod, (sender as ObjectListView).SelectedItem?.Text);
            ShowItemInRightView(Rod_Prop);
        }

        //Нажатия по списку лески

        private void FlineListView_MouseClick(object sender, MouseEventArgs e) {
            ViewItemActivate?.Invoke(ShopItemType.Fline, (sender as ObjectListView).SelectedItem?.Text);
            ShowItemInRightView(FLine_Prop);
        }

        private void FlineListView_MouseDoubleClick(object sender, MouseEventArgs e) {
            ViewItemDoubleClick?.Invoke(FLine_Prop);
        }

        //Нажатия по списку катушек

        private void ReelsView_MouseClick(object sender, MouseEventArgs e) {
            ViewItemActivate?.Invoke(ShopItemType.Reel, (sender as ObjectListView).SelectedItem?.Text);
            ShowItemInRightView(Reel_Prop);
        }

        private void ReelsView_MouseDoubleClick(object sender, MouseEventArgs e) {
            ViewItemDoubleClick?.Invoke(Reel_Prop);
        }

        //Нажатия по списку наживок

        private void BaitListView_Click(object sender, MouseEventArgs e) {
            ViewItemActivate?.Invoke(ShopItemType.Bait, (sender as ObjectListView).SelectedItem?.Text);
            ShowItemInRightView(Bait_Prop);
        }

        private void BaitListView_MouseDClick(object sender, MouseEventArgs e) {
            ViewItemDoubleClick?.Invoke(Bait_Prop);
        }

        private void CloseButton_Click(object sender, EventArgs e) {
            CloseButtonClick?.Invoke(sender, e);
        }

        //Нажатия по списку приманок

        private void LuresView_MouseClick(object sender, MouseEventArgs e) {
            ViewItemActivate?.Invoke(ShopItemType.Lure, (sender as ObjectListView).SelectedItem?.Text);
            ShowItemInRightView(Lure_Prop);
        }

        private void LuresView_MouseDoubleClick(object sender, MouseEventArgs e) {
            ViewItemDoubleClick?.Invoke(Lure_Prop);
        }

        //Нажатия по списку крючков

        private void HookView_MouseClick(object sender, MouseEventArgs e) {
            ViewItemActivate?.Invoke(ShopItemType.Hook, (sender as ObjectListView).SelectedItem?.Text);
            ShowItemInRightView(Hook_Prop);
        }

        private void HookView_MouseDoubleClick(object sender, MouseEventArgs e) {
            ViewItemDoubleClick?.Invoke(Hook_Prop);
        }

        //Нажатия по списку основ

        private void BasicView_MouseClick(object sender, MouseEventArgs e) {
            ViewItemActivate?.Invoke(ShopItemType.Basic, (sender as ObjectListView).SelectedItem?.Text);
            ShowItemInRightView(Basic_Prop);
        }

        private void BasicView_MouseDoubleClick(object sender, MouseEventArgs e) {
            ViewItemDoubleClick?.Invoke(Basic_Prop);
        }

        //Нажатия по списку ароматизаторов

        private void AromaView_MouseClick(object sender, MouseEventArgs e) {
            ViewItemActivate?.Invoke(ShopItemType.Aroma, (sender as ObjectListView).SelectedItem?.Text);
            ShowItemInRightView(Aroma_Prop);
        }

        private void AromaView_MouseDoubleClick(object sender, MouseEventArgs e) {
            ViewItemDoubleClick?.Invoke(Aroma_Prop);
            ShowItemInRightView(Aroma_Prop);
        }

        #endregion viewlogic clicks
    }
}