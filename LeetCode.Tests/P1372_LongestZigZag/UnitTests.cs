using LeetCode.Problems.P1372_LongestZigZag;
using LeetCode.Problems.Shared;

namespace LeetCode.Tests.P1372_LongestZigZag;
public class UnitTests
{
    [Theory]
    [InlineData(3, 1,null,1,1,1,null,null,1,1,null,1,null,null,null,1)]
    [InlineData(4, 1,1,1,null,1,null,null,1,1,null,1)]
    [InlineData(0, 1)]
    public void Original(int expected, params int?[] treeValues)
    {
        var root = treeValues.ToTreeNode();

        var result = LongestZigZag.Original(root);
        Assert.Equal(expected, result);
    }
} // end class