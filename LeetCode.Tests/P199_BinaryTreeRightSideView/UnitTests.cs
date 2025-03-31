using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.Shared;

namespace LeetCode.Tests.P199_BinaryTreeRightSideView;


public class UnitTests
{
    [Theory]
    [InlineData(new int[] { 1,3,4 }, 1, 2, 3, null, 5, null, 4)]
    [InlineData(new int[] { 1,3,4, 5 }, 1,2,3,4,null,null,null,5)]
    [InlineData(new int[] { 1,3}, 1, null, 3)]
    [InlineData(new int[]{})]
    public void Original(int[] expected, params int?[] treeValues)
    {
        var root = treeValues.ToTreeNode();
        var result = RightSideView.FoundSolution(root);
        Assert.Equal(expected, result.ToArray());
    }
}
