using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.P1448_CountGoodNodesInBinaryTree;
using LeetCode.Problems.Shared;

namespace LeetCode.Tests.P1448_CountGoodNodesInBinaryTree;

public class UnitTests
{
    [Theory]
    [InlineData(4, 3,1,4,3,null,1,5)]
    [InlineData(3, 3,3,null,4,2)]
    [InlineData(1, 1)]
    public void Original(int expected, params int?[] input)
    {
        var root = input.ToTreeNode();

        var result = GoodNodes.Original(root);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(4, 3,1,4,3,null,1,5)]
    [InlineData(3, 3,3,null,4,2)]
    [InlineData(1, 1)]
    public void BreadthFirstSearch(int expected, params int?[] input)
    {
        var root = input.ToTreeNode();

        var result = GoodNodes.BreadthFirstSearch(root);
        Assert.Equal(expected, result);
    }
} // end class
