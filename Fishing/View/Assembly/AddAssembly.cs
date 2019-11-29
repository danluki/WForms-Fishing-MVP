using Fishing.Presenter;
using System;
using System.Windows.Forms;
using Fishing.BL.Presenter;

namespace Fishing.View.Assembly {
    public partial class AddAssembly : Form, IAddAssembly {
        public AddAssembly() {
            InitializeComponent();
        }

        public string AssemblyName { get => nameBox.Text; set => nameBox.Text = value; }
        public BasePresenter Presenter { private get; set; }

        public event EventHandler AddAssemblyClick;

        private void Add_Click(object sender, EventArgs e) {
            AddAssemblyClick?.Invoke(this, EventArgs.Empty);
            Down();
        }

        public void Open() {
            this.Show();
        }

        public void Down() {
            this.Close();
        }
    }
}