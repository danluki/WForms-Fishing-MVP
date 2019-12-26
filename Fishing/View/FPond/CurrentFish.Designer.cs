namespace Fishing
{
    partial class CurrentFish
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.WeightLabel = new System.Windows.Forms.Label();
            this.FishImage = new System.Windows.Forms.PictureBox();
            this.PriceButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FishImage)).BeginInit();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameLabel.Location = new System.Drawing.Point(68, 452);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(66, 24);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "label1";
            // 
            // WeightLabel
            // 
            this.WeightLabel.AutoSize = true;
            this.WeightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WeightLabel.Location = new System.Drawing.Point(538, 452);
            this.WeightLabel.Name = "WeightLabel";
            this.WeightLabel.Size = new System.Drawing.Size(66, 24);
            this.WeightLabel.TabIndex = 2;
            this.WeightLabel.Text = "label2";
            // 
            // FishImage
            // 
            this.FishImage.Location = new System.Drawing.Point(12, 13);
            this.FishImage.Name = "FishImage";
            this.FishImage.Size = new System.Drawing.Size(673, 421);
            this.FishImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FishImage.TabIndex = 0;
            this.FishImage.TabStop = false;
            // 
            // PriceButton
            // 
            this.PriceButton.Enabled = false;
            this.PriceButton.Location = new System.Drawing.Point(163, 452);
            this.PriceButton.Name = "PriceButton";
            this.PriceButton.Size = new System.Drawing.Size(339, 23);
            this.PriceButton.TabIndex = 3;
            this.PriceButton.UseVisualStyleBackColor = true;
            // 
            // CurrentFish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(697, 492);
            this.ControlBox = false;
            this.Controls.Add(this.PriceButton);
            this.Controls.Add(this.WeightLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.FishImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CurrentFish";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CurrentFish";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Yellow;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CurrentFish_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.FishImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.PictureBox FishImage;
        protected internal System.Windows.Forms.Label NameLabel;
        protected internal System.Windows.Forms.Label WeightLabel;
        protected internal System.Windows.Forms.Button PriceButton;
    }
}