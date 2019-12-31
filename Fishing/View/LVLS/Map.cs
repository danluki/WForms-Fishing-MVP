using Fishing.BL.Model.Game;
using Fishing.BL.Model.LVLS;
using Fishing.BL.Resources.Images;
using Fishing.BL.View;
using Fishing.Presenter;
using Fishing.View.DeepField;
using Fishing.View.LVLS;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fishing {

    public partial class Map : Form, IMap {
        public static GameForm ozero;
        public Image BackImage { get => BackgroundImage; set => BackgroundImage = value; }
        public Map() {
            InitializeComponent();
            BackgroundImage = Game.GetGame().CurrentWater.MapImage;
            foreach (var p in Game.GetGame().CurrentWater.Locations) {
                PictureBox box = new PictureBox() {
                    Left = p.Left,
                    Top = p.Top,
                    Width = p.Width,
                    Height = p.Height,
                    BackgroundImage = Images.blackkrug,
                    BackColor = Color.Transparent,
                    BackgroundImageLayout = ImageLayout.Stretch,
                    Tag = p.LocName,
                    BorderStyle = BorderStyle.None,
                };
                box.Click += Box_Click;
                Controls.Add(box);
            }
        }

        private void Box_Click(object sender, EventArgs e) {
            var lvlrealisation = new Lvl();
            lvlrealisation.GetLVLData((sender as PictureBox).Tag.ToString());
            Create(lvlrealisation);
        }

        public void Open() {
            Show();
        }

        public void Down() {
            Close();
        }

        public void Create(Lvl lvl) {
            UI.Gui = new UI(lvl);
            Game.GetGame().View = new GameForm();
            var presenter = new LvlPresenter(Game.GetGame().View, UI.Gui, lvl);
            presenter.Run();
            new DeepField(lvl);
            UI.Gui.Show();
            Close();
        }

        private void CloseButton_Click(object sender, EventArgs e) {
            Close();
        }
    }
}