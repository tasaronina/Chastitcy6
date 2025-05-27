using System;

namespace Chastitcy6
{
    public static class Utils
    {
        public static int Clamp(int value, int min, int max)
            => value < min ? min : value > max ? max : value;
    }
}
