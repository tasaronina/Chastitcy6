using System.Drawing;

namespace Chastitcy6
{
    // класс «телепорт»: при попадании частицы в круг-вход
    // переносит её в точку-выход
    public class Teleport : IImpactPoint
    {
        // координаты точки выхода
        public float ExitX;
        public float ExitY;

        // радиус действия портала
        public float Radius = 50;

        // цвет пера для рисования круга входа
        public Color EntryPenColor { get; set; } = Color.Red;
        // цвет пера для рисования круга выхода
        public Color ExitPenColor { get; set; } = Color.MediumPurple;
        // цвет пера для рисования линии между входом и выходом
        public Color LinePenColor { get; set; } = Color.Green;

        // вызывается для каждой частицы
        public override void ImpactParticle(Particle p)
        {
            // вектор от центра входа к частице
            float dx = p.X - X;
            float dy = p.Y - Y;

            // если частица внутри радиуса входа
            if (dx * dx + dy * dy <= Radius * Radius)
            {
                // перемещаем её в точку выхода
                p.X = ExitX;
                p.Y = ExitY;
            }
        }

        // рисует портал: линия, входной и выходной круги
        public override void Render(Graphics g)
        {
            //  линия от входа к выходу
            using (var pen = new Pen(LinePenColor, 2))
                g.DrawLine(pen, X, Y, ExitX, ExitY);

            // круг входа
            using (var pen = new Pen(EntryPenColor, 2))
                g.DrawEllipse(pen, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            //  круг выхода
            using (var pen = new Pen(ExitPenColor, 2))
                g.DrawEllipse(pen, ExitX - Radius, ExitY - Radius, Radius * 2, Radius * 2);
        }
    }
}
