using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chastitcy6
{
    public abstract class IImpactPoint
    {
        public float X; // ну точка же, вот и две координаты
        public float Y;

        // абстрактный метод с помощью которого будем изменять состояние частиц
        // например притягивать
        public abstract void ImpactParticle(Particle particle);

        // базовый класс для отрисовки точечки
        public virtual void Render(Graphics g)
        {
            g.FillEllipse(
                    new SolidBrush(Color.Red),
                    X - 5,
                    Y - 5,
                    10,
                    10
                );
        }

        public class GravityPoint : IImpactPoint
        {
            public int Power = 100; // сила притяжения

            // а сюда по сути скопировали с минимальными правками то что было в UpdateState
            public override void ImpactParticle(Particle particle)
            {
                float gX = X - particle.X;
                float gY = Y - particle.Y;

                double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
                if (r + particle.Radius < Power / 2) // если частица оказалось внутри окружности
                {
                    // то притягиваем ее
                    float r2 = (float)Math.Max(100, gX * gX + gY * gY);
                    particle.SpeedX += gX * Power / r2;
                    particle.SpeedY += gY * Power / r2;
                }
            }

            public override void Render(Graphics g)
            {
                // буду рисовать окружность с диаметром равным Power
                g.DrawEllipse(
                       new Pen(Color.Red),
                       X - Power / 2,
                       Y - Power / 2,
                       Power,
                       Power
                   );

                var stringFormat = new StringFormat(); // создаем экземпляр класса
                stringFormat.Alignment = StringAlignment.Center; // выравнивание по горизонтали
                stringFormat.LineAlignment = StringAlignment.Center; // выравнивание по вертикали

                g.DrawString(
                    $"Я гравитон\nc силой {Power}", // надпись, можно перенос строки вставлять (если вы Катя, то может не работать и надо использовать \r\n)
                    new Font("Verdana", 10), // шрифт и его размер
                    new SolidBrush(Color.White), // цвет шрифта
                    X, // расположение в пространстве
                    Y,
                    stringFormat // передаем инфу о выравнивании
                );
            }
        }

        public class AntiGravityPoint : IImpactPoint
        {
            public int Power = 100; // сила отторжения

            // а сюда по сути скопировали с минимальными правками то что было в UpdateState
            public override void ImpactParticle(Particle particle)
            {
                float gX = X - particle.X;
                float gY = Y - particle.Y;
                float r2 = (float)Math.Max(100, gX * gX + gY * gY);

                particle.SpeedX -= gX * Power / r2; // тут минусики вместо плюсов
                particle.SpeedY -= gY * Power / r2; // и тут
            }
        }


    }
}
