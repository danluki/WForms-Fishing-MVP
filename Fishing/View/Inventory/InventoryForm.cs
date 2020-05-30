using BrightIdeasSoftware;
using Fishing.BL.Model.Baits;
using Fishing.BL.Model.FeedingUp;
using Fishing.BL.Model.Game;
using Fishing.BL.Model.Game.Inventory;
using Fishing.BL.Model.Hooks;
using Fishing.BL.Model.Items;
using Fishing.BL.Presenter;
using Fishing.BL.View;
using Fishing.Presenter;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Fishing.View.Inventory {

    public partial class Inventory : Form, IInventory {
        private readonly Panel panel;
        private readonly Player _player = Game.GetGame().Player;

        public Inventory() {
            InitializeComponent();
            if (_player.FirstRod != null) {
                fRoadButton.Enabled = true;
            }
            if (_player.SecondRod != null) {
                sRoadButton.Enabled = true;
            }
            if (_player.ThirdRod != null) {
                tRoadButton.Enabled = true;
            }
            panel = new Panel {
                Width = 100,
                Height = 100,
                Left = PointToClient(Cursor.Position).X,
                Top = PointToClient(Cursor.Position).Y,
                BackColor = Color.Black
            };

        }

        public Rod Rod_P { get; set; }

        public Reel Reel_P { get; set; }

        public Fishingline FLine_P { get; set; }

        public Lure Lure_P { get; set; }

        public Item Item_P { get; set; }

        public BL.Model.Game.Assembly Assembly_P { get; set; }

        public Bait Bait_P { get; set; }

        public BaseHook Hook_P { get; set; }

        public InventoryPresenter Presenter { get; set; }
        public string RoadText { get => roadTextBox.Text; set => roadTextBox.Text = value; }
        public string ReelText { get => reelTextBox.Text; set => reelTextBox.Text = value; }
        public string FLineText { get => flineTextBox.Text; set => flineTextBox.Text = value; }
        public string LureText { get => lureTextBox.Text; set => lureTextBox.Text = value; }
        public string AssNumbText { get => assNumberLabel.Text; set => assNumberLabel.Text = value; }
        public int RoadWearValue { get => roadWearBar.Value; set => roadWearBar.Value = value; }
        public int ReelWearMax { get => reelWearBar.Maximum; set => reelWearBar.Maximum = value; }
        public int ReelWearValue { get => reelWearBar.Value; set => reelWearBar.Value = value; }
        public string HookBoxText { get => hookNameBox.Text; set => hookNameBox.Text = value; }

        public event EventHandler CloseButtonClick;

        public event EventHandler MakeOutClick;

        public event EventHandler RoadButtonsClick;


        public event Action InventoryLoaded;
        public event Action<InventoryItemType, Guid> ViewItemActivate;
        public event Action<Item> ViewItemDoubleClick;
        public event Action<BL.Model.Game.Assembly> ViewAssemblyItemDoubleClick;

        #region ProduceItems

        //Методы устанавливают входные коллекции нужным ObjectListView

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

        private void ProduceAssemblies(IEnumerable<BL.Model.Game.Assembly> assemblies) {
            AssembliesView.SetObjects(assemblies);
        }

        #endregion ProduceItems

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
            if (Game.GetGame().Player.EquipedRod.Assembly == null || Game.GetGame().Player.EquipedRod.IsBaitInWater) return;
            if (Game.GetGame().Player.EquipedRod.Assembly.FishBait is Lure) {
                //var presenter = new SelectorPresenter<Lure>(new LureSelector<Lure>(Game.GetGame().Player.LureInventory), UI.Gui);
                //presenter.Run();
            }
            if (!(Game.GetGame().Player.EquipedRod.Assembly.FishBait is Bait)) return;
            {
                //var presenter = new SelectorPresenter<Bait>(new LureSelector<Bait>(Game.GetGame().Player.BaitInventory), UI.Gui);
                //presenter.Run();
            }
        }

        #region ViewsClick


        #endregion ViewsClick

        private void ItemsTab_Click(object sender, EventArgs e) {
            if (Assembly_P != null) {
                if (Assembly_P.Rod.RodType == RodType.Spinning) {
                    BaitsView.Enabled = false;
                    LuresView.Enabled = true;
                    HooksView.Enabled = false;
                    Hook_P = null;
                }

                if (Assembly_P.Rod.RodType == RodType.Feeder ||
                    Assembly_P.Rod.RodType == RodType.Float) {
                    BaitsView.Enabled = true;
                    LuresView.Enabled = false;
                    HooksView.Enabled = true;
                }
            }
        }

        public void ShowItemInRightView(Item item) {
            switch (Item.SelectItemType(item)) {
                case Rod rod:
                ItemImageBox.BackgroundImage = rod.Picture;
                NameBox.Text = string.Format($"Удочка: {rod.Name}");
                PowerBox.Text = string.Format($"{rod.Power / 1000} кг. ");
                TypeBox.Text = string.Format($"Тип: {rod.RodType}");

                break;

                case Reel reel:
                ItemImageBox.BackgroundImage = reel.Picture;
                NameBox.Text = string.Format($"Катушка: {reel.Name}");
                PowerBox.Text = string.Format($"Мощность: {reel.Power}");
                TypeBox.Text = string.Empty;

                break;

                case Fishingline fline:
                ItemImageBox.BackgroundImage = fline.Picture;
                NameBox.Text = string.Format($"Леска: {fline.Name}");
                PowerBox.Text = string.Format($"Прочность: {fline.Power / 1000} кг.");
                TypeBox.Text = string.Empty;

                break;

                case Lure lure:
                ItemImageBox.BackgroundImage = lure.Picture;
                NameBox.Text = string.Format($"Приманка: {lure.Name}");
                PowerBox.Text = string.Format($"Глуб. проводки: {lure.DeepType}");
                TypeBox.Text = string.Format($"Размер: {lure.Size}");

                break;

                case Bait bait:
                ItemImageBox.BackgroundImage = bait.Picture;
                NameBox.Text = string.Format($"Наживка: {bait.Name}");
                PowerBox.Text = string.Format($"Кол-во: {bait.Count}");
                TypeBox.Text = string.Empty;

                break;

                case BaseHook bh:
                ItemImageBox.BackgroundImage = bh.Picture;
                NameBox.Text = string.Format($"Наживка: {bh.Name}");
                PowerBox.Text = string.Format($"Шанс схода: {bh.GatheringChance}");
                TypeBox.Text = string.Empty;
                break;

                default:
                ItemImageBox.BackgroundImage = item.Picture;
                NameBox.Text = string.Format($"Предмет: {item.Name}");
                break;
            }
        }

        public void ShowAssembly(BL.Model.Game.Assembly assembly) {
            if (assembly == null) return;
            assemblyType.Text = assembly.Rod?.RodType.ToString();
            RoadText = assembly.Rod?.Name;
            ReelText = assembly.Reel?.Name;
            LureText = assembly.FishBait?.Name;
            FLineText = assembly.Fline?.Name;
            hookNameBox.Text = assembly.Hook?.Name;

            RoadBox.BackgroundImage = assembly.Rod?.Picture;
            ReelBox.BackgroundImage = assembly.Reel?.Picture;
            BaitBox.BackgroundImage = assembly.FishBait?.Picture;
            FLineBox.BackgroundImage = assembly.Fline?.Picture;
            hookImageBox.BackgroundImage = assembly.Hook?.Picture;

            if (assembly.Rod != null)
                RoadWearValue = 1000 - assembly.Rod.Wear;
            if (assembly.Reel != null) 
                ReelWearValue = 1000 - assembly.Reel.Wear;
        }

        public void Open() {
            Show();
        }

        public void Down() {
            Close();
        }

        private void Inventory_Load(object sender, EventArgs e) {
            this.Presenter.ProduceFishinglines += ProduceFishinglines;
            this.Presenter.ProduceReels += ProduceReels;
            this.Presenter.ProduceLures += ProduceLures;
            this.Presenter.ProduceBaits += ProduceBaits;
            this.Presenter.ProduceHooks += ProduceHooks;
            this.Presenter.ProduceAssemblies += ProduceAssemblies;

            InventoryLoaded?.Invoke();
        }

        private void AssembliesView_MouseClick(object sender, MouseEventArgs e) {
            if (AssembliesView.SelectedObject != null) {
                ViewItemActivate?.Invoke(InventoryItemType.Assembly, ((Fishing.BL.Model.Game.Assembly)(sender as ObjectListView).SelectedObject).UniqueIdentifer);
            }
        }

        private void AssembliesView_MouseDoubleClick(object sender, MouseEventArgs e) {
            ViewAssemblyItemDoubleClick?.Invoke(Assembly_P);
        }

        private void FishinglinesView_MouseClick(object sender, MouseEventArgs e) {
            if (FishinglinesView.SelectedObject != null) {
                ViewItemActivate?.Invoke(InventoryItemType.Fishingline, ((Fishingline)(sender as ObjectListView).SelectedObject).UniqueIdentifer);
            }
        }

        private void FlinesView_MouseDoubleClick(object sender, MouseEventArgs e) {
            ViewItemDoubleClick?.Invoke(FLine_P);
        }

        private void ReelsView_MouseClick(object sender, MouseEventArgs e) {
            if (ReelsView.SelectedObject != null) {
                ViewItemActivate?.Invoke(InventoryItemType.Reel, ((Reel)(sender as ObjectListView).SelectedObject).UniqueIdentifer);
            }
        }
        private void ReelsView_MouseDoubleClick(object sender, MouseEventArgs e) {
            ViewItemDoubleClick?.Invoke(Reel_P);
        }

        private void LuresView_MouseClick(object sender, MouseEventArgs e) {
            if (LuresView.SelectedObject != null) {
                ViewItemActivate?.Invoke(InventoryItemType.Lure, ((Lure)(sender as ObjectListView).SelectedObject).UniqueIdentifer);
            }
        }
        private void LuresView_MouseDoubleClick(object sender, MouseEventArgs e) {
            ViewItemDoubleClick?.Invoke(Lure_P);
        }

        private void BaitsView_MouseClick(object sender, MouseEventArgs e) {
            if (BaitsView.SelectedObject != null) {
                ViewItemActivate?.Invoke(InventoryItemType.Bait, ((Bait)(sender as ObjectListView).SelectedObject).UniqueIdentifer);
            }
        }

        private void BaitsView_MouseDoubleClick(object sender, MouseEventArgs e) {
            ViewItemDoubleClick?.Invoke(Bait_P);
        }

        private void HooksView_MouseClick(object sender, MouseEventArgs e) {
            if (HooksView.SelectedObject != null) {
                ViewItemActivate?.Invoke(InventoryItemType.Hook, ((BaseHook)(sender as ObjectListView).SelectedObject).UniqueIdentifer);
            }
        }

        private void HooksView_MouseDoubleClick(object sender, MouseEventArgs e) {
            ViewItemDoubleClick?.Invoke(Hook_P);
        }
    }

}