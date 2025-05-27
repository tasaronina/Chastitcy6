using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chastitcy6
{
    public partial class Form1 : Form
    {
        private PumpEmitter emitter;
        private bool placingDrain;
        private readonly Image bg = Properties.Resources.Kvartira;

        private int score = 0;
        private float elapsed = 0f;
        private const float winTime = 60f;
        private const float loseThreshold = 0.7f;

        public Form1()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {
            placingDrain = false;
            score = 0;
            elapsed = 0f;

            emitter = new PumpEmitter(picDisplay.Width, picDisplay.Height, 20);

            // Начальное состояние UI
            btnPumpToggle.Text = "Запустить насос";
            lblScore.Text = "Счёт: 0";
            lblTime.Text = "Время: 0";
            lblWaterPercent.Text = "0%";
            lblOverheat.Text = "Перегрев: 0";
            prgWater.Value = 0;
            prgOverheat.Value = 0;

            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            elapsed += timer1.Interval / 1000f;
            lblTime.Text = $"Время: {elapsed:0.0}";

            int prevFlooded = CountFlooded();

            emitter.UpdateState();

            int newFlooded = CountFlooded() - prevFlooded;
            score -= newFlooded;

            // Вода
            int total = emitter.cols * emitter.rows;
            int flooded = CountFlooded();
            float level = flooded / (float)total;
            prgWater.Value = (int)(level * 100);
            lblWaterPercent.Text = prgWater.Value + "%";

            // Перегрев
            float ore = emitter.Overheat;
            prgOverheat.Value = (int)(ore / emitter.OverheatMax * 100);
            lblOverheat.Text = $"Перегрев: {ore:0}";

            // Счёт
            lblScore.Text = $"Счёт: {score}";

            // Победа/поражение
            if (level > loseThreshold)
            {
                timer1.Stop();
                MessageBox.Show("Поражение: квартира затоплена", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (elapsed >= winTime)
            {
                timer1.Stop();
                MessageBox.Show($"Победа! Вы выжили {winTime} сек.", "You Win", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            picDisplay.Invalidate();
        }

        private int CountFlooded()
        {
            int cnt = 0;
            foreach (var t in emitter.tiles)
                if (t.flooded) cnt++;
            return cnt;
        }

        private void PicDisplay_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            if (bg != null)
                g.DrawImage(bg, new Rectangle(0, 0, picDisplay.Width, picDisplay.Height));
            else
                g.Clear(Color.White);

            foreach (var t in emitter.tiles)
                t.Render(g);

            emitter.Render(g);
        }

        private void PicDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if (!placingDrain) return;
            var dp = new DrainPoint { X = e.X, Y = e.Y };
            emitter.AddDrain(dp);
            placingDrain = false;
            btnPlaceDrain.Enabled = true;
        }

        private void BtnPumpToggle_Click(object sender, EventArgs e)
        {
            emitter.PumpOn = !emitter.PumpOn;
            btnPumpToggle.Text = emitter.PumpOn ? "Остановить насос" : "Запустить насос";
        }

        private void BtnPlaceDrain_Click(object sender, EventArgs e)
        {
            placingDrain = true;
            btnPlaceDrain.Enabled = false;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            StartGame();
        }
    }
}
