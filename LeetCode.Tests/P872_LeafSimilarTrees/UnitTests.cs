using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using LeetCode.Problems.P872_LeafSimilarTrees;
using LeetCode.Problems.Shared;

namespace LeetCode.Tests.P872_LeafSimilarTrees;

public class TestDataGenerator : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new List<object[]>
    {
        new object[] {
            new int?[] { 3, 5, 1, 6, 2, 9, 8, null, null, 7, 4 },
            //            0  1  2  3  4  5  6  7     8     9     10    11    12    13 14 - length = 15
            new int?[] {  3, 5, 1, 6, 7, 4, 2, null, null, null, null, null, null, 9, 8 },
            true
        },
        new object[] {
            new int?[] { 1,2,3},
            new int?[] {  1,3,3 },
            false
        },
        new object[] {
            new int?[] { 3,5,1,6,7,4,2,null,null,null,null,null,null,9,11,null,null,8,10 },
            new int?[] { 3,5,1,6,2,9,8,null,null,7,4 },
            false
        }
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class UnitTests
{

    [Theory]
    [ClassData(typeof(TestDataGenerator))]
    public void Original(int?[] treeInput1, int?[] treeInput2, bool expected)
    {
        var root1 = treeInput1.ToTreeNode();
        var root2 = treeInput2.ToTreeNode();

        var result = LeafSimilar.Original(root1, root2);
        Assert.Equal(expected, result);
    } // end method
} // end class
