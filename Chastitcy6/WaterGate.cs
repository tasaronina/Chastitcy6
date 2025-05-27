using System.Drawing;

namespace Chastitcy6
{
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
            using (var pen = new Pen(Color.Green, 2))
                g.DrawLine(pen, X, Y, ExitX, ExitY);

            using (var pen = new Pen(Color.Red, 2))
                g.DrawEllipse(pen, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);

            using (var pen = new Pen(Color.MediumPurple, 2))
                g.DrawEllipse(pen, ExitX - Radius, ExitY - Radius, 2 * Radius, 2 * Radius);
        }
    }
}
