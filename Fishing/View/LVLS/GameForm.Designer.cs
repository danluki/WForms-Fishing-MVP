namespace Fishing.View.LVLS
{
    partial class GameForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainTimerTick = new System.Windows.Forms.Timer(this.components);
            this.soundPlayerTimer = new System.Windows.Forms.Timer(this.components);
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.decrementSatiety = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // mainTimerTick
            // 
            this.mainTimerTick.Enabled = true;
            this.mainTimerTick.Interval = 15;
            this.mainTimerTick.Tick += new System.EventHandler(this.MainTaskTimer_Tick);
            // 
            // soundPlayerTimer
            // 
            this.soundPlayerTimer.Enabled = true;
            this.soundPlayerTimer.Interval = 30000;
            this.soundPlayerTimer.Tick += new System.EventHandler(this.SoundPlayerTimer_Tick);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Enabled = true;
            this.refreshTimer.Interval = 15;
            // 
            // decrementSatiety
            // 
            this.decrementSatiety.Enabled = true;
            this.decrementSatiety.Interval = 30000;
            this.decrementSatiety.Tick += new System.EventHandler(this.DecrementSatiety_Tick);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fishing";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion
        protected internal System.Windows.Forms.Timer mainTimerTick;
        private System.Windows.Forms.Timer soundPlayerTimer;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.Timer decrementSatiety;
    }
}

