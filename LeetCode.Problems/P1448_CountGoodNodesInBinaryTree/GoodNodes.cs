using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.Shared;
using Microsoft.Diagnostics.Tracing.Parsers.AspNet;

namespace LeetCode.Problems.P1448_CountGoodNodesInBinaryTree;

/**************************************************************************
Given a binary tree root, a node X in the tree is named good if in the path 
from root to X there are no nodes with a value greater than X.

Return the number of good nodes in the binary tree.

Constraints:
The number of nodes in the binary tree is in the range [1, 10^5].
Each node's value is between [-10^4, 10^4].

Example 1:
Input: root = [3,1,4,3,null,1,5]
Output: 4
Explanation: Nodes in blue are good.
Root Node (3) is always a good node.
Node 4 -> (3,4) is the maximum value in the path starting from the root.
Node 5 -> (3,4,5) is the maximum value in the path
Node 3 -> (3,1,3) is the maximum value in the path.

Example 2:
Input: root = [3,3,null,4,2]
Output: 3
Explanation: Node 2 -> (3, 3, 2) is not good, because "3" is higher than it.

Example 3:
Input: root = [1]
Output: 1
Explanation: Root is considered as good.
**************************************************************************/
public class GoodNodes
{
    public static int Original(TreeNode root)
    {
        return DepthFirstSearch(root, Int32.MinValue);
    } // end method

    public static int DepthFirstSearch(TreeNode root, int max)
    {
        if(root == null)
        {
            return 0;
        }

        var nexMax = Math.Max(max, root.val);

        var left = DepthFirstSearch(root.left, nexMax);
        var right = DepthFirstSearch(root.right, nexMax);

        return left + right + (root.val >= max ? 1 : 0);
    }

    /// <summary>
    /// Based on a solution found
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static int BreadthFirstSearch(TreeNode root)
    {
        var queue = new Queue<(TreeNode node, int pathMax)>();

        queue.Enqueue((root, int.MinValue));
        var result = 0;

        while(queue.Count > 0)
        {
            var currentNodeTouple = queue.Dequeue();
            var pathMax = Math.Max(currentNodeTouple.pathMax, currentNodeTouple.node.val);

            if(currentNodeTouple.node.val >= pathMax)
            {
                result++;
            }

            if(currentNodeTouple.node.left != null)
            {
                queue.Enqueue((currentNodeTouple.node.left, pathMax));
            }

            if(currentNodeTouple.node.right != null)
            {
                queue.Enqueue((currentNodeTouple.node.right, pathMax));
            }
        }

        return result;
    } // end method
} // end class
