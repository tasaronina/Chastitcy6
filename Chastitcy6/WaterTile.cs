using System.Drawing;

namespace Chastitcy6
{
    public class WaterTile
    {
        public Rectangle area;
        public int waterAmount;
        public bool flooded;
        public float FrozenUntil;    // время, до которого заморожена

        public void Update(int threshold)
        {
            if (!flooded && waterAmount > threshold)
                flooded = true;
        }

        // Теперь принимает текущее игровое время
        public void Render(Graphics g, float currentTime)
        {
            if (currentTime < FrozenUntil)
            {
                // заморожена — рисуем почти белую плитку
                using (var brush = new SolidBrush(Color.FromArgb(200, Color.White)))
                    g.FillRectangle(brush, area);
            }
            else if (flooded)
            {
                // затоплена
                using (var brush = new SolidBrush(Color.FromArgb(100, Color.Blue)))
                    g.FillRectangle(brush, area);
            }
            else if (waterAmount > 0)
            {
                // просто влажная
                using (var brush = new SolidBrush(Color.FromArgb(50, Color.LightBlue)))
                    g.FillRectangle(brush, area);
            }

            // рамка плитки
            using (var pen = new Pen(Color.DarkBlue, 1))
                g.DrawRectangle(pen, area);
        }
    }
}
