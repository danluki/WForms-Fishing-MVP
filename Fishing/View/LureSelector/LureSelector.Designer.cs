namespace Fishing.View.LureSelector
{
    partial class LureSelector<T> 
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
            this.lureList = new System.Windows.Forms.ListBox();
            this.lureImage = new System.Windows.Forms.PictureBox();
            this.deepBox = new System.Windows.Forms.TextBox();
            this.sizeBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lureImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lureList
            // 
            this.lureList.FormattingEnabled = true;
            this.lureList.Location = new System.Drawing.Point(23, 12);
            this.lureList.Name = "lureList";
            this.lureList.Size = new System.Drawing.Size(130, 160);
            this.lureList.TabIndex = 0;
            this.lureList.SelectedIndexChanged += new System.EventHandler(this.LureList_SelectedIndexChanged);
            this.lureList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LureList_MouseDoubleClick);
            // 
            // lureImage
            // 
            this.lureImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lureImage.Location = new System.Drawing.Point(159, 12);
            this.lureImage.Name = "lureImage";
            this.lureImage.Size = new System.Drawing.Size(109, 78);
            this.lureImage.TabIndex = 1;
            this.lureImage.TabStop = false;
            // 
            // deepBox
            // 
            this.deepBox.Location = new System.Drawing.Point(159, 97);
            this.deepBox.Name = "deepBox";
            this.deepBox.Size = new System.Drawing.Size(109, 20);
            this.deepBox.TabIndex = 2;
            // 
            // sizeBox
            // 
            this.sizeBox.Location = new System.Drawing.Point(159, 124);
            this.sizeBox.Name = "sizeBox";
            this.sizeBox.Size = new System.Drawing.Size(109, 20);
            this.sizeBox.TabIndex = 3;
            // 
            // LureSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Fishing.Properties.Resources.layer10;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(289, 181);
            this.Controls.Add(this.sizeBox);
            this.Controls.Add(this.deepBox);
            this.Controls.Add(this.lureImage);
            this.Controls.Add(this.lureList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LureSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LureSelector";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.ActiveBorder;
            ((System.ComponentModel.ISupportInitialize)(this.lureImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lureList;
        private System.Windows.Forms.PictureBox lureImage;
        private System.Windows.Forms.TextBox deepBox;
        private System.Windows.Forms.TextBox sizeBox;
    }
}