using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.P2095_DeleteFromLinkedList;
using LeetCode.Problems.Shared;
using LeetCode.Tests.Shared;

namespace LeetCode.Tests.P2095_DeleteFromLinkedList;

public class UnitTests
{
    [Theory]
    [InlineData(new int[] {}, 1)]
    [InlineData(new int[] {1}, 1, 2)]
    [InlineData(new int[] {1, 3}, 1, 2, 3)]
    [InlineData(new int[] {1, 2, 4}, 1, 2, 3, 4)]
    [InlineData(new int[] {1,3,4,1,2,6}, 1,3,4,7,1,2,6)]
    public void Original(int[] expectedNums, params int[] inputNums)
    {
        var listNode = ListNode.ToListNode(inputNums);
        var expected = ListNode.ToListNode(expectedNums);

        var result = DeleteMiddle.Original(listNode);

        if(expected != null)
        {
            for(var i = 0; i < expectedNums.Length; i++)
            {
                Assert.Equal(expected.val, result.val);
                
                if(expected.next != null)
                {
                    expected = expected.next;
                    result = result.next;
                }
                else
                {
                    Assert.Null(result.next);
                }
            }
        }
        else
        {
            Assert.Null(result);
        }
    } // end method

    [Theory]
    [InlineData(new int[] {}, 1)]
    [InlineData(new int[] {1}, 1, 2)]
    [InlineData(new int[] {1, 3}, 1, 2, 3)]
    [InlineData(new int[] {1, 2, 4}, 1, 2, 3, 4)]
    [InlineData(new int[] {1,3,4,1,2,6}, 1,3,4,7,1,2,6)]
    public void FastAndSlowPointers(int[] expectedNums, params int[] inputNums)
    {
        var listNode = ListNode.ToListNode(inputNums);
        var expected = ListNode.ToListNode(expectedNums);

        var result = DeleteMiddle.FastAndSlowPointers(listNode);

        expected.AssertEqual(result);
        if(expected != null)
        {
            for(var i = 0; i < expectedNums.Length; i++)
            {
                Assert.Equal(expected.val, result.val);
                
                if(expected.next != null)
                {
                    expected = expected.next;
                    result = result.next;
                }
                else
                {
                    Assert.Null(result.next);
                }
            }
        }
        else
        {
            Assert.Null(result);
        }
    } // end method
}
