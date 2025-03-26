using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.Shared;

namespace LeetCode.Problems.P104_MaximumDepthBinaryTree;

/******************************************************************************
Given the root of a binary tree, return its maximum depth.

A binary tree's maximum depth is the number of nodes along the longest path 
from the root node down to the farthest leaf node.

Example 1:
Input: root = [3,9,20,null,null,15,7]
Output: 3

Example 2:
Input: root = [1,null,2]
Output: 2

Constraints:
The number of nodes in the tree is in the range [0, 10^4].
-100 <= Node.val <= 100

******************************************************************************/
public class MaximumDepth
{
    public static int Original(TreeNode root)
    {
        var result = 0;

        if(root == null)
        {
            return result;
        }

        var pointerStack = new Stack<TreeNode>();
        pointerStack.Push(root);

        while(pointerStack.Count > 0)
        {
            var current = pointerStack.Peek();
            if(current.left != null)
            {
                pointerStack.Push(current.left);
                // detach the left node
                current.left = null;
            }
            else if(current.right != null)
            {
                pointerStack.Push(current.right);
                // detach the right node
                current.right = null;
            }
            else
            {
                result = Math.Max(result, pointerStack.Count);
                pointerStack.Pop();
            }
        }

        return result;
    } // end method

    public static int FoundSolution(TreeNode root)
    {
        if(root == null)
        {
            return 0;
        }

        var leftDepth = FoundSolution(root.left);
        var rightDepth = FoundSolution(root.right);
        return Math.Max(leftDepth, rightDepth) + 1;
    } // end method
} // end class