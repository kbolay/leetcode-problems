using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.P735_AsteroidCollision;

namespace LeetCode.Tests.P735_AsteroidCollision;

public class UnitTests
{
    /******************************************************************************
    Example 1:
    Input: asteroids = [5,10,-5]
    Output: [5,10]
    Explanation: The 10 and -5 collide resulting in 10. The 5 and 10 never collide.

    Example 2:
    Input: asteroids = [8,-8]
    Output: []
    Explanation: The 8 and -8 collide exploding each other.

    Example 3:
    Input: asteroids = [10,2,-5]
    Output: [10]
    Explanation: The 2 and -5 collide resulting in -5. The 10 and -5 collide resulting in 10.
    **************************************************************/
    [Theory]
    [InlineData(new int[] {5,10}, 5,10,-5)]
    [InlineData(new int[] {}, 8,-8)]
    [InlineData(new int[] {10}, 10,2,-5)]
    [InlineData(new int[] {-2,-1,1,2}, -2,-1,1,2)]
    public void Original(int[] expected, params int[] input)
    {
        var result = AsteroidCollision.Original(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] {5,10}, 5,10,-5)]
    [InlineData(new int[] {}, 8,-8)]
    [InlineData(new int[] {10}, 10,2,-5)]
    [InlineData(new int[] {-2,-1,1,2}, -2,-1,1,2)]
    public void FoundSolution(int[] expected, params int[] input)
    {
        var result = AsteroidCollision.FoundSolution(input);
        Assert.Equal(expected, result);
    }
}
