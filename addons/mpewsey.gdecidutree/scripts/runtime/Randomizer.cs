using Godot;
using System;
using System.Collections.Generic;

namespace MPewsey.GDecidutree
{
    public static class Randomizer
    {
        private static Random Random { get; } = new Random();

        public static void Shuffle<T>(IList<T> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                var j = Random.Next(i, list.Count);
                (list[j], list[i]) = (list[i], list[j]);
            }
        }

        public static List<T> Shuffled<T>(IEnumerable<T> collection)
        {
            var copy = new List<T>(collection);
            Shuffle(copy);
            return copy;
        }

        public static bool ChanceSatisfied(double chance)
        {
            return chance >= 1 || (chance > 0 && Range01() <= chance);
        }

        public static double Range01()
        {
            return Random.NextDouble();
        }

        public static int Range(int max)
        {
            return Random.Next(max);
        }

        public static int Range(int min, int max)
        {
            return Random.Next(min, max);
        }

        public static double Range(double max)
        {
            return max * Range01();
        }

        public static double Range(double min, double max)
        {
            var t = Range01();
            return max * t + (1 - t) * min;
        }

        public static Vector2 InsideUnitCircle()
        {
            var radius = Math.Sqrt(Range01());
            var angle = Range(2 * Math.PI);
            var x = radius * Math.Cos(angle);
            var y = radius * Math.Sin(angle);
            return new Vector2((float)x, (float)y);
        }
    }
}