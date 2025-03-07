using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.P1341_KidsWithCandies;

namespace LeetCode.Tests.P1341_KidsWithCandies;

public class UnitTests
{
    [Theory]
    [InlineData(new int[] {2,3,5,1,3}, 3, new bool[] {true, true, true, false, true})]
    [InlineData(new int[] {4,2,1,1,2}, 1, new bool[] {true, false, false, false, false})]
    [InlineData(new int[] {12, 1, 12}, 3, new bool[] {true, false, true})]
    public void FirstImplementation(int[] candies, int extraCandies, bool[] expected)
    {
        var result = KidsWithCandies.GetMaxCandies(candies, extraCandies);

        Assert.Equal(expected, result);
    }
}
