using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.P206_ReverseLinkedList;
using LeetCode.Problems.Shared;
using LeetCode.Tests.Shared;

namespace LeetCode.Tests.P206_ReverseLinkedList;

/**************************************************************
Given the head of a singly linked list, reverse the list, 
and return the reversed list.

Constraints:
The number of nodes in the list is the range [0, 5000].
-5000 <= Node.val <= 5000

Example 1:
Input: head = [1,2,3,4,5]
Output: [5,4,3,2,1]

Example 2:
Input: head = [1,2]
Output: [2,1]

Example 3:
Input: head = []
Output: []
**************************************************************/
public class UnitTests
{
    [Theory]
    [InlineData(new int[] {})]
    [InlineData(new int[] {1}, 1)]
    [InlineData(new int[] { 2, 1}, 1, 2)]
    [InlineData(new int[] { 5,4,3,2,1}, 1, 2,3,4,5)]
    public void Original(int[] expectedNums, params int[] inputNums)
    {
        var expected = ListNode.ToListNode(expectedNums);
        var head = ListNode.ToListNode(inputNums);

        var result = ReverseLinkedList.Original(head);

        expected.AssertEqual(result);
    } // end method
} // end method