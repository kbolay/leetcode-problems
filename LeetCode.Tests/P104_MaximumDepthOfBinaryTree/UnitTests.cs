using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.P104_MaximumDepthBinaryTree;
using LeetCode.Problems.Shared;

namespace LeetCode.Tests.P104_MaximumDepthOfBinaryTree;

public class UnitTests
{
    [Theory]
    [InlineData(3, 3, 9, 20, null, null, 15, 7)]
    [InlineData(2, 1, null, 2)]
    public void Original(int expected, params int?[] input)
    {
        var root = input.ToTreeNode();

        var result = MaximumDepth.Original(root);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(3, 3, 9, 20, null, null, 15, 7)]
    [InlineData(2, 1, null, 2)]
    public void FoundSolution(int expected, params int?[] input)
    {
        var root = input.ToTreeNode();

        var result = MaximumDepth.FoundSolution(root);
        Assert.Equal(expected, result);
    }
}

