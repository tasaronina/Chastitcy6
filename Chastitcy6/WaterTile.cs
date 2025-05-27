using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chastitcy6
{
    // описывает одну ячейку карты с уровнем воды
    public class WaterTile
    {
        public Rectangle area;      // экранная область tile
        public int waterLevel;      // накопленная вода
        public bool flooded;        // была ли она затоплена

        // проверка: если воды слишком много — затопить
        public void Update(int threshold)
        {
            if (!flooded && waterLevel > threshold)
                flooded = true;
            // сброс уровня (не накапливаем дальше, пока flooded)
            if (flooded) waterLevel = 0;
        }

        // рисует плитку: серая, если flooded; иначе белая
        public void Render(Graphics g)
        {
            using (var brush = new SolidBrush(flooded
                   ? Color.LightGray
                   : Color.White))
            {
                g.FillRectangle(brush, area);
            }
            // можно дорисовать контур
            g.DrawRectangle(Pens.Black, area);
        }
    }
}
