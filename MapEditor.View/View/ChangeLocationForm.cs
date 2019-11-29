using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fishing.BL;
using Fishing.BL.Model.Waters;
using MapEditor.BL;
using MapEditor.View.View;
using Saver.BL.Controller;

namespace MapEditor.View {
    public partial class ChangeLocationForm : Form
    {
        private bool _isSetsDeepMode;
        private bool _isLeftButtonPressed;
        private int _labelsStartX;
        private int _labelsStartY;
        private int _labelsEndX;
        private int _labelsEndY;
        private int _labelXCount;
        private int _labelYCount;
        private Label[,] _deepArray;
        private readonly PictureBox box;
        public ChangeLocationForm(PictureBox locationBox) {
            InitializeComponent();
            Text += locationBox.Tag.ToString();
            box = locationBox;
            nameTextBox.Text = locationBox.Tag.ToString();
            nibbleComboBox.ValueMember = locationBox.Tag.ToString();

        }

        private void UploadImageButton_Click(object sender, EventArgs e) {
            var dia = new OpenFileDialog {
                Filter = "Joint Photographic Experts Group .jpg|*.jpg;|Portable Network Graphics .png| *.png |Bitmap Picture .bmp| *.bmp"
            };
            if (dia.ShowDialog() != DialogResult.OK) return;

            locationImageBox.BackgroundImage = Image.FromFile(dia.FileName);
            CurrentWater.MInfo.BackImg = locationImageBox.BackgroundImage;
        }

        private void SetDeepsButton_Click(object sender, EventArgs e)
        {
            locationImageBox.Cursor = Cursors.Cross;
            _isSetsDeepMode = true;
        }


        private void LocationImageBox_MouseMove(object sender, MouseEventArgs e) {
            locationImageBox.Refresh();
        }

        private void LocationImageBox_MouseUp(object sender, MouseEventArgs e) {
            if (!_isSetsDeepMode) return;
            if (e.Button != MouseButtons.Left) return;
            _isLeftButtonPressed = false;
            _labelsEndX = PointToClient(Cursor.Position).X;
            _labelsEndY = PointToClient(Cursor.Position).Y;
            _labelXCount = (_labelsEndX - _labelsStartX) / 40;
            _labelYCount = (_labelsEndY - _labelsStartY) / 23;
            _deepArray = new Label[_labelXCount, _labelYCount];
            for (var y = 0; y < _labelYCount; y++)
            {
                for (var x = 0; x < _labelXCount; x++)
                {
                    _deepArray[x, y] = new Label() {
                        Left = _labelsStartX + 5 + x * 40,
                        Top = _labelsStartY + y * 23,
                        Height = 23,
                        TextAlign = ContentAlignment.MiddleLeft,
                        ForeColor = Color.White,
                        Width = 40,
                        Visible = true,
                        Font = new Font("Arial", 8, FontStyle.Regular),
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = Color.Transparent
                    };
                    _deepArray[x, y].Click += (o, args) =>
                    {
                        var r = new Rectangle(((Label) o).Location, new Size(40, 23));
                        if (r.IntersectsWith(new Rectangle(PointToClient(Cursor.Position), new Size(1, 1))))
                        {
                            if (setDeepButton.Checked)
                            {
                                int.TryParse(deepTextBox.Text, out var res);
                                ((Label)o).Text = res.ToString();
                            }

                            if (setSnagButton.Checked)
                            {
                                ((Label)o).Tag = 1;
                                ((Label)o).BackColor = Color.Black;
                            }
                        }
                    };
                    locationImageBox.Controls.Add(_deepArray[x, y]);
                }
            }

        }

        private void LocationImageBox_MouseDown(object sender, MouseEventArgs e) {
            if (!_isSetsDeepMode) return;
            if (e.Button != MouseButtons.Left) return;
            _isLeftButtonPressed = true;
            _labelsStartX = PointToClient(Cursor.Position).X;
            _labelsStartY = PointToClient(Cursor.Position).Y;
        }

        private void LocationImageBox_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            if(!_isSetsDeepMode) return;
            if (!_isLeftButtonPressed) return;
            g.DrawRectangle(
                new Pen(Color.Yellow), 
                x: _labelsStartX, y: _labelsStartY, 
                PointToClient(Cursor.Position).X - _labelsStartX,
                PointToClient(Cursor.Position).Y - _labelsStartY 
                );
        }

        private void AddFishesButton_Click(object sender, EventArgs e)
        {
            var form = new AddFishesForm(nameTextBox.Text);
            form.Show();
        }

        private void GenerateButtonClick_Click(object sender, EventArgs e)
        {
            var rand = new Random();
            if (!int.TryParse(minDeepTextBox.Text, out var minDeep)) return;
            if (!int.TryParse(maxDeepTextBox.Text, out var maxDeep)) return;
            if (!int.TryParse(filterComboBox.SelectedItem.ToString(), out var filter)) return;
            if(_deepArray == null) return;
            for (var y = 0; y < _labelYCount; y++)
            {
                for (var x = 0; x < _labelXCount; x++)
                {
                    _deepArray[x, y].Text = y <= _labelYCount / 2 ? rand.Next(maxDeep - filter, maxDeep).ToString() : rand.Next(minDeep, minDeep + filter).ToString();
                    _deepArray[x, y].Tag = "0";
                }
            }

            
        }

        private void SaveButton_Click(object sender, EventArgs e) {
            var saver = new SerializeDataSaver();
            CurrentWater.MInfo.Locations.Add((PicturesBoxInfo)box);
            var lInfos = new LabelInfo[_labelXCount, _labelYCount];
            if (_deepArray == null) return;
            saveButton.Enabled = false;
            for (var y = 0; y < _labelYCount; y++)
            {
                for (var x = 0; x < _labelXCount; x++)
                {
                    lInfos[x, y] = (LabelInfo)_deepArray[x, y];
                }
            }
            saver.Save(CurrentWater.MInfo.WaterName + "\\" + nameTextBox.Text + "\\DeepField.dat", lInfos);
            var str = _labelXCount + " " + _labelYCount + " " + _labelsStartX + " " + _labelsStartY;
            File.WriteAllText(CurrentWater.MInfo.WaterName + "\\" + nameTextBox.Text + "\\LVLInfo", str);
            this.Close();
        }
    }
}
