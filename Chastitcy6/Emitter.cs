using System;
using System.Collections.Generic;
using System.Drawing;

namespace Chastitcy6
{
    public class Emitter
    {
        protected List<Particle> particles = new List<Particle>();
        protected List<DrainPoint> drains = new List<DrainPoint>();
        private static readonly Random rand = new Random();

        public int X, Y;
        public int Direction = 90, Spreading = 30;
        public int SpeedMin = 2, SpeedMax = 8;
        public int RadiusMin = 2, RadiusMax = 6;
        public int LifeMin = 30, LifeMax = 80;
        public int BaseParticles = 5;

        public bool PumpOn = false;
        public float Overheat = 0f, OverheatMax = 100f;
        public float OverheatRate = 1f, CoolRate = 0.5f;

        public virtual Particle CreateParticle()
        {
            return new ParticleColorful();
        }

        public void ResetParticle(Particle p)
        {
            p.Life = rand.Next(LifeMin, LifeMax);
            p.X = X; p.Y = Y;
            double rad = (Direction + rand.Next(Spreading) - Spreading / 2.0) * Math.PI / 180.0;
            float speed = rand.Next(SpeedMin, SpeedMax);
            p.SpeedX = (float)(Math.Cos(rad) * speed);
            p.SpeedY = -(float)(Math.Sin(rad) * speed);
            p.Radius = rand.Next(RadiusMin, RadiusMax);
        }

        public virtual void UpdateState()
        {
            // Handle overheat
            if (PumpOn && Overheat < OverheatMax)
                Overheat += OverheatRate;
            else if (!PumpOn && Overheat > 0)
                Overheat = System.Math.Max(0, Overheat - CoolRate);

            if (Overheat >= OverheatMax) PumpOn = false;

            int toCreate = PumpOn ? BaseParticles + (int)(Overheat / 10) : 0;

            for (int i = 0; i < particles.Count; i++)
            {
                var p = particles[i];
                if (p.Life <= 0)
                {
                    if (toCreate-- > 0) ResetParticle(p);
                }
                else
                {
                    p.X += p.SpeedX; p.Y += p.SpeedY;
                    p.Life--;
                }
            }

            while (toCreate-- > 0)
            {
                var p = CreateParticle();
                ResetParticle(p);
                particles.Add(p);
            }
        }

        public void AddDrain(DrainPoint dp) => drains.Add(dp);

        public void Render(Graphics g)
        {
            foreach (var d in drains) d.Render(g);
            foreach (var p in particles) p.Draw(g);
        }
    }
}
