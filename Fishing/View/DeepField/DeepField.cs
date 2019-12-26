using Fishing.BL.Model.LVLS;
using Fishing.BL.Presenter;
using Fishing.BL.View;
using System.Windows.Forms;

namespace Fishing.View.DeepField {

    public partial class DeepField : Form, IDeepField {

        public DeepField(Lvl lvl) {
            InitializeComponent();
            for (var y = 0; y < lvl.Height; y++) {
                for (var x = 0; x < lvl.Widgth; x++) {
                    Controls.Add(lvl.DeepArray[x, y]);
                }
            }
        }

        public BasePresenter Presenter { get; set; }

        public void Down() {
            Close();
        }

        public void Open() {
            Show();
        }
    }
}