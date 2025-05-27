using System;
using System.Drawing;

namespace Chastitcy6
{
    /// <summary>
    /// базовая частица
    /// </summary>
    public class Particle
    {
        public float X, Y;           // позиция
        public float SpeedX, SpeedY; // вектор скорости
        public float Life;           // оставшиеся тики жизни
        public int Radius;         // радиус

        /// <summary>
        /// виртуальный метод рисования — рисуем простой чёрный кружок
        /// </summary>
        public virtual void Draw(Graphics g)
        {
            using (var brush = new SolidBrush(Color.Black))
            {
                g.FillEllipse(brush, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            }
        }
    }

    /// <summary>
    /// цветная частица с градиентом из FromColor в ToColor
    /// </summary>
    public class ParticleColorful : Particle
    {
        public Color FromColor;
        public Color ToColor;

        /// <summary>
        /// смешиваем два цвета по t от 0 до 1
        /// </summary>
        public static Color MixColor(Color c1, Color c2, float t)
        {
            return Color.FromArgb(
                (int)(c2.A * t + c1.A * (1 - t)),
                (int)(c2.R * t + c1.R * (1 - t)),
                (int)(c2.G * t + c1.G * (1 - t)),
                (int)(c2.B * t + c1.B * (1 - t))
            );
        }

        /// <summary>
        /// отрисовка кружка с плавным затуханием и тонкой тенью
        /// </summary>
        public override void Draw(Graphics g)
        {
            // коэффициент прозрачности / перехода
            float k = Math.Min(1f, Life / 100f);
            var color = MixColor(ToColor, FromColor, k);

            using (var brush = new SolidBrush(color))
            using (var pen = new Pen(Color.FromArgb((int)(k * 100), Color.Black), 1))
            {
                g.FillEllipse(brush, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
                g.DrawEllipse(pen, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
            }
        }
    }
}
