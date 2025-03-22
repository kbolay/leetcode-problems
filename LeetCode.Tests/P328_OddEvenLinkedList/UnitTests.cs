using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.P328_OddEvenLinkedList;
using LeetCode.Problems.Shared;
using LeetCode.Tests.Shared;

namespace LeetCode.Tests.P328_OddEvenLinkedList;

/******************************************************************************
Given the head of a singly linked list, group all the nodes with odd 
indices together followed by the nodes with even indices, and return 
the reordered list.

The first node is considered odd, and the second node is even, and so on.

Note that the relative order inside both the even and odd groups should 
remain as it was in the input.

You must solve the problem in O(1) extra space complexity and O(n) 
time complexity.

Constraints:
The number of nodes in the linked list is in the range [0, 104].
-106 <= Node.val <= 106

Example 1:
Input: head = [1,2,3,4,5]
Output: [1,3,5,2,4]

Example 2:
Input: head = [2,1,3,5,6,4,7]
Output: [2,3,6,7,1,5,4]
******************************************************************************/
public class UnitTests
{
    [Theory]
    [InlineData(new int[] { })]
    [InlineData(new int[] { 1 }, 1)]
    [InlineData(new int[] { 1,2 }, 1,2)]
    [InlineData(new int[] { 1,3,2 }, 1,2,3)]
    [InlineData(new int[] { 1,3,5,2,4}, 1,2,3,4,5)]
    [InlineData(new int[] { 2,3,6,7,1,5,4}, 2,1,3,5,6,4,7)]
    public void FoundSolution(int[] expectedNums, params int[] input)
    {
        var expected = ListNode.ToListNode(expectedNums);
        var head = ListNode.ToListNode(input);

        var result = OddEvenList.FoundSolution(head);

        expected.AssertEqual(result);
    }
}