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
using System.Drawing;
using System.Windows.Forms;
using Fishing.BL.Model.LVLS;

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
            _presenter.Run(); //Mistake
            _sound = new SounderPresenter(this, lvl);
            _sound.Run();

            MoneyLValue = Player.GetPlayer().Money;
            timeLabel.Text = Game.GetGame().Time.ToString();

            Game.GetGame().HoursInc += GUI_HoursInc;
            Player.GetPlayer().EventHistoryUpdated += ShowLastEvent;
            Player.GetPlayer().SatietyUpdated += SatietyUpdated;
        }

        private void SatietyUpdated(int obj) {
            eatingBar.Increment(obj);
        }

        private void ShowLastEvent() {
            AddEventToBox(Player.GetPlayer().EventHistory.Peek());
        }

        private void GUI_HoursInc(object sender, EventArgs e) {
            timeLabel.Text = Game.GetGame().Time.ToString();
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
            var baitPic = road.Assembly.FishBait.Pict;
            var fLinePic = road.Assembly.FLine.Pict;
            var roadPic = road.Assembly.Road.Pict;
            var reelPic = road.Assembly.Reel.Pict;
            var hookPic = road.Assembly.Hook.Pict;
            BaitPicture = baitPic != null ? road.Assembly.FishBait.Pict : default;
            if (baitPic != null) {
                BaitPicture = road.Assembly.FishBait.Pict;
            }
            if (fLinePic != null) {
                FLinePicture = road.Assembly.FLine.Pict;
            }
            if (roadPic != null) {
                RoadPicture = road.Assembly.Road.Pict;
            }
            if (reelPic != null) {
                ReelPicture = road.Assembly.Reel.Pict;
            }
            if (!(road.Assembly.Road is Feeder)) return;
            if (hookPic != null) {
                HookPicture = road.Assembly.Hook.Pict;
            }
        }

        public void Open() {
            this.Show();
        }

        public void Down() {
            this.Show();
        }
    }
}