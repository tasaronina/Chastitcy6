using System.Drawing;

namespace Chastitcy6
{
    public class PumpEmitter : Emitter
    {
        public WaterTile[,] tiles;
        public int cols, rows;
        private int width, height;
        private int threshold = 50;

        public PumpEmitter(int w, int h, int tileSize)
        {
            width = w; height = h;
            cols = w / tileSize; rows = h / tileSize;
            tiles = new WaterTile[cols, rows];
            for (int x = 0; x < cols; x++)
                for (int y = 0; y < rows; y++)
                    tiles[x, y] = new WaterTile
                    {
                        area = new Rectangle(x * tileSize, y * tileSize, tileSize, tileSize)
                    };
            X = w - tileSize / 2;
            Y = h - tileSize / 2;
        }

        public override void UpdateState()
        {
            base.UpdateState();

            // particles → tiles
            foreach (var p in particles)
            {
                int ix = Utils.Clamp((int)(p.X * cols / (float)width), 0, cols - 1);
                int iy = Utils.Clamp((int)(p.Y * rows / (float)height), 0, rows - 1);
                tiles[ix, iy].waterAmount++;
            }

            // update flooded
            foreach (var t in tiles) t.Update(threshold);

            // drains
            foreach (var d in drains) d.DrainTiles(tiles);
        }
    }
}
