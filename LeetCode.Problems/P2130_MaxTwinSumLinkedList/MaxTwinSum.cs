using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.Shared;

namespace LeetCode.Problems.P2130_MaxTwinSumLinkedList;

/******************************************************************************
In a linked list of size n, where n is even, the ith node (0-indexed) of the 
linked list is known as the twin of the (n-1-i)th node, if 0 <= i <= (n / 2) - 1.

For example, if n = 4, then node 0 is the twin of node 3, and node 1 is the 
twin of node 2. These are the only nodes with twins for n = 4.
The twin sum is defined as the sum of a node and its twin.

Given the head of a linked list with even length, return the maximum twin 
sum of the linked list.

Constraints:
The number of nodes in the list is an even integer in the range [2, 10^5].
1 <= Node.val <= 10^5

Example 1:
Input: head = [5,4,2,1]
Output: 6
Explanation:
Nodes 0 and 1 are the twins of nodes 3 and 2, respectively. All have twin sum = 6.
There are no other nodes with twins in the linked list.
Thus, the maximum twin sum of the linked list is 6. 

Example 2:
Input: head = [4,2,2,3]
Output: 7
Explanation:
The nodes with twins present in this linked list are:
- Node 0 is the twin of node 3 having a twin sum of 4 + 3 = 7.
- Node 1 is the twin of node 2 having a twin sum of 2 + 2 = 4.
Thus, the maximum twin sum of the linked list is max(7, 4) = 7.

Example 3:
Input: head = [1,100000]
Output: 100001
Explanation:
There is only one node with a twin in the linked list having twin sum of 1 + 100000 = 100001.
******************************************************************************/
public class MaxTwinSum
{
    /// <summary>
    /// Use a fast (2x) pointer to find the end.
    /// While we are finding the end reverse the first half of the linked list.
    /// Then start iterating through the twins.
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public static int Original(ListNode head)
    {
        var result = 0;

        // use this pointer to find the end
        var fastPointer = head.next.next;

        // grab a pointer to the second node
        var iteratorPointer = head.next;

        // remove the link from the head to the second node
        head.next = null;
 
        // reverse the first half of the linked list
        while(fastPointer != null && fastPointer.next != null)
        {   
            // get a pointer to the next node on the iterator
            var nextHolder = iteratorPointer.next;

            // assign head to the end
            iteratorPointer.next = head;
            
            // assign the current position as head 
            head = iteratorPointer;

            // move to the next node from the original input
            iteratorPointer = nextHolder;

            // move the fast pointer two positions
            fastPointer = fastPointer.next.next;
        }

        // head now is the reversed front half of the linked list
        // iterator pointer should be pointing to the first node in the second half of the linked list
        while(head != null && iteratorPointer != null)
        {
            result = Math.Max(result, head.val + iteratorPointer.val);
            head = head.next;
            iteratorPointer = iteratorPointer.next;
        }

        return result;
    } // end method
} // end class