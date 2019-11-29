namespace MapEditor.View {
    partial class CreateLocationForm {
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
            this.percentNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.locNameBox = new System.Windows.Forms.TextBox();
            this.undoButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.percentNumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 13);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(57, 13);
            label1.TabIndex = 0;
            label1.Text = "Название";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(13, 48);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(98, 13);
            label2.TabIndex = 2;
            label2.Text = "Качество клёва %";
            // 
            // percentNumUpDown
            // 
            this.percentNumUpDown.Location = new System.Drawing.Point(117, 46);
            this.percentNumUpDown.Name = "percentNumUpDown";
            this.percentNumUpDown.Size = new System.Drawing.Size(199, 20);
            this.percentNumUpDown.TabIndex = 3;
            // 
            // locNameBox
            // 
            this.locNameBox.Location = new System.Drawing.Point(77, 13);
            this.locNameBox.Name = "locNameBox";
            this.locNameBox.Size = new System.Drawing.Size(239, 20);
            this.locNameBox.TabIndex = 4;
            // 
            // undoButton
            // 
            this.undoButton.Location = new System.Drawing.Point(166, 85);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(75, 23);
            this.undoButton.TabIndex = 5;
            this.undoButton.Text = "Отмена";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(247, 85);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 6;
            this.createButton.Text = "Создать";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // CreateLocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 109);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.undoButton);
            this.Controls.Add(this.locNameBox);
            this.Controls.Add(this.percentNumUpDown);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Name = "CreateLocationForm";
            this.Text = "CreateLocationForm";
            ((System.ComponentModel.ISupportInitialize)(this.percentNumUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown percentNumUpDown;
        private System.Windows.Forms.TextBox locNameBox;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.Button createButton;
    }
}