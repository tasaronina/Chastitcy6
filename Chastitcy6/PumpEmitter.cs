using System;
using System.Collections.Generic;
using System.Drawing;

namespace Chastitcy6
{
    public class PumpEmitter
    {
        public WaterTile[,] tiles;
        public int cols, rows;
        private int width, height;
        public int FlowRate { get; set; } = 2;

        private List<LeakPoint> leaks = new List<LeakPoint>();
        private List<DrainPoint> drains = new List<DrainPoint>();
        private List<Particle> particles = new List<Particle>();
        private List<BuffPoint> buffPoints = new List<BuffPoint>();

        private float gameTime = 0f;
        public float GameTime => gameTime;

        private float leakTimer = 0f;
        private float leakInterval = 2f;     // каждые 2 сек новая утечка

        private float buffTimer = 0f;
        private float nextBuffIn = 8f;       // интервал спавна баффа
        private static readonly Random rand = new Random();

        public PumpEmitter(int w, int h, int tileSize)
        {
            width = w; height = h;
            cols = w / tileSize;
            rows = h / tileSize;
            tiles = new WaterTile[cols, rows];
            for (int x = 0; x < cols; x++)
                for (int y = 0; y < rows; y++)
                    tiles[x, y] = new WaterTile
                    {
                        area = new Rectangle(x * tileSize, y * tileSize, tileSize, tileSize)
                    };
        }

        public IReadOnlyList<BuffPoint> BuffPoints => buffPoints;

        public Particle CreateParticle() => new ParticleColorful
        {
            FromColor = Color.LightBlue,
            ToColor = Color.Transparent
        };

        public void AddParticle(Particle p) => particles.Add(p);

        public void AddDrain(DrainPoint d)
        {
            d.CreatedAt = gameTime;
            drains.Add(d);
        }

        public void ClearLeaksAt(float x, float y, float r)
        {
            leaks.RemoveAll(lp =>
                (lp.X - x) * (lp.X - x) + (lp.Y - y) * (lp.Y - y) <= r * r);
        }

        public void FreezeCryo(float dur)
        {
            foreach (var lp in leaks)
                lp.FreezeUntil = gameTime + dur;
        }

        private void TrySpawnLeak(float dt)
        {
            leakTimer += dt;
            if (leakTimer < leakInterval) return;
            leakTimer = 0;

            // случайная точка по периметру
            float perimeter = 2 * (width + height);
            float pos = (float)(rand.NextDouble() * perimeter);
            float x, y;
            if (pos < width) { x = pos; y = 0; }
            else if (pos < width + height) { x = width; y = pos - width; }
            else if (pos < 2 * width + height) { x = width - (pos - (width + height)); y = height; }
            else { x = 0; y = height - (pos - (2 * width + height)); }

            leaks.Add(new LeakPoint
            {
                X = x,
                Y = y,
                CreatedAt = gameTime,
                Lifetime = 9999f,
                GetFlowRate = () => FlowRate
            });
        }

        private void TrySpawnBuff(float dt)
        {
            buffTimer += dt;
            if (buffTimer < nextBuffIn) return;
            buffTimer = 0;
            nextBuffIn = 5f + (float)rand.NextDouble() * 5f;  // каждые 5–10 сек

            buffPoints.Add(new BuffPoint
            {
                Type = (rand.Next(2) == 0) ? BuffType.Hammer : BuffType.Cryo,
                X = (float)(rand.NextDouble() * width),
                Y = (float)(rand.NextDouble() * height),
                CreatedAt = gameTime,
                Lifetime = 8f
            });
        }

        public void UpdateState(float dt)
        {
            gameTime += dt;

            // спавним утечки + баффы
            TrySpawnLeak(dt);
            TrySpawnBuff(dt);

            // убираем просроченные баффы
            buffPoints.RemoveAll(b => gameTime - b.CreatedAt > b.Lifetime);

            // утечки эмитят частицы
            foreach (var lp in leaks)
                lp.Emit(this);

            // дренажи высасывают воду
            foreach (var d in drains)
                d.DrainTiles(tiles);

            // убираем просроченные дренажи
            drains.RemoveAll(d => gameTime - d.CreatedAt > d.Lifetime);

            // частицы заполняют плитки, но не замороженные
            foreach (var p in particles)
            {
                if (p.Life-- <= 0) continue;

                p.X += p.SpeedX;
                p.Y += p.SpeedY;

                int ix = Math.Min(Math.Max((int)(p.X * cols / width), 0), cols - 1);
                int iy = Math.Min(Math.Max((int)(p.Y * rows / height), 0), rows - 1);

                // если плитка заморожена — не добавляем воды
                if (tiles[ix, iy].FrozenUntil > gameTime)
                    continue;

                tiles[ix, iy].waterAmount++;
            }

            // обновляем flooded
            foreach (var t in tiles)
                t.Update(50);
        }

        public void Render(Graphics g)
        {
            // плитки
            foreach (var t in tiles)
                t.Render(g, gameTime);

            // утечки
            foreach (var lp in leaks)
                lp.Render(g, gameTime);

            // дренажи
            foreach (var d in drains)
                d.Render(g, gameTime);

            // баффы
            foreach (var b in buffPoints)
                b.Render(g, gameTime);

            // частицы
            foreach (var p in particles)
                p.Draw(g);
        }
    }
}
