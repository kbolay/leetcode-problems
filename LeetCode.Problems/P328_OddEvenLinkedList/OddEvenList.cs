using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.Shared;

namespace LeetCode.Problems.P328_OddEvenLinkedList;

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
public class OddEvenList
{
    /// <summary>
    /// Needed to find a solution to understand this.
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public static ListNode FoundSolution(ListNode head)
    {
        if(head == null || head.next == null)
        {
            return head;
        }

        // odd points directly to head
        var odd = head; 

        // even points to the first even indexed node
        var even = head.next;

        // even head maintains the starting point of the even indexed nodes
        var evenHead = even;

        while(even != null && even.next != null)
        {
            // assign the next odd index to odd.next
            // this modifies the input 
            odd.next = even.next;

            // advance the odd pointer to the next odd index
            // move the odd pointer to the next item 
            odd = odd.next;

            // assign even.next to the next even indexed node
            even.next = even.next.next;

            // assign even to the next even indexed node
            even = even.next;
        }

        odd.next = evenHead;
        return head;
    }
} // end class
