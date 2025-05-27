namespace Chastitcy6
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        public System.Windows.Forms.PictureBox picDisplay;
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TrackBar trkAngle;
        public System.Windows.Forms.Label lblAngleValue;
        public System.Windows.Forms.TrackBar trkPower;
        public System.Windows.Forms.Label lblPowerValue;
        public System.Windows.Forms.Button btnAddGate;
        public System.Windows.Forms.Button btnAddGravity;
        public System.Windows.Forms.Label lblScore;
        public System.Windows.Forms.Label lblTime;
        public System.Windows.Forms.Label lblHint;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.trkAngle = new System.Windows.Forms.TrackBar();
            this.lblAngleValue = new System.Windows.Forms.Label();
            this.trkPower = new System.Windows.Forms.TrackBar();
            this.lblPowerValue = new System.Windows.Forms.Label();
            this.btnAddGate = new System.Windows.Forms.Button();
            this.btnAddGravity = new System.Windows.Forms.Button();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkPower)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();

            // 
            // picDisplay
            // 
            this.picDisplay.Location = new System.Drawing.Point(12, 12);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(624, 485);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            this.picDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.picDisplay_Paint);
            this.picDisplay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PicDisplay_MouseClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblHint);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.lblScore);
            this.panel1.Controls.Add(this.btnAddGravity);
            this.panel1.Controls.Add(this.btnAddGate);
            this.panel1.Controls.Add(this.lblPowerValue);
            this.panel1.Controls.Add(this.trkPower);
            this.panel1.Controls.Add(this.lblAngleValue);
            this.panel1.Controls.Add(this.trkAngle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(654, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 522);
            this.panel1.TabIndex = 1;
            // 
            // trkAngle
            // 
            this.trkAngle.Location = new System.Drawing.Point(10, 15);
            this.trkAngle.Maximum = 360;
            this.trkAngle.TickFrequency = 45;
            this.trkAngle.Name = "trkAngle";
            this.trkAngle.Size = new System.Drawing.Size(200, 45);
            this.trkAngle.TabIndex = 2;
            this.trkAngle.Scroll += new System.EventHandler(this.trkAngle_Scroll);
            // 
            // lblAngleValue
            // 
            this.lblAngleValue.AutoSize = true;
            this.lblAngleValue.Location = new System.Drawing.Point(220, 15);
            this.lblAngleValue.Name = "lblAngleValue";
            this.lblAngleValue.Size = new System.Drawing.Size(14, 16);
            this.lblAngleValue.Text = "0";
            // 
            // trkPower
            // 
            this.trkPower.Location = new System.Drawing.Point(10, 70);
            this.trkPower.Minimum = 1;
            this.trkPower.Maximum = 100;
            this.trkPower.TickFrequency = 10;
            this.trkPower.Name = "trkPower";
            this.trkPower.Size = new System.Drawing.Size(200, 45);
            this.trkPower.TabIndex = 3;
            this.trkPower.Value = 20;
            this.trkPower.Scroll += new System.EventHandler(this.trkPower_Scroll);
            // 
            // lblPowerValue
            // 
            this.lblPowerValue.AutoSize = true;
            this.lblPowerValue.Location = new System.Drawing.Point(220, 70);
            this.lblPowerValue.Name = "lblPowerValue";
            this.lblPowerValue.Size = new System.Drawing.Size(21, 16);
            this.lblPowerValue.Text = "20";
            // 
            // btnAddGate
            // 
            this.btnAddGate.Location = new System.Drawing.Point(10, 125);
            this.btnAddGate.Name = "btnAddGate";
            this.btnAddGate.Size = new System.Drawing.Size(232, 30);
            this.btnAddGate.TabIndex = 4;
            this.btnAddGate.Text = "Добавить шлюз";
            this.btnAddGate.UseVisualStyleBackColor = true;
            this.btnAddGate.Click += new System.EventHandler(this.btnAddGate_Click);
            // 
            // btnAddGravity
            // 
            this.btnAddGravity.Location = new System.Drawing.Point(10, 165);
            this.btnAddGravity.Name = "btnAddGravity";
            this.btnAddGravity.Size = new System.Drawing.Size(232, 30);
            this.btnAddGravity.TabIndex = 5;
            this.btnAddGravity.Text = "Добавить гравитон";
            this.btnAddGravity.UseVisualStyleBackColor = true;
            this.btnAddGravity.Click += new System.EventHandler(this.btnAddGravity_Click);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(10, 220);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(81, 16);
            this.lblScore.Text = "Счёт: 0";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(10, 250);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(79, 16);
            this.lblTime.Text = "Время: 00:00";
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.Location = new System.Drawing.Point(10, 285);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(200, 32);
            this.lblHint.Text = "L-клик: вход шлюза\nR-клик: выход шлюза";

            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 522);
            this.Controls.Add(this.picDisplay);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Повелитель Потопа";

            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkPower)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
