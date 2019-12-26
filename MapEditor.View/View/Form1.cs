using MapEditor.BL;
using MapEditor.View.View;
using Saver.BL.Controller;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace MapEditor.View {

    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
        }

        private void FileToolStripMenuItem_Click(object sender, EventArgs e) {
        }

        private void CreateNewWaterToolStripMenuItem_Click(object sender, EventArgs e) {
            var mapForm = new NewMapForm();
            mapForm.Show();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e) {
            var saver = new SerializeDataSaver();
            File.WriteAllText(CurrentWater.MInfo.WaterName + "\\WaterInfo", CurrentWater.MInfo.WaterInfoString);
            CurrentWater.MInfo.BackImg.Save(CurrentWater.MInfo.WaterName + "\\MapImg.png", ImageFormat.Png);
            saver.Save(CurrentWater.MInfo.WaterName + "\\Map.dat", CurrentWater.MInfo.Locations);
            foreach (var loc in CurrentWater.MInfo.Locations) {
                Directory.CreateDirectory(CurrentWater.MInfo.WaterName + "\\" + loc.LocName);
            }
        }
    }
}