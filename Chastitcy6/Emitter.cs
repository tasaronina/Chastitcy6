using System;
using System.Collections.Generic;
using System.Drawing;

namespace Chastitcy6
{
    /// <summary>
    /// базовый эмиттер частиц
    /// </summary>
    public class Emitter
    {
        // точки воздействия на частицы (гравитоны, шлюзы и т.п.)
        public List<IImpactPoint> impactPoints = new List<IImpactPoint>();

        // внутренний список частиц
        protected List<Particle> particles = new List<Particle>();

        // генератор случайных чисел
        private static readonly Random rand = new Random();

        // --- настраиваемые параметры эмиттера ---
        public int X, Y;                      // положение «насоса»
        public int Direction = -90;           // направление потока (градусы)
        public int Spreading = 30;           // разброс углов
        public int SpeedMin = 5;            // минимальная скорость
        public int SpeedMax = 8;            // максимальная скорость
        public int RadiusMin = 2;            // минимальный радиус частицы
        public int RadiusMax = 6;            // максимальный радиус
        public int LifeMin = 30;           // минимальная «жизнь»
        public int LifeMax = 80;           // максимальная «жизнь»
        public int ParticlesPerTick = 20;     // квота частиц на тик
        public Color ColorFrom = Color.LightBlue;
        public Color ColorTo = Color.Blue;

        /// <summary>
        /// создаёт новую цветную частицу
        /// </summary>
        public virtual Particle CreateParticle()
        {
            var p = new ParticleColorful();
            p.FromColor = ColorFrom;
            p.ToColor = ColorTo;
            return p;
        }

        /// <summary>
        /// «воскрешает» частицу в центре эмиттера
        /// </summary>
        public void ResetParticle(Particle p)
        {
            p.Life = rand.Next(LifeMin, LifeMax);
            p.X = X;
            p.Y = Y;
            double ang = Direction + rand.Next(Spreading) - Spreading / 2.0;
            float speed = rand.Next(SpeedMin, SpeedMax);
            p.SpeedX = (float)(Math.Cos(ang * Math.PI / 180) * speed);
            p.SpeedY = (float)(-Math.Sin(ang * Math.PI / 180) * speed);
            p.Radius = rand.Next(RadiusMin, RadiusMax);
        }

        /// <summary>
        /// базовое обновление: двигаем, применяем точки воздействия, создаём/воскрешаем
        /// </summary>
        public virtual void UpdateState()
        {
            int quota = ParticlesPerTick;

            // 1) обновляем существующие
            foreach (var p in particles)
            {
                if (p.Life <= 0)
                {
                    if (quota > 0)
                    {
                        quota--;
                        ResetParticle(p);
                    }
                }
                else
                {
                    // применяем все «гравитоны» и т.п.
                    foreach (var ip in impactPoints)
                        ip.ImpactParticle(p);

                    // двигаем
                    p.X += p.SpeedX;
                    p.Y += p.SpeedY;
                    p.Life--;
                }
            }

            // 2) создаём новых, если осталась квота
            while (quota-- > 0)
            {
                var p = CreateParticle();
                ResetParticle(p);
                particles.Add(p);
            }
        }

        /// <summary>
        /// очищает все частицы
        /// </summary>
        public void Clear()
        {
            particles.Clear();
        }

        /// <summary>
        /// рисует частицы и все точки воздействия
        /// </summary>
        public void Render(Graphics g)
        {
            foreach (var p in particles)
                p.Draw(g);
            foreach (var ip in impactPoints)
                ip.Render(g);
        }
    }
}
