namespace LeetCode.Problems.P1341_KidsWithCandies;

public static class KidsWithCandies
{
    public static bool[] GetMaxCandies(int[] candies, int extraCandies)
    {
        var maxValue = candies.Max();
        var willBeMax = maxValue - extraCandies;

        return Enumerable.Range(0, candies.Length)
                    .Select(x => candies[x] >= willBeMax)
                    .ToArray();
    } // end method
} // end class
