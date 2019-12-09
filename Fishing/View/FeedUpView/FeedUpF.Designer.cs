namespace Fishing.View.FeedUpView {
    partial class FeedUpF {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeedUpF));
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            this.closeButton = new System.Windows.Forms.PictureBox();
            this.feedupBox = new System.Windows.Forms.PictureBox();
            this.createButton = new System.Windows.Forms.Button();
            this.feedsUpBox = new System.Windows.Forms.ListBox();
            this.aromaListsBox = new System.Windows.Forms.ListBox();
            this.baitsListBox = new System.Windows.Forms.ListBox();
            this.curFeedUpAromasBox = new System.Windows.Forms.ListBox();
            this.curFeedUpBaitBox = new System.Windows.Forms.ListBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.feedupBox)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("closeButton.BackgroundImage")));
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeButton.Location = new System.Drawing.Point(588, -2);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(27, 31);
            this.closeButton.TabIndex = 0;
            this.closeButton.TabStop = false;
            this.closeButton.Tag = "exit";
            this.closeButton.MouseEnter += new System.EventHandler(this.CloseButton_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.CloseButton_MouseLeave);
            // 
            // feedupBox
            // 
            this.feedupBox.Location = new System.Drawing.Point(36, 386);
            this.feedupBox.Name = "feedupBox";
            this.feedupBox.Size = new System.Drawing.Size(136, 95);
            this.feedupBox.TabIndex = 4;
            this.feedupBox.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Location = new System.Drawing.Point(77, 484);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(45, 13);
            label1.TabIndex = 5;
            label1.Text = "Основа";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label2.Location = new System.Drawing.Point(195, 409);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(37, 39);
            label2.TabIndex = 6;
            label2.Text = "+";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label3.Location = new System.Drawing.Point(400, 409);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(37, 39);
            label3.TabIndex = 8;
            label3.Text = "+";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Location = new System.Drawing.Point(276, 484);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(88, 13);
            label4.TabIndex = 10;
            label4.Text = "Ароматизаторы";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.Location = new System.Drawing.Point(492, 484);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(53, 13);
            label5.TabIndex = 11;
            label5.Text = "Наживка";
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(36, 500);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(546, 23);
            this.createButton.TabIndex = 12;
            this.createButton.Text = "Собрать";
            this.createButton.UseVisualStyleBackColor = true;
            // 
            // feedsUpBox
            // 
            this.feedsUpBox.FormattingEnabled = true;
            this.feedsUpBox.Location = new System.Drawing.Point(36, 23);
            this.feedsUpBox.Name = "feedsUpBox";
            this.feedsUpBox.Size = new System.Drawing.Size(546, 108);
            this.feedsUpBox.TabIndex = 13;
            // 
            // aromaListsBox
            // 
            this.aromaListsBox.FormattingEnabled = true;
            this.aromaListsBox.Location = new System.Drawing.Point(36, 147);
            this.aromaListsBox.Name = "aromaListsBox";
            this.aromaListsBox.Size = new System.Drawing.Size(546, 108);
            this.aromaListsBox.TabIndex = 14;
            // 
            // baitsListBox
            // 
            this.baitsListBox.FormattingEnabled = true;
            this.baitsListBox.Location = new System.Drawing.Point(36, 261);
            this.baitsListBox.Name = "baitsListBox";
            this.baitsListBox.Size = new System.Drawing.Size(546, 108);
            this.baitsListBox.TabIndex = 15;
            // 
            // curFeedUpAromasBox
            // 
            this.curFeedUpAromasBox.FormattingEnabled = true;
            this.curFeedUpAromasBox.Location = new System.Drawing.Point(248, 386);
            this.curFeedUpAromasBox.Name = "curFeedUpAromasBox";
            this.curFeedUpAromasBox.Size = new System.Drawing.Size(132, 95);
            this.curFeedUpAromasBox.TabIndex = 16;
            // 
            // curFeedUpBaitBox
            // 
            this.curFeedUpBaitBox.FormattingEnabled = true;
            this.curFeedUpBaitBox.Location = new System.Drawing.Point(443, 386);
            this.curFeedUpBaitBox.Name = "curFeedUpBaitBox";
            this.curFeedUpBaitBox.Size = new System.Drawing.Size(132, 95);
            this.curFeedUpBaitBox.TabIndex = 17;
            // 
            // FeedUpF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Fishing.Properties.Resources.layer10;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(617, 542);
            this.Controls.Add(this.curFeedUpBaitBox);
            this.Controls.Add(this.curFeedUpAromasBox);
            this.Controls.Add(this.baitsListBox);
            this.Controls.Add(this.aromaListsBox);
            this.Controls.Add(this.feedsUpBox);
            this.Controls.Add(this.createButton);
            this.Controls.Add(label5);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.feedupBox);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FeedUpF";
            this.Tag = "";
            this.Text = "FeedUpF";
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.feedupBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox closeButton;
        private System.Windows.Forms.PictureBox feedupBox;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.ListBox feedsUpBox;
        private System.Windows.Forms.ListBox aromaListsBox;
        private System.Windows.Forms.ListBox baitsListBox;
        private System.Windows.Forms.ListBox curFeedUpAromasBox;
        private System.Windows.Forms.ListBox curFeedUpBaitBox;
    }
}