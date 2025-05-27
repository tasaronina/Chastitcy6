using System.Drawing;

namespace Chastitcy6
{
    public class WaterTile
    {
        public Rectangle area;
        public int waterAmount;
        public bool flooded;

        public void Update(int threshold)
        {
            if (!flooded && waterAmount > threshold)
                flooded = true;
        }

        public void Render(Graphics g)
        {
            if (waterAmount > 0)
            {
                int alpha = System.Math.Min(waterAmount * 2, 200);
                using (var brush = new SolidBrush(Color.FromArgb(alpha, 0, 100, 255)))
                {
                    g.FillRectangle(brush, area);
                }
            }

            if (flooded)
            {
                g.DrawRectangle(Pens.Blue, area);
            }
        }
    }
}
