using Fishing.BL.Resources.Images;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fishing.BL;
using MapEditor.BL;

namespace MapEditor.View {
    public partial class CreateLocationForm : Form
    {
        private readonly WaterForm _form;
        public CreateLocationForm(WaterForm form) {
            InitializeComponent();
            _form = form;
            Text = form.name;
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            var box = new PictureBox()
            {
                BackgroundImage = Images.blackkrug,
                Height = 25,
                Width = 25,
                Tag = locNameBox.Text,
                Left = 0,
                Top = 0,
                BackColor = Color.Transparent,
                Text = percentNumUpDown.Value.ToString(CultureInfo.InvariantCulture)
            };
            box.Click += (o, args) =>
            {
                var b = _form.SelectedBox;
                if (b != null) {
                    b.BackgroundImage = Images.blackkrug;
                }
                _form.SelectedBox = box;
                box.BackgroundImage = Images.blackkrug_act; ;
            };
            _form.mapPictureBox.Controls.Add(box);
        }
    }
}
