using System.Windows.Forms;

namespace Fishing.View.ItemShower {
    public partial class ItemShower : Form {
        public ItemShower() {
            InitializeComponent();
            Location = PointToClient(Cursor.Position);
        }
    }
}