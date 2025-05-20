using System;
using System.Drawing;

namespace Chastitcy6
{
    // точка воздействия на частицы (абстрактный базовый класс)
    public abstract class IImpactPoint
    {
        // координата x центра точки воздействия
        public float X;
        // координата y центра точки воздействия
        public float Y;

        // вызывается для каждой частицы, чтобы изменить её скорость или позицию
        public abstract void ImpactParticle(Particle particle);

        // отрисовка точки воздействия по умолчанию — красный кружок радиусом 5px
        public virtual void Render(Graphics g)
        {
            using (var brush = new SolidBrush(Color.Red))
                g.FillEllipse(brush, X - 5, Y - 5, 10, 10);
        }

        // гравитон: притягивает частицы к себе
        public class GravityPoint : IImpactPoint
        {
            // сила притяжения (чем выше, тем сильнее эффект)
            public int Power = 100;

            // притягиваем частицу, изменяя её скорость
            public override void ImpactParticle(Particle particle)
            {
                // вектор от частицы к центру гравитона
                float dx = X - particle.X;
                float dy = Y - particle.Y;

                // квадрат расстояния, минимум 100, чтобы не было «дёрганий»
                float dist2 = Math.Max(100, dx * dx + dy * dy);

                // ускорение обратно пропорционально расстоянию в квадрате
                particle.SpeedX += dx * Power / dist2;
                particle.SpeedY += dy * Power / dist2;
            }

            // рисуем гравитон таким же красным кружком
            public override void Render(Graphics g)
            {
                using (var brush = new SolidBrush(Color.Red))
                    g.FillEllipse(brush, X - 5, Y - 5, 10, 10);
            }
        }
    }
}
