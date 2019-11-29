namespace Fishing.View.Trip
{
    partial class TripForm
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
            this.closeButton = new System.Windows.Forms.Button();
            this.mapBox = new System.Windows.Forms.PictureBox();
            this.goButton = new System.Windows.Forms.Button();
            this.moneyLabel = new System.Windows.Forms.TextBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.updateHours = new System.Windows.Forms.Timer(this.components);
            this.watersBox = new System.Windows.Forms.ListBox();
            this.carButton = new System.Windows.Forms.Button();
            this.trainButton = new System.Windows.Forms.Button();
            this.planeButton = new System.Windows.Forms.Button();
            this.daysUpDown = new System.Windows.Forms.DomainUpDown();
            this.tripBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.mapBox)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(644, 17);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(24, 23);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // mapBox
            // 
            this.mapBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mapBox.Location = new System.Drawing.Point(172, 42);
            this.mapBox.Name = "mapBox";
            this.mapBox.Size = new System.Drawing.Size(496, 436);
            this.mapBox.TabIndex = 1;
            this.mapBox.TabStop = false;
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(581, 590);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(87, 27);
            this.goButton.TabIndex = 2;
            this.goButton.Text = "Поехать";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // moneyLabel
            // 
            this.moneyLabel.Location = new System.Drawing.Point(489, 20);
            this.moneyLabel.Name = "moneyLabel";
            this.moneyLabel.ReadOnly = true;
            this.moneyLabel.Size = new System.Drawing.Size(142, 20);
            this.moneyLabel.TabIndex = 3;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeLabel.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeLabel.Location = new System.Drawing.Point(338, 24);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(0, 16);
            this.timeLabel.TabIndex = 4;
            // 
            // updateHours
            // 
            this.updateHours.Enabled = true;
            this.updateHours.Interval = 30000;
            this.updateHours.Tick += new System.EventHandler(this.UpdateHours_Tick);
            // 
            // watersBox
            // 
            this.watersBox.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.watersBox.FormattingEnabled = true;
            this.watersBox.ItemHeight = 16;
            this.watersBox.Location = new System.Drawing.Point(30, 15);
            this.watersBox.Name = "watersBox";
            this.watersBox.Size = new System.Drawing.Size(136, 596);
            this.watersBox.TabIndex = 5;
            this.watersBox.SelectedIndexChanged += new System.EventHandler(this.WatersBox_SelectedIndexChanged);
            // 
            // carButton
            // 
            this.carButton.Location = new System.Drawing.Point(172, 483);
            this.carButton.Name = "carButton";
            this.carButton.Size = new System.Drawing.Size(92, 34);
            this.carButton.TabIndex = 6;
            this.carButton.Text = "Машина(+2000)";
            this.carButton.UseVisualStyleBackColor = true;
            this.carButton.Click += new System.EventHandler(this.CarButton_Click);
            // 
            // trainButton
            // 
            this.trainButton.Location = new System.Drawing.Point(270, 483);
            this.trainButton.Name = "trainButton";
            this.trainButton.Size = new System.Drawing.Size(90, 34);
            this.trainButton.TabIndex = 7;
            this.trainButton.Text = "Поезд(+5000)";
            this.trainButton.UseVisualStyleBackColor = true;
            this.trainButton.Click += new System.EventHandler(this.TrainButton_Click);
            // 
            // planeButton
            // 
            this.planeButton.Location = new System.Drawing.Point(366, 484);
            this.planeButton.Name = "planeButton";
            this.planeButton.Size = new System.Drawing.Size(104, 35);
            this.planeButton.TabIndex = 8;
            this.planeButton.Text = "Самолет(+20000)";
            this.planeButton.UseVisualStyleBackColor = true;
            this.planeButton.Click += new System.EventHandler(this.PlaneButton_Click);
            // 
            // daysUpDown
            // 
            this.daysUpDown.Items.Add("1");
            this.daysUpDown.Items.Add("2");
            this.daysUpDown.Items.Add("3");
            this.daysUpDown.Items.Add("4");
            this.daysUpDown.Items.Add("5");
            this.daysUpDown.Items.Add("6");
            this.daysUpDown.Items.Add("7");
            this.daysUpDown.Items.Add("8");
            this.daysUpDown.Items.Add("9");
            this.daysUpDown.Items.Add("10");
            this.daysUpDown.Items.Add("11");
            this.daysUpDown.Items.Add("12");
            this.daysUpDown.Items.Add("13");
            this.daysUpDown.Items.Add("14");
            this.daysUpDown.Location = new System.Drawing.Point(172, 523);
            this.daysUpDown.Name = "daysUpDown";
            this.daysUpDown.Size = new System.Drawing.Size(120, 20);
            this.daysUpDown.TabIndex = 9;
            this.daysUpDown.Text = "Дни:";
            this.daysUpDown.SelectedItemChanged += new System.EventHandler(this.DaysUpDown_SelectedItemChanged);
            // 
            // tripBox
            // 
            this.tripBox.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tripBox.Location = new System.Drawing.Point(476, 483);
            this.tripBox.Name = "tripBox";
            this.tripBox.Size = new System.Drawing.Size(192, 101);
            this.tripBox.TabIndex = 10;
            this.tripBox.Text = "";
            this.tripBox.MouseEnter += new System.EventHandler(this.TripBox_MouseEnter);
            // 
            // TripForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Fishing.Properties.Resources.layer10;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(709, 640);
            this.Controls.Add(this.tripBox);
            this.Controls.Add(this.daysUpDown);
            this.Controls.Add(this.planeButton);
            this.Controls.Add(this.trainButton);
            this.Controls.Add(this.carButton);
            this.Controls.Add(this.watersBox);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.moneyLabel);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.mapBox);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TripForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TripForm";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.mapBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.PictureBox mapBox;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.TextBox moneyLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Timer updateHours;
        private System.Windows.Forms.ListBox watersBox;
        private System.Windows.Forms.Button carButton;
        private System.Windows.Forms.Button trainButton;
        private System.Windows.Forms.Button planeButton;
        private System.Windows.Forms.DomainUpDown daysUpDown;
        private System.Windows.Forms.RichTextBox tripBox;
    }
}