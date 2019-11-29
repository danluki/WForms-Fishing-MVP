namespace Fishing.View.Statistic
{
    partial class StatisticForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticForm));
            this.CloseButton = new System.Windows.Forms.Button();
            this.StatisticControl = new System.Windows.Forms.TabControl();
            this.PlayerStats = new System.Windows.Forms.TabPage();
            this.TakenFishes = new System.Windows.Forms.Label();
            this.TornsFLineLabel = new System.Windows.Forms.Label();
            this.BrokenRoadsLabel = new System.Windows.Forms.Label();
            this.GatheringLabel = new System.Windows.Forms.Label();
            this.MoneyLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.GameLogs = new System.Windows.Forms.TabPage();
            this.EventView = new System.Windows.Forms.ListView();
            this.eventsList = new System.Windows.Forms.ImageList(this.components);
            this.StatisticControl.SuspendLayout();
            this.PlayerStats.SuspendLayout();
            this.GameLogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(552, 12);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(24, 23);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // StatisticControl
            // 
            this.StatisticControl.Controls.Add(this.PlayerStats);
            this.StatisticControl.Controls.Add(this.GameLogs);
            this.StatisticControl.Location = new System.Drawing.Point(30, 35);
            this.StatisticControl.Name = "StatisticControl";
            this.StatisticControl.SelectedIndex = 0;
            this.StatisticControl.Size = new System.Drawing.Size(546, 471);
            this.StatisticControl.TabIndex = 1;
            // 
            // PlayerStats
            // 
            this.PlayerStats.Controls.Add(this.TakenFishes);
            this.PlayerStats.Controls.Add(this.TornsFLineLabel);
            this.PlayerStats.Controls.Add(this.BrokenRoadsLabel);
            this.PlayerStats.Controls.Add(this.GatheringLabel);
            this.PlayerStats.Controls.Add(this.MoneyLabel);
            this.PlayerStats.Controls.Add(this.NameLabel);
            this.PlayerStats.Location = new System.Drawing.Point(4, 22);
            this.PlayerStats.Name = "PlayerStats";
            this.PlayerStats.Padding = new System.Windows.Forms.Padding(3);
            this.PlayerStats.Size = new System.Drawing.Size(538, 445);
            this.PlayerStats.TabIndex = 0;
            this.PlayerStats.Text = "Статистика";
            this.PlayerStats.UseVisualStyleBackColor = true;
            // 
            // TakenFishes
            // 
            this.TakenFishes.AutoSize = true;
            this.TakenFishes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TakenFishes.Location = new System.Drawing.Point(11, 200);
            this.TakenFishes.Name = "TakenFishes";
            this.TakenFishes.Size = new System.Drawing.Size(174, 24);
            this.TakenFishes.TabIndex = 5;
            this.TakenFishes.Text = "Поймано хвостов:";
            // 
            // TornsFLineLabel
            // 
            this.TornsFLineLabel.AutoSize = true;
            this.TornsFLineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TornsFLineLabel.Location = new System.Drawing.Point(11, 165);
            this.TornsFLineLabel.Name = "TornsFLineLabel";
            this.TornsFLineLabel.Size = new System.Drawing.Size(173, 24);
            this.TornsFLineLabel.TabIndex = 4;
            this.TornsFLineLabel.Text = "Порванные лески:";
            // 
            // BrokenRoadsLabel
            // 
            this.BrokenRoadsLabel.AutoSize = true;
            this.BrokenRoadsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BrokenRoadsLabel.Location = new System.Drawing.Point(11, 130);
            this.BrokenRoadsLabel.Name = "BrokenRoadsLabel";
            this.BrokenRoadsLabel.Size = new System.Drawing.Size(185, 24);
            this.BrokenRoadsLabel.TabIndex = 3;
            this.BrokenRoadsLabel.Text = "Сломанные удочки:";
            // 
            // GatheringLabel
            // 
            this.GatheringLabel.AutoSize = true;
            this.GatheringLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GatheringLabel.Location = new System.Drawing.Point(11, 95);
            this.GatheringLabel.Name = "GatheringLabel";
            this.GatheringLabel.Size = new System.Drawing.Size(74, 24);
            this.GatheringLabel.TabIndex = 2;
            this.GatheringLabel.Text = "Сходы:";
            // 
            // MoneyLabel
            // 
            this.MoneyLabel.AutoSize = true;
            this.MoneyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MoneyLabel.Location = new System.Drawing.Point(11, 62);
            this.MoneyLabel.Name = "MoneyLabel";
            this.MoneyLabel.Size = new System.Drawing.Size(82, 24);
            this.MoneyLabel.TabIndex = 1;
            this.MoneyLabel.Text = "Деньги:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameLabel.Location = new System.Drawing.Point(8, 7);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(94, 42);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Имя";
            // 
            // GameLogs
            // 
            this.GameLogs.Controls.Add(this.EventView);
            this.GameLogs.Location = new System.Drawing.Point(4, 22);
            this.GameLogs.Name = "GameLogs";
            this.GameLogs.Padding = new System.Windows.Forms.Padding(3);
            this.GameLogs.Size = new System.Drawing.Size(538, 445);
            this.GameLogs.TabIndex = 1;
            this.GameLogs.Text = "Лог событий";
            this.GameLogs.UseVisualStyleBackColor = true;
            // 
            // EventView
            // 
            this.EventView.Location = new System.Drawing.Point(0, 0);
            this.EventView.Name = "EventView";
            this.EventView.Size = new System.Drawing.Size(287, 500);
            this.EventView.SmallImageList = this.eventsList;
            this.EventView.TabIndex = 0;
            this.EventView.UseCompatibleStateImageBehavior = false;
            this.EventView.View = System.Windows.Forms.View.SmallIcon;
            // 
            // eventsList
            // 
            this.eventsList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("eventsList.ImageStream")));
            this.eventsList.TransparentColor = System.Drawing.Color.Transparent;
            this.eventsList.Images.SetKeyName(0, "break.png");
            this.eventsList.Images.SetKeyName(1, "hvastun.png");
            this.eventsList.Images.SetKeyName(2, "spoon.png");
            this.eventsList.Images.SetKeyName(3, "vert.png");
            this.eventsList.Images.SetKeyName(4, "deepvobler.png");
            this.eventsList.Images.SetKeyName(5, "sriv.png");
            this.eventsList.Images.SetKeyName(6, "vibro.png");
            this.eventsList.Images.SetKeyName(7, "bio.png");
            this.eventsList.Images.SetKeyName(8, "eat.png");
            // 
            // StatisticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Fishing.Properties.Resources.layer10;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(606, 528);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.StatisticControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StatisticForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StatisticForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.StatisticForm_Load);
            this.StatisticControl.ResumeLayout(false);
            this.PlayerStats.ResumeLayout(false);
            this.PlayerStats.PerformLayout();
            this.GameLogs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.TabControl StatisticControl;
        private System.Windows.Forms.TabPage PlayerStats;
        private System.Windows.Forms.TabPage GameLogs;
        private System.Windows.Forms.Label BrokenRoadsLabel;
        private System.Windows.Forms.Label GatheringLabel;
        private System.Windows.Forms.Label MoneyLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label TornsFLineLabel;
        private System.Windows.Forms.Label TakenFishes;
        private System.Windows.Forms.ListView EventView;
        private System.Windows.Forms.ImageList eventsList;
    }
}