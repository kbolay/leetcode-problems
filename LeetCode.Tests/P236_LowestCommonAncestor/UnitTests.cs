using LeetCode.Problems.P236_LowestCommonAncestor;
using LeetCode.Problems.Shared;

namespace LeetCode.Tests.P236_LowestCommonAncestor;

public class UnitTests
{
    [Theory]
    [InlineData(3, 5, 1, 3,5,1,6,2,0,8,null,null,7,4)]
    [InlineData(5, 5, 4, 3,5,1,6,2,0,8,null,null,7,4)]
    [InlineData(1, 1, 2, 1,2)]
    public void Original(int expected, int p, int q, params int?[] treeValues)
    {
        var root = treeValues.ToTreeNode();
        var result = LowestCommonAncestor.Original(root, new TreeNode(p), new TreeNode(q));
        Assert.Equal(expected, result.val);
    }
}