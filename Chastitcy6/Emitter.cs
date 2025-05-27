using System;
using System.Collections.Generic;
using System.Drawing;

namespace Chastitcy6
{
    // эмиттер генерирует частицы, обновляет их состояние и рисует
    public class Emitter
    {
        // список точек воздействия (телепорты, гравитоны и пр.)
        public List<IImpactPoint> impactPoints = new List<IImpactPoint>();

        // список самих частиц (protected, чтобы наследники могли его использовать)
        protected List<Particle> particles = new List<Particle>();

        // генератор случайных чисел
        private static readonly Random rand = new Random();

        // ----- настройки эмиттера -----

        public int X; // положение источника
        public int Y;

        public int Direction = 0;   // направление (градусы)
        public int Spreading = 360; // разброс (градусы)

        public int SpeedMin = 1;    // скорость частицы
        public int SpeedMax = 10;

        public int RadiusMin = 2;   // радиус частицы
        public int RadiusMax = 10;

        public int LifeMin = 20;    // время жизни частицы
        public int LifeMax = 100;

        public int ParticlesPerTick = 1; // квота на тик

        public Color ColorFrom = Color.White;              // градиент
        public Color ColorTo = Color.FromArgb(0, Color.Black);

        // создаёт новую частицу (можно переопределить)
        public virtual Particle CreateParticle()
        {
            var p = new ParticleColorful();
            p.FromColor = ColorFrom;
            p.ToColor = ColorTo;
            return p;
        }

        // сбрасывает (или «воскрешает») частицу на позицию эмиттера
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

        // основное обновление: движем, телепортируем, создаём/воскрешаем
        public virtual void UpdateState()
        {
            int toCreate = ParticlesPerTick;

            // 1) проход по уже существующим частицам
            foreach (var p in particles)
            {
                if (p.Life <= 0)
                {
                    if (toCreate > 0)
                    {
                        toCreate--;
                        ResetParticle(p);
                    }
                }
                else
                {
                    // применяем все точки воздействия
                    foreach (var point in impactPoints)
                        point.ImpactParticle(p);

                    // двигаем частицу
                    p.X += p.SpeedX;
                    p.Y += p.SpeedY;

                    // уменьшаем жизнь
                    p.Life--;
                }
            }

            // 2) создаём новых, если осталась квота
            while (toCreate > 0)
            {
                toCreate--;
                var p = CreateParticle();
                ResetParticle(p);
                particles.Add(p);
            }
        }

        // отрисовываем частицы и точки воздействия
        public void Render(Graphics g)
        {
            foreach (var p in particles)
                p.Draw(g);

            foreach (var point in impactPoints)
                point.Render(g);
        }
    }
}
