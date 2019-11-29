namespace MapEditor.View {
    partial class WaterForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.mapPictureBox = new System.Windows.Forms.PictureBox();
            this.uploadBackImageButton = new System.Windows.Forms.Button();
            this.createNewLocationButton = new System.Windows.Forms.Button();
            this.deleteLocationButton = new System.Windows.Forms.Button();
            this.changeLocationButton = new System.Windows.Forms.Button();
            this.waterProperties = new System.Windows.Forms.GroupBox();
            this.housePriceLabel = new System.Windows.Forms.Label();
            this.minLevelLabel = new System.Windows.Forms.Label();
            this.pricePerDayLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).BeginInit();
            this.waterProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapPictureBox
            // 
            this.mapPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mapPictureBox.Location = new System.Drawing.Point(0, 0);
            this.mapPictureBox.Name = "mapPictureBox";
            this.mapPictureBox.Size = new System.Drawing.Size(800, 700);
            this.mapPictureBox.TabIndex = 0;
            this.mapPictureBox.TabStop = false;
            this.mapPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapPictureBox_MouseDown);
            this.mapPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapPictureBox_MouseMove);
            this.mapPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MapPictureBox_MouseUp);
            // 
            // uploadBackImageButton
            // 
            this.uploadBackImageButton.Location = new System.Drawing.Point(2, 836);
            this.uploadBackImageButton.Name = "uploadBackImageButton";
            this.uploadBackImageButton.Size = new System.Drawing.Size(93, 23);
            this.uploadBackImageButton.TabIndex = 1;
            this.uploadBackImageButton.Text = "Загрузить фон";
            this.uploadBackImageButton.UseVisualStyleBackColor = true;
            this.uploadBackImageButton.Click += new System.EventHandler(this.CreateNewLocation_Click);
            // 
            // createNewLocationButton
            // 
            this.createNewLocationButton.Location = new System.Drawing.Point(101, 836);
            this.createNewLocationButton.Name = "createNewLocationButton";
            this.createNewLocationButton.Size = new System.Drawing.Size(93, 23);
            this.createNewLocationButton.TabIndex = 2;
            this.createNewLocationButton.Text = "Новая локация";
            this.createNewLocationButton.UseVisualStyleBackColor = true;
            this.createNewLocationButton.Click += new System.EventHandler(this.CreateNewLocationButton_Click);
            // 
            // deleteLocationButton
            // 
            this.deleteLocationButton.Location = new System.Drawing.Point(534, 836);
            this.deleteLocationButton.Name = "deleteLocationButton";
            this.deleteLocationButton.Size = new System.Drawing.Size(125, 23);
            this.deleteLocationButton.TabIndex = 3;
            this.deleteLocationButton.Text = "Удалить локацию";
            this.deleteLocationButton.UseVisualStyleBackColor = true;
            this.deleteLocationButton.Click += new System.EventHandler(this.DeleteLocationButton_Click);
            // 
            // changeLocationButton
            // 
            this.changeLocationButton.Location = new System.Drawing.Point(665, 836);
            this.changeLocationButton.Name = "changeLocationButton";
            this.changeLocationButton.Size = new System.Drawing.Size(151, 23);
            this.changeLocationButton.TabIndex = 4;
            this.changeLocationButton.Text = "Редактировать локацию";
            this.changeLocationButton.UseVisualStyleBackColor = true;
            this.changeLocationButton.Click += new System.EventHandler(this.ChangeLocationButton_Click);
            // 
            // waterProperties
            // 
            this.waterProperties.Controls.Add(this.housePriceLabel);
            this.waterProperties.Controls.Add(this.minLevelLabel);
            this.waterProperties.Controls.Add(this.pricePerDayLabel);
            this.waterProperties.Location = new System.Drawing.Point(306, 771);
            this.waterProperties.Name = "waterProperties";
            this.waterProperties.Size = new System.Drawing.Size(200, 88);
            this.waterProperties.TabIndex = 5;
            this.waterProperties.TabStop = false;
            // 
            // housePriceLabel
            // 
            this.housePriceLabel.AutoSize = true;
            this.housePriceLabel.Location = new System.Drawing.Point(6, 38);
            this.housePriceLabel.Name = "housePriceLabel";
            this.housePriceLabel.Size = new System.Drawing.Size(71, 13);
            this.housePriceLabel.TabIndex = 1;
            this.housePriceLabel.Text = "Цена дома:  ";
            // 
            // minLevelLabel
            // 
            this.minLevelLabel.AutoSize = true;
            this.minLevelLabel.Location = new System.Drawing.Point(6, 60);
            this.minLevelLabel.Name = "minLevelLabel";
            this.minLevelLabel.Size = new System.Drawing.Size(60, 13);
            this.minLevelLabel.TabIndex = 1;
            this.minLevelLabel.Text = "Уровень:  ";
            // 
            // pricePerDayLabel
            // 
            this.pricePerDayLabel.AutoSize = true;
            this.pricePerDayLabel.Location = new System.Drawing.Point(6, 16);
            this.pricePerDayLabel.Name = "pricePerDayLabel";
            this.pricePerDayLabel.Size = new System.Drawing.Size(84, 13);
            this.pricePerDayLabel.TabIndex = 0;
            this.pricePerDayLabel.Text = "Цена за день:  ";
            // 
            // WaterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 861);
            this.Controls.Add(this.waterProperties);
            this.Controls.Add(this.changeLocationButton);
            this.Controls.Add(this.deleteLocationButton);
            this.Controls.Add(this.createNewLocationButton);
            this.Controls.Add(this.uploadBackImageButton);
            this.Controls.Add(this.mapPictureBox);
            this.Name = "WaterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Водоём - ";
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).EndInit();
            this.waterProperties.ResumeLayout(false);
            this.waterProperties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button uploadBackImageButton;
        private System.Windows.Forms.Button createNewLocationButton;
        private System.Windows.Forms.Button deleteLocationButton;
        private System.Windows.Forms.Button changeLocationButton;
        private System.Windows.Forms.GroupBox waterProperties;
        private System.Windows.Forms.Label housePriceLabel;
        private System.Windows.Forms.Label minLevelLabel;
        private System.Windows.Forms.Label pricePerDayLabel;
        public System.Windows.Forms.PictureBox mapPictureBox;
    }
}