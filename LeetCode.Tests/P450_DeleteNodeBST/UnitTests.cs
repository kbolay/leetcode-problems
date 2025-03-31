using System.Collections;
using LeetCode.Problems.P450_DeleteNodeBST;
using LeetCode.Problems.Shared;

namespace LeetCode.Tests.P450_DeleteNodeBST;

public class UnitTests
{
    [Theory]
    [ClassData(typeof(TestDataGenerator))]
    public void Original(int?[] bstValues, int key, int?[] expectedValues)
    {
        var bst = bstValues.ToTreeNode();
        var result = DeleteNode.Original(bst, key);

        Assert.Equal(expectedValues, result.ToValues());
    } // end method
}

public class TestDataGenerator : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new List<object[]>
    {
        new object[] {
            new int?[] { 5,3,6,2,4,null,7},
            3,
            new int?[] { 5,4,6,2,null,null,7},
        },
        new object[] {
            new int?[] { 5,3,6,2,4,null,7},
            0,
            new int?[] { 5,3,6,2,4,null,7},
        },
        new object[] {
            new int?[] { },
            0,
            new int?[] { },
        },
        new object[] {
            new int?[] { 0 },
            0,
            new int?[] { }
        }
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}