using System.Collections.Generic;

namespace MPewsey.GDecidutree
{
    public static class Comparison
    {
        public static bool IsSatisfied<T>(ComparisonType type, T left, T right)
        {
            return IsSatisfied(type, Comparer<T>.Default.Compare(left, right));
        }

        public static bool IsSatisfied(ComparisonType type, int comparison)
        {
            switch (type)
            {
                case ComparisonType.Equal:
                    return comparison == 0;
                case ComparisonType.NotEqual:
                    return comparison != 0;
                case ComparisonType.LessThan:
                    return comparison < 0;
                case ComparisonType.LessThanOrEqual:
                    return comparison <= 0;
                case ComparisonType.GreaterThan:
                    return comparison > 0;
                case ComparisonType.GreaterThanOrEqual:
                    return comparison >= 0;
                default:
                    throw new System.ArgumentException($"Unhandled comparison type: {type}.");
            }
        }
    }
}