using System;
using System.Drawing;

namespace Chastitcy6
{
    public class LeakPoint
    {
        private static readonly Random rand = new Random();

        public float X, Y;
        public float CreatedAt;
        public float Lifetime = 9999f;       // жива всё время
        public float FreezeUntil;
        public Func<int> GetFlowRate;

        public void Emit(PumpEmitter emitter)
        {
            if (emitter.GameTime < FreezeUntil) return;

            int rate = GetFlowRate();
            for (int i = 0; i < rate; i++)
            {
                var p = emitter.CreateParticle();
                p.Life = 40 + rand.Next(30);
                p.Radius = rand.Next(2, 6);
                p.X = X; p.Y = Y;
                double dir = rand.NextDouble() * 2 * Math.PI;
                float speed = 1 + (float)rand.NextDouble() * 2;
                p.SpeedX = (float)(Math.Cos(dir) * speed);
                p.SpeedY = (float)(Math.Sin(dir) * speed);
                emitter.AddParticle(p);
            }
        }

        public void Render(Graphics g, float currentTime)
        {
            float age = (currentTime - CreatedAt) / Lifetime;
            if (age < 0) age = 0;
            if (age > 1) age = 1;
            int alpha = (int)((1 - age) * 255);
            using (var pen = new Pen(Color.FromArgb(alpha, Color.DarkBlue), 2))
                g.DrawEllipse(pen, X - 6, Y - 6, 12, 12);
        }
    }
}
