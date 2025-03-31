using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.P1161_MaxLevelSumBinaryTree;
using LeetCode.Problems.Shared;

namespace LeetCode.Tests.P1161_MaxLevelSumBinaryTree;
public class UnitTests
{
    [Theory]
    [InlineData(2, 1, 7, 0, 7, -8, null, null)]
    [InlineData(2, 909, null, 10250, 98693,-89388,null,null,null,-32127)]
    public void Original(int expected, params int?[] treeValues)
    {
        var root = treeValues.ToTreeNode();
        var result = MaxLevelSum.Original(root);
        Assert.Equal(expected, result);
    } // end method
} // end method