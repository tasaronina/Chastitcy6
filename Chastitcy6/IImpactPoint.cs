// ImpactPoints.cs
using System.Drawing;

namespace Chastitcy6
{
    /// <summary>
    /// Базовый интерфейс точки воздействия на частицу.
    /// </summary>
    public abstract class IImpactPoint
    {
        public float X, Y;
        public abstract void ImpactParticle(Particle p);
        public virtual void Render(Graphics g) { }
    }

    /// <summary>
    /// Гравитон: притягивает частицы.
    /// </summary>
    public class GravityPoint : IImpactPoint
    {
        public float Power = 100;

        public override void ImpactParticle(Particle p)
        {
            float dx = X - p.X, dy = Y - p.Y;
            float dist2 = dx * dx + dy * dy;
            if (dist2 < 100) dist2 = 100;
            p.SpeedX += dx * Power / dist2;
            p.SpeedY += dy * Power / dist2;
        }

        public override void Render(Graphics g)
        {
            g.FillEllipse(Brushes.Red, X - 5, Y - 5, 10, 10);
        }
    }

    /// <summary>
    /// Портал-утечка: при попадании частицы переносит её на ExitX, ExitY.
    /// </summary>
    public class WaterGate : IImpactPoint
    {
        public float ExitX, ExitY;
        public float Radius = 30;

        public override void ImpactParticle(Particle p)
        {
            float dx = p.X - X, dy = p.Y - Y;
            if (dx * dx + dy * dy <= Radius * Radius)
            {
                p.X = ExitX;
                p.Y = ExitY;
            }
        }

        public override void Render(Graphics g)
        {
            using (var penG = new Pen(Color.Green, 2))
                g.DrawLine(penG, X, Y, ExitX, ExitY);
            using (var penR = new Pen(Color.Red, 2))
                g.DrawEllipse(penR, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
            using (var penP = new Pen(Color.MediumPurple, 2))
                g.DrawEllipse(penP, ExitX - Radius, ExitY - Radius, 2 * Radius, 2 * Radius);
        }
    }
}
