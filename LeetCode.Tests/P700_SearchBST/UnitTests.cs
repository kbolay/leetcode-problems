using LeetCode.Problems.P700_SearchBST;
using LeetCode.Problems.Shared;

namespace LeetCode.Tests.P700_SearchBST;

public class UnitTests
{
    [Theory]
    [InlineData(2, new int[] { 2,1,3 }, new int[]{ 4,2,7,1,3})]
    [InlineData(5, new int[] { }, new int[]{ 4,2,7,1,3})]
    public void Original(int val, int[] expectedValues, params int[] treeValues)
    {
        var root = treeValues.ToTreeNode();

        var result = SearchBST.Original(root, val);

        Assert.Equal(expectedValues, result.FromBSTTOValues());
    } // end method
} // end class