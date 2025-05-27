using System.Drawing;
using System;

public class WaterTile
{
    public Rectangle area;
    public int waterAmount;
    public bool flooded;

    // обновление: flood смотрит на внешний threshold
    public void Update(int threshold)
    {
        if (waterAmount > 0)
            waterAmount = Math.Max(0, waterAmount - 1);

        flooded = waterAmount >= threshold;
    }

    // Рисуем без "threshold"!
    public void Render(Graphics g)
    {
        // полупрозрачная заливка по waterAmount
        if (waterAmount > 0)
        {
            int alpha = (int)(200F * Math.Min(1F, waterAmount / 100F));
            using (var b = new SolidBrush(Color.FromArgb(alpha, 30, 144, 255)))
                g.FillRectangle(b, area);
        }

        // контур сетки
        g.DrawRectangle(Pens.DimGray, area);

        // если flooded == true — добавляем волну
        if (flooded)
        {
            using (var pen = new Pen(Color.LightSkyBlue, 1))
            {
                for (int x = area.Left; x < area.Right; x += 6)
                    g.DrawArc(pen, x, area.Top - 2, 6, 6, 0, 180);
            }
        }
    }
}
