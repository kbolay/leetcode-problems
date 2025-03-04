using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode.Problems.P2_AddTwoNumbers
{
    public class ListNode 
    {
        public int val;
        public ListNode? next;

        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public class P2AddTwoNumbers
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2) 
        {
            return AddListNodes(l1, l2);
        }

        public ListNode AddListNodes(ListNode l1, ListNode l2, int carryValue = 0)
        {
            int nodeValue = carryValue;
            ListNode? l1Next = null;
            ListNode? l2Next = null;
            int nextCarryValue = 0;

            if(l1 != null) 
            {
                nodeValue += l1.val;
                l1Next = l1.next;
            }

            if(l2 != null)
            {
                nodeValue += l2.val;
                l2Next = l2.next;
            }
            
            if(nodeValue >= 10)
            {
                nextCarryValue = 1;
                nodeValue = nodeValue % 10;
            }

            ListNode? next = null;
            if(l1Next != null || l2Next != null || nextCarryValue > 0)
            {
                next = AddListNodes(l1Next!, l2Next!, nextCarryValue);
            }

            return new ListNode(nodeValue, next);
        }
    }
}