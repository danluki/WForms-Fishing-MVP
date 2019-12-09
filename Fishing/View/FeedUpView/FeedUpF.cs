using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fishing.BL.Model.Game;

namespace Fishing.View.FeedUpView {
    public partial class FeedUpF : Form {
        public FeedUpF() {
            InitializeComponent();
            
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.BackgroundImage = FeedUpRes.exit_d;
        }

        private void CloseButton_MouseEnter(object sender, EventArgs e) {
            closeButton.BackgroundImage = FeedUpRes.exit_a;
        }
    }
}
