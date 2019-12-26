using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Eating;
using Fishing.BL.Model.FeedingUp;
using Fishing.BL.Model.Game;
using Fishing.BL.Model.Hooks;
using Fishing.BL.Model.Items;
using Fishing.BL.Presenter;
using System;
using System.Windows.Forms;

namespace Fishing.View.Shop {

    public partial class Shop : Form, IShop {

        public Shop() {
            InitializeComponent();
            RoadsList.DataSource = Item.Roads;
            ReelsList.DataSource = Item.Reels;
            FLineList.DataSource = Item.FLines;
            foreach (var fb in FishBait.FishBaits) {
                switch (fb) {
                    case Lure _:
                    lureBox.Items.Add(fb);
                    break;

                    case Bait _:
                    baitsList.Items.Add(fb);
                    break;
                }
            }
            hookList.DataSource = Item.Hooks;
            basicsBox.DataSource = Item.Basics;
            aromasBox.DataSource = Item.Aromas;
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
        public BasePresenter Presenter { get; set; }
        public Basic Basic_P { get => (Basic)Item.GetItemByName(basicsBox.SelectedItem.ToString()); set => throw new NotImplementedException(); }
        public Aroma Aroma_P { get => (Aroma)Item.GetItemByName(aromasBox.SelectedItem.ToString()); set => throw new NotImplementedException(); }

        public event EventHandler FLineDoubleClick;

        public event EventHandler RoadDoubleClick;

        public event EventHandler ReelDoubleClick;

        public event EventHandler CloseButtonClick;

        public event EventHandler ProductDoubleClick;

        public event EventHandler LureDoubleClick;

        public event EventHandler BaitDoubleClick;

        public event EventHandler HookDoubleClick;

        public event EventHandler AromaDoubleClick;

        public event EventHandler BasicDoubleClick;

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

        public void AddItemToRightView(Item item) {
            try {
                if (Item.SelectItemType(item) is Basic) {
                    var r = (Basic)item;
                    itemBox.BackgroundImage = r.Picture;
                    nameBox.Text = r.Name;
                    powerBox.Text = " ";
                    label1.Text = " ";
                }
                if (Item.SelectItemType(item) is Aroma) {
                    var r = (Aroma)item;
                    itemBox.BackgroundImage = r.Picture;
                    nameBox.Text = r.Name;
                    powerBox.Text = " ";
                    label1.Text = " ";
                }
                if (Item.SelectItemType(item) is Road) {
                    var r = (Road)item;
                    itemBox.BackgroundImage = r.Picture;
                    nameBox.Text = r.Name;
                    powerBox.Text = r.Power.ToString();
                    label1.Text = " ";
                }
                if (Item.SelectItemType(item) is Reel) {
                    var r = (Reel)item;
                    itemBox.BackgroundImage = r.Picture;
                    nameBox.Text = r.Name;
                    powerBox.Text = r.Power.ToString();
                    typeBox.Text = " ";
                    label1.Text = " ";
                }
                if (Item.SelectItemType(item) is FLine) {
                    var r = (FLine)item;
                    itemBox.BackgroundImage = r.Picture;
                    nameBox.Text = r.Name;
                    powerBox.Text = r.Power.ToString();
                    typeBox.Text = " ";
                    label1.Text = " ";
                }
                if (Item.SelectItemType(item) is Food) {
                    var r = (Food)item;
                    itemBox.BackgroundImage = r.Picture;
                    nameBox.Text = r.Name;
                    powerBox.Text = r.Productivity.ToString();
                    typeBox.Text = " ";
                    label1.Text = " ";
                }
                if (Item.SelectItemType(item) is Lure) {
                    var r = (Lure)item;
                    itemBox.BackgroundImage = r.Picture;
                    nameBox.Text = r.Name;
                    powerBox.Text = r.DeepType.ToString();
                    typeBox.Text = r.Size.ToString();
                    label1.Text = " ";
                }
                if (Item.SelectItemType(item) is Bait) {
                    var r = (Bait)item;
                    itemBox.BackgroundImage = r.Picture;
                    nameBox.Text = r.Name;
                    powerBox.Text = "Кол-во: 30";
                    typeBox.Text = " ";
                    label1.Text = " ";
                }

                if (!(Item.SelectItemType(item) is BaseHook)) return;
                {
                    var r = (BaseHook)item;
                    itemBox.BackgroundImage = r.Picture;
                    nameBox.Text = r.Name;
                    powerBox.Text = r.GatheringChance.ToString();
                    typeBox.Text = " ";
                    label1.Text = " ";
                }
            }
            catch (ArgumentOutOfRangeException) { }
        }

        private void basicsBox_SelectedIndexChanged(object sender, EventArgs e) {
            AddItemToRightView(Basic_P);
        }

        private void basicsBox_MouseDoubleClick(object sender, MouseEventArgs e) {
            BasicDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        private void aromasBox_SelectedIndexChanged(object sender, EventArgs e) {
            AddItemToRightView(Aroma_P);
        }

        private void aromasBox_MouseDoubleClick(object sender, MouseEventArgs e) {
            AromaDoubleClick?.Invoke(this, EventArgs.Empty);
        }
    }
}