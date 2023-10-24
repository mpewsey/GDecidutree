using System;
using System.Collections.Generic;

namespace MPewsey.GDecidutree
{
    public static class Randomizer
    {
        public static Random Random { get; private set; } = new Random();

        public static void SetSeed(int seed)
        {
            Random = new Random(seed);
        }

        public static void Shuffle<T>(IList<T> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                var j = Random.Next(i, list.Count);
                (list[j], list[i]) = (list[i], list[j]);
            }
        }

        public static bool ChanceSatisfied(double chance)
        {
            return chance >= 1 || (chance > 0 && Random.NextDouble() <= chance);
        }
    }
}