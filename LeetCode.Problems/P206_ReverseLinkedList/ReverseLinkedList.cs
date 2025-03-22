using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using LeetCode.Problems.Shared;

namespace LeetCode.Problems.P206_ReverseLinkedList;

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
public class ReverseLinkedList
{
    public static ListNode Original(ListNode head)
    {
        if(head == null || head.next == null)
        {
            return head;
        }

        // grab a pointer to the second node
        var iteratorPointer = head.next;

        // remove the link from the head to the second node
        head.next = null;
 
        // move current to next real node
        // assign new first to current next
        // assign current to the actual next from head
        while(iteratorPointer != null)
        {   
            // get a pointer to the next node on the iterator
            var nextHolder = iteratorPointer.next;

            // assign head to the end
            iteratorPointer.next = head;
            
            // assign the current position as head 
            head = iteratorPointer;

            // move to the next node from the original input
            iteratorPointer = nextHolder;
        }

        return head;
    } // end method
} // end class