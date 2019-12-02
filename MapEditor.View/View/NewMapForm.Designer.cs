namespace MapEditor.View.View {
    partial class NewMapForm {
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            this.waterNameBox = new System.Windows.Forms.TextBox();
            this.pricePerDayBox = new System.Windows.Forms.TextBox();
            this.housePriceBox = new System.Windows.Forms.TextBox();
            this.levelNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.createButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.levelNumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 13);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(104, 13);
            label1.TabIndex = 0;
            label1.Text = "Название водоёма";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(13, 37);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(75, 13);
            label2.TabIndex = 1;
            label2.Text = "Цена за день";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(13, 64);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(91, 13);
            label3.TabIndex = 2;
            label3.Text = "Стоимость дома";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(13, 88);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(44, 13);
            label4.TabIndex = 3;
            label4.Text = "Разряд";
            // 
            // waterNameBox
            // 
            this.waterNameBox.Location = new System.Drawing.Point(188, 13);
            this.waterNameBox.Name = "waterNameBox";
            this.waterNameBox.Size = new System.Drawing.Size(220, 20);
            this.waterNameBox.TabIndex = 4;
            // 
            // pricePerDayBox
            // 
            this.pricePerDayBox.Location = new System.Drawing.Point(188, 39);
            this.pricePerDayBox.Name = "pricePerDayBox";
            this.pricePerDayBox.Size = new System.Drawing.Size(220, 20);
            this.pricePerDayBox.TabIndex = 5;
            // 
            // housePriceBox
            // 
            this.housePriceBox.Location = new System.Drawing.Point(188, 65);
            this.housePriceBox.Name = "housePriceBox";
            this.housePriceBox.Size = new System.Drawing.Size(220, 20);
            this.housePriceBox.TabIndex = 5;
            // 
            // levelNumUpDown
            // 
            this.levelNumUpDown.Location = new System.Drawing.Point(188, 92);
            this.levelNumUpDown.Name = "levelNumUpDown";
            this.levelNumUpDown.Size = new System.Drawing.Size(41, 20);
            this.levelNumUpDown.TabIndex = 6;
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(372, 321);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 7;
            this.createButton.Text = "Создать";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // NewMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 346);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.levelNumUpDown);
            this.Controls.Add(this.housePriceBox);
            this.Controls.Add(this.pricePerDayBox);
            this.Controls.Add(this.waterNameBox);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "NewMapForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NewMapForm";
            ((System.ComponentModel.ISupportInitialize)(this.levelNumUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox waterNameBox;
        private System.Windows.Forms.TextBox pricePerDayBox;
        private System.Windows.Forms.TextBox housePriceBox;
        private System.Windows.Forms.NumericUpDown levelNumUpDown;
        private System.Windows.Forms.Button createButton;
    }
}