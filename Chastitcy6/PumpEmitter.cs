using System.Drawing;

namespace Chastitcy6
{
    /// <summary>
    /// специализированный эмиттер: к базовому поведению добавляет
    /// «заполнение» плиток водой при пересечении
    /// </summary>
    public class PumpEmitter : Emitter
    {
        public WaterTile[,] tiles;
        public int cols, rows;

        public override void UpdateState()
        {
            base.UpdateState();

            // для каждой частицы «добавляем воду» в ту плитку, где она оказалась
            foreach (var p in particles)
            {
                // находим плитку через проход по всему массиву
                for (int i = 0; i < cols; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        if (tiles[i, j].area.Contains((int)p.X, (int)p.Y))
                        {
                            tiles[i, j].waterAmount++;
                            break;
                        }
                    }
                }
            }
        }
    }
}
