using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Chastitcy6
{
    public partial class Form1 : Form
    {
        private const int cols = 10, rows = 8;
        private WaterTile[,] tiles = new WaterTile[cols, rows];
        private PumpEmitter pump;
        private WaterGate gate;

        private bool addingGate = false;
        private bool addingGravity = false;
        private int threshold = 10;
        private int score = 0;
        private Stopwatch gameClock = new Stopwatch();

        public Form1()
        {
            InitializeComponent();

            // 1) — строим сетку плиток
            int w = picDisplay.Width / cols;
            int h = picDisplay.Height / rows;
            for (int i = 0; i < cols; i++)
                for (int j = 0; j < rows; j++)
                    tiles[i, j] = new WaterTile
                    {
                        area = new Rectangle(i * w, j * h, w, h)
                    };

            // 2) — создаём насос-эмиттер
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
            pump.impactPoints.Add(new IImpactPoint.GravityPoint());

            // 3) — создаём стартовый шлюз
            gate = new WaterGate
            {
                X = picDisplay.Width / 4,
                Y = picDisplay.Height / 2,
                ExitX = picDisplay.Width * 3 / 4,
                ExitY = picDisplay.Height / 2,
                Radius = 30
            };
            pump.impactPoints.Add(gate);

            // 4) — подписываемся на события
            btnAddGate.Click += btnAddGate_Click;
            btnAddGravity.Click += btnAddGravity_Click;
            trkAngle.Scroll += trkAngle_Scroll;
            trkPower.Scroll += trkPower_Scroll;
            picDisplay.MouseClick += PicDisplay_MouseClick;
            timer1.Tick += timer1_Tick;

            // 5) — стартуем таймер/часы
            timer1.Interval = 40;
            timer1.Start();
            gameClock.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // обновляем логику
            foreach (var t in tiles)
                t.Update(threshold);

            pump.UpdateState();

            // пересчёт очков
            score = 0;
            foreach (var t in tiles)
                if (!t.flooded) score++;
            lblScore.Text = "Счёт: " + score;

            // обновление времени
            var ts = gameClock.Elapsed;
            lblTime.Text = $"Время: {ts.Minutes:00}:{ts.Seconds:00}";

            // перерисовка экрана
            picDisplay.Invalidate();
        }

        private void picDisplay_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.Black);

            // рисуем плитки
            foreach (var t in tiles)
                t.Render(g);

            // рисуем частицы и шлюз
            pump.Render(g);
        }

        private void PicDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if (addingGate)
            {
                pump.impactPoints.Add(new WaterGate
                {
                    X = e.X,
                    Y = e.Y,
                    ExitX = e.X,
                    ExitY = e.Y,
                    Radius = 30
                });
                addingGate = false;
                return;
            }
            if (addingGravity)
            {
                pump.impactPoints.Add(new IImpactPoint.GravityPoint
                {
                    X = e.X,
                    Y = e.Y
                });
                addingGravity = false;
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                gate.X = e.X;
                gate.Y = e.Y;
            }
            else
            {
                gate.ExitX = e.X;
                gate.ExitY = e.Y;
            }
        }

        private void btnAddGate_Click(object sender, EventArgs e)
        {
            addingGate = true;
            addingGravity = false;
        }

        private void btnAddGravity_Click(object sender, EventArgs e)
        {
            addingGravity = true;
            addingGate = false;
        }

        private void trkAngle_Scroll(object sender, EventArgs e)
        {
            pump.Direction = trkAngle.Value;
            lblAngleValue.Text = trkAngle.Value.ToString();
        }

        private void trkPower_Scroll(object sender, EventArgs e)
        {
            pump.ParticlesPerTick = trkPower.Value;
            lblPowerValue.Text = trkPower.Value.ToString();
        }
    }
}
