using System;
using System.Drawing;

namespace Chastitcy6
{
    public enum BuffType { Hammer, Cryo }

    public class BuffPoint
    {
        public BuffType Type;
        public float X, Y;
        public float CreatedAt;
        public float Lifetime = 8f;   // живёт 8 секунд
        public float Radius = 16f;

        public bool HitTest(float px, float py)
            => (px - X) * (px - X) + (py - Y) * (py - Y) <= Radius * Radius;

        // Рисуем только если ещё не истёк lifetime
        public void Render(Graphics g, float currentTime)
        {
            if (currentTime - CreatedAt > Lifetime) return;

            Color bg = Type == BuffType.Hammer ? Color.OrangeRed : Color.LightCyan;
            using (var brush = new SolidBrush(Color.FromArgb(180, bg)))
                g.FillEllipse(brush, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            using (var pen = new Pen(Color.Black, 2))
                g.DrawEllipse(pen, X - Radius, Y - Radius, Radius * 2, Radius * 2);
        }
    }
}
