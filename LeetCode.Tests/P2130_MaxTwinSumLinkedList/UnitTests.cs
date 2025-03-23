using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.P2130_MaxTwinSumLinkedList;
using LeetCode.Problems.Shared;

namespace LeetCode.Tests.P2130_MaxTwinSumLinkedList;

public class UnitTests
{
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
    [Theory]
    [InlineData(1, 0,1)]
    [InlineData(0, 0,0)]
    [InlineData(3, 1,2)]
    [InlineData(5, 1,2,3,4)]
    [InlineData(6, 5,4,2,1)]
    [InlineData(7, 4,2,2,3)]
    [InlineData(100001, 1,100000)]
    [InlineData(938, 242,271,234,13,58,477,269,211,221,143,6,90,191,387,337,276,123,267,418,235,444,498,91,388,224,326,41,171,270,132,204,426,251,2,283,406,190,241,151,452,433,118,469,305,338,140,177,244,34,339,449,496,383,176,4,376,180,73,75,484,211,83,405,343,290,437,215,264,249,291,385,283,37,192,243,199,339,357,341,286,253,188,487,138,175,132,42,381,452,370,458,238,328,311,481,395,260,385,244,411,197,463,213,256,210,340,210,360,131,124,208,217,38,304,43,55,345,155,251,369,439,168,285,188,55,9,300,377,354,287,398,327,374,161,493,348,130,139,283,304,141,178,65,417,409,135,71,324,79,142,203,42,101,128,44,468,80,190,370,251,314,486,392,138,28,180,277,244,276,239,221,410,165,414,489,280,30,164,197,309,352,84,131,463,345,50,169,289,474,422,393,95,350,176,383,302,440,412,448,313,481,146,484,213,405,239,323,40,58,72,487,365,237,29,341,312,201,235,452,350,348,327,369,284,446,109,172,7,202,156,202,448,176,418,1,40,188,438,489,12,305,59,247,449,471,319,261,475,358,210,357,409,398,53,31,82,416,485,189,198,310,20,30,310,326,428,118,150,164,8,425,245,321,288,37,429,423,414,79,217,468,173,412,209,472,39,422,54,311,90,191,396,395,333,318,465,84,80,320,148,171,334,42,264,181,46,425,91,215,374,172,426,204,368,214,53,88,308,290,89,355,232,499,160,99,453,448,423,212,399,365,165,438,494,288,109,179,467,25,414,48,224,119,267,37,242,59,211,82,380,326,104,416,112)]
    [InlineData(174, 10, 15, 23, 75, 99, 8, 88, 44)]
    public void Original(int expected, params int[] inputNums)
    {
        var head = ListNode.ToListNode(inputNums);
        var result = MaxTwinSum.Original(head);
        Assert.Equal(expected, result);
    } // end method
} // end class
