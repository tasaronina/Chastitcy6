using System.Drawing;

namespace Chastitcy6
{
    /// <summary>
    /// одна «плитка» пола, может быть залита водой
    /// </summary>
    public class WaterTile
    {
        public Rectangle area;    // экранная область
        public int waterAmount;   // условные «единицы воды»
        public bool flooded;      // когда вода ≥ threshold

        /// <summary>
        /// обновить состояние flooded
        /// </summary>
        public void Update(int threshold)
        {
            if (waterAmount >= threshold)
                flooded = true;
        }

        /// <summary>
        /// отрисовка в Form1 — не нужна здесь
        /// </summary>
    }
}
