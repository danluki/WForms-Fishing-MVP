using Fishing.BL.Model.FeedingUp;
using Fishing.BL.Model.Game;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fishing.View.FeedUpView {

    public partial class FeedUpF : Form {
        private readonly Player _player = Game.GetGame().Player;

        public FeedUpF() {
            InitializeComponent();
            //aromaListsBox.DataSource = _player.AromaInventory;
            //feedsUpBox.DataSource = _player.BasicInventory;
           // baitsListBox.DataSource = _player.BaitInventory;
            //feedUpsBox.DataSource = _player.FeedUpInventory;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e) {
            closeButton.BackgroundImage = FeedUpRes.exit_d;
        }

        private void CloseButton_MouseEnter(object sender, EventArgs e) {
            closeButton.BackgroundImage = FeedUpRes.exit_a;
        }

        private void CreateButton_Click(object sender, EventArgs e) {
            if (curFeedUpAromasBox.Items.Count == curFeedUpBasic.Items.Count) {
                //var basic = _player.GetBasicByName(curFeedUpBasic.Items[0]?.ToString());
                //var aroma = _player.GetAromaByName(curFeedUpAromasBox.Items[0]?.ToString());
                //var bait = _player.GetBaitByName(curFeedUpBaitBox.Items[0]?.ToString());
               // var feedUp = new Feedup(basic, aroma, bait, new Dictionary<Type, int>());
                //if (feedUp.Create()) {
                   // _player.FeedUpInventory.Add(feedUp);
                //}
            }
        }

        private void closeButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void feedsUpBox_MouseDoubleClick(object sender, MouseEventArgs e) {
            curFeedUpBasic.Items.Add(feedsUpBox.SelectedItem.ToString());
        }

        private void aromaListsBox_MouseDoubleClick(object sender, MouseEventArgs e) {
            curFeedUpAromasBox.Items.Add(aromaListsBox.SelectedItem.ToString());
        }

        private void baitsListBox_MouseDoubleClick(object sender, MouseEventArgs e) {
            curFeedUpBaitBox.Items.Add(baitsListBox.SelectedItem.ToString());
        }

        private void feedUpsBox_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (feedUpsBox.SelectedItem != null) {
                //_player.EquipedFeedUp = _player.GetFeedUpByName(feedUpsBox.SelectedItem.ToString());
            }
        }
    }
}