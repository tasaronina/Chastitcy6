using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Chastitcy6
{
    public partial class Form1 : Form
    {
        private PumpEmitter emitter;
        private bool placingDrain;
        private float elapsed;
        private int score;

        private int hammerCount = 0, cryoCount = 0;
        private bool useHammerMode = false, useCryoMode = false;

        private const float winTime = 70f, loseThreshold = 0.5f;
        private readonly Image bg = Properties.Resources.Kvartira;

        public Form1()
        {
            InitializeComponent();

            lblFlowSpeed.Text = $"Скорость потока: {trkFlowSpeed.Value}";
            StartGame();
        }

        private void StartGame()
        {
            timer1.Stop();
            score = 0; elapsed = 0f;
            placingDrain = false;
            hammerCount = cryoCount = 0;
            useHammerMode = useCryoMode = false;
            UpdateBuffUI();

            emitter = new PumpEmitter(picDisplay.Width, picDisplay.Height, 20)
            {
                FlowRate = trkFlowSpeed.Value
            };

            prgWater.Value = 0;
            lblWaterPercent.Text = "0%";
            lblTime.Text = "Время: 0";
            lblScore.Text = "Счёт: 0";

            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            float dt = timer1.Interval / 1000f;
            elapsed += dt;
            lblTime.Text = $"Время: {elapsed:0.0}";

            int prevFlood = CountFlooded();
            emitter.UpdateState(dt);
            int newFlood = CountFlooded() - prevFlood;
            score -= newFlood;

            float level = CountFlooded() / (float)(emitter.cols * emitter.rows);
            int perc = (int)(level * 100);
            prgWater.Value = Math.Min(Math.Max(perc, 0), 100);
            lblWaterPercent.Text = $"{prgWater.Value}%";
            lblScore.Text = $"Счёт: {score}";

            if (elapsed >= winTime)
            {
                timer1.Stop();
                string caption = level <= loseThreshold ? "You Win" : "Game Over";
                MessageBoxIcon icon = level <= loseThreshold ? MessageBoxIcon.Information : MessageBoxIcon.Warning;
                MessageBox.Show(
                    level <= loseThreshold
                        ? $"Победа! Затоплено {level * 100:0}% плиток."
                        : $"Поражение: затоплено {level * 100:0}% плиток.",
                    caption, MessageBoxButtons.OK, icon
                );
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

        private void UpdateBuffUI()
        {
            lblHammerCount.Text = $"Молотков: {hammerCount}";
            btnUseHammer.Enabled = hammerCount > 0;
            lblCryoCount.Text = $"Крио: {cryoCount}";
            btnUseCryo.Enabled = cryoCount > 0;
        }

        private void PicDisplay_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            if (bg != null)
                g.DrawImage(bg, new Rectangle(0, 0, picDisplay.Width, picDisplay.Height));
            else
                g.Clear(Color.White);

            emitter.Render(g);
        }

        private void PicDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            // 1) Размещение дренажа
            if (placingDrain)
            {
                emitter.AddDrain(new DrainPoint { X = e.X, Y = e.Y });
                placingDrain = false;
                btnPlaceDrain.Enabled = true;
                return;
            }

            // 2) Сбор баффа
            var buff = emitter.BuffPoints.FirstOrDefault(b => b.HitTest(e.X, e.Y));
            if (buff != null)
            {
                if (buff.Type == BuffType.Hammer) hammerCount++;
                else cryoCount++;

                UpdateBuffUI();
                emitter.BuffPoints
                       .Cast<BuffPoint>()
                       .ToList()
                       .Remove(buff);   // убираем из списка напрямую
                return;
            }

            // 3) Использование молотка
            if (useHammerMode)
            {
                emitter.ClearLeaksAt(e.X, e.Y, 100f);
                useHammerMode = false;
                return;
            }

            // 4) Использование крио
            if (useCryoMode)
            {
                // заморозить плитки
                foreach (var t in emitter.tiles)
                    t.FrozenUntil = emitter.GameTime + 5f;
                useCryoMode = false;
                return;
            }
        }

        private void BtnUseHammer_Click(object sender, EventArgs e)
        {
            if (hammerCount > 0)
            {
                hammerCount--;
                useHammerMode = true;
                UpdateBuffUI();
            }
        }

        private void BtnUseCryo_Click(object sender, EventArgs e)
        {
            if (cryoCount > 0)
            {
                cryoCount--;
                useCryoMode = true;
                UpdateBuffUI();
            }
        }

        private void TrkFlowSpeed_Scroll(object sender, EventArgs e)
        {
            emitter.FlowRate = trkFlowSpeed.Value;
            lblFlowSpeed.Text = $"Скорость потока: {emitter.FlowRate}";
        }

        private void BtnPlaceDrain_Click(object sender, EventArgs e)
        {
            placingDrain = true;
            btnPlaceDrain.Enabled = false;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            StartGame();
        }
    }
}
