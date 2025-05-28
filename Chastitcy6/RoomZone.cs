using System.Drawing;

namespace Chastitcy6
{
    public class RoomZone
    {
        public RectangleF Area;
        public float FloodThreshold = 0.6f;
        public bool Darkened;

        public void UpdateZone(WaterTile[,] tiles)
        {
            int cols = tiles.GetLength(0), rows = tiles.GetLength(1);
            int total = 0, flooded = 0;
            foreach (var t in tiles)
            {
                if (Area.Contains(t.area))
                {
                    total++;
                    if (t.flooded) flooded++;
                }
            }
            if (total > 0 && flooded / (float)total > FloodThreshold)
                Darkened = true;
        }

        public void RenderOverlay(Graphics g)
        {
            if (!Darkened) return;
            using (var brush = new SolidBrush(Color.FromArgb(64, Color.Black)))
                g.FillRectangle(brush, Area);
        }
    }
}
