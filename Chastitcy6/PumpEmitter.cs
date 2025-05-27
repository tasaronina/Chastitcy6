using System;
using System.Collections.Generic;
using System.Drawing;

namespace Chastitcy6
{
    // эмиттер капелек-частиц
    public class PumpEmitter
    {
        public List<IImpactPoint> impactPoints = new List<IImpactPoint>();
        private List<Particle> particles = new List<Particle>();
        private static readonly Random rand = new Random();

        public WaterTile[,] tiles;  // ссылка на плитки
        public int cols, rows;      // размеры массива

        public int X, Y;            // позиция насоса
        public int Direction;       // направление в градусах
        public int Spreading;       // разброс угла
        public int SpeedMin, SpeedMax;
        public int RadiusMin = 2, RadiusMax = 8;
        public int LifeMin = 20, LifeMax = 100;
        public int ParticlesPerTick = 20;
        public Color ColorFrom, ColorTo;

        // создаём новую цветную частицу
        public virtual Particle CreateParticle()
        {
            var p = new ParticleColorful();
            (p as ParticleColorful).FromColor = ColorFrom;
            (p as ParticleColorful).ToColor = ColorTo;
            return p;
        }

        // сброс параметров частицы (при возрождении)
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

        // обновляем всех частиц и создаём новые
        public void UpdateState()
        {
            int toCreate = ParticlesPerTick;

            foreach (var p in particles)
            {
                if (p.Life <= 0)
                {
                    if (toCreate-- > 0)
                        ResetParticle(p);
                }
                else
                {
                    foreach (var ip in impactPoints)
                        ip.ImpactParticle(p);

                    p.X += p.SpeedX;
                    p.Y += p.SpeedY;
                    p.Life--;

                    // при попадании в плитку увеличиваем уровень воды
                    int cx = (int)(p.X / tiles.GetLength(0) * cols);
                    int cy = (int)(p.Y / tiles.GetLength(1) * rows);
                    if (cx >= 0 && cy >= 0 && cx < cols && cy < rows)
                        tiles[cx, cy].waterAmount++;
                }
            }

            while (toCreate-- > 0)
            {
                var p = CreateParticle();
                ResetParticle(p);
                particles.Add(p);
            }
        }

        // рисуем все частицы и все точки воздействия
        public void Render(Graphics g)
        {
            foreach (var p in particles)
                (p as ParticleColorful).Draw(g);

            foreach (var ip in impactPoints)
                ip.Render(g);
        }
    }
}
