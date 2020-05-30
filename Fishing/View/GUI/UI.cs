using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Game;
using Fishing.BL.Model.Items;
using Fishing.BL.Model.LVLS;
using Fishing.BL.Model.UserEvent;
using Fishing.BL.Presenter;
using Fishing.BL.View;
using Fishing.Presenter;
using Fishing.Resources;
using Fishing.View.FeedUpView;
using Fishing.View.FoodInventory;
using Fishing.View.GUI;
using Fishing.View.Inventory;
using Fishing.View.LureSelector;
using Fishing.View.Statistic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fishing {

    public partial class UI : Form, IGUIPresenter, ISounder {
        Player _player = Game.GetGame().Player;
        public static UI Gui;
        private readonly GUIPresenter _presenter;
        private readonly SounderPresenter _sound;

        public UI(Lvl lvl) {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | 
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);
            eatingBar.Value = _player.Satiety;

            _presenter = new GUIPresenter(this);
            _presenter.Run();

            _sound = new SounderPresenter(this, lvl);
            _sound.Run();

            MoneyLValue = _player.Money;
            timeLabel.Text = Game.GetGame().Time.ToString();

            Game.GetGame().HoursInc += GUI_HoursInc;
            _player.Statistic.EventHistoryUpdated += ShowLastEvent;
            _player.SatietyUpdated += SatietyUpdated;
            _player.Gathering += UI_Gathering;
            _player.UpdateBucketImage += UI_UpdateBucketImage;

            waterInfoBox.Text += Game.GetGame().CurrentWater.ToString();
            playersCountLabel.Text += "1"; //TODO Players Count
            daysRemainLabel.Text += _player.HoursRemain;
        }

        private void UI_Gathering() {
            ResetBarValues();
            fBaitCountsLabel.Text = string.Empty;
        }

        private void UI_UpdateBucketImage() {
            FeedUpButton.BackgroundImage = (Image)GuiButtons.ResourceManager.GetObject("bucket_fu_d");
        }

        public Bitmap BaitPicture { get => (Bitmap)BaitsPicture.BackgroundImage; set => BaitsPicture.BackgroundImage = value; }
        public string DeepValue { get => DeepLabel.Text; set => DeepLabel.Text = value; }
        public int RoadBarValue { get => ReelBar.Value; set => ReelBar.Value = value; }
        public int FLineBarValue { get => FLineBar.Value; set => FLineBar.Value = value; }
        public int EventBoxItemsCount { get => eventsView.Items.Count; set => throw new NotImplementedException(); }
        public int MoneyLValue { get=> _player.Money; set => MoneyLabel.Text = "Деньги:" + value.ToString(); }
        public int LureDeepValue { get => int.Parse(LureDeep.Text); set => LureDeep.Text = value.ToString(); }
        public string WiringType { get => WiringTypeLabel.Text; set => WiringTypeLabel.Text = value; }
        public int EatingBarValue { get => eatingBar.Value; set => eatingBar.Value = value; }
        public Image RoadPicture { get => roadBox.BackgroundImage; set => roadBox.BackgroundImage = value; }
        public Image ReelPicture { get => reelBox.BackgroundImage; set => reelBox.BackgroundImage = value; }
        public Image FLinePicture { get => flineBox.BackgroundImage; set => flineBox.BackgroundImage = value; }
        public Image HookPicture { get => hookBox.BackgroundImage; set => hookBox.BackgroundImage = value; }
        public GUIPresenter Presenter { get; set; }
        public string LocationNameLabelText { get => locationLabel.Text; set => locationLabel.Text += value; }

        public event PaintEventHandler SounderPaint;

        private void SatietyUpdated() {
            eatingBar.Value = _player.Satiety;
        }

        private void ShowLastEvent() {
            AddEventToBox(_player.Statistic.Events.Peek());
        }

        private void GUI_HoursInc(object sender, EventArgs e) {
            timeLabel.Text = Game.GetGame().Time.ToString();
            daysRemainLabel.Text = "Часов осталось:" + _player.HoursRemain;
        }

        private void MapLabel_Click(object sender, EventArgs e) {
            Gui.Close();
            Game.GetGame().View.Down();
            var map = new Map();
            map.Show();
        }

        private void MenuLabel_Click(object sender, EventArgs e) {
            Gui.Close();
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
            if (_player.EquipedRod.Assembly == null || _player.EquipedRod.IsBaitInWater) return;
            if (_player.EquipedRod.Assembly.FishBait is Lure) {
                //var pres = new SelectorPresenter<Lure>(new LureSelector<Lure>(_player.LureInventory), this);
                //pres.Run();
            }
            if (!(_player.EquipedRod.Assembly.FishBait is Bait)) return;
            {
                //var pres = new SelectorPresenter<Bait>(new LureSelector<Bait>(_player.BaitInventory), this);
                //pres.Run();
            }
        }

        private void EatingBar_Click(object sender, EventArgs e) {
            var pres = new FoodPresenter(new FoodInventory());
            pres.Run();
        }

        private void InventoryBox_Click(object sender, EventArgs e) {
            var pres = new InventoryPresenter(new Inventory(), this);
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
            if (_player.EquipedFeedUp == null) {
                FeedUpButton.BackgroundImage = (Image)GuiButtons.ResourceManager.GetObject("bucket_em_a");
            }
            else {
                FeedUpButton.BackgroundImage = (Image)GuiButtons.ResourceManager.GetObject("bucket_fu_a");
            }
        }

        private void FeedUpButton_MouseLeave(object sender, EventArgs e) {
            if (_player.EquipedFeedUp == null) {
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

        private void Buttons_MouseLeave(object sender, EventArgs e) {
            if (sender is PictureBox picturebox)
                picturebox.BackgroundImage = (Image)GuiButtons.ResourceManager.GetObject(picturebox.Tag + "_d");
        }

        private void FeedUpButton_Click(object sender, EventArgs e) {
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

        public void AddRoadToGUI(GameRod road) {
            if (road == null) return;

            BaitPicture = road.Assembly.FishBait?.Picture;
            FLinePicture = road.Assembly.Fline?.Picture;
            FLinePicture = road.Assembly.Fline?.Picture;
            RoadPicture = road.Assembly.Rod?.Picture;
            ReelPicture = road.Assembly.Reel?.Picture;

            if (road.Assembly.Rod?.RodType == RodType.Feeder) {
                HookPicture = road.Assembly.Hook?.Picture;
                fBaitCountsLabel.Text = ((Bait)road.Assembly.FishBait)?.Count.ToString();
            }
            else {
                if (road.Assembly.FishBait != null) {
                    fBaitCountsLabel.Text = "1";
                }
            }
        }

        public void Open() {
            this.Show();
        }

        public void Down() {
            Show();
        }

        public void ResetBarValues() {
            FLineBarValue = 0;
            RoadBarValue = 0;
        }
    }
}