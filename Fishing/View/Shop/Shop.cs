using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Eating;
using Fishing.BL.Model.Hooks;
using Fishing.Presenter;
using Fishing.View.Shop;
using System;
using System.Windows.Forms;
using Fishing.BL.Model.Game;
using Fishing.BL.Presenter;

namespace Fishing {
    public partial class Shop : Form, IShop {
        public Shop() {
            InitializeComponent();
            RoadsList.DataSource = Item.Roads;
            ReelsList.DataSource = Item.Reels;
            FLineList.DataSource = Item.FLines;
            foreach (var fb in FishBait.FishBaits)
            {
                switch (fb)
                {
                    case Lure _:
                        lureBox.Items.Add(fb);
                        break;
                    case Bait _:
                        baitsList.Items.Add(fb);
                        break;
                }
            }
            hookList.DataSource = Item.Hooks;
            moneyBox.Text = Player.GetPlayer().Money.ToString();
        }

        public Road Road_P { get => (Road)Item.GetItemByName(RoadsList.SelectedItem.ToString()); set => throw new ArgumentException(); }
        public Reel Reel_P { get => (Reel)Item.GetItemByName(ReelsList.SelectedItem.ToString()); set => throw new ArgumentException(); }
        public FLine FLine_P { get => (FLine)Item.GetItemByName(FLineList.SelectedItem.ToString()); set => throw new ArgumentException(); }
        public Lure Lure_P { get => (Lure)FishBait.GetFishBaitByName(lureBox.SelectedItem.ToString()); set => throw new ArgumentException(); }
        public Bait Bait_P { get => (Bait)FishBait.GetFishBaitByName(baitsList.SelectedItem.ToString()); set => throw new ArgumentException(); }
        public BaseHook Hook_P { get => (BaseHook)Item.GetItemByName(hookList.SelectedItem.ToString()); set => throw new ArgumentException(); }
        public string MoneyL { get => moneyBox.Text; set => moneyBox.Text = value; }
        public string LowerL { get => label1.Text; set => label1.Text = value; }
        public BasePresenter Presenter { private get; set; }

        public event EventHandler FLineDoubleClick;

        public event EventHandler RoadDoubleClick;

        public event EventHandler ReelDoubleClick;

        public event EventHandler CloseButtonClick;

        public event EventHandler ProductDoubleClick;

        public event EventHandler LureDoubleClick;

        public event EventHandler BaitDoubleClick;

        public event EventHandler HookDoubleClick;

        private void RoadsList_SelectedIndexChanged_1(object sender, EventArgs e) {
            AddItemToRightView(Road_P);
        }

        private void FLineList_SelectedIndexChanged(object sender, EventArgs e) {
            AddItemToRightView(FLine_P);
        }

        private void ReelsList_SelectedIndexChanged(object sender, EventArgs e) {
            AddItemToRightView(Reel_P);
        }

        private void FLineList_MouseDoubleClick(object sender, MouseEventArgs e) {
            FLineDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        private void ReelsList_MouseDoubleClick(object sender, MouseEventArgs e) {
            ReelDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        private void CloseButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void RoadsList_MouseDoubleClick_1(object sender, MouseEventArgs e) {
            RoadDoubleClick?.Invoke(this, EventArgs.Empty);
        }
        private void LureBox_SelectedIndexChanged(object sender, EventArgs e) {
            AddItemToRightView(Lure_P);
        }

        private void LureBox_DoubleClick(object sender, EventArgs e) {
            LureDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        private void BaitsList_SelectedIndexChanged(object sender, EventArgs e) {
            AddItemToRightView(Bait_P);
        }

        private void BaitsList_MouseDoubleClick(object sender, MouseEventArgs e) {
            BaitDoubleClick?.Invoke(this, e);
        }

        private void HookList_SelectedIndexChanged(object sender, EventArgs e) {
            AddItemToRightView(Hook_P);
        }

        private void HookList_MouseDoubleClick(object sender, MouseEventArgs e) {
            HookDoubleClick?.Invoke(this, e);
        }

        private void FoodsBox_DoubleClick(object sender, EventArgs e) {
            ProductDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        public void Open() {
            this.Show();
        }

        public void Down() {
            this.Close();
        }

        public void AddItemToRightView(Item i) {
            try {
                if (Item.SelectItemType(i) is Road) {
                    var r = (Road)i;
                    itemBox.BackgroundImage = r.Pict;
                    nameBox.Text = r.Name;
                    powerBox.Text = r.Power.ToString();
                    priceBox.Text = r.Price.ToString();
                    label1.Text = " ";
                }
                if (Item.SelectItemType(i) is Reel) {
                    var r = (Reel)i;
                    itemBox.BackgroundImage = r.Pict;
                    nameBox.Text = r.Name;
                    powerBox.Text = r.Power.ToString();
                    priceBox.Text = r.Price.ToString();
                    typeBox.Text = " ";
                    label1.Text = " ";
                }
                if (Item.SelectItemType(i) is FLine) {
                    var r = (FLine)i;
                    itemBox.BackgroundImage = r.Pict;
                    nameBox.Text = r.Name;
                    powerBox.Text = r.Power.ToString();
                    priceBox.Text = r.Price.ToString();
                    typeBox.Text = " ";
                    label1.Text = " ";
                }
                if (Item.SelectItemType(i) is Food) {
                    var r = (Food)i;
                    itemBox.BackgroundImage = r.Pict;
                    nameBox.Text = r.Name;
                    powerBox.Text = r.Productivity.ToString();
                    priceBox.Text = r.Price.ToString();
                    typeBox.Text = " ";
                    label1.Text = " ";
                }
                if (Item.SelectItemType(i) is Lure) {
                    var r = (Lure)i;
                    itemBox.BackgroundImage = r.Pict;
                    nameBox.Text = r.Name;
                    powerBox.Text = r.DeepType.ToString();
                    priceBox.Text = r.Price.ToString();
                    typeBox.Text = r.Size.ToString();
                    label1.Text = " ";
                }
                if (Item.SelectItemType(i) is Bait) {
                    var r = (Bait)i;
                    itemBox.BackgroundImage = r.Pict;
                    nameBox.Text = r.Name;
                    powerBox.Text = "Кол-во: 30";
                    priceBox.Text = r.Price.ToString();
                    typeBox.Text = " ";
                    label1.Text = " ";
                }

                if (!(Item.SelectItemType(i) is BaseHook)) return;
                {
                    var r = (BaseHook)i;
                    itemBox.BackgroundImage = r.Pict;
                    nameBox.Text = r.Name;
                    powerBox.Text = r.GatheringChance.ToString();
                    priceBox.Text = r.Price.ToString();
                    typeBox.Text = " ";
                    label1.Text = " ";
                }
            }
            catch (ArgumentOutOfRangeException) { }
        }

    }
}