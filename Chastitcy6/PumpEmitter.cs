using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chastitcy6
{
    // эмиттер, который вместо простого рендеринга частиц
    // увеличивает waterLevel в той плитке, куда попала капля
    public class PumpEmitter : Emitter
    {
        public WaterTile[,] tiles;   // ссылка на карту плиток
        public int cols, rows;       // размеры сетки

        // переводит мировые x,y в индекс плитки
        private WaterTile GetTileAt(float x, float y)
        {
            int ix = (int)(x / (tiles[0, 0].area.Width));
            int iy = (int)(y / (tiles[0, 0].area.Height));
            if (ix < 0 || ix >= cols || iy < 0 || iy >= rows)
                return null;
            return tiles[ix, iy];
        }

        // переопределяем: капля воды при попадании «умирает» и кладёт +1 в waterLevel
        public override void UpdateState()
        {
            int toCreate = ParticlesPerTick;
            foreach (var p in particles)
            {
                if (p.Life <= 0 && toCreate > 0)
                {
                    toCreate--;
                    ResetParticle(p);
                }
                else if (p.Life > 0)
                {
                    // проверяем плитку, куда попала капля
                    var tile = GetTileAt(p.X, p.Y);
                    if (tile != null && !tile.flooded)
                    {
                        tile.waterLevel++;
                        p.Life = 0;   // «поглощаем» каплю
                        continue;
                    }
                    // обычное движение и силы
                    foreach (var point in impactPoints)
                        point.ImpactParticle(p);
                    p.X += p.SpeedX;
                    p.Y += p.SpeedY;
                    p.Life--;
                }
            }
            while (toCreate > 0)
            {
                toCreate--;
                var p = CreateParticle();
                ResetParticle(p);
                particles.Add(p);
            }
        }
    }
}
