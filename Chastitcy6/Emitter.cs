using System;
using System.Collections.Generic;
using System.Drawing;

namespace Chastitcy6
{
    /// <summary>
    /// эмиттер генерирует частицы, обновляет их состояние и рисует
    /// </summary>
    public class Emitter
    {
        // список точек воздействия (телепорты, гравитоны и пр.)
        public List<IImpactPoint> impactPoints = new List<IImpactPoint>();

        // внутренний список самих частиц
        protected List<Particle> particles = new List<Particle>();

        // генератор случайных чисел
        private static readonly Random rand = new Random();

        // ----- настроки эмиттера -----
        public int X, Y;                 // положение источника
        public int Direction = 0;        // направление (градусы)
        public int Spreading = 360;      // разброс (градусы)
        public int SpeedMin = 1;         // скорость частицы
        public int SpeedMax = 10;
        public int RadiusMin = 2;        // радиус частицы
        public int RadiusMax = 10;
        public int LifeMin = 20;         // время жизни (ticks)
        public int LifeMax = 100;
        public int ParticlesPerTick = 1; // квота на тик
        public Color ColorFrom = Color.White;
        public Color ColorTo = Color.FromArgb(0, Color.Black);

        /// <summary>создаёт новую частицу (можно переопределить в наследниках)</summary>
        public virtual Particle CreateParticle()
        {
            var p = new ParticleColorful
            {
                FromColor = ColorFrom,
                ToColor = ColorTo
            };
            return p;
        }

        /// <summary>сбрасывает (воскрешает) частицу в исходное состояние</summary>
        public void ResetParticle(Particle p)
        {
            p.Life = rand.Next(LifeMin, LifeMax);
            p.X = X;
            p.Y = Y;

            double dir = Direction + rand.Next(Spreading) - Spreading / 2.0;
            float speed = rand.Next(SpeedMin, SpeedMax);

            p.SpeedX = (float)(Math.Cos(dir / 180 * Math.PI) * speed);
            p.SpeedY = -(float)(Math.Sin(dir / 180 * Math.PI) * speed);
            p.Radius = rand.Next(RadiusMin, RadiusMax);
        }

        /// <summary>основное обновление: движем, телепортируем, создаём/воскрешаем</summary>
        public virtual void UpdateState()
        {
            int toCreate = ParticlesPerTick;

            // 1) пробег по уже существующим частицам
            foreach (var p in particles)
            {
                if (p.Life <= 0)
                {
                    // воскрешаем до квоты
                    if (toCreate > 0)
                    {
                        toCreate--;
                        ResetParticle(p);
                    }
                }
                else
                {
                    // точки воздействия (гравитоны, телепорты и т.д.)
                    foreach (var ip in impactPoints)
                        ip.ImpactParticle(p);

                    // движение
                    p.X += p.SpeedX;
                    p.Y += p.SpeedY;
                    p.Life--;
                }
            }

            // 2) создаём новых, если осталась квота
            while (toCreate-- > 0)
            {
                var p = CreateParticle();
                ResetParticle(p);
                particles.Add(p);
            }
        }

        /// <summary>отрисовываем все частицы и все точки воздействия</summary>
        public void Render(Graphics g)
        {
            foreach (var p in particles)
            {
                // вызываем Draw у любой частицы
                p.Draw(g);
            }

            // рендер точек воздействия поверх частиц
            foreach (var ip in impactPoints)
            {
                ip.Render(g);
            }
        }
    }
}
