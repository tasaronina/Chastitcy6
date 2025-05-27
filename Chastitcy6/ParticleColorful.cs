using System;
using System.Drawing;

namespace Chastitcy6
{
    public class ParticleColorful : Particle
    {
        public Color FromColor = Color.LightBlue;
        public Color ToColor = Color.Transparent;

        private static Color Mix(Color c1, Color c2, float t)
        {
            return Color.FromArgb(
                (int)(c2.A * t + c1.A * (1 - t)),
                (int)(c2.R * t + c1.R * (1 - t)),
                (int)(c2.G * t + c1.G * (1 - t)),
                (int)(c2.B * t + c1.B * (1 - t))
            );
        }

        public override void Draw(Graphics g)
        {
            float k = Life / 100f;
            if (k < 0) k = 0;
            if (k > 1) k = 1;
            Color col = Mix(ToColor, FromColor, k);
            using (var b = new SolidBrush(col))
            {
                g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            }
        }
    }
}
