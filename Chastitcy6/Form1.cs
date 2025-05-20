using Chastitcy6;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace Chastitcy6
{
    public partial class Form1 : Form
    {
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter;
        Teleport teleport;      // ← один портал

        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            // 1) Эмиттер
            emitter = new Emitter
            {
                Direction = -90,
                Spreading = 45,
                SpeedMin = 8,
                SpeedMax = 14,
                ParticlesPerTick = 30,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };
            emitters.Add(emitter);

            // 2) Единственный портал: красный вход → фиолетовый выход
            teleport = new Teleport
            {
                X = picDisplay.Width / 2 - 100,  // стартовый красный
                Y = picDisplay.Height / 2,
                ExitX = picDisplay.Width / 2 + 100,  // фиолетовый
                ExitY = picDisplay.Height / 2,
                Radius = 50,
                EntryPenColor = Color.Red,
                ExitPenColor = Color.MediumPurple,
                LinePenColor = Color.Green
            };
            emitter.impactPoints.Add(teleport);

            // 3) Подписываемся на клики
            picDisplay.MouseClick += picDisplay_MouseClick;

            // 4) Таймер и старт
            timer1.Interval = 40;
            timer1.Start();
        }

        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // движем красный вход
                teleport.X = e.X;
                teleport.Y = e.Y;
            }
            else if (e.Button == MouseButtons.Right)
            {
                // движем фиолетовый выход
                teleport.ExitX = e.X;
                teleport.ExitY = e.Y;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.White);
                emitter.Render(g);
            }
            picDisplay.Invalidate();
        }
    }
}