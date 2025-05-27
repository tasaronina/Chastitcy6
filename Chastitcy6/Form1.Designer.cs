// Form1.Designer.cs
using System.Drawing;
using System.Windows.Forms;
using System;

namespace Chastitcy6
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        public PictureBox picDisplay;
        public Timer timer1;
        public Panel panel1;
        public TrackBar trkAngle;
        public Label lblAngleValue;
        public TrackBar trkPower;
        public Label lblPowerValue;
        public Button btnAddGate;
        public Button btnAddGravity;
        public Label lblScore;
        public Label lblTime;
        public Label lblHint;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picDisplay = new PictureBox();
            this.timer1 = new Timer(this.components);
            this.panel1 = new Panel();
            this.trkAngle = new TrackBar();
            this.lblAngleValue = new Label();
            this.trkPower = new TrackBar();
            this.lblPowerValue = new Label();
            this.btnAddGate = new Button();
            this.btnAddGravity = new Button();
            this.lblScore = new Label();
            this.lblTime = new Label();
            this.lblHint = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkPower)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();

            // picDisplay
            this.picDisplay.Location = new Point(12, 12);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new Size(624, 485);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            this.picDisplay.Paint += new PaintEventHandler(this.picDisplay_Paint);
            this.picDisplay.MouseClick += new MouseEventHandler(this.picDisplay_MouseClick);

            // timer1
            this.timer1.Interval = 40;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);

            // panel1
            this.panel1.Controls.Add(this.lblHint);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.lblScore);
            this.panel1.Controls.Add(this.btnAddGravity);
            this.panel1.Controls.Add(this.btnAddGate);
            this.panel1.Controls.Add(this.lblPowerValue);
            this.panel1.Controls.Add(this.trkPower);
            this.panel1.Controls.Add(this.lblAngleValue);
            this.panel1.Controls.Add(this.trkAngle);
            this.panel1.Dock = DockStyle.Right;
            this.panel1.Location = new Point(654, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(360, 522);
            this.panel1.TabIndex = 1;

            // trkAngle
            this.trkAngle.Location = new Point(10, 15);
            this.trkAngle.Maximum = 360;
            this.trkAngle.TickFrequency = 45;
            this.trkAngle.Name = "trkAngle";
            this.trkAngle.Size = new Size(200, 45);
            this.trkAngle.Value = 270;

            // lblAngleValue
            this.lblAngleValue.AutoSize = true;
            this.lblAngleValue.Location = new Point(220, 15);
            this.lblAngleValue.Name = "lblAngleValue";
            this.lblAngleValue.Text = "270";

            // trkPower
            this.trkPower.Location = new Point(10, 70);
            this.trkPower.Minimum = 1;
            this.trkPower.Maximum = 100;
            this.trkPower.TickFrequency = 10;
            this.trkPower.Name = "trkPower";
            this.trkPower.Size = new Size(200, 45);
            this.trkPower.Value = 20;

            // lblPowerValue
            this.lblPowerValue.AutoSize = true;
            this.lblPowerValue.Location = new Point(220, 70);
            this.lblPowerValue.Name = "lblPowerValue";
            this.lblPowerValue.Text = "20";

            // btnAddGate
            this.btnAddGate.Location = new Point(10, 125);
            this.btnAddGate.Name = "btnAddGate";
            this.btnAddGate.Size = new Size(232, 30);
            this.btnAddGate.Text = "Добавить шлюз";
            this.btnAddGate.UseVisualStyleBackColor = true;

            // btnAddGravity
            this.btnAddGravity.Location = new Point(10, 165);
            this.btnAddGravity.Name = "btnAddGravity";
            this.btnAddGravity.Size = new Size(232, 30);
            this.btnAddGravity.Text = "Добавить гравитон";
            this.btnAddGravity.UseVisualStyleBackColor = true;

            // lblScore
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new Point(10, 220);
            this.lblScore.Name = "lblScore";
            this.lblScore.Text = "Счёт: 0";

            // lblTime
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new Point(10, 250);
            this.lblTime.Name = "lblTime";
            this.lblTime.Text = "Время: 00:00";

            // lblHint
            this.lblHint.AutoSize = true;
            this.lblHint.Location = new Point(10, 285);
            this.lblHint.Name = "lblHint";
            this.lblHint.Text = "L-клик: вход шлюза\nR-клик: выход шлюза";

            // Form1
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1037, 522);
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
    }
}
