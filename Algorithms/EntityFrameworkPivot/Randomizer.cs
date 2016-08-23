using System;

namespace Algorithms.EntityFrameworkPivot
{
    public static class Randomizer
    {
        private static readonly Random _random = new Random();

        public static T GetRandom<T>(params T[] items)
        {
            var next = _random.Next(0, items.Length - 1);
            return items[next];
        }
    }
}