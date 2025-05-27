using System.Drawing;

namespace Chastitcy6
{
    public abstract class IImpactPoint
    {
        public float X, Y;
        public abstract void ImpactParticle(Particle p);
        public virtual void Render(Graphics g) { }
    }

    public class DrainPoint
    {
        public float X, Y;
        public float Radius = 50;
        public int Power = 5;

        public int DrainTiles(WaterTile[,] tiles)
        {
            int drainedCount = 0;
            foreach (var t in tiles)
            {
                float cx = t.area.X + t.area.Width / 2f;
                float cy = t.area.Y + t.area.Height / 2f;
                float dx = cx - X;
                float dy = cy - Y;
                if (dx * dx + dy * dy <= Radius * Radius)
                {
                    int prev = t.waterAmount;
                    t.waterAmount = System.Math.Max(0, t.waterAmount - Power);
                    if (prev > t.waterAmount) drainedCount++;
                    if (t.waterAmount == 0 && t.flooded)
                    {
                        t.flooded = false;
                    }
                }
            }
            return drainedCount;
        }

        public void Render(Graphics g)
        {
            using (var pen = new Pen(Color.Cyan, 2))
            {
                g.DrawEllipse(pen, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            }
        }
    }
}
