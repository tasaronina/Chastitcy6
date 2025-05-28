namespace Chastitcy6
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar trkFlowSpeed;
        private System.Windows.Forms.Label lblFlowSpeed;
        private System.Windows.Forms.Button btnPlaceDrain;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ProgressBar prgWater;
        private System.Windows.Forms.Label lblWaterPercent;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblHammerCount;
        private System.Windows.Forms.Button btnUseHammer;
        private System.Windows.Forms.Label lblCryoCount;
        private System.Windows.Forms.Button btnUseCryo;

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
            this.trkFlowSpeed = new System.Windows.Forms.TrackBar();
            this.lblFlowSpeed = new System.Windows.Forms.Label();
            this.btnPlaceDrain = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.prgWater = new System.Windows.Forms.ProgressBar();
            this.lblWaterPercent = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblHammerCount = new System.Windows.Forms.Label();
            this.btnUseHammer = new System.Windows.Forms.Button();
            this.lblCryoCount = new System.Windows.Forms.Label();
            this.btnUseCryo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkFlowSpeed)).BeginInit();
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
            // trkFlowSpeed
            // 
            this.trkFlowSpeed.Location = new System.Drawing.Point(830, 19);
            this.trkFlowSpeed.Maximum = 20;
            this.trkFlowSpeed.Minimum = 1;
            this.trkFlowSpeed.Name = "trkFlowSpeed";
            this.trkFlowSpeed.Size = new System.Drawing.Size(200, 56);
            this.trkFlowSpeed.TabIndex = 1;
            this.trkFlowSpeed.Value = 2;
            this.trkFlowSpeed.Scroll += new System.EventHandler(this.TrkFlowSpeed_Scroll);
            // 
            // lblFlowSpeed
            // 
            this.lblFlowSpeed.AutoSize = true;
            this.lblFlowSpeed.Location = new System.Drawing.Point(830, 0);
            this.lblFlowSpeed.Name = "lblFlowSpeed";
            this.lblFlowSpeed.Size = new System.Drawing.Size(130, 16);
            this.lblFlowSpeed.TabIndex = 2;
            this.lblFlowSpeed.Text = "Скорость потока: 2";
            // 
            // btnPlaceDrain
            // 
            this.btnPlaceDrain.Location = new System.Drawing.Point(830, 81);
            this.btnPlaceDrain.Name = "btnPlaceDrain";
            this.btnPlaceDrain.Size = new System.Drawing.Size(200, 43);
            this.btnPlaceDrain.TabIndex = 3;
            this.btnPlaceDrain.Text = "Разместить осушитель";
            this.btnPlaceDrain.Click += new System.EventHandler(this.BtnPlaceDrain_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(830, 133);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(200, 30);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Сброс";
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // prgWater
            // 
            this.prgWater.Location = new System.Drawing.Point(830, 179);
            this.prgWater.Name = "prgWater";
            this.prgWater.Size = new System.Drawing.Size(200, 37);
            this.prgWater.TabIndex = 5;
            // 
            // lblWaterPercent
            // 
            this.lblWaterPercent.AutoSize = true;
            this.lblWaterPercent.Location = new System.Drawing.Point(1036, 179);
            this.lblWaterPercent.Name = "lblWaterPercent";
            this.lblWaterPercent.Size = new System.Drawing.Size(26, 16);
            this.lblWaterPercent.TabIndex = 6;
            this.lblWaterPercent.Text = "0%";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTime.Location = new System.Drawing.Point(864, 229);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(96, 25);
            this.lblTime.TabIndex = 7;
            this.lblTime.Text = "Время: 0";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScore.Location = new System.Drawing.Point(879, 270);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(81, 25);
            this.lblScore.TabIndex = 8;
            this.lblScore.Text = "Счёт: 0";
            // 
            // lblHammerCount
            // 
            this.lblHammerCount.AutoSize = true;
            this.lblHammerCount.Location = new System.Drawing.Point(830, 313);
            this.lblHammerCount.Name = "lblHammerCount";
            this.lblHammerCount.Size = new System.Drawing.Size(85, 16);
            this.lblHammerCount.TabIndex = 9;
            this.lblHammerCount.Text = "Молотков: 0";
            // 
            // btnUseHammer
            // 
            this.btnUseHammer.Enabled = false;
            this.btnUseHammer.Location = new System.Drawing.Point(830, 332);
            this.btnUseHammer.Name = "btnUseHammer";
            this.btnUseHammer.Size = new System.Drawing.Size(200, 64);
            this.btnUseHammer.TabIndex = 10;
            this.btnUseHammer.Text = "Использовать Молоток";
            this.btnUseHammer.Click += new System.EventHandler(this.BtnUseHammer_Click);
            // 
            // lblCryoCount
            // 
            this.lblCryoCount.AutoSize = true;
            this.lblCryoCount.Location = new System.Drawing.Point(830, 415);
            this.lblCryoCount.Name = "lblCryoCount";
            this.lblCryoCount.Size = new System.Drawing.Size(52, 16);
            this.lblCryoCount.TabIndex = 11;
            this.lblCryoCount.Text = "Крио: 0";
            // 
            // btnUseCryo
            // 
            this.btnUseCryo.Enabled = false;
            this.btnUseCryo.Location = new System.Drawing.Point(833, 434);
            this.btnUseCryo.Name = "btnUseCryo";
            this.btnUseCryo.Size = new System.Drawing.Size(200, 70);
            this.btnUseCryo.TabIndex = 12;
            this.btnUseCryo.Text = "Использовать Крио";
            this.btnUseCryo.Click += new System.EventHandler(this.BtnUseCryo_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1100, 516);
            this.Controls.Add(this.picDisplay);
            this.Controls.Add(this.trkFlowSpeed);
            this.Controls.Add(this.lblFlowSpeed);
            this.Controls.Add(this.btnPlaceDrain);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.prgWater);
            this.Controls.Add(this.lblWaterPercent);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblHammerCount);
            this.Controls.Add(this.btnUseHammer);
            this.Controls.Add(this.lblCryoCount);
            this.Controls.Add(this.btnUseCryo);
            this.Name = "Form1";
            this.Text = "Повелитель Потопа";
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkFlowSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
