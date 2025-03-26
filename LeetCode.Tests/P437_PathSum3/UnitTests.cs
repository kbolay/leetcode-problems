using LeetCode.Problems.P437_PathSum3;
using LeetCode.Problems.Shared;

namespace LeetCode.Tests.P437_PathSum3;

public class UnitTests
{
    [Theory]
    [InlineData(3, 8, 10,5,-3,3,2,null,11,3,-2,null,1)]
    [InlineData(3, 22, 5,4,8,11,null,13,4,7,2,null,null,5,1)]
    [InlineData(1, 1, 1)]
    [InlineData(13, 2, 1,0,1,1,2,0,-1,0,1,-1,0,-1,0,1,0)]
    [InlineData(0, 0, 1000000000,1000000000,null,294967296,null,1000000000,null,1000000000,null,1000000000)]
    public void Original(int expected, int targetSum, params int?[] treeValues)
    {
        var root = treeValues.ToTreeNode();
        var result = PathSum.Original(root, targetSum);

        Assert.Equal(expected, result);
    } // end method

    [Theory]
    [InlineData(3, 8, 10,5,-3,3,2,null,11,3,-2,null,1)]
    [InlineData(3, 22, 5,4,8,11,null,13,4,7,2,null,null,5,1)]
    [InlineData(1, 1, 1)]
    [InlineData(13, 2, 1,0,1,1,2,0,-1,0,1,-1,0,-1,0,1,0)]
    [InlineData(0, 0, 1000000000,1000000000,null,294967296,null,1000000000,null,1000000000,null,1000000000)]
    public void FoundSolution(int expected, int targetSum, params int?[] treeValues)
    {
        var root = treeValues.ToTreeNode();
        var result = PathSum.FoundSolution(root, targetSum);

        Assert.Equal(expected, result);
    } // end method
} // end class