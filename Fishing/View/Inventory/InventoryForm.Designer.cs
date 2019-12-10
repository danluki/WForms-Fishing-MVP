namespace Fishing.View.Inventory
{
    partial class Inventory
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventory));
            this.BaitBox = new System.Windows.Forms.PictureBox();
            this.FLineBox = new System.Windows.Forms.PictureBox();
            this.ReelBox = new System.Windows.Forms.PictureBox();
            this.RoadBox = new System.Windows.Forms.PictureBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.powerBox = new System.Windows.Forms.TextBox();
            this.typeBox = new System.Windows.Forms.TextBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.lureList = new System.Windows.Forms.ImageList(this.components);
            this.roadsList = new System.Windows.Forms.ImageList(this.components);
            this.roadTextBox = new System.Windows.Forms.TextBox();
            this.reelTextBox = new System.Windows.Forms.TextBox();
            this.flineTextBox = new System.Windows.Forms.TextBox();
            this.lureTextBox = new System.Windows.Forms.TextBox();
            this.makeOutButton = new System.Windows.Forms.Button();
            this.fRoadButton = new System.Windows.Forms.Button();
            this.sRoadButton = new System.Windows.Forms.Button();
            this.tRoadButton = new System.Windows.Forms.Button();
            this.assemblyPanel = new System.Windows.Forms.Panel();
            this.assNumberLabel = new System.Windows.Forms.Label();
            this.assemblyType = new System.Windows.Forms.TextBox();
            this.itemImageBox = new System.Windows.Forms.PictureBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.hooksBox = new System.Windows.Forms.ListBox();
            this.baitPage = new System.Windows.Forms.TabPage();
            this.baitsBox = new System.Windows.Forms.ListBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.assembliesBox = new BrightIdeasSoftware.ObjectListView();
            this.roadNameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.countBox = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.luresView = new System.Windows.Forms.ListView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ReelsList = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.FLineList = new System.Windows.Forms.ListBox();
            this.ItemsTab = new System.Windows.Forms.TabControl();
            this.powerColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.typeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.hookImageBox = new System.Windows.Forms.PictureBox();
            this.hookNamneBox = new System.Windows.Forms.TextBox();
            this.reelWearBar = new VerticalProgressBar.VerticalProgressBar();
            this.roadWearBar = new VerticalProgressBar.VerticalProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.BaitBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FLineBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReelBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoadBox)).BeginInit();
            this.assemblyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemImageBox)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.baitPage.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.assembliesBox)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.ItemsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hookImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // BaitBox
            // 
            this.BaitBox.BackColor = System.Drawing.Color.Transparent;
            this.BaitBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BaitBox.Location = new System.Drawing.Point(163, 312);
            this.BaitBox.Name = "BaitBox";
            this.BaitBox.Size = new System.Drawing.Size(100, 64);
            this.BaitBox.TabIndex = 3;
            this.BaitBox.TabStop = false;
            this.BaitBox.Click += new System.EventHandler(this.BaitBox_Click);
            // 
            // FLineBox
            // 
            this.FLineBox.BackColor = System.Drawing.Color.Transparent;
            this.FLineBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FLineBox.BackgroundImage")));
            this.FLineBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FLineBox.Location = new System.Drawing.Point(163, 214);
            this.FLineBox.Name = "FLineBox";
            this.FLineBox.Size = new System.Drawing.Size(100, 66);
            this.FLineBox.TabIndex = 2;
            this.FLineBox.TabStop = false;
            // 
            // ReelBox
            // 
            this.ReelBox.BackColor = System.Drawing.Color.Transparent;
            this.ReelBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ReelBox.BackgroundImage")));
            this.ReelBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ReelBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("ReelBox.InitialImage")));
            this.ReelBox.Location = new System.Drawing.Point(141, 3);
            this.ReelBox.Name = "ReelBox";
            this.ReelBox.Size = new System.Drawing.Size(91, 101);
            this.ReelBox.TabIndex = 1;
            this.ReelBox.TabStop = false;
            // 
            // RoadBox
            // 
            this.RoadBox.BackColor = System.Drawing.Color.Transparent;
            this.RoadBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RoadBox.Location = new System.Drawing.Point(6, 3);
            this.RoadBox.Name = "RoadBox";
            this.RoadBox.Size = new System.Drawing.Size(97, 251);
            this.RoadBox.TabIndex = 0;
            this.RoadBox.TabStop = false;
            // 
            // nameBox
            // 
            this.nameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nameBox.Location = new System.Drawing.Point(377, 611);
            this.nameBox.Name = "nameBox";
            this.nameBox.ReadOnly = true;
            this.nameBox.Size = new System.Drawing.Size(110, 20);
            this.nameBox.TabIndex = 13;
            // 
            // powerBox
            // 
            this.powerBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.powerBox.Location = new System.Drawing.Point(377, 559);
            this.powerBox.Name = "powerBox";
            this.powerBox.ReadOnly = true;
            this.powerBox.Size = new System.Drawing.Size(110, 20);
            this.powerBox.TabIndex = 14;
            // 
            // typeBox
            // 
            this.typeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.typeBox.Location = new System.Drawing.Point(377, 585);
            this.typeBox.Name = "typeBox";
            this.typeBox.ReadOnly = true;
            this.typeBox.Size = new System.Drawing.Size(110, 20);
            this.typeBox.TabIndex = 16;
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.Location = new System.Drawing.Point(637, 608);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(33, 23);
            this.CloseButton.TabIndex = 24;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // lureList
            // 
            this.lureList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("lureList.ImageStream")));
            this.lureList.TransparentColor = System.Drawing.Color.Transparent;
            this.lureList.Images.SetKeyName(0, "vob.png");
            this.lureList.Images.SetKeyName(1, "vibro.png");
            this.lureList.Images.SetKeyName(2, "vert.png");
            this.lureList.Images.SetKeyName(3, "spoon.png");
            // 
            // roadsList
            // 
            this.roadsList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("roadsList.ImageStream")));
            this.roadsList.TransparentColor = System.Drawing.Color.Transparent;
            this.roadsList.Images.SetKeyName(0, "rm_but01.png");
            this.roadsList.Images.SetKeyName(1, "shop_but01.png");
            this.roadsList.Images.SetKeyName(2, "shop_but02.png");
            // 
            // roadTextBox
            // 
            this.roadTextBox.Location = new System.Drawing.Point(3, 260);
            this.roadTextBox.Name = "roadTextBox";
            this.roadTextBox.Size = new System.Drawing.Size(100, 20);
            this.roadTextBox.TabIndex = 28;
            // 
            // reelTextBox
            // 
            this.reelTextBox.Location = new System.Drawing.Point(141, 174);
            this.reelTextBox.Name = "reelTextBox";
            this.reelTextBox.Size = new System.Drawing.Size(91, 20);
            this.reelTextBox.TabIndex = 29;
            // 
            // flineTextBox
            // 
            this.flineTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flineTextBox.Location = new System.Drawing.Point(163, 286);
            this.flineTextBox.Name = "flineTextBox";
            this.flineTextBox.Size = new System.Drawing.Size(100, 20);
            this.flineTextBox.TabIndex = 30;
            // 
            // lureTextBox
            // 
            this.lureTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lureTextBox.Location = new System.Drawing.Point(163, 382);
            this.lureTextBox.Name = "lureTextBox";
            this.lureTextBox.Size = new System.Drawing.Size(100, 20);
            this.lureTextBox.TabIndex = 31;
            // 
            // makeOutButton
            // 
            this.makeOutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.makeOutButton.Location = new System.Drawing.Point(280, 556);
            this.makeOutButton.Name = "makeOutButton";
            this.makeOutButton.Size = new System.Drawing.Size(91, 23);
            this.makeOutButton.TabIndex = 33;
            this.makeOutButton.Text = "Разобрать";
            this.makeOutButton.UseVisualStyleBackColor = true;
            this.makeOutButton.Click += new System.EventHandler(this.MakeOutButton_Click);
            // 
            // fRoadButton
            // 
            this.fRoadButton.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold);
            this.fRoadButton.Location = new System.Drawing.Point(513, 608);
            this.fRoadButton.Name = "fRoadButton";
            this.fRoadButton.Size = new System.Drawing.Size(27, 23);
            this.fRoadButton.TabIndex = 34;
            this.fRoadButton.Text = "1";
            this.fRoadButton.UseVisualStyleBackColor = true;
            this.fRoadButton.Click += new System.EventHandler(this.RoadButtons_Click);
            // 
            // sRoadButton
            // 
            this.sRoadButton.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold);
            this.sRoadButton.Location = new System.Drawing.Point(546, 608);
            this.sRoadButton.Name = "sRoadButton";
            this.sRoadButton.Size = new System.Drawing.Size(27, 23);
            this.sRoadButton.TabIndex = 35;
            this.sRoadButton.Text = "2";
            this.sRoadButton.UseVisualStyleBackColor = true;
            this.sRoadButton.Click += new System.EventHandler(this.RoadButtons_Click);
            // 
            // tRoadButton
            // 
            this.tRoadButton.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold);
            this.tRoadButton.Location = new System.Drawing.Point(579, 608);
            this.tRoadButton.Name = "tRoadButton";
            this.tRoadButton.Size = new System.Drawing.Size(27, 23);
            this.tRoadButton.TabIndex = 36;
            this.tRoadButton.Text = "3";
            this.tRoadButton.UseVisualStyleBackColor = true;
            this.tRoadButton.Click += new System.EventHandler(this.RoadButtons_Click);
            // 
            // assemblyPanel
            // 
            this.assemblyPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("assemblyPanel.BackgroundImage")));
            this.assemblyPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.assemblyPanel.Controls.Add(this.hookNamneBox);
            this.assemblyPanel.Controls.Add(this.hookImageBox);
            this.assemblyPanel.Controls.Add(this.reelWearBar);
            this.assemblyPanel.Controls.Add(this.BaitBox);
            this.assemblyPanel.Controls.Add(this.roadWearBar);
            this.assemblyPanel.Controls.Add(this.assNumberLabel);
            this.assemblyPanel.Controls.Add(this.assemblyType);
            this.assemblyPanel.Controls.Add(this.ReelBox);
            this.assemblyPanel.Controls.Add(this.FLineBox);
            this.assemblyPanel.Controls.Add(this.RoadBox);
            this.assemblyPanel.Controls.Add(this.roadTextBox);
            this.assemblyPanel.Controls.Add(this.reelTextBox);
            this.assemblyPanel.Controls.Add(this.lureTextBox);
            this.assemblyPanel.Controls.Add(this.flineTextBox);
            this.assemblyPanel.Location = new System.Drawing.Point(393, 55);
            this.assemblyPanel.Name = "assemblyPanel";
            this.assemblyPanel.Size = new System.Drawing.Size(266, 415);
            this.assemblyPanel.TabIndex = 37;
            // 
            // assNumberLabel
            // 
            this.assNumberLabel.AutoSize = true;
            this.assNumberLabel.BackColor = System.Drawing.Color.Transparent;
            this.assNumberLabel.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold);
            this.assNumberLabel.Location = new System.Drawing.Point(112, 237);
            this.assNumberLabel.Name = "assNumberLabel";
            this.assNumberLabel.Size = new System.Drawing.Size(0, 19);
            this.assNumberLabel.TabIndex = 31;
            // 
            // assemblyType
            // 
            this.assemblyType.Location = new System.Drawing.Point(3, 286);
            this.assemblyType.Name = "assemblyType";
            this.assemblyType.Size = new System.Drawing.Size(100, 20);
            this.assemblyType.TabIndex = 30;
            // 
            // itemImageBox
            // 
            this.itemImageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.itemImageBox.BackColor = System.Drawing.Color.Transparent;
            this.itemImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.itemImageBox.Location = new System.Drawing.Point(396, 476);
            this.itemImageBox.Name = "itemImageBox";
            this.itemImageBox.Size = new System.Drawing.Size(80, 77);
            this.itemImageBox.TabIndex = 12;
            this.itemImageBox.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.hooksBox);
            this.tabPage4.Location = new System.Drawing.Point(4, 20);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(338, 506);
            this.tabPage4.TabIndex = 7;
            this.tabPage4.Text = "Крючки";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // hooksBox
            // 
            this.hooksBox.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.hooksBox.FormattingEnabled = true;
            this.hooksBox.ItemHeight = 22;
            this.hooksBox.Location = new System.Drawing.Point(0, 0);
            this.hooksBox.Name = "hooksBox";
            this.hooksBox.Size = new System.Drawing.Size(335, 510);
            this.hooksBox.TabIndex = 0;
            this.hooksBox.SelectedIndexChanged += new System.EventHandler(this.HooksBox_SelectedIndexChanged);
            this.hooksBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.HooksBox_MouseDoubleClick);
            // 
            // baitPage
            // 
            this.baitPage.Controls.Add(this.baitsBox);
            this.baitPage.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.baitPage.Location = new System.Drawing.Point(4, 20);
            this.baitPage.Name = "baitPage";
            this.baitPage.Padding = new System.Windows.Forms.Padding(3);
            this.baitPage.Size = new System.Drawing.Size(338, 506);
            this.baitPage.TabIndex = 6;
            this.baitPage.Text = "Наживка";
            this.baitPage.UseVisualStyleBackColor = true;
            // 
            // baitsBox
            // 
            this.baitsBox.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.baitsBox.FormattingEnabled = true;
            this.baitsBox.ItemHeight = 22;
            this.baitsBox.Location = new System.Drawing.Point(0, 0);
            this.baitsBox.Name = "baitsBox";
            this.baitsBox.Size = new System.Drawing.Size(338, 488);
            this.baitsBox.TabIndex = 0;
            this.baitsBox.SelectedIndexChanged += new System.EventHandler(this.BaitsBox_SelectedIndexChanged);
            this.baitsBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.BaitsBox_MouseDoubleClick);
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.SeaGreen;
            this.tabPage6.BackgroundImage = global::Fishing.Properties.Resources.layer10;
            this.tabPage6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage6.Controls.Add(this.assembliesBox);
            this.tabPage6.Controls.Add(this.countBox);
            this.tabPage6.Location = new System.Drawing.Point(4, 20);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(338, 506);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Удочки";
            // 
            // assembliesBox
            // 
            this.assembliesBox.AllColumns.Add(this.roadNameColumn);
            this.assembliesBox.AllColumns.Add(this.powerColumn);
            this.assembliesBox.AllColumns.Add(this.typeColumn);
            this.assembliesBox.CellEditUseWholeCell = false;
            this.assembliesBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.roadNameColumn,
            this.powerColumn,
            this.typeColumn});
            this.assembliesBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.assembliesBox.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.assembliesBox.Location = new System.Drawing.Point(15, 11);
            this.assembliesBox.Name = "assembliesBox";
            this.assembliesBox.Size = new System.Drawing.Size(308, 480);
            this.assembliesBox.SmallImageList = this.roadsList;
            this.assembliesBox.TabIndex = 38;
            this.assembliesBox.UseCompatibleStateImageBehavior = false;
            this.assembliesBox.View = System.Windows.Forms.View.Details;
            this.assembliesBox.SelectedIndexChanged += new System.EventHandler(this.assembliesBox_SelectedIndexChanged_2);
            this.assembliesBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.assembliesBox_MouseDoubleClick_2);
            // 
            // roadNameColumn
            // 
            this.roadNameColumn.AspectName = "Road";
            this.roadNameColumn.Groupable = false;
            this.roadNameColumn.IsEditable = false;
            this.roadNameColumn.Sortable = false;
            this.roadNameColumn.Text = "Название";
            this.roadNameColumn.Width = 76;
            // 
            // countBox
            // 
            this.countBox.Location = new System.Drawing.Point(255, 510);
            this.countBox.Name = "countBox";
            this.countBox.Size = new System.Drawing.Size(68, 18);
            this.countBox.TabIndex = 18;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.luresView);
            this.tabPage5.Location = new System.Drawing.Point(4, 20);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(338, 506);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Приманки";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // luresView
            // 
            this.luresView.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.luresView.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.luresView.Location = new System.Drawing.Point(0, 0);
            this.luresView.MultiSelect = false;
            this.luresView.Name = "luresView";
            this.luresView.Size = new System.Drawing.Size(338, 498);
            this.luresView.SmallImageList = this.lureList;
            this.luresView.StateImageList = this.lureList;
            this.luresView.TabIndex = 0;
            this.luresView.UseCompatibleStateImageBehavior = false;
            this.luresView.View = System.Windows.Forms.View.SmallIcon;
            this.luresView.SelectedIndexChanged += new System.EventHandler(this.LuresView_SelectedIndexChanged);
            this.luresView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LuresView_MouseDoubleClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ReelsList);
            this.tabPage3.Location = new System.Drawing.Point(4, 20);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(338, 506);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Катушки";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ReelsList
            // 
            this.ReelsList.BackColor = System.Drawing.Color.SeaGreen;
            this.ReelsList.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.ReelsList.FormattingEnabled = true;
            this.ReelsList.ItemHeight = 22;
            this.ReelsList.Location = new System.Drawing.Point(-4, 0);
            this.ReelsList.Name = "ReelsList";
            this.ReelsList.Size = new System.Drawing.Size(342, 488);
            this.ReelsList.TabIndex = 5;
            this.ReelsList.SelectedIndexChanged += new System.EventHandler(this.ReelsList_SelectedIndexChanged);
            this.ReelsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ReelsList_MouseDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.FLineList);
            this.tabPage2.Location = new System.Drawing.Point(4, 20);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(338, 506);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Леска";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FLineList
            // 
            this.FLineList.BackColor = System.Drawing.Color.SeaGreen;
            this.FLineList.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.FLineList.ItemHeight = 22;
            this.FLineList.Location = new System.Drawing.Point(-4, 0);
            this.FLineList.Name = "FLineList";
            this.FLineList.Size = new System.Drawing.Size(339, 488);
            this.FLineList.TabIndex = 6;
            this.FLineList.SelectedIndexChanged += new System.EventHandler(this.FLineList_SelectedIndexChanged);
            this.FLineList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FLineList_MouseDoubleClick);
            // 
            // ItemsTab
            // 
            this.ItemsTab.Controls.Add(this.tabPage6);
            this.ItemsTab.Controls.Add(this.tabPage2);
            this.ItemsTab.Controls.Add(this.tabPage3);
            this.ItemsTab.Controls.Add(this.tabPage5);
            this.ItemsTab.Controls.Add(this.baitPage);
            this.ItemsTab.Controls.Add(this.tabPage4);
            this.ItemsTab.Font = new System.Drawing.Font("Palatino Linotype", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ItemsTab.Location = new System.Drawing.Point(41, 27);
            this.ItemsTab.Name = "ItemsTab";
            this.ItemsTab.SelectedIndex = 0;
            this.ItemsTab.Size = new System.Drawing.Size(346, 530);
            this.ItemsTab.TabIndex = 23;
            this.ItemsTab.Click += new System.EventHandler(this.ItemsTab_Click);
            // 
            // powerColumn
            // 
            this.powerColumn.AspectName = "Road.Power";
            this.powerColumn.Groupable = false;
            this.powerColumn.Text = "Прочность";
            this.powerColumn.Width = 91;
            // 
            // typeColumn
            // 
            this.typeColumn.AspectName = "Road.Type";
            this.typeColumn.FillsFreeSpace = true;
            this.typeColumn.Groupable = false;
            this.typeColumn.Text = "Тип";
            // 
            // hookImageBox
            // 
            this.hookImageBox.BackColor = System.Drawing.Color.Transparent;
            this.hookImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hookImageBox.Location = new System.Drawing.Point(6, 312);
            this.hookImageBox.Name = "hookImageBox";
            this.hookImageBox.Size = new System.Drawing.Size(100, 64);
            this.hookImageBox.TabIndex = 34;
            this.hookImageBox.TabStop = false;
            // 
            // hookNamneBox
            // 
            this.hookNamneBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.hookNamneBox.Location = new System.Drawing.Point(6, 382);
            this.hookNamneBox.Name = "hookNamneBox";
            this.hookNamneBox.Size = new System.Drawing.Size(100, 20);
            this.hookNamneBox.TabIndex = 35;
            // 
            // reelWearBar
            // 
            this.reelWearBar.BorderStyle = VerticalProgressBar.BorderStyles.Classic;
            this.reelWearBar.Color = System.Drawing.Color.Blue;
            this.reelWearBar.Location = new System.Drawing.Point(238, 3);
            this.reelWearBar.Maximum = 100;
            this.reelWearBar.Minimum = 0;
            this.reelWearBar.Name = "reelWearBar";
            this.reelWearBar.Size = new System.Drawing.Size(15, 191);
            this.reelWearBar.Step = 10;
            this.reelWearBar.Style = VerticalProgressBar.Styles.Classic;
            this.reelWearBar.TabIndex = 33;
            this.reelWearBar.Value = 0;
            // 
            // roadWearBar
            // 
            this.roadWearBar.BorderStyle = VerticalProgressBar.BorderStyles.None;
            this.roadWearBar.Color = System.Drawing.Color.Blue;
            this.roadWearBar.Location = new System.Drawing.Point(105, 3);
            this.roadWearBar.Maximum = 100;
            this.roadWearBar.Minimum = 0;
            this.roadWearBar.Name = "roadWearBar";
            this.roadWearBar.Size = new System.Drawing.Size(15, 182);
            this.roadWearBar.Step = 1;
            this.roadWearBar.Style = VerticalProgressBar.Styles.Classic;
            this.roadWearBar.TabIndex = 32;
            this.roadWearBar.Value = 0;
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(715, 650);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.itemImageBox);
            this.Controls.Add(this.powerBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.assemblyPanel);
            this.Controls.Add(this.tRoadButton);
            this.Controls.Add(this.sRoadButton);
            this.Controls.Add(this.fRoadButton);
            this.Controls.Add(this.makeOutButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ItemsTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Inventory";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.BaitBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FLineBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReelBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoadBox)).EndInit();
            this.assemblyPanel.ResumeLayout(false);
            this.assemblyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemImageBox)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.baitPage.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.assembliesBox)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ItemsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hookImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected internal System.Windows.Forms.PictureBox RoadBox;
        protected internal System.Windows.Forms.PictureBox ReelBox;
        protected internal System.Windows.Forms.PictureBox FLineBox;
        protected internal System.Windows.Forms.PictureBox BaitBox;
        protected internal System.Windows.Forms.TextBox nameBox;
        protected internal System.Windows.Forms.TextBox powerBox;
        protected internal System.Windows.Forms.TextBox typeBox;
        protected internal System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.TextBox roadTextBox;
        private System.Windows.Forms.TextBox reelTextBox;
        private System.Windows.Forms.TextBox flineTextBox;
        private System.Windows.Forms.TextBox lureTextBox;
        private System.Windows.Forms.Button makeOutButton;
        private System.Windows.Forms.Button fRoadButton;
        private System.Windows.Forms.Button sRoadButton;
        private System.Windows.Forms.Button tRoadButton;
        private System.Windows.Forms.ImageList roadsList;
        private System.Windows.Forms.ImageList lureList;
        private System.Windows.Forms.Panel assemblyPanel;
        private System.Windows.Forms.TextBox assemblyType;
        protected internal System.Windows.Forms.PictureBox itemImageBox;
        private System.Windows.Forms.Label assNumberLabel;
        private VerticalProgressBar.VerticalProgressBar reelWearBar;
        private VerticalProgressBar.VerticalProgressBar roadWearBar;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListBox hooksBox;
        private System.Windows.Forms.TabPage baitPage;
        private System.Windows.Forms.ListBox baitsBox;
        private System.Windows.Forms.TabPage tabPage6;
        protected internal System.Windows.Forms.TextBox countBox;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ListView luresView;
        private System.Windows.Forms.TabPage tabPage3;
        protected internal System.Windows.Forms.ListBox ReelsList;
        private System.Windows.Forms.TabPage tabPage2;
        protected internal System.Windows.Forms.ListBox FLineList;
        protected internal System.Windows.Forms.TabControl ItemsTab;
        private BrightIdeasSoftware.ObjectListView assembliesBox;
        private BrightIdeasSoftware.OLVColumn roadNameColumn;
        private BrightIdeasSoftware.OLVColumn powerColumn;
        private BrightIdeasSoftware.OLVColumn typeColumn;
        private System.Windows.Forms.TextBox hookNamneBox;
        protected internal System.Windows.Forms.PictureBox hookImageBox;
    }
}