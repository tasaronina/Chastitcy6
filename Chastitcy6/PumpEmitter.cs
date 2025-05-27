using System.Drawing;

namespace Chastitcy6
{
    // насос-эмиттер: капли попадают в тайлы и накапливаются в tiles[x,y].waterLevel
    public class PumpEmitter : Emitter
    {
        public WaterTile[,] tiles;   // ссылка на карту
        public int cols, rows;       // размер карты

        private WaterTile GetTileAt(float x, float y)
        {
            int ix = (int)(x / tiles[0, 0].area.Width);
            int iy = (int)(y / tiles[0, 0].area.Height);
            if (ix < 0 || ix >= cols || iy < 0 || iy >= rows) return null;
            return tiles[ix, iy];
        }

        // переопределяем логику: вместо обычной отрисовки капель
        // заполняем тайлы водой
        public override void UpdateState()
        {
            int toCreate = ParticlesPerTick;

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
                    // проверяем тайл под каплей
                    var tile = GetTileAt(p.X, p.Y);
                    if (tile != null && !tile.flooded)
                    {
                        tile.waterLevel++;
                        p.Life = 0;
                        continue;
                    }

                    // иначе обычная логика точек воздействия
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
