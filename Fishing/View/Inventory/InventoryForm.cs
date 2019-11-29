using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Hooks;
using Fishing.BL.Model.Items;
using Fishing.BL.Model.Lures;
using Fishing.BL.Presenter;
using Fishing.Presenter;
using Fishing.View.Assembly;
using Fishing.View.Inventory;
using Fishing.View.LureSelector;
using System;
using System.Windows.Forms;
using Fishing.BL.Model.Game;

namespace Fishing {

    public partial class Inventory : Form, IInventory {

        public Inventory() {
            InitializeComponent();
            if (Player.GetPlayer().Assemblies.Count == 0) {
                var add = new AddAssembly();
                add.Show();
            }
            if (Player.GetPlayer().FirstRoad != null) {
                fRoadButton.Enabled = true;
            }
            if (Player.GetPlayer().SecondRoad != null) {
                sRoadButton.Enabled = true;
            }
            if (Player.GetPlayer().ThirdRoad != null) {
                tRoadButton.Enabled = true;
            }
            FLineList.DataSource = Player.GetPlayer().FLineInv;
            ReelsList.DataSource = Player.GetPlayer().ReelInv;
            baitsBox.DataSource = Player.GetPlayer().BaitInv;
            hooksBox.DataSource = Player.GetPlayer().HooksInv;

            foreach (var r in Player.GetPlayer().RoadInv) {
                var lvi = new ListViewItem {
                    Text = r.Name
                };
                switch (r) {
                    case Spinning _:
                    lvi.ImageIndex = roadsList.Images.IndexOfKey("shop_but02.png");
                    break;

                    case Float _:
                    lvi.ImageIndex = roadsList.Images.IndexOfKey("shop_but01.png");
                    break;

                    case Feeder _:
                    lvi.ImageIndex = roadsList.Images.IndexOfKey("rm_but01.png");
                    break;
                }
                roadsView.Items.Add(lvi);
            }

            foreach (var l in Player.GetPlayer().LureInv) {
                var lvi = new ListViewItem {
                    Text = l.Name
                };
                switch (l) {
                    case Shaker _:
                    lvi.ImageIndex = lureList.Images.IndexOfKey("spoon.png");
                    break;

                    case Pinwheel _:
                    lvi.ImageIndex = lureList.Images.IndexOfKey("vert.png");
                    break;

                    case Wobbler _:
                    lvi.ImageIndex = lureList.Images.IndexOfKey("vob.png");
                    break;

                    case Jig _:
                    lvi.ImageIndex = lureList.Images.IndexOfKey("vibro.png");
                    break;
                }

                luresView.Items.Add(lvi);
            }
            assembliesBox.DataSource = Player.GetPlayer().Assemblies;
        }

        public Road Road_P {
            get {
                try {
                    return Player.GetPlayer().RoadInv[roadsView.SelectedIndices[0]];
                }
                catch (ArgumentOutOfRangeException) { }

                return null;
            }
            set {
            }
        }

        public Reel Reel_P {
            get {
                try {
                    return Player.GetPlayer().ReelInv[ReelsList.SelectedIndex];
                }
                catch (ArgumentOutOfRangeException) { }

                return null;
            }
            set {
            }
        }

        public FLine FLine_P {
            get {
                try {
                    return Player.GetPlayer().FLineInv[FLineList.SelectedIndex];
                }
                catch (ArgumentOutOfRangeException) { }

                return null;
            }
            set {
            }
        }

        public Lure Lure_P {
            get {
                try {
                    return Player.GetPlayer().LureInv[luresView.SelectedIndices[0]];
                }
                catch (ArgumentOutOfRangeException) { }

                return null;
            }
            set {
            }
        }

        public Assembly Assembly_P {
            get {
                try {
                    return Player.GetPlayer().Assemblies[assembliesBox.SelectedIndex];
                }
                catch (ArgumentOutOfRangeException) { }

                return null;
            }
            set { }
        }

        public Bait Bait_P {
            get {
                try {
                    return Player.GetPlayer().BaitInv[baitsBox.SelectedIndex];
                }
                catch (ArgumentOutOfRangeException) { }

                return null;
            }
            set { }
        }

        public BaseHook Hook_P {
            get {
                try {
                    return Player.GetPlayer().HooksInv[hooksBox.SelectedIndex];
                }
                catch (ArgumentOutOfRangeException) { }

                return null;
            }
            set { }
        }

        public string RoadText { get => roadTextBox.Text; set => roadTextBox.Text = value; }
        public string ReelText { get => reelTextBox.Text; set => reelTextBox.Text = value; }
        public string FLineText { get => flineTextBox.Text; set => flineTextBox.Text = value; }
        public string LureText { get => lureTextBox.Text; set => lureTextBox.Text = value; }
        public BasePresenter Presenter { private get; set; }
        public string AssNumbText { get => assNumberLabel.Text; set => assNumberLabel.Text = value; }
        public int RoadWearValue { get => roadWearBar.Value; set => roadWearBar.Value = value; }
        public int ReelWearMax { get => reelWearBar.Maximum; set => reelWearBar.Maximum = value; }
        public int ReelWearValue { get => reelWearBar.Value; set => reelWearBar.Value = value; }

        public event EventHandler FLineSelectedIndexChanged;

        public event EventHandler RoadSelectedIndexChanged;

        public event EventHandler ReelSelectedIndexChanged;

        public event EventHandler LureSelectedIndexChanged;

        public event EventHandler FLineDoubleClick;

        public event EventHandler RoadDoubleClick;

        public event EventHandler ReelDoubleClick;

        public event EventHandler LureDoubleClick;

        public event EventHandler CloseButtonClick;

        public event EventHandler FetchButtonClick;

        public event EventHandler AssemblyDoubleClick;

        public event EventHandler MakeOutClick;

        public event EventHandler BaitDoubleClick;

        public event EventHandler BaitSelectedIndexChanged;

        public event EventHandler HookDoubleClick;

        public event EventHandler HookSelectedIndex;

        public event EventHandler RoadButtonsClick;

        private void RoadButtons_Click(object sender, EventArgs e) {
            RoadButtonsClick?.Invoke(sender, e);
        }

        private void RoadsList_SelectedIndexChanged(object sender, EventArgs e) {
            RoadSelectedIndexChanged?.Invoke(this, EventArgs.Empty);
        }

        private void FLineList_SelectedIndexChanged(object sender, EventArgs e) {
            FLineSelectedIndexChanged?.Invoke(this, EventArgs.Empty);
        }

        private void ReelsList_SelectedIndexChanged(object sender, EventArgs e) {
            ReelSelectedIndexChanged?.Invoke(this, EventArgs.Empty);
        }

        private void LuresList_SelectedIndexChanged(object sender, EventArgs e) {
            LureSelectedIndexChanged?.Invoke(this, EventArgs.Empty);
        }

        private void AssembliesBox_MouseDoubleClick(object sender, MouseEventArgs e) {
            AssemblyDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        private void LuresList_MouseDoubleClick(object sender, MouseEventArgs e) {
            LureDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        private void ReelsList_MouseDoubleClick(object sender, MouseEventArgs e) {
            ReelDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        private void FLineList_MouseDoubleClick(object sender, MouseEventArgs e) {
            FLineDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        private void CloseButton_Click(object sender, EventArgs e) {
            CloseButtonClick?.Invoke(this, EventArgs.Empty);
        }

        private void FetchButton_Click(object sender, EventArgs e) {
            FetchButtonClick?.Invoke(this, EventArgs.Empty);
        }

        private void MakeOutButton_Click(object sender, EventArgs e) {
            MakeOutClick?.Invoke(this, EventArgs.Empty);
        }

        private void AddButton_Click(object sender, EventArgs e) {
            var addPresenter = new AssemblyPresenter(new AddAssembly());
            addPresenter.Run();
        }

        private void BaitBox_Click(object sender, EventArgs e) {
            if (Player.GetPlayer().EquipedRoad.Assembly == null || Player.GetPlayer().EquipedRoad.IsBaitInWater) return;
            if (Player.GetPlayer().EquipedRoad.Assembly.FishBait is Lure) {
                var presenter = new SelectorPresenter<Lure>(new LureSelector<Lure>(Player.GetPlayer().LureInv), UI.Gui);
                presenter.Run();
            }
            if (!(Player.GetPlayer().EquipedRoad.Assembly.FishBait is Bait)) return;
            {
                var presenter = new SelectorPresenter<Bait>(new LureSelector<Bait>(Player.GetPlayer().BaitInv), UI.Gui);
                presenter.Run();
            }
        }

        private void RoadsView_SelectedIndexChanged(object sender, EventArgs e) {
            RoadSelectedIndexChanged?.Invoke(this, EventArgs.Empty);
        }

        private void RoadsView_MouseDoubleClick(object sender, MouseEventArgs e) {
            RoadDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        private void LuresView_SelectedIndexChanged(object sender, EventArgs e) {
            LureSelectedIndexChanged?.Invoke(this, EventArgs.Empty);
        }

        private void LuresView_MouseDoubleClick(object sender, MouseEventArgs e) {
            LureDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        private void BaitsBox_SelectedIndexChanged(object sender, EventArgs e) {
            BaitSelectedIndexChanged?.Invoke(this, EventArgs.Empty);
        }

        private void BaitsBox_MouseDoubleClick(object sender, MouseEventArgs e) {
            BaitDoubleClick?.Invoke(this, e);
        }

        private void HooksBox_SelectedIndexChanged(object sender, EventArgs e) {
            HookSelectedIndex?.Invoke(this, EventArgs.Empty);
        }

        private void HooksBox_MouseDoubleClick(object sender, MouseEventArgs e) {
            HookDoubleClick?.Invoke(this, e);
        }

        public void AddItemToRightView(Item item) {
            switch (Item.SelectItemType(item)) {
                case Road r:
                itemImageBox.BackgroundImage = r.Pict;
                nameBox.Text = r.Name;
                powerBox.Text = r.Power.ToString();
                typeBox.Text = r.GetType().ToString();
                break;

                case Reel r:
                itemImageBox.Image = r.Pict;
                nameBox.Text = r.Name;
                powerBox.Text = r.Power.ToString();
                typeBox.Text = "";
                break;

                case FLine fl:
                itemImageBox.Image = fl.Pict;
                nameBox.Text = fl.Name;
                powerBox.Text = fl.Power.ToString();
                typeBox.Text = "";
                break;

                case Lure l:
                itemImageBox.BackgroundImage = l.Pict;
                nameBox.Text = l.Name;
                powerBox.Text = "";
                typeBox.Text = "";
                break;

                case Bait b:
                itemImageBox.BackgroundImage = b.Pict;
                nameBox.Text = b.Name;
                powerBox.Text = b.Count.ToString();
                typeBox.Text = "";
                break;

                case BaseHook bk:
                itemImageBox.BackgroundImage = bk.Pict;
                nameBox.Text = bk.Name;
                powerBox.Text = bk.GatheringChance.ToString();
                typeBox.Text = "";
                break;
            }
        }

        public void ShowAssembly(Assembly ass)
        {
            if (ass == null) return;
            try {
                switch (ass.Road)
                {
                    case Spinning _:
                        assemblyType.Text = "Спиннинг";
                        break;
                    case Feeder _:
                        assemblyType.Text = "Фидер";
                        break;
                    case Float _:
                        assemblyType.Text = "Поплавок";
                        break;
                }

                RoadBox.BackgroundImage = ass.Road.Pict;
                ReelBox.BackgroundImage = ass.Reel.Pict;
                BaitBox.BackgroundImage = ass.FishBait.Pict;
                FLineBox.BackgroundImage = ass.FLine.Pict;
                RoadText = ass.Road.Name;
                ReelText = ass.Reel.Name;
                LureText = ass.FishBait.Name;
                FLineText = ass.FLine.Name;
            }
            catch (ArgumentOutOfRangeException) { }
            catch (NullReferenceException) { }
        }

        public void Open() {
            Show();
        }

        public void Down() {
            Close();
        }
    }
}