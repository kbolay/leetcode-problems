using LeetCode.Problems.P547_NumberOfProvinces;

namespace LeetCode.Tests.P547_NumberOfProvinces;

public class UnitTests
{
    [Theory]
    [InlineData(2, 
        new int[] { 1, 1, 0 },
        new int[] { 1, 1, 0 },
        new int[] { 0, 0, 1}
    )]
    [InlineData(3, 
        new int[] { 1, 0, 0 },
        new int[] { 0, 1, 0 },
        new int[] { 0, 0, 1}
    )]
    public void Original(int expected, params int[][] input)
    {
        var result = FindCircleNum.Original(input);
        Assert.Equal(expected, result);
    } // end method

    [Theory]
    [InlineData(2, 
        new int[] { 1, 1, 0 },
        new int[] { 1, 1, 0 },
        new int[] { 0, 0, 1}
    )]
    [InlineData(3, 
        new int[] { 1, 0, 0 },
        new int[] { 0, 1, 0 },
        new int[] { 0, 0, 1}
    )]
    public void WithBoolSpan(int expected, params int[][] input)
    {
        var result = FindCircleNum.WithBoolSpan(input);
        Assert.Equal(expected, result);
    } // end method

    [Theory]
    [InlineData(2, 
        new int[] { 1, 1, 0 },
        new int[] { 1, 1, 0 },
        new int[] { 0, 0, 1}
    )]
    [InlineData(3, 
        new int[] { 1, 0, 0 },
        new int[] { 0, 1, 0 },
        new int[] { 0, 0, 1}
    )]
    public void FoundSolution(int expected, params int[][] input)
    {
        var result = FindCircleNum.FoundSolution(input);
        Assert.Equal(expected, result);
    } // end method

    [Theory]
    [InlineData(2, 
        new int[] { 1, 1, 0 },
        new int[] { 1, 1, 0 },
        new int[] { 0, 0, 1}
    )]
    [InlineData(3, 
        new int[] { 1, 0, 0 },
        new int[] { 0, 1, 0 },
        new int[] { 0, 0, 1}
    )]
    public void FoundSolutionBoolSpan(int expected, params int[][] input)
    {
        var result = FindCircleNum.FoundSolutionBoolSpan(input);
        Assert.Equal(expected, result);
    } // end method
} // end class