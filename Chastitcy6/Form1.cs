using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Chastitcy6
{
    public partial class Form1 : Form
    {
        private const int cols = 10, rows = 8;
        private WaterTile[,] tiles = new WaterTile[cols, rows];
        private PumpEmitter pump;
        private bool addingGravity = false;
        private readonly int threshold = 10;
        private int score = 0;
        private Stopwatch gameClock = new Stopwatch();

        public Form1()
        {
            InitializeComponent();

            // 1) создаём сетку плиток
            int w = picDisplay.Width / cols;
            int h = picDisplay.Height / rows;
            for (int i = 0; i < cols; i++)
                for (int j = 0; j < rows; j++)
                    tiles[i, j] = new WaterTile
                    {
                        area = new Rectangle(i * w, j * h, w, h),
                        waterAmount = 0,
                        flooded = false
                    };

            // 2) настраиваем «насос-эмиттер»
            pump = new PumpEmitter
            {
                tiles = tiles,
                cols = cols,
                rows = rows,
                Direction = trkAngle.Value,
                Spreading = 30,
                SpeedMin = 5,
                SpeedMax = 8,
                ParticlesPerTick = trkPower.Value,
                ColorFrom = Color.LightBlue,
                ColorTo = Color.Blue,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height
            };
            // добавляем один гравитон по умолчанию
            pump.impactPoints.Add(new IImpactPoint.GravityPoint
            {
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
                Power = 200
            });

            // 3) привязываем события
            btnAddGravity.Click += BtnAddGravity_Click;
            btnReset.Click += BtnReset_Click;
            trkAngle.Scroll += TrkAngle_Scroll;
            trkPower.Scroll += TrkPower_Scroll;
            picDisplay.Paint += PicDisplay_Paint;
            picDisplay.MouseClick += PicDisplay_MouseClick;
            timer1.Tick += Timer1_Tick;

            // 4) стартуем таймер и секундомер
            timer1.Interval = 40;
            timer1.Start();
            gameClock.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            // a) обновляем плитки и частицы
            foreach (var t in tiles) t.Update(threshold);
            pump.UpdateState();

            // b) пересчитываем счёт (кол-во невсплывших плиток)
            score = 0;
            foreach (var t in tiles)
                if (!t.flooded) score++;
            lblScore.Text = "Счёт: " + score;

            // c) обновляем Health-бар
            int total = cols * rows, flooded = 0;
            foreach (var t in tiles) if (t.flooded) flooded++;
            int pct = flooded * 100 / total;
            prgWaterLevel.Value = Math.Min(pct, 100);
            lblWaterPercent.Text = pct + "%";

            // d) проверяем Game Over
            CheckGameOver();

            // e) обновляем время
            var ts = gameClock.Elapsed;
            lblTime.Text = $"Время: {ts.Minutes:00}:{ts.Seconds:00}";

            // f) просим перерисовать
            picDisplay.Invalidate();
        }

        private void PicDisplay_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            // 1) фон — план квартиры
            g.DrawImage(Properties.Resources.Kvartira,
                new Rectangle(0, 0, picDisplay.Width, picDisplay.Height));

            // 2) рисуем плитки: вода, контуры, волны
            foreach (var t in tiles)
            {
                if (t.waterAmount > 0)
                {
                    int alpha = (int)(200f * Math.Min(1f, t.waterAmount / (float)threshold));
                    using (var b = new SolidBrush(Color.FromArgb(alpha, 30, 144, 255)))
                        g.FillRectangle(b, t.area);
                }
                g.DrawRectangle(Pens.DimGray, t.area);

                if (t.flooded)
                {
                    using (var pen = new Pen(Color.LightSkyBlue, 1))
                        for (int x = t.area.Left; x < t.area.Right; x += 6)
                            g.DrawArc(pen, x, t.area.Top - 2, 6, 6, 0, 180);
                }
            }

            // 3) рендерим частицы и гравитоны
            pump.Render(g);
        }

        private void PicDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if (!addingGravity) return;

            // добавляем новый гравитон в точку клика
            pump.impactPoints.Add(new IImpactPoint.GravityPoint
            {
                X = e.X,
                Y = e.Y,
                Power = 200
            });
            addingGravity = false;
        }

        private void BtnAddGravity_Click(object sender, EventArgs e)
        {
            addingGravity = true;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            // сброс плиток
            foreach (var t in tiles)
            {
                t.waterAmount = 0;
                t.flooded = false;
            }

            // очистка всех частиц
            pump.Clear();

            // сброс прогресса
            score = 0;
            lblScore.Text = "Счёт: 0";
            prgWaterLevel.Value = 0;
            lblWaterPercent.Text = "0%";

            // рестарт времени
            gameClock.Restart();
            timer1.Start();
        }

        private void TrkAngle_Scroll(object sender, EventArgs e)
        {
            pump.Direction = trkAngle.Value;
            lblAngleValue.Text = trkAngle.Value.ToString();
        }

        private void TrkPower_Scroll(object sender, EventArgs e)
        {
            pump.ParticlesPerTick = trkPower.Value;
            lblPowerValue.Text = trkPower.Value.ToString();
        }

        private void CheckGameOver()
        {
            // координаты насоса попадают в плитку
            int ix = Math.Min(cols - 1, Math.Max(0, pump.X * cols / picDisplay.Width));
            int iy = Math.Min(rows - 1, Math.Max(0, pump.Y * rows / picDisplay.Height));

            if (tiles[ix, iy].flooded)
            {
                timer1.Stop();
                gameClock.Stop();
                var dr = MessageBox.Show(
                    "Вода добралась до насоса!\nИгра окончена.\nЗапустить заново?",
                    "Game Over",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (dr == DialogResult.Yes)
                    BtnReset_Click(null, null);
                else
                    Close();
            }
        }
    }
}
