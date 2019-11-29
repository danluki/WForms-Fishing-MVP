namespace MapEditor.View {
    partial class ChangeLocationForm {
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
            System.Windows.Forms.Label label5;
            this.locationImageBox = new System.Windows.Forms.PictureBox();
            this.graphicBox = new System.Windows.Forms.GroupBox();
            this.deepTextBox = new System.Windows.Forms.TextBox();
            this.setSnagButton = new System.Windows.Forms.RadioButton();
            this.setDeepButton = new System.Windows.Forms.RadioButton();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nibbleComboBox = new System.Windows.Forms.ComboBox();
            this.uploadImageButton = new System.Windows.Forms.Button();
            this.setDeepsButton = new System.Windows.Forms.Button();
            this.addFishesButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.undoButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.generateButtonClick = new System.Windows.Forms.Button();
            this.filterComboBox = new System.Windows.Forms.ComboBox();
            this.maxDeepTextBox = new System.Windows.Forms.TextBox();
            this.minDeepTextBox = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.locationImageBox)).BeginInit();
            this.graphicBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 607);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(57, 13);
            label1.TabIndex = 2;
            label1.Text = "Название";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 634);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(46, 13);
            label2.TabIndex = 4;
            label2.Text = "Клёв % ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(6, 16);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(75, 13);
            label3.TabIndex = 12;
            label3.Text = "Мин. Глубина";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(178, 16);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(81, 13);
            label4.TabIndex = 14;
            label4.Text = "Макс. Глубина";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(6, 47);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(47, 13);
            label5.TabIndex = 16;
            label5.Text = "Фильтр";
            // 
            // locationImageBox
            // 
            this.locationImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.locationImageBox.Location = new System.Drawing.Point(0, 0);
            this.locationImageBox.Name = "locationImageBox";
            this.locationImageBox.Size = new System.Drawing.Size(1024, 600);
            this.locationImageBox.TabIndex = 0;
            this.locationImageBox.TabStop = false;
            this.locationImageBox.Paint += new System.Windows.Forms.PaintEventHandler(this.LocationImageBox_Paint);
            this.locationImageBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LocationImageBox_MouseDown);
            this.locationImageBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LocationImageBox_MouseMove);
            this.locationImageBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LocationImageBox_MouseUp);
            // 
            // graphicBox
            // 
            this.graphicBox.Controls.Add(this.deepTextBox);
            this.graphicBox.Controls.Add(this.setSnagButton);
            this.graphicBox.Controls.Add(this.setDeepButton);
            this.graphicBox.Location = new System.Drawing.Point(404, 607);
            this.graphicBox.Name = "graphicBox";
            this.graphicBox.Size = new System.Drawing.Size(200, 100);
            this.graphicBox.TabIndex = 1;
            this.graphicBox.TabStop = false;
            this.graphicBox.Text = "Кисть";
            // 
            // deepTextBox
            // 
            this.deepTextBox.Location = new System.Drawing.Point(133, 20);
            this.deepTextBox.Name = "deepTextBox";
            this.deepTextBox.Size = new System.Drawing.Size(61, 20);
            this.deepTextBox.TabIndex = 2;
            // 
            // setSnagButton
            // 
            this.setSnagButton.AutoSize = true;
            this.setSnagButton.Location = new System.Drawing.Point(6, 43);
            this.setSnagButton.Name = "setSnagButton";
            this.setSnagButton.Size = new System.Drawing.Size(122, 17);
            this.setSnagButton.TabIndex = 1;
            this.setSnagButton.TabStop = true;
            this.setSnagButton.Text = "Установить корягу";
            this.setSnagButton.UseVisualStyleBackColor = true;
            // 
            // setDeepButton
            // 
            this.setDeepButton.AutoSize = true;
            this.setDeepButton.Location = new System.Drawing.Point(7, 20);
            this.setDeepButton.Name = "setDeepButton";
            this.setDeepButton.Size = new System.Drawing.Size(127, 17);
            this.setDeepButton.TabIndex = 0;
            this.setDeepButton.TabStop = true;
            this.setDeepButton.Text = "Установить глубину";
            this.setDeepButton.UseVisualStyleBackColor = true;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(76, 607);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 3;
            // 
            // nibbleComboBox
            // 
            this.nibbleComboBox.FormattingEnabled = true;
            this.nibbleComboBox.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55",
            "60",
            "65",
            "70",
            "75",
            "80",
            "85",
            "90",
            "95",
            "100"});
            this.nibbleComboBox.Location = new System.Drawing.Point(76, 634);
            this.nibbleComboBox.Name = "nibbleComboBox";
            this.nibbleComboBox.Size = new System.Drawing.Size(100, 21);
            this.nibbleComboBox.TabIndex = 5;
            // 
            // uploadImageButton
            // 
            this.uploadImageButton.Location = new System.Drawing.Point(0, 684);
            this.uploadImageButton.Name = "uploadImageButton";
            this.uploadImageButton.Size = new System.Drawing.Size(92, 23);
            this.uploadImageButton.TabIndex = 6;
            this.uploadImageButton.Text = "Загрузить фон";
            this.uploadImageButton.UseVisualStyleBackColor = true;
            this.uploadImageButton.Click += new System.EventHandler(this.UploadImageButton_Click);
            // 
            // setDeepsButton
            // 
            this.setDeepsButton.Location = new System.Drawing.Point(98, 684);
            this.setDeepsButton.Name = "setDeepsButton";
            this.setDeepsButton.Size = new System.Drawing.Size(92, 23);
            this.setDeepsButton.TabIndex = 7;
            this.setDeepsButton.Text = "Посторить дно";
            this.setDeepsButton.UseVisualStyleBackColor = true;
            this.setDeepsButton.Click += new System.EventHandler(this.SetDeepsButton_Click);
            // 
            // addFishesButton
            // 
            this.addFishesButton.Location = new System.Drawing.Point(196, 684);
            this.addFishesButton.Name = "addFishesButton";
            this.addFishesButton.Size = new System.Drawing.Size(113, 23);
            this.addFishesButton.TabIndex = 8;
            this.addFishesButton.Text = "Добавить рыбу";
            this.addFishesButton.UseVisualStyleBackColor = true;
            this.addFishesButton.Click += new System.EventHandler(this.AddFishesButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(865, 684);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // undoButton
            // 
            this.undoButton.Location = new System.Drawing.Point(946, 684);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(75, 23);
            this.undoButton.TabIndex = 10;
            this.undoButton.Text = "Отмена";
            this.undoButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.generateButtonClick);
            this.groupBox1.Controls.Add(this.filterComboBox);
            this.groupBox1.Controls.Add(label5);
            this.groupBox1.Controls.Add(this.maxDeepTextBox);
            this.groupBox1.Controls.Add(label4);
            this.groupBox1.Controls.Add(this.minDeepTextBox);
            this.groupBox1.Controls.Add(label3);
            this.groupBox1.Location = new System.Drawing.Point(610, 607);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 73);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Автоматическая генерация глубин";
            // 
            // generateButtonClick
            // 
            this.generateButtonClick.Location = new System.Drawing.Point(165, 41);
            this.generateButtonClick.Name = "generateButtonClick";
            this.generateButtonClick.Size = new System.Drawing.Size(160, 23);
            this.generateButtonClick.TabIndex = 12;
            this.generateButtonClick.Text = "Сгенерировать";
            this.generateButtonClick.UseVisualStyleBackColor = true;
            this.generateButtonClick.Click += new System.EventHandler(this.GenerateButtonClick_Click);
            // 
            // filterComboBox
            // 
            this.filterComboBox.FormattingEnabled = true;
            this.filterComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.filterComboBox.Location = new System.Drawing.Point(88, 43);
            this.filterComboBox.Name = "filterComboBox";
            this.filterComboBox.Size = new System.Drawing.Size(60, 21);
            this.filterComboBox.TabIndex = 12;
            // 
            // maxDeepTextBox
            // 
            this.maxDeepTextBox.Location = new System.Drawing.Point(265, 16);
            this.maxDeepTextBox.Name = "maxDeepTextBox";
            this.maxDeepTextBox.Size = new System.Drawing.Size(60, 20);
            this.maxDeepTextBox.TabIndex = 15;
            // 
            // minDeepTextBox
            // 
            this.minDeepTextBox.Location = new System.Drawing.Point(88, 16);
            this.minDeepTextBox.Name = "minDeepTextBox";
            this.minDeepTextBox.Size = new System.Drawing.Size(60, 20);
            this.minDeepTextBox.TabIndex = 13;
            // 
            // ChangeLocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 714);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.undoButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.addFishesButton);
            this.Controls.Add(this.setDeepsButton);
            this.Controls.Add(this.uploadImageButton);
            this.Controls.Add(this.nibbleComboBox);
            this.Controls.Add(label2);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(label1);
            this.Controls.Add(this.graphicBox);
            this.Controls.Add(this.locationImageBox);
            this.Name = "ChangeLocationForm";
            this.Text = "Локация - ";
            ((System.ComponentModel.ISupportInitialize)(this.locationImageBox)).EndInit();
            this.graphicBox.ResumeLayout(false);
            this.graphicBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox locationImageBox;
        private System.Windows.Forms.GroupBox graphicBox;
        private System.Windows.Forms.TextBox deepTextBox;
        private System.Windows.Forms.RadioButton setSnagButton;
        private System.Windows.Forms.RadioButton setDeepButton;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.ComboBox nibbleComboBox;
        private System.Windows.Forms.Button uploadImageButton;
        private System.Windows.Forms.Button setDeepsButton;
        private System.Windows.Forms.Button addFishesButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox filterComboBox;
        private System.Windows.Forms.TextBox maxDeepTextBox;
        private System.Windows.Forms.TextBox minDeepTextBox;
        private System.Windows.Forms.Button generateButtonClick;
    }
}