using System;
using System.Drawing;

namespace Chastitcy6
{
    /// <summary>
    /// абстрактная «точка воздействия» на частицу
    /// </summary>
    public abstract class IImpactPoint
    {
        public float X, Y;

        /// <summary>
        /// вызывается для каждой частицы каждую итерацию
        /// </summary>
        public abstract void ImpactParticle(Particle p);

        /// <summary>
        /// по умолчанию рисуем красный кружок радиусом 5px
        /// </summary>
        public virtual void Render(Graphics g)
        {
            using (var b = new SolidBrush(Color.Red))
                g.FillEllipse(b, X - 5, Y - 5, 10, 10);
        }

        /// <summary>
        /// гравитон — притягивает частицы к себе
        /// </summary>
        public class GravityPoint : IImpactPoint
        {
            public int Power = 100;

            public override void ImpactParticle(Particle p)
            {
                float dx = X - p.X;
                float dy = Y - p.Y;
                float d2 = Math.Max(100, dx * dx + dy * dy);
                p.SpeedX += dx * Power / d2;
                p.SpeedY += dy * Power / d2;
            }

            public override void Render(Graphics g)
            {
                // рисуем чуть бóльшим кружком
                using (var pen = new Pen(Color.Red, 2))
                    g.DrawEllipse(pen, X - 8, Y - 8, 16, 16);
            }
        }
    }
}
