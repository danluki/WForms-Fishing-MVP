using Fishing.AbstractFish;
using Fishing.BL.Controller;
using Fishing.BL.Model.Baits;
using MapEditor.BL;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MapEditor.View.View {

    public partial class AddFishesForm : Form {
        private const int FishesMaxCount = 1000;
        private int _index;
        private readonly string _locName;

        public AddFishesForm(string locName) {
            InitializeComponent();
            GameLoader.GetLoader().IntializeLures();
            GameLoader.GetLoader().SetAllFishesName();
            baitsBox.DataSource = FishBait.FishBaits;
            foreach (var str in Fish.AllFishes.Keys) {
                fishesBox.Items.Add(str);
            }
            _locName = locName;
        }

        private void AddButton_Click(object sender, EventArgs e) {
            if (_index == FishesMaxCount) return;
            if (int.TryParse(maxDeepText.Text, out var maxD)) {
                if (int.TryParse(minDeepText.Text, out var minD)) {
                    if (minD < maxD) {
                        if (int.TryParse(countTextBox.Text, out var count)) {
                            if (count <= FishesMaxCount) //TODO Check For ComboBox
                            {
                                for (var i = 0; i < int.Parse(countTextBox.Text); i++) {
                                    fishesGridView.Rows.Add();
                                    fishesGridView["NameColumn", _index].Value = fishNameLabel.Text;
                                    fishesGridView["CountColumn", _index].Value = "1";
                                    fishesGridView["SizeColumn", _index].Value = sizeComboBox.Text;
                                    fishesGridView["MinDeepColumn", _index].Value = minDeepText.Text;
                                    fishesGridView["MaxDeepColumn", _index].Value = maxDeepText.Text;
                                    fishesGridView["BaitColumn", _index].Value = sizeComboBox.SelectedValue;
                                    var sb = new StringBuilder("[");
                                    foreach (var b in baitsBox.SelectedItems) {
                                        if (!b.Equals(baitsBox.SelectedItems[baitsBox.SelectedItems.Count - 1])) {
                                            sb.Append(b + ",");
                                        }
                                        else {
                                            sb.Append(b);
                                        }
                                        fishesGridView["BaitColumn", _index].Value = sb + "]";
                                    }
                                    _index++;
                                }
                                totalCountLabel.Text = $@"{_index} / {FishesMaxCount}";
                            }
                            else {
                                MessageBox.Show(Texts.FishesCountMustBeLessThanThousand);
                            }
                        }
                        else {
                            MessageBox.Show(Texts.FishesCountNeedToBeNumber);
                        }
                    }
                    else {
                        MessageBox.Show(Texts.MinDeepNeedToBeLowerThanMax);
                    }
                }
                else {
                    MessageBox.Show(Texts.DeepNeedToBeNumber);
                }
            }
            else {
                MessageBox.Show(Texts.DeepNeedToBeNumber);
            }
        }

        private void FishesBox_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (fishesBox.SelectedItem != null) {
                fishNameLabel.Text = fishesBox.SelectedItem.ToString();
            }
        }

        private void SaveButtonClick_Click(object sender, EventArgs e) {
            if (_index != FishesMaxCount) return;
            for (var i = 0; i < FishesMaxCount; i++) {
                var name = fishesGridView["NameColumn", i].Value;
                var size = fishesGridView["SizeColumn", i].Value;
                var mind = fishesGridView["MinDeepColumn", i].Value;
                var maxd = fishesGridView["MaxDeepColumn", i].Value;
                var baits = fishesGridView["BaitColumn", i].Value;
                var str = $@"{name}:{size} {mind}-{maxd} {baits}";
                Directory.CreateDirectory(CurrentWater.MInfo.WaterName);
                Directory.CreateDirectory($@"{CurrentWater.MInfo.WaterName}\{_locName}");
                File.AppendAllText($@"{CurrentWater.MInfo.WaterName}\{_locName}\Fisheslist", str + "\n");
            }
            Close();
        }
    }
}