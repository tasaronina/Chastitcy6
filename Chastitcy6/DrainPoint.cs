using System;
using System.Drawing;

namespace Chastitcy6
{
    public class DrainPoint
    {
        public float X, Y;
        public float CreatedAt;
        public float Lifetime = 8f;   // живёт 8 секунд
        public float Radius = 30f;
        public int Power = 20;

        public void DrainTiles(WaterTile[,] tiles)
        {
            int cols = tiles.GetLength(0), rows = tiles.GetLength(1);
            for (int i = 0; i < cols; i++)
                for (int j = 0; j < rows; j++)
                {
                    var t = tiles[i, j];
                    float cx = t.area.X + t.area.Width / 2f;
                    float cy = t.area.Y + t.area.Height / 2f;
                    float dx = cx - X, dy = cy - Y;
                    if (dx * dx + dy * dy <= Radius * Radius)
                    {
                        t.waterAmount = Math.Max(0, t.waterAmount - Power);
                        if (t.waterAmount == 0) t.flooded = false;
                    }
                }
        }

        public void Render(Graphics g, float currentTime)
        {
            // рисуем только если ещё не истёк lifetime
            if (currentTime - CreatedAt > Lifetime) return;
            using (var pen = new Pen(Color.Cyan, 2))
                g.DrawEllipse(pen, X - Radius, Y - Radius, Radius * 2, Radius * 2);
        }
    }
}
