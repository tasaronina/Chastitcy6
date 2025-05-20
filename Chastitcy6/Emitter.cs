using System;
using System.Collections.Generic;
using System.Drawing;

namespace Chastitcy6
{
    // эмиттер генерирует частицы, обновляет их состояние и рисует
    public class Emitter
    {
        // список точек воздействия (гравитоны, телепорты и прочие импакт-поинты)
        public List<IImpactPoint> impactPoints = new List<IImpactPoint>();

        // внутренний список самих частиц
        private List<Particle> particles = new List<Particle>();

        // генератор случайных чисел для эмиттера
        private static readonly Random rand = new Random();

        // координаты центра эмиттера
        public int X;
        public int Y;

        // направление вылета (в градусах) и разброс
        public int Direction = 0;
        public int Spreading = 360;

        // диапазон скоростей частиц
        public int SpeedMin = 1;
        public int SpeedMax = 10;

        // диапазон радиусов частиц
        public int RadiusMin = 2;
        public int RadiusMax = 10;

        // диапазон времени жизни частиц
        public int LifeMin = 20;
        public int LifeMax = 100;

        // сколько частиц создаётся за один тик
        public int ParticlesPerTick = 1;

        // цветовой градиент частиц: от ColorFrom → к ColorTo
        public Color ColorFrom = Color.White;
        public Color ColorTo = Color.FromArgb(0, Color.Black);

        // создаёт новый экземпляр цветной частицы
        public virtual Particle CreateParticle()
        {
            var p = new ParticleColorful();
            p.FromColor = ColorFrom;
            p.ToColor = ColorTo;
            return p;
        }

        // сбрасывает параметры частицы в начальное состояние
        public void ResetParticle(Particle p)
        {
            // задаём случайную продолжительность жизни
            p.Life = rand.Next(LifeMin, LifeMax);

            // возвращаем частицу в центр эмиттера
            p.X = X;
            p.Y = Y;

            // рассчитываем направление с учётом разброса
            double dir = Direction + rand.Next(Spreading) - Spreading / 2.0;
            float speed = rand.Next(SpeedMin, SpeedMax);

            // назначаем вектор скорости
            p.SpeedX = (float)(Math.Cos(dir / 180 * Math.PI) * speed);
            p.SpeedY = -(float)(Math.Sin(dir / 180 * Math.PI) * speed);

            // случайный радиус
            p.Radius = rand.Next(RadiusMin, RadiusMax);
        }

        // обновляет положение, жизнь и создаёт новые частицы
        public void UpdateState()
        {
            int toCreate = ParticlesPerTick;

            // пробегаем по всем частицам
            foreach (var p in particles)
            {
                if (p.Life <= 0)
                {
                    // если частица «умерла» и ещё можно создать новую
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

                    // перемещаем частицу
                    p.X += p.SpeedX;
                    p.Y += p.SpeedY;

                    // уменьшаем жизнь
                    p.Life--;
                }
            }

            // если остались «билеты» на создание, порождаем новые частицы
            while (toCreate > 0)
            {
                toCreate--;
                var p = CreateParticle();
                ResetParticle(p);
                particles.Add(p);
            }
        }

        // рисует все частицы и все точки воздействия
        public void Render(Graphics g)
        {
            foreach (var p in particles)
                p.Draw(g);

            foreach (var point in impactPoints)
                point.Render(g);
        }
    }
}
