// Emitter.cs
using System.Collections.Generic;
using System.Drawing;

namespace Chastitcy6
{
    public class Emitter
    {
        protected List<Particle> particles = new List<Particle>();
        public virtual Particle CreateParticle() => new ParticleColorful();

        internal void AddParticle(Particle p) => particles.Add(p);

        public virtual void UpdateState() { }
        public virtual void Render(Graphics g) { }
    }
}
