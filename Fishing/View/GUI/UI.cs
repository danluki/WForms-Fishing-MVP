using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Game;
using Fishing.BL.Model.Items;
using Fishing.BL.Model.UserEvent;
using Fishing.BL.Presenter;
using Fishing.BL.View;
using Fishing.Presenter;
using Fishing.View.FoodInventory;
using Fishing.View.GUI;
using Fishing.View.LureSelector;
using Fishing.View.Statistic;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Fishing.BL.Model.LVLS;
using Fishing.Resources;
using Fishing.View.FeedUpView;
using Fishing.View.Inventory;

namespace Fishing {

    public partial class UI : Form, IGUIPresenter, ISounder {
        public static UI Gui;
        private readonly GUIPresenter _presenter;
        private readonly SounderPresenter _sound;

        public UI(Lvl lvl) {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint |
                                                                            ControlStyles.UserPaint, true);
            eatingBar.Value = Player.GetPlayer().Satiety;

            _presenter = new GUIPresenter(this);
            _presenter.Run();

            _sound = new SounderPresenter(this, lvl);
            _sound.Run();

            MoneyLValue = Player.GetPlayer().Money;
            timeLabel.Text = Game.GetGame().Time.ToString();

            Game.GetGame().HoursInc += GUI_HoursInc;
            Player.GetPlayer().EventHistoryUpdated += ShowLastEvent;
            Player.GetPlayer().SatietyUpdated += SatietyUpdated;
            Player.GetPlayer().Gathering += UI_Gathering;
            Player.GetPlayer().UpdateBucketImage += UI_UpdateBucketImage;
        }

        private void UI_Gathering()
        {
            ReelBar.Value = 0;
            FLineBar.Value = 0;
            fBaitCountsLabel.Text = "";
        }

        private void UI_UpdateBucketImage() {
            FeedUpButton.BackgroundImage = (Image)GuiButtons.ResourceManager.GetObject("bucket_fu_d");
        }

        public Bitmap BaitPicture { get => (Bitmap)BaitsPicture.BackgroundImage; set => BaitsPicture.BackgroundImage = value; }
        public string DeepValue { get => DeepLabel.Text; set => DeepLabel.Text = value; }
        public int RoadBarValue { get => ReelBar.Value; set => ReelBar.Value = value; }
        public int FLineBarValue { get => FLineBar.Value; set => FLineBar.Value = value; }
        public int EventBoxItemsCount { get => eventsView.Items.Count; set => throw new NotImplementedException(); }
        public int MoneyLValue { get => Convert.ToInt32(MoneyLabel.Text); set => MoneyLabel.Text = value.ToString(); }
        public int LureDeepValue { get => Convert.ToInt32(LureDeep.Text); set => LureDeep.Text = value.ToString(); }
        public string WiringType { get => WiringTypeLabel.Text; set => WiringTypeLabel.Text = value; }
        public int EatingBarValue { get => eatingBar.Value; set => eatingBar.Value = value; }
        public Image RoadPicture { get => roadBox.BackgroundImage; set => roadBox.BackgroundImage = value; }
        public Image ReelPicture { get => reelBox.BackgroundImage; set => reelBox.BackgroundImage = value; }
        public Image FLinePicture { get => flineBox.BackgroundImage; set => flineBox.BackgroundImage = value; }
        public Image HookPicture { get => hookBox.BackgroundImage; set => hookBox.BackgroundImage = value; }
        public BasePresenter Presenter { private get; set; }

        public event PaintEventHandler SounderPaint;


        private void SatietyUpdated(int obj) {
            eatingBar.Increment(obj);
        }

        private void ShowLastEvent() {
            AddEventToBox(Player.GetPlayer().EventHistory.Peek());
        }

        private void GUI_HoursInc(object sender, EventArgs e) {
            timeLabel.Text = Game.GetGame().Time.ToString();
        }


        private void MapLabel_Click(object sender, EventArgs e) {
            Gui.Close();
            Game.GetGame().View.Down();
            var map = new Map();
            map.Show();
        }

        private void MenuLabel_Click(object sender, EventArgs e) {
            Game.GetGame().View.Down();
        }

        private void SettingLabel_Click(object sender, EventArgs e) {
            var f = new SettingsForm();
            f.Show();
        }

        private void FishingPondBox_Click(object sender, EventArgs e) {
            var f = new FishPondForm();
            f.Show();
        }

        private void BaitsPicture_Click(object sender, EventArgs e) {
            if (Player.GetPlayer().EquipedRoad.Assembly == null || Player.GetPlayer().EquipedRoad.IsBaitInWater) return;
            if (Player.GetPlayer().EquipedRoad.Assembly.FishBait is Lure) {
                var pres = new SelectorPresenter<Lure>(new LureSelector<Lure>(Player.GetPlayer().LureInv), this);
                pres.Run();
            }
            if (!(Player.GetPlayer().EquipedRoad.Assembly.FishBait is Bait)) return;
            {
                var pres = new SelectorPresenter<Bait>(new LureSelector<Bait>(Player.GetPlayer().BaitInv), this);
                pres.Run();
            }
        }

        private void EatingBar_Click(object sender, EventArgs e) {
            var pres = new FoodPresenter(new FoodInventory());
            pres.Run();
        }

        private void InventoryBox_Click(object sender, EventArgs e) {
            var pres = new InventoryPresenter(new Inventory(), Gui);
            pres.Run();
        }

        private void StatsBox_Click(object sender, EventArgs e) {
            var pres = new StatisticPresenter(new StatisticForm());
            pres.Run();
        }

        private void SounderPanel_Paint(object sender, PaintEventArgs e) {
            SounderPaint?.Invoke(this, e);
        }

        private void SounderUpdater_Tick(object sender, EventArgs e) {
            SounderPanel.Refresh();
        }

        private void FeedUpButton_MouseEnter(object sender, EventArgs e) {
            if (Player.GetPlayer().EquipedFeedUp == null)
            {
                FeedUpButton.BackgroundImage = (Image)GuiButtons.ResourceManager.GetObject("bucket_em_a");
            }
            else
            {
                FeedUpButton.BackgroundImage = (Image)GuiButtons.ResourceManager.GetObject("bucket_fu_a");
            }
        }

        private void FeedUpButton_MouseLeave(object sender, EventArgs e) {
            if (Player.GetPlayer().EquipedFeedUp == null) {
                FeedUpButton.BackgroundImage = (Image)GuiButtons.ResourceManager.GetObject("bucket_em_d");
            }
            else {
                FeedUpButton.BackgroundImage = (Image)GuiButtons.ResourceManager.GetObject("bucket_fu_d");
            }
        }

        private void Buttons_MouseEnter(object sender, EventArgs e) {
            if (sender is PictureBox picturebox)
                picturebox.BackgroundImage = (Image)GuiButtons.ResourceManager.GetObject(picturebox.Tag + "_a");
        }

        private void Buttons_MouseLeave(object sender, EventArgs e)
        {
            if (sender is PictureBox picturebox)
                picturebox.BackgroundImage = (Image) GuiButtons.ResourceManager.GetObject(picturebox.Tag + "_d");
        }

        private void FeedUpButton_Click(object sender, EventArgs e)
        {
            var feedUpForm = new FeedUpF();
            feedUpForm.Show();
        }
        public void AddEventToBox(BaseEvent ev) {
            var lvi = new ListViewItem {
                Text = ev.Text,
                ImageIndex = ev.Index
            };
            if (ev is TrophyFishEvent) {
                lvi.ForeColor = Color.White;
                lvi.BackColor = Color.Navy;
            }
            eventsView.Items.Add(lvi);
        }

        public void ClearEvents() {
            eventsView.Items.Clear();
        }

        public void IncrementRoadBarValue(int value) {
            ReelBar.Increment(value);
        }

        public void IncrementFLineBarValue(int value) {
            FLineBar.Increment(value);
        }

        public void CheckNeedsAndClearEventBox() {
            if (EventBoxItemsCount >= 5) {
                ClearEvents();
            }
        }

        public void AddRoadToGUI(GameRoad road) {
            if(road == null) return;
            if (road.Assembly.IsAssemblyFull())
            {

                BaitPicture = road.Assembly.FishBait?.Picture;
                FLinePicture = road.Assembly.FLine?.Picture;
                FLinePicture = road.Assembly.FLine?.Picture;
                RoadPicture = road.Assembly.Road?.Picture;
                ReelPicture = road.Assembly.Reel?.Picture;

                if (road.Assembly.Road?.Type == RoadType.Feeder)
                {
                    HookPicture = road.Assembly.Hook?.Picture;
                    fBaitCountsLabel.Text = ((Bait) road.Assembly.FishBait)?.Count.ToString();
                }
                else
                {
                    if (road.Assembly.FishBait != null)
                    {
                        fBaitCountsLabel.Text = "1";
                    }
                }
            }
        }

        public void Open() {
            this.Show();
        }

        public void Down() {
            Show();
        }
    }
}