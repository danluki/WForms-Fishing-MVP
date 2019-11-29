namespace Fishing.View.FoodInventory
{
    partial class FoodInventory
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
            this.foodsBox = new System.Windows.Forms.ListBox();
            this.FoodBox = new System.Windows.Forms.PictureBox();
            this.foodProductBox = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FoodBox)).BeginInit();
            this.SuspendLayout();
            // 
            // foodsBox
            // 
            this.foodsBox.Location = new System.Drawing.Point(25, 13);
            this.foodsBox.Name = "foodsBox";
            this.foodsBox.Size = new System.Drawing.Size(213, 290);
            this.foodsBox.Sorted = true;
            this.foodsBox.TabIndex = 0;
            this.foodsBox.SelectedIndexChanged += new System.EventHandler(this.FoodsBox_SelectedIndexChanged);
            this.foodsBox.DoubleClick += new System.EventHandler(this.FoodsBox_DoubleClick);
            // 
            // FoodBox
            // 
            this.FoodBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FoodBox.Location = new System.Drawing.Point(245, 13);
            this.FoodBox.Name = "FoodBox";
            this.FoodBox.Size = new System.Drawing.Size(127, 126);
            this.FoodBox.TabIndex = 1;
            this.FoodBox.TabStop = false;
            // 
            // foodProductBox
            // 
            this.foodProductBox.Location = new System.Drawing.Point(245, 146);
            this.foodProductBox.Name = "foodProductBox";
            this.foodProductBox.Size = new System.Drawing.Size(127, 20);
            this.foodProductBox.TabIndex = 2;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(349, 279);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(22, 23);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // FoodInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Fishing.Properties.Resources.layer10;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(402, 320);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.foodProductBox);
            this.Controls.Add(this.FoodBox);
            this.Controls.Add(this.foodsBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FoodInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FoodInventory";
            ((System.ComponentModel.ISupportInitialize)(this.FoodBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox foodsBox;
        private System.Windows.Forms.PictureBox FoodBox;
        private System.Windows.Forms.TextBox foodProductBox;
        private System.Windows.Forms.Button closeButton;
    }
}