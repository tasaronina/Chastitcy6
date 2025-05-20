using System.Drawing;

namespace Chastitcy6
{
    public class Teleport : IImpactPoint
    {
        public float ExitX;
        public float ExitY;
        public float Radius = 50;

        public Color EntryPenColor { get; set; } = Color.Red;
        public Color ExitPenColor { get; set; } = Color.MediumPurple;
        public Color LinePenColor { get; set; } = Color.Green;

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
            // линия
            using (var pen = new Pen(LinePenColor, 2))
                g.DrawLine(pen, X, Y, ExitX, ExitY);

            // вход (красный)
            using (var pen = new Pen(EntryPenColor, 2))
                g.DrawEllipse(pen, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            // выход (фиолетовый)
            using (var pen = new Pen(ExitPenColor, 2))
                g.DrawEllipse(pen, ExitX - Radius, ExitY - Radius, Radius * 2, Radius * 2);
        }
    }
}
