using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chastitcy6
{
    // шлюз-перенаправитель: капли, попавшие в круг входа, мгновенно перемещаются в точку выхода
    public class WaterGate : IImpactPoint
    {
        public float ExitX;
        public float ExitY;
        public float Radius = 30;

        // цвета для отрисовки (можно менять)
        public Color EntryColor = Color.Red;
        public Color ExitColor = Color.MediumPurple;
        public Color LineColor = Color.Green;

        // при попадании капли в круг «входа» переносим её в выход
        public override void ImpactParticle(Particle p)
        {
            float dx = p.X - X;
            float dy = p.Y - Y;
            if (dx * dx + dy * dy <= Radius * Radius)
            {
                p.X = ExitX;
                p.Y = ExitY;
            }
        }

        // рисуем линию и два круга
        public override void Render(Graphics g)
        {
            using (var pen = new Pen(LineColor, 2))
                g.DrawLine(pen, X, Y, ExitX, ExitY);
            using (var pen = new Pen(EntryColor, 2))
                g.DrawEllipse(pen, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            using (var pen = new Pen(ExitColor, 2))
                g.DrawEllipse(pen, ExitX - Radius, ExitY - Radius, Radius * 2, Radius * 2);
        }
    }
}