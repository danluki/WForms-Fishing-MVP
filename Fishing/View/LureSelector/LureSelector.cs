using Fishing.BL.Model.Baits;
using Fishing.BL.Presenter;
using Fishing.View.LureSelector.View;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Fishing.View.LureSelector {

    public partial class LureSelector<T> : Form, ISelector<T>
        where T : FishBait {
        private readonly BindingList<T> List;

        public LureSelector(BindingList<T> list) {
            InitializeComponent();
            List = list;
            lureList.DataSource = list;
        }

        public Image Picture { get => lureImage.BackgroundImage; set => lureImage.BackgroundImage = FishBait.Picture; }
        public string DeepBoxText { get => deepBox.Text; set => deepBox.Text = value; }
        public string SizeBoxText { get => sizeBox.Text; set => sizeBox.Text = value; }
        public SelectorPresenter<T> Presenter { get; set; }
        public T FishBait { get => List[lureList.SelectedIndex]; set => throw new NotImplementedException(); }

        public event EventHandler LureListIndexChanged;

        public event EventHandler LureListDoubleClick;

        private void LureList_SelectedIndexChanged(object sender, EventArgs e) {
            LureListIndexChanged?.Invoke(this, EventArgs.Empty);
        }

        private void LureList_MouseDoubleClick(object sender, MouseEventArgs e) {
            LureListDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        public void Open() {
            if (this != null) {
                this.Show();
            }
        }

        public void Down() {
            if (this != null) {
                this.Close();
            }
        }
    }
}