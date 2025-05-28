using System;
using System.Drawing;

namespace Chastitcy6
{
    public enum BoosterType { Hammer, Cryo }

    public class Booster
    {
        public BoosterType Type;
        public float X, Y;
        public float Radius = 100f;
        public bool Collected;

        public void Render(Graphics g)
        {
            Color c = Type == BoosterType.Hammer ? Color.OrangeRed : Color.LightCyan;
            using (var brush = new SolidBrush(Color.FromArgb(128, c)))
                g.FillEllipse(brush, X - Radius / 2, Y - Radius / 2, Radius, Radius);
        }

        public bool HitTest(float px, float py)
            => (px - X) * (px - X) + (py - Y) * (py - Y) <= (Radius / 2) * (Radius / 2);
    }
}
