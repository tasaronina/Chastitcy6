namespace Chastitcy6
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar trkAngle;
        private System.Windows.Forms.Label lblAngleValue;
        private System.Windows.Forms.TrackBar trkPower;
        private System.Windows.Forms.Label lblPowerValue;
        private System.Windows.Forms.Button btnAddGravity;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.ProgressBar prgWaterLevel;
        private System.Windows.Forms.Label lblWaterPercent;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Panel panel1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trkAngle = new System.Windows.Forms.TrackBar();
            this.lblAngleValue = new System.Windows.Forms.Label();
            this.trkPower = new System.Windows.Forms.TrackBar();
            this.lblPowerValue = new System.Windows.Forms.Label();
            this.btnAddGravity = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.prgWaterLevel = new System.Windows.Forms.ProgressBar();
            this.lblWaterPercent = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkPower)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();

            // picDisplay
            this.picDisplay.Location = new System.Drawing.Point(12, 12);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(624, 485);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;

            // trkAngle
            this.trkAngle.Location = new System.Drawing.Point(10, 10);
            this.trkAngle.Maximum = 360;
            this.trkAngle.TickFrequency = 45;
            this.trkAngle.Name = "trkAngle";
            this.trkAngle.Size = new System.Drawing.Size(200, 45);
            this.trkAngle.Value = 270;

            // lblAngleValue
            this.lblAngleValue.AutoSize = true;
            this.lblAngleValue.Location = new System.Drawing.Point(220, 10);
            this.lblAngleValue.Name = "lblAngleValue";
            this.lblAngleValue.Text = "270";

            // trkPower
            this.trkPower.Location = new System.Drawing.Point(10, 60);
            this.trkPower.Minimum = 1;
            this.trkPower.Maximum = 100;
            this.trkPower.TickFrequency = 10;
            this.trkPower.Name = "trkPower";
            this.trkPower.Size = new System.Drawing.Size(200, 45);
            this.trkPower.Value = 20;

            // lblPowerValue
            this.lblPowerValue.AutoSize = true;
            this.lblPowerValue.Location = new System.Drawing.Point(220, 60);
            this.lblPowerValue.Name = "lblPowerValue";
            this.lblPowerValue.Text = "20";

            // btnAddGravity
            this.btnAddGravity.Location = new System.Drawing.Point(10, 115);
            this.btnAddGravity.Name = "btnAddGravity";
            this.btnAddGravity.Size = new System.Drawing.Size(200, 30);
            this.btnAddGravity.Text = "Добавить гравитон";
            this.btnAddGravity.UseVisualStyleBackColor = true;

            // btnReset
            this.btnReset.Location = new System.Drawing.Point(10, 155);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(200, 30);
            this.btnReset.Text = "Сбросить";
            this.btnReset.UseVisualStyleBackColor = true;

            // lblScore
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(10, 200);
            this.lblScore.Name = "lblScore";
            this.lblScore.Text = "Счёт: 0";

            // lblTime
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(10, 230);
            this.lblTime.Name = "lblTime";
            this.lblTime.Text = "Время: 00:00";

            // prgWaterLevel
            this.prgWaterLevel.Location = new System.Drawing.Point(10, 270);
            this.prgWaterLevel.Name = "prgWaterLevel";
            this.prgWaterLevel.Size = new System.Drawing.Size(200, 23);

            // lblWaterPercent
            this.lblWaterPercent.AutoSize = true;
            this.lblWaterPercent.Location = new System.Drawing.Point(220, 270);
            this.lblWaterPercent.Name = "lblWaterPercent";
            this.lblWaterPercent.Text = "0%";

            // lblHint
            this.lblHint.AutoSize = true;
            this.lblHint.Location = new System.Drawing.Point(10, 310);
            this.lblHint.Name = "lblHint";
            this.lblHint.Text = "L-клик: добавить гравитон";

            // panel1
            this.panel1.Controls.Add(this.trkAngle);
            this.panel1.Controls.Add(this.lblAngleValue);
            this.panel1.Controls.Add(this.trkPower);
            this.panel1.Controls.Add(this.lblPowerValue);
            this.panel1.Controls.Add(this.btnAddGravity);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.lblScore);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.prgWaterLevel);
            this.panel1.Controls.Add(this.lblWaterPercent);
            this.panel1.Controls.Add(this.lblHint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(650, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 522);
            this.panel1.TabIndex = 1;

            // Form1
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 522);
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
