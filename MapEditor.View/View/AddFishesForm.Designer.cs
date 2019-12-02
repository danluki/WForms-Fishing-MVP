namespace MapEditor.View.View {
    partial class AddFishesForm {
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
            this.fishesBox = new System.Windows.Forms.ListBox();
            this.fishesGridView = new System.Windows.Forms.DataGridView();
            this.addButton = new System.Windows.Forms.Button();
            this.fishSetting = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.maxDeepText = new System.Windows.Forms.TextBox();
            this.minDeepText = new System.Windows.Forms.TextBox();
            this.baitsBox = new System.Windows.Forms.ListBox();
            this.sizeComboBox = new System.Windows.Forms.ComboBox();
            this.countTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fishNameLabel = new System.Windows.Forms.Label();
            this.saveButtonClick = new System.Windows.Forms.Button();
            this.totalCountLabel = new System.Windows.Forms.Label();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinDeepColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxDeepColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BaitColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.fishesGridView)).BeginInit();
            this.fishSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // fishesBox
            // 
            this.fishesBox.FormattingEnabled = true;
            this.fishesBox.Location = new System.Drawing.Point(765, 12);
            this.fishesBox.Name = "fishesBox";
            this.fishesBox.Size = new System.Drawing.Size(135, 433);
            this.fishesBox.TabIndex = 0;
            this.fishesBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FishesBox_MouseDoubleClick);
            // 
            // fishesGridView
            // 
            this.fishesGridView.AllowUserToDeleteRows = false;
            this.fishesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fishesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.CountColumn,
            this.SizeColumn,
            this.MinDeepColumn,
            this.MaxDeepColumn,
            this.BaitColumn});
            this.fishesGridView.Location = new System.Drawing.Point(12, 12);
            this.fishesGridView.Name = "fishesGridView";
            this.fishesGridView.Size = new System.Drawing.Size(747, 433);
            this.fishesGridView.TabIndex = 1;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(660, 447);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(99, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "<< Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // fishSetting
            // 
            this.fishSetting.Controls.Add(this.label2);
            this.fishSetting.Controls.Add(this.maxDeepText);
            this.fishSetting.Controls.Add(this.minDeepText);
            this.fishSetting.Controls.Add(this.baitsBox);
            this.fishSetting.Controls.Add(this.sizeComboBox);
            this.fishSetting.Controls.Add(this.countTextBox);
            this.fishSetting.Controls.Add(this.label1);
            this.fishSetting.Controls.Add(this.fishNameLabel);
            this.fishSetting.Location = new System.Drawing.Point(12, 473);
            this.fishSetting.Name = "fishSetting";
            this.fishSetting.Size = new System.Drawing.Size(610, 96);
            this.fishSetting.TabIndex = 4;
            this.fishSetting.TabStop = false;
            this.fishSetting.Text = "Инструменты";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "-";
            // 
            // maxDeepText
            // 
            this.maxDeepText.Location = new System.Drawing.Point(303, 59);
            this.maxDeepText.Name = "maxDeepText";
            this.maxDeepText.Size = new System.Drawing.Size(100, 20);
            this.maxDeepText.TabIndex = 6;
            // 
            // minDeepText
            // 
            this.minDeepText.Location = new System.Drawing.Point(181, 56);
            this.minDeepText.Name = "minDeepText";
            this.minDeepText.Size = new System.Drawing.Size(100, 20);
            this.minDeepText.TabIndex = 5;
            // 
            // baitsBox
            // 
            this.baitsBox.FormattingEnabled = true;
            this.baitsBox.Location = new System.Drawing.Point(414, 8);
            this.baitsBox.Name = "baitsBox";
            this.baitsBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.baitsBox.Size = new System.Drawing.Size(190, 82);
            this.baitsBox.TabIndex = 4;
            // 
            // sizeComboBox
            // 
            this.sizeComboBox.Items.AddRange(new object[] {
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
            this.sizeComboBox.Location = new System.Drawing.Point(287, 31);
            this.sizeComboBox.Name = "sizeComboBox";
            this.sizeComboBox.Size = new System.Drawing.Size(121, 21);
            this.sizeComboBox.TabIndex = 3;
            // 
            // countTextBox
            // 
            this.countTextBox.Location = new System.Drawing.Point(181, 32);
            this.countTextBox.Name = "countTextBox";
            this.countTextBox.Size = new System.Drawing.Size(100, 20);
            this.countTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Редактировать: ";
            // 
            // fishNameLabel
            // 
            this.fishNameLabel.AutoSize = true;
            this.fishNameLabel.Location = new System.Drawing.Point(199, 16);
            this.fishNameLabel.Name = "fishNameLabel";
            this.fishNameLabel.Size = new System.Drawing.Size(57, 13);
            this.fishNameLabel.TabIndex = 0;
            this.fishNameLabel.Text = "Название";
            // 
            // saveButtonClick
            // 
            this.saveButtonClick.Location = new System.Drawing.Point(812, 557);
            this.saveButtonClick.Name = "saveButtonClick";
            this.saveButtonClick.Size = new System.Drawing.Size(99, 23);
            this.saveButtonClick.TabIndex = 5;
            this.saveButtonClick.Text = "Сохранить";
            this.saveButtonClick.UseVisualStyleBackColor = true;
            this.saveButtonClick.Click += new System.EventHandler(this.SaveButtonClick_Click);
            // 
            // totalCountLabel
            // 
            this.totalCountLabel.AutoSize = true;
            this.totalCountLabel.Location = new System.Drawing.Point(612, 452);
            this.totalCountLabel.Name = "totalCountLabel";
            this.totalCountLabel.Size = new System.Drawing.Size(42, 13);
            this.totalCountLabel.TabIndex = 6;
            this.totalCountLabel.Text = "0/1000";
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Рыба";
            this.NameColumn.Name = "NameColumn";
            // 
            // CountColumn
            // 
            this.CountColumn.HeaderText = "Кол-во";
            this.CountColumn.Name = "CountColumn";
            // 
            // SizeColumn
            // 
            this.SizeColumn.HeaderText = "Размер (%)";
            this.SizeColumn.Name = "SizeColumn";
            // 
            // MinDeepColumn
            // 
            this.MinDeepColumn.HeaderText = "Мин. Глубина";
            this.MinDeepColumn.Name = "MinDeepColumn";
            // 
            // MaxDeepColumn
            // 
            this.MaxDeepColumn.HeaderText = "Макс. Глубина";
            this.MaxDeepColumn.Name = "MaxDeepColumn";
            // 
            // BaitColumn
            // 
            this.BaitColumn.HeaderText = "Приманки";
            this.BaitColumn.Name = "BaitColumn";
            // 
            // AddFishesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 581);
            this.Controls.Add(this.totalCountLabel);
            this.Controls.Add(this.saveButtonClick);
            this.Controls.Add(this.fishSetting);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.fishesGridView);
            this.Controls.Add(this.fishesBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddFishesForm";
            this.Text = "AddFishesForm";
            ((System.ComponentModel.ISupportInitialize)(this.fishesGridView)).EndInit();
            this.fishSetting.ResumeLayout(false);
            this.fishSetting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox fishesBox;
        private System.Windows.Forms.DataGridView fishesGridView;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.GroupBox fishSetting;
        private System.Windows.Forms.ListBox baitsBox;
        private System.Windows.Forms.ComboBox sizeComboBox;
        private System.Windows.Forms.TextBox countTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label fishNameLabel;
        private System.Windows.Forms.Button saveButtonClick;
        private System.Windows.Forms.Label totalCountLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox maxDeepText;
        private System.Windows.Forms.TextBox minDeepText;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinDeepColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxDeepColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BaitColumn;
    }
}