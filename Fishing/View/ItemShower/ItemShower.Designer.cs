namespace Fishing.View.ItemShower
{
    partial class ItemShower
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
            this.itemImage = new System.Windows.Forms.PictureBox();
            this.itemInfo = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.itemImage)).BeginInit();
            this.SuspendLayout();
            // 
            // itemImage
            // 
            this.itemImage.Location = new System.Drawing.Point(2, 3);
            this.itemImage.Name = "itemImage";
            this.itemImage.Size = new System.Drawing.Size(180, 107);
            this.itemImage.TabIndex = 0;
            this.itemImage.TabStop = false;
            // 
            // itemInfo
            // 
            this.itemInfo.Location = new System.Drawing.Point(2, 116);
            this.itemInfo.Name = "itemInfo";
            this.itemInfo.Size = new System.Drawing.Size(180, 93);
            this.itemInfo.TabIndex = 1;
            this.itemInfo.Text = "";
            // 
            // ItemShower
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 211);
            this.Controls.Add(this.itemInfo);
            this.Controls.Add(this.itemImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ItemShower";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ItemShower";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.itemImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox itemImage;
        private System.Windows.Forms.RichTextBox itemInfo;
    }
}