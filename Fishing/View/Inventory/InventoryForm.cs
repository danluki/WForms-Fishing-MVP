using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Game;
using Fishing.BL.Model.Hooks;
using Fishing.BL.Model.Items;
using Fishing.BL.Presenter;
using Fishing.BL.View;
using Fishing.View.Assembly;
using Fishing.View.LureSelector;
using System;
using System.Windows.Forms;

namespace Fishing.View.Inventory {

    public partial class Inventory : Form, IInventory {
        private readonly Player _player = Game.GetGame().Player;

        public Inventory() {
            InitializeComponent();
            if (_player.FirstRoad != null) {
                fRoadButton.Enabled = true;
            }
            if (_player.SecondRoad != null) {
                sRoadButton.Enabled = true;
            }
            if (_player.ThirdRoad != null) {
                tRoadButton.Enabled = true;
            }

            assembliesBox.SetObjects(_player.Assemblies);
            flinesView.SetObjects(_player.FLineInv);
            reelsView.SetObjects(_player.ReelInv);
            luresView.SetObjects(_player.LureInv);
            baitsView.SetObjects(_player.BaitInv);
            hooksView.SetObjects(_player.HooksInv);
        }

        public Road Road_P { get; set; }

        public Reel Reel_P { get; set; }

        public FLine FLine_P { get; set; }

        public Lure Lure_P { get; set; }

        public Item Item_P { get; set; }

        public BL.Model.Game.Assembly Assembly_P {
            get {
                try {
                    return Game.GetGame().Player.Assemblies[assembliesBox.SelectedIndex];
                }
                catch (ArgumentOutOfRangeException) { }

                return null;
            }
            set { }
        }

        public Bait Bait_P { get; set; }

        public BaseHook Hook_P { get; set; }

        public string RoadText { get => roadTextBox.Text; set => roadTextBox.Text = value; }
        public string ReelText { get => reelTextBox.Text; set => reelTextBox.Text = value; }
        public string FLineText { get => flineTextBox.Text; set => flineTextBox.Text = value; }
        public string LureText { get => lureTextBox.Text; set => lureTextBox.Text = value; }
        public BasePresenter Presenter { get; set; }
        public string AssNumbText { get => assNumberLabel.Text; set => assNumberLabel.Text = value; }
        public int RoadWearValue { get => roadWearBar.Value; set => roadWearBar.Value = value; }
        public int ReelWearMax { get => reelWearBar.Maximum; set => reelWearBar.Maximum = value; }
        public int ReelWearValue { get => reelWearBar.Value; set => reelWearBar.Value = value; }
        public string HookBoxText { get => hookNameBox.Text; set => hookNameBox.Text = value; }
        public string AssembliesViewSelectedItemText { get => assembliesBox.SelectedItem.Text; set => throw new NotImplementedException(); }
        public string FlinesViewSelectedItemText { get => flinesView.SelectedItem?.Text; set => throw new NotImplementedException(); }
        public string ReelsViewSelectedItemText { get => reelsView.SelectedItem?.Text; set => throw new NotImplementedException(); }
        public string BaitsViewSelectedItemText { get => baitsView.SelectedItem?.Text; set => throw new NotImplementedException(); }
        public string LuresViewSelectedItemText { get => luresView.SelectedItem?.Text; set => throw new NotImplementedException(); }
        public string HooksViewSelectedItemText { get => hooksView.SelectedItem?.Text; set => throw new NotImplementedException(); }

        public event EventHandler CloseButtonClick;

        public event EventHandler AssemblyDoubleClick;

        public event EventHandler MakeOutClick;

        public event EventHandler ViewsDoubleClick;

        public event EventHandler ViewsSelectedIndexChanged;

        public event EventHandler RoadButtonsClick;

        public event EventHandler AssemblyBoxSelectedIndexChanged;

        private void RoadButtons_Click(object sender, EventArgs e) {
            RoadButtonsClick?.Invoke(sender, e);
        }

        private void CloseButton_Click(object sender, EventArgs e) {
            CloseButtonClick?.Invoke(this, EventArgs.Empty);
        }

        private void MakeOutButton_Click(object sender, EventArgs e) {
            MakeOutClick?.Invoke(this, EventArgs.Empty);
        }

        private void BaitBox_Click(object sender, EventArgs e) {
            if (Game.GetGame().Player.EquipedRoad.Assembly == null || Game.GetGame().Player.EquipedRoad.IsBaitInWater) return;
            if (Game.GetGame().Player.EquipedRoad.Assembly.FishBait is Lure) {
                var presenter = new SelectorPresenter<Lure>(new LureSelector<Lure>(Game.GetGame().Player.LureInv), UI.Gui);
                presenter.Run();
            }
            if (!(Game.GetGame().Player.EquipedRoad.Assembly.FishBait is Bait)) return;
            {
                var presenter = new SelectorPresenter<Bait>(new LureSelector<Bait>(Game.GetGame().Player.BaitInv), UI.Gui);
                presenter.Run();
            }
        }

        #region ViewsClick

        private void reelsView_MouseDoubleClick(object sender, MouseEventArgs e) {
            ViewsDoubleClick?.Invoke(reelsView, EventArgs.Empty);
        }

        private void reelsView_SelectedIndexChanged(object sender, EventArgs e) {
            ViewsSelectedIndexChanged?.Invoke(reelsView, EventArgs.Empty);
        }

        private void luresView_MouseDoubleClick_1(object sender, MouseEventArgs e) {
            ViewsDoubleClick?.Invoke(luresView, EventArgs.Empty);
        }

        private void luresView_SelectedIndexChanged_1(object sender, EventArgs e) {
            ViewsSelectedIndexChanged?.Invoke(luresView, EventArgs.Empty);
        }

        private void baitsView_MouseDoubleClick(object sender, MouseEventArgs e) {
            ViewsDoubleClick?.Invoke(baitsView, EventArgs.Empty);
        }

        private void baitsView_SelectedIndexChanged(object sender, EventArgs e) {
            ViewsSelectedIndexChanged?.Invoke(baitsView, EventArgs.Empty);
        }

        private void hooksView_MouseDoubleClick(object sender, MouseEventArgs e) {
            ViewsDoubleClick?.Invoke(hooksView, EventArgs.Empty);
        }

        private void hooksView_SelectedIndexChanged(object sender, EventArgs e) {
            ViewsSelectedIndexChanged?.Invoke(hooksView, EventArgs.Empty);
        }

        private void FlinesView_SelectedIndexChanged(object sender, EventArgs e) {
            ViewsSelectedIndexChanged?.Invoke(flinesView, EventArgs.Empty);
        }

        private void FlinesView_MouseDoubleClick(object sender, MouseEventArgs e) {
            ViewsDoubleClick?.Invoke(flinesView, EventArgs.Empty);
        }

        private void assembliesBox_MouseDoubleClick_2(object sender, MouseEventArgs e) {
            AssemblyDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        private void assembliesBox_SelectedIndexChanged_2(object sender, EventArgs e) {
            AssemblyBoxSelectedIndexChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion ViewsClick

        private void ItemsTab_Click(object sender, EventArgs e) {
            if (Assembly_P != null) {
                if (Assembly_P.Road.Type == RoadType.Spinning) {
                    baitsView.Enabled = false;
                    luresView.Enabled = true;
                    Hook_P = null;
                }

                if (Assembly_P.Road.Type == RoadType.Feeder || Assembly_P.Road.Type == RoadType.Float) {
                    baitsView.Enabled = true;
                    luresView.Enabled = false;
                }
            }
        }

        public void AddItemToRightView(Item item) {
            switch (Item.SelectItemType(item)) {
                case Road r:
                itemImageBox.BackgroundImage = r.Picture;
                nameBox.Text = r.Name;
                powerBox.Text = r.Power.ToString();
                typeBox.Text = r.GetType().ToString();
                break;

                case Reel r:
                itemImageBox.Image = r.Picture;
                nameBox.Text = r.Name;
                powerBox.Text = r.Power.ToString();
                typeBox.Text = "";
                break;

                case FLine fl:
                itemImageBox.BackgroundImage = fl.Picture;
                nameBox.Text = fl.Name;
                powerBox.Text = fl.Power.ToString();
                typeBox.Text = "";
                break;

                case Lure l:
                itemImageBox.BackgroundImage = l.Picture;
                nameBox.Text = l.Name;
                powerBox.Text = "";
                typeBox.Text = "";
                break;

                case Bait b:
                itemImageBox.BackgroundImage = b.Picture;
                nameBox.Text = b.Name;
                powerBox.Text = b.Count.ToString();
                typeBox.Text = "";
                break;

                case BaseHook bk:
                itemImageBox.BackgroundImage = bk.Picture;
                nameBox.Text = bk.Name;
                powerBox.Text = bk.GatheringChance.ToString();
                typeBox.Text = "";
                break;
            }
        }

        public void ShowAssembly(BL.Model.Game.Assembly assembly) {
            if (assembly == null) return;
            assemblyType.Text = assembly.Road?.Type.ToString();
            RoadText = assembly.Road?.Name;
            ReelText = assembly.Reel?.Name;
            LureText = assembly.FishBait?.Name;
            FLineText = assembly.FLine?.Name;
            hookNameBox.Text = assembly.Hook?.Name;

            RoadBox.BackgroundImage = assembly.Road?.Picture;
            ReelBox.BackgroundImage = assembly.Reel?.Picture;
            BaitBox.BackgroundImage = assembly.FishBait?.Picture;
            FLineBox.BackgroundImage = assembly.FLine?.Picture;
            hookImageBox.BackgroundImage = assembly.Hook?.Picture;

            if (assembly.Road != null)
                RoadWearValue = assembly.Road.Wear;
            if (assembly.Reel != null)
                ReelWearValue = assembly.Reel.Wear;
        }

        public void Open() {
            Show();
        }

        public void Down() {
            Close();
        }
    }
}