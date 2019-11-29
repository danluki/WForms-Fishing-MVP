using Fishing.BL;
using Fishing.BL.Resources.Images;

namespace Fishing
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.MapButton = new System.Windows.Forms.Button();
            this.ShopButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SettingButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TravelButton = new System.Windows.Forms.Button();
            this.sellFishButton = new System.Windows.Forms.Button();
            this.FoodShopButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MapButton
            // 
            this.MapButton.BackColor = System.Drawing.Color.Transparent;
            this.MapButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MapButton.BackgroundImage")));
            this.MapButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MapButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MapButton.Location = new System.Drawing.Point(517, 31);
            this.MapButton.Name = "MapButton";
            this.MapButton.Size = new System.Drawing.Size(120, 120);
            this.MapButton.TabIndex = 0;
            this.MapButton.UseVisualStyleBackColor = false;
            this.MapButton.Click += new System.EventHandler(this.MapButton_Click);
            this.MapButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.MapButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // ShopButton
            // 
            this.ShopButton.BackColor = System.Drawing.Color.Transparent;
            this.ShopButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ShopButton.BackgroundImage")));
            this.ShopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ShopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShopButton.Location = new System.Drawing.Point(47, 82);
            this.ShopButton.Name = "ShopButton";
            this.ShopButton.Size = new System.Drawing.Size(257, 69);
            this.ShopButton.TabIndex = 1;
            this.ShopButton.UseVisualStyleBackColor = false;
            this.ShopButton.Click += new System.EventHandler(this.ShopButton_Click);
            this.ShopButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.ShopButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(532, 418);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(105, 34);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Выход";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SettingButton
            // 
            this.SettingButton.Location = new System.Drawing.Point(380, 418);
            this.SettingButton.Name = "SettingButton";
            this.SettingButton.Size = new System.Drawing.Size(105, 34);
            this.SettingButton.TabIndex = 3;
            this.SettingButton.Text = "Настройки";
            this.SettingButton.UseVisualStyleBackColor = true;
            this.SettingButton.Click += new System.EventHandler(this.SettingButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(33, 428);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 24);
            this.label2.TabIndex = 5;
            // 
            // TravelButton
            // 
            this.TravelButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TravelButton.BackgroundImage")));
            this.TravelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TravelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TravelButton.Location = new System.Drawing.Point(380, 273);
            this.TravelButton.Name = "TravelButton";
            this.TravelButton.Size = new System.Drawing.Size(257, 62);
            this.TravelButton.TabIndex = 7;
            this.TravelButton.UseVisualStyleBackColor = true;
            this.TravelButton.Click += new System.EventHandler(this.Button1_Click);
            this.TravelButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.TravelButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // sellFishButton
            // 
            this.sellFishButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sellFishButton.BackgroundImage")));
            this.sellFishButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sellFishButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sellFishButton.Location = new System.Drawing.Point(47, 157);
            this.sellFishButton.Name = "sellFishButton";
            this.sellFishButton.Size = new System.Drawing.Size(257, 64);
            this.sellFishButton.TabIndex = 8;
            this.sellFishButton.UseVisualStyleBackColor = true;
            this.sellFishButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.sellFishButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // FoodShopButton
            // 
            this.FoodShopButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FoodShopButton.BackgroundImage")));
            this.FoodShopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FoodShopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FoodShopButton.Location = new System.Drawing.Point(47, 227);
            this.FoodShopButton.Name = "FoodShopButton";
            this.FoodShopButton.Size = new System.Drawing.Size(257, 64);
            this.FoodShopButton.TabIndex = 9;
            this.FoodShopButton.UseVisualStyleBackColor = true;
            this.FoodShopButton.Click += new System.EventHandler(this.FoodShopButton_Click);
            this.FoodShopButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.FoodShopButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(680, 480);
            this.Controls.Add(this.FoodShopButton);
            this.Controls.Add(this.sellFishButton);
            this.Controls.Add(this.TravelButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SettingButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ShopButton);
            this.Controls.Add(this.MapButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.TransparencyKey = System.Drawing.Color.DimGray;
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected internal System.Windows.Forms.Label label2;
        protected internal System.Windows.Forms.Button MapButton;
        protected internal System.Windows.Forms.Button ShopButton;
        protected internal System.Windows.Forms.Button CloseButton;
        protected internal System.Windows.Forms.Button SettingButton;
        private System.Windows.Forms.Button TravelButton;
        private System.Windows.Forms.Button sellFishButton;
        private System.Windows.Forms.Button FoodShopButton;
    }
}