using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.P238_ProductOfArrayExceptSelf;

namespace LeetCode.Tests.P238_ProductOfArrayExceptSelf;

public class UnitTests
{
    [Theory]
    [InlineData(new int[] {1,2,3,4}, new int[] {24,12,8,6})]
    [InlineData(new int[] {-1,1,0,-3,3}, new int[] {0,0,9,0,0})]
    [InlineData(new int[] {-1,1,0, 0,3}, new int[] {0,0,0,0,0})]
    public void Simple(int[] nums, int[] expected)
    {
        var result = ProductOfArrayExceptSelf.Simple(nums);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] {1,2,3,4}, new int[] {24,12,8,6})]
    [InlineData(new int[] {-1,1,0,-3,3}, new int[] {0,0,9,0,0})]
    [InlineData(new int[] {-1,1,0, 0,3}, new int[] {0,0,0,0,0})]
    public void CorrectSolution(int[] nums, int[] expected)
    {
        var result = ProductOfArrayExceptSelf.CorrectSolution(nums);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] {1,2,3,4}, new int[] {24,12,8,6})]
    [InlineData(new int[] {-1,1,0,-3,3}, new int[] {0,0,9,0,0})]
    [InlineData(new int[] {-1,1,0, 0,3}, new int[] {0,0,0,0,0})]
    public void CorrectSolutionWithSpans(int[] nums, int[] expected)
    {
        var result = ProductOfArrayExceptSelf.CorrectSolutionWithSpans(nums);
        Assert.Equal(expected, result);
    }
}