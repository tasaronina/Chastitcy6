using System;
using System.Drawing;

namespace Chastitcy6
{
    // базовый интерфейс «точки воздействия» на частицу
    public abstract class IImpactPoint
    {
        public float X; // координата центра
        public float Y;

        // вызывается для каждой частицы, чтобы изменить её состояние
        public abstract void ImpactParticle(Particle particle);

        // отрисовка (по умолчанию маленький красный кружок)
        public virtual void Render(Graphics g)
        {
            using (var brush = new SolidBrush(Color.Red))
                g.FillEllipse(brush, X - 5, Y - 5, 10, 10);
        }

        // гравитон (притягивает частицы)
        public class GravityPoint : IImpactPoint
        {
            public int Power = 100; // сила притяжения

            public override void ImpactParticle(Particle p)
            {
                float dx = X - p.X;
                float dy = Y - p.Y;
                float dist2 = Math.Max(100, dx * dx + dy * dy);
                p.SpeedX += dx * Power / dist2;
                p.SpeedY += dy * Power / dist2;
            }

            public override void Render(Graphics g)
            {
                using (var brush = new SolidBrush(Color.Red))
                    g.FillEllipse(brush, X - 5, Y - 5, 10, 10);
            }
        }
    }
}
