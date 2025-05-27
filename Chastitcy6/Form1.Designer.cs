namespace Chastitcy6
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnPumpToggle;
        private System.Windows.Forms.Button btnPlaceDrain;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ProgressBar prgWater;
        private System.Windows.Forms.Label lblWaterPercent;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.ProgressBar prgOverheat;
        private System.Windows.Forms.Label lblOverheat;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnPumpToggle = new System.Windows.Forms.Button();
            this.btnPlaceDrain = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.prgWater = new System.Windows.Forms.ProgressBar();
            this.lblWaterPercent = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.prgOverheat = new System.Windows.Forms.ProgressBar();
            this.lblOverheat = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.Location = new System.Drawing.Point(12, 12);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(800, 480);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            this.picDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.PicDisplay_Paint);
            this.picDisplay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PicDisplay_MouseClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // btnPumpToggle
            // 
            this.btnPumpToggle.Location = new System.Drawing.Point(830, 30);
            this.btnPumpToggle.Name = "btnPumpToggle";
            this.btnPumpToggle.Size = new System.Drawing.Size(200, 30);
            this.btnPumpToggle.TabIndex = 1;
            this.btnPumpToggle.Text = "Запустить насос";
            this.btnPumpToggle.UseVisualStyleBackColor = true;
            this.btnPumpToggle.Click += new System.EventHandler(this.BtnPumpToggle_Click);
            // 
            // btnPlaceDrain
            // 
            this.btnPlaceDrain.Location = new System.Drawing.Point(830, 70);
            this.btnPlaceDrain.Name = "btnPlaceDrain";
            this.btnPlaceDrain.Size = new System.Drawing.Size(200, 30);
            this.btnPlaceDrain.TabIndex = 2;
            this.btnPlaceDrain.Text = "Разместить осушитель";
            this.btnPlaceDrain.UseVisualStyleBackColor = true;
            this.btnPlaceDrain.Click += new System.EventHandler(this.BtnPlaceDrain_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(830, 110);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(200, 30);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Сброс";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // prgWater
            // 
            this.prgWater.Location = new System.Drawing.Point(830, 160);
            this.prgWater.Name = "prgWater";
            this.prgWater.Size = new System.Drawing.Size(200, 23);
            this.prgWater.TabIndex = 4;
            // 
            // lblWaterPercent
            // 
            this.lblWaterPercent.AutoSize = true;
            this.lblWaterPercent.Location = new System.Drawing.Point(1040, 160);
            this.lblWaterPercent.Name = "lblWaterPercent";
            this.lblWaterPercent.Size = new System.Drawing.Size(24, 16);
            this.lblWaterPercent.TabIndex = 5;
            this.lblWaterPercent.Text = "0%";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(830, 200);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(64, 16);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "Время: 0";
            // 
            // lblOverheat
            // 
            this.lblOverheat.AutoSize = true;
            this.lblOverheat.Location = new System.Drawing.Point(830, 230);
            this.lblOverheat.Name = "lblOverheat";
            this.lblOverheat.Size = new System.Drawing.Size(82, 16);
            this.lblOverheat.TabIndex = 7;
            this.lblOverheat.Text = "Перегрев: 0";
            // 
            // prgOverheat
            // 
            this.prgOverheat.Location = new System.Drawing.Point(830, 250);
            this.prgOverheat.Name = "prgOverheat";
            this.prgOverheat.Size = new System.Drawing.Size(200, 23);
            this.prgOverheat.TabIndex = 8;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(830, 290);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(47, 16);
            this.lblScore.TabIndex = 9;
            this.lblScore.Text = "Счёт: ";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1100, 510);
            this.Controls.Add(this.picDisplay);
            this.Controls.Add(this.btnPumpToggle);
            this.Controls.Add(this.btnPlaceDrain);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.prgWater);
            this.Controls.Add(this.lblWaterPercent);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblOverheat);
            this.Controls.Add(this.prgOverheat);
            this.Controls.Add(this.lblScore);
            this.Name = "Form1";
            this.Text = "Повелитель Потопа";
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
