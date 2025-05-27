using System.Drawing;

namespace Chastitcy6
{
    public class Particle
    {
        public float X, Y;
        public float SpeedX, SpeedY;
        public float Life;
        public int Radius;

        public virtual void Draw(Graphics g)
        {
            using (var b = new SolidBrush(Color.Black))
            {
                g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            }
        }
    }
}
