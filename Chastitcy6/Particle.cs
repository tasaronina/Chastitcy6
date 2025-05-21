using System;
using System.Drawing;

namespace Chastitcy6
{
    // базовый класс частицы
    public class Particle
    {
        public int Radius;       // радиус частицы
        public float X;          // координата x
        public float Y;          // координата y

        public float SpeedX;     // скорость по оси x
        public float SpeedY;     // скорость по оси y

        public float Life;       // оставшееся время жизни

        // генератор случайных чисел для всех частиц
        private static readonly Random rand = new Random();

        // создаем новую частицу с рандомными параметрами
        public Particle()
        {
            double direction = rand.Next(360);
            float speed = 1 + rand.Next(10);

            SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            Radius = 2 + rand.Next(10);
            Life = 20 + rand.Next(100);
        }

       
        public virtual void Draw(Graphics g)
        {
            //расчитыывается время жизни частицы и в соответсвии рисует затухающей или нет
            float k = Math.Min(1f, Life / 100f);
            int alpha = (int)(k * 255);

            using (var brush = new SolidBrush(Color.FromArgb(alpha, Color.Black)))
            {
                g.FillEllipse(brush, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            }
        }
    }

    // класс цветной частицы, наследует базовую логику
    public class ParticleColorful : Particle
    {
        public Color FromColor;  // начальный цвет
        public Color ToColor;    // конечный цвет

        // смешиваем два цвета в зависимости от k (0..1)
        private static Color MixColor(Color c1, Color c2, float k)
        {
            return Color.FromArgb(
                (int)(c2.A * k + c1.A * (1 - k)),
                (int)(c2.R * k + c1.R * (1 - k)),
                (int)(c2.G * k + c1.G * (1 - k)),
                (int)(c2.B * k + c1.B * (1 - k))
            );
        }

        // рисуем частицу, меняющую цвет от FromColor к ToColor
        public override void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100f);
            Color color = MixColor(ToColor, FromColor, k);

            using (var brush = new SolidBrush(color))
            {
                g.FillEllipse(brush, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            }
        }
    }
}
