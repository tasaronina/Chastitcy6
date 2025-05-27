using System;
using System.Drawing;

namespace Chastitcy6
{
    /// <summary>
    /// базовая частица
    /// </summary>
    public class Particle
    {
        public float X, Y;        // позиция
        public float SpeedX, SpeedY;
        public float Life;        // оставшиеся «тиков» жизни
        public int Radius;        // радиус для отрисовки

        /// <summary>
        /// рисуем простую чёрную точку (закрас)
        /// </summary>
        public virtual void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100f);
            int alpha = (int)(k * 255);
            using (var b = new SolidBrush(Color.FromArgb(alpha, Color.Black)))
            {
                g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            }
        }
    }

    /// <summary>
    /// цветная частица с плавным переходом FromColor → ToColor
    /// </summary>
    public class ParticleColorful : Particle
    {
        public Color FromColor, ToColor;

        private static Color Mix(Color a, Color b, float t)
        {
            return Color.FromArgb(
                (int)(b.A * t + a.A * (1 - t)),
                (int)(b.R * t + a.R * (1 - t)),
                (int)(b.G * t + a.G * (1 - t)),
                (int)(b.B * t + a.B * (1 - t))
            );
        }

        public override void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100f);
            var col = Mix(FromColor, ToColor, 1 - k);
            using (var b = new SolidBrush(col))
            {
                g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            }
        }
    }
}
