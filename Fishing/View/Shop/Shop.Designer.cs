using Fishing.BL;
using Fishing.BL.Resources.Images;

namespace Fishing
{
    partial class Shop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shop));
            this.itemBox = new System.Windows.Forms.PictureBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.powerBox = new System.Windows.Forms.TextBox();
            this.priceBox = new System.Windows.Forms.TextBox();
            this.typeBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.moneyBox = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.hooksPage = new System.Windows.Forms.TabPage();
            this.hookList = new System.Windows.Forms.ListBox();
            this.baitsPage = new System.Windows.Forms.TabPage();
            this.baitsList = new System.Windows.Forms.ListBox();
            this.lurePage = new System.Windows.Forms.TabPage();
            this.lureBox = new System.Windows.Forms.ListBox();
            this.ReelsPage = new System.Windows.Forms.TabPage();
            this.ReelsList = new System.Windows.Forms.ListBox();
            this.FLinePage = new System.Windows.Forms.TabPage();
            this.FLineList = new System.Windows.Forms.ListBox();
            this.RoadPage = new System.Windows.Forms.TabPage();
            this.RoadsList = new System.Windows.Forms.ListBox();
            this.shopTab = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.itemBox)).BeginInit();
            this.hooksPage.SuspendLayout();
            this.baitsPage.SuspendLayout();
            this.lurePage.SuspendLayout();
            this.ReelsPage.SuspendLayout();
            this.FLinePage.SuspendLayout();
            this.RoadPage.SuspendLayout();
            this.shopTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemBox
            // 
            this.itemBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.itemBox.Location = new System.Drawing.Point(524, 57);
            this.itemBox.Name = "itemBox";
            this.itemBox.Size = new System.Drawing.Size(232, 214);
            this.itemBox.TabIndex = 11;
            this.itemBox.TabStop = false;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(576, 287);
            this.nameBox.Name = "nameBox";
            this.nameBox.ReadOnly = true;
            this.nameBox.Size = new System.Drawing.Size(180, 20);
            this.nameBox.TabIndex = 12;
            // 
            // powerBox
            // 
            this.powerBox.Location = new System.Drawing.Point(576, 313);
            this.powerBox.Name = "powerBox";
            this.powerBox.ReadOnly = true;
            this.powerBox.Size = new System.Drawing.Size(180, 20);
            this.powerBox.TabIndex = 13;
            // 
            // priceBox
            // 
            this.priceBox.Location = new System.Drawing.Point(576, 339);
            this.priceBox.Name = "priceBox";
            this.priceBox.ReadOnly = true;
            this.priceBox.Size = new System.Drawing.Size(180, 20);
            this.priceBox.TabIndex = 14;
            // 
            // typeBox
            // 
            this.typeBox.Location = new System.Drawing.Point(576, 365);
            this.typeBox.Name = "typeBox";
            this.typeBox.ReadOnly = true;
            this.typeBox.Size = new System.Drawing.Size(180, 20);
            this.typeBox.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(664, 561);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 18;
            // 
            // moneyBox
            // 
            this.moneyBox.Location = new System.Drawing.Point(555, 31);
            this.moneyBox.Name = "moneyBox";
            this.moneyBox.Size = new System.Drawing.Size(162, 20);
            this.moneyBox.TabIndex = 20;
            this.moneyBox.Text = "Деньги:";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(723, 26);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(33, 23);
            this.closeButton.TabIndex = 23;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // hooksPage
            // 
            this.hooksPage.Controls.Add(this.hookList);
            this.hooksPage.Location = new System.Drawing.Point(4, 22);
            this.hooksPage.Name = "hooksPage";
            this.hooksPage.Padding = new System.Windows.Forms.Padding(3);
            this.hooksPage.Size = new System.Drawing.Size(457, 425);
            this.hooksPage.TabIndex = 6;
            this.hooksPage.Text = "Крючки";
            this.hooksPage.UseVisualStyleBackColor = true;
            // 
            // hookList
            // 
            this.hookList.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.hookList.FormattingEnabled = true;
            this.hookList.ItemHeight = 22;
            this.hookList.Location = new System.Drawing.Point(-4, -2);
            this.hookList.Name = "hookList";
            this.hookList.Size = new System.Drawing.Size(461, 422);
            this.hookList.TabIndex = 0;
            this.hookList.SelectedIndexChanged += new System.EventHandler(this.HookList_SelectedIndexChanged);
            this.hookList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.HookList_MouseDoubleClick);
            // 
            // baitsPage
            // 
            this.baitsPage.Controls.Add(this.baitsList);
            this.baitsPage.Location = new System.Drawing.Point(4, 22);
            this.baitsPage.Name = "baitsPage";
            this.baitsPage.Padding = new System.Windows.Forms.Padding(3);
            this.baitsPage.Size = new System.Drawing.Size(457, 425);
            this.baitsPage.TabIndex = 5;
            this.baitsPage.Text = "Наживка";
            this.baitsPage.UseVisualStyleBackColor = true;
            // 
            // baitsList
            // 
            this.baitsList.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.baitsList.FormattingEnabled = true;
            this.baitsList.ItemHeight = 22;
            this.baitsList.Location = new System.Drawing.Point(0, 0);
            this.baitsList.Name = "baitsList";
            this.baitsList.Size = new System.Drawing.Size(454, 422);
            this.baitsList.TabIndex = 21;
            this.baitsList.SelectedIndexChanged += new System.EventHandler(this.BaitsList_SelectedIndexChanged);
            this.baitsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.BaitsList_MouseDoubleClick);
            // 
            // lurePage
            // 
            this.lurePage.Controls.Add(this.lureBox);
            this.lurePage.Location = new System.Drawing.Point(4, 22);
            this.lurePage.Name = "lurePage";
            this.lurePage.Padding = new System.Windows.Forms.Padding(3);
            this.lurePage.Size = new System.Drawing.Size(457, 425);
            this.lurePage.TabIndex = 4;
            this.lurePage.Text = "Приманки";
            this.lurePage.UseVisualStyleBackColor = true;
            // 
            // lureBox
            // 
            this.lureBox.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.lureBox.FormattingEnabled = true;
            this.lureBox.ItemHeight = 22;
            this.lureBox.Location = new System.Drawing.Point(0, 0);
            this.lureBox.Name = "lureBox";
            this.lureBox.Size = new System.Drawing.Size(454, 422);
            this.lureBox.TabIndex = 0;
            this.lureBox.SelectedIndexChanged += new System.EventHandler(this.LureBox_SelectedIndexChanged);
            this.lureBox.DoubleClick += new System.EventHandler(this.LureBox_DoubleClick);
            // 
            // ReelsPage
            // 
            this.ReelsPage.Controls.Add(this.ReelsList);
            this.ReelsPage.Location = new System.Drawing.Point(4, 22);
            this.ReelsPage.Name = "ReelsPage";
            this.ReelsPage.Padding = new System.Windows.Forms.Padding(3);
            this.ReelsPage.Size = new System.Drawing.Size(457, 425);
            this.ReelsPage.TabIndex = 2;
            this.ReelsPage.Text = "Катушки";
            this.ReelsPage.UseVisualStyleBackColor = true;
            // 
            // ReelsList
            // 
            this.ReelsList.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.ReelsList.FormattingEnabled = true;
            this.ReelsList.ItemHeight = 22;
            this.ReelsList.Location = new System.Drawing.Point(0, 0);
            this.ReelsList.Name = "ReelsList";
            this.ReelsList.Size = new System.Drawing.Size(498, 444);
            this.ReelsList.TabIndex = 17;
            this.ReelsList.SelectedIndexChanged += new System.EventHandler(this.ReelsList_SelectedIndexChanged);
            this.ReelsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ReelsList_MouseDoubleClick);
            // 
            // FLinePage
            // 
            this.FLinePage.Controls.Add(this.FLineList);
            this.FLinePage.Location = new System.Drawing.Point(4, 22);
            this.FLinePage.Name = "FLinePage";
            this.FLinePage.Padding = new System.Windows.Forms.Padding(3);
            this.FLinePage.Size = new System.Drawing.Size(457, 425);
            this.FLinePage.TabIndex = 1;
            this.FLinePage.Text = "Леска";
            this.FLinePage.UseVisualStyleBackColor = true;
            // 
            // FLineList
            // 
            this.FLineList.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.FLineList.FormattingEnabled = true;
            this.FLineList.ItemHeight = 22;
            this.FLineList.Location = new System.Drawing.Point(0, 0);
            this.FLineList.Name = "FLineList";
            this.FLineList.Size = new System.Drawing.Size(461, 422);
            this.FLineList.TabIndex = 19;
            this.FLineList.SelectedIndexChanged += new System.EventHandler(this.FLineList_SelectedIndexChanged);
            this.FLineList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FLineList_MouseDoubleClick);
            // 
            // RoadPage
            // 
            this.RoadPage.Controls.Add(this.RoadsList);
            this.RoadPage.Location = new System.Drawing.Point(4, 22);
            this.RoadPage.Name = "RoadPage";
            this.RoadPage.Padding = new System.Windows.Forms.Padding(3);
            this.RoadPage.Size = new System.Drawing.Size(457, 425);
            this.RoadPage.TabIndex = 0;
            this.RoadPage.Text = "Удочки";
            this.RoadPage.UseVisualStyleBackColor = true;
            // 
            // RoadsList
            // 
            this.RoadsList.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RoadsList.FormattingEnabled = true;
            this.RoadsList.ItemHeight = 22;
            this.RoadsList.Location = new System.Drawing.Point(0, 0);
            this.RoadsList.Name = "RoadsList";
            this.RoadsList.Size = new System.Drawing.Size(454, 422);
            this.RoadsList.TabIndex = 0;
            this.RoadsList.SelectedIndexChanged += new System.EventHandler(this.RoadsList_SelectedIndexChanged_1);
            this.RoadsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RoadsList_MouseDoubleClick_1);
            // 
            // shopTab
            // 
            this.shopTab.Controls.Add(this.RoadPage);
            this.shopTab.Controls.Add(this.FLinePage);
            this.shopTab.Controls.Add(this.ReelsPage);
            this.shopTab.Controls.Add(this.lurePage);
            this.shopTab.Controls.Add(this.baitsPage);
            this.shopTab.Controls.Add(this.hooksPage);
            this.shopTab.Location = new System.Drawing.Point(53, 37);
            this.shopTab.Name = "shopTab";
            this.shopTab.SelectedIndex = 0;
            this.shopTab.Size = new System.Drawing.Size(465, 451);
            this.shopTab.TabIndex = 22;
            // 
            // Shop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 612);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.shopTab);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.priceBox);
            this.Controls.Add(this.powerBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.itemBox);
            this.Controls.Add(this.moneyBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Shop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Продукты";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.itemBox)).EndInit();
            this.hooksPage.ResumeLayout(false);
            this.baitsPage.ResumeLayout(false);
            this.lurePage.ResumeLayout(false);
            this.ReelsPage.ResumeLayout(false);
            this.FLinePage.ResumeLayout(false);
            this.RoadPage.ResumeLayout(false);
            this.shopTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected internal System.Windows.Forms.PictureBox itemBox;
        protected internal System.Windows.Forms.TextBox nameBox;
        protected internal System.Windows.Forms.TextBox powerBox;
        protected internal System.Windows.Forms.TextBox priceBox;
        protected internal System.Windows.Forms.TextBox typeBox;
        protected internal System.Windows.Forms.TextBox moneyBox;
        protected internal System.Windows.Forms.Button closeButton;
        protected internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage hooksPage;
        private System.Windows.Forms.ListBox hookList;
        private System.Windows.Forms.TabPage baitsPage;
        private System.Windows.Forms.ListBox baitsList;
        private System.Windows.Forms.TabPage lurePage;
        private System.Windows.Forms.ListBox lureBox;
        private System.Windows.Forms.TabPage ReelsPage;
        protected internal System.Windows.Forms.ListBox ReelsList;
        private System.Windows.Forms.TabPage FLinePage;
        protected internal System.Windows.Forms.ListBox FLineList;
        private System.Windows.Forms.TabPage RoadPage;
        protected internal System.Windows.Forms.ListBox RoadsList;
        private System.Windows.Forms.TabControl shopTab;
    }
}