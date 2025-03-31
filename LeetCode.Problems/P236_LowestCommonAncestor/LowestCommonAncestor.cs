using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using LeetCode.Problems.P328_OddEvenLinkedList;
using LeetCode.Problems.Shared;
using Microsoft.Diagnostics.Tracing.Stacks;

namespace LeetCode.Problems.P236_LowestCommonAncestor;

/**********************************************************
Given a binary tree, find the lowest common ancestor (LCA) 
of two given nodes in the tree.

According to the definition of LCA on Wikipedia: 
“The lowest common ancestor is defined between two nodes p 
and q as the lowest node in T that has both p and q as 
descendants (where we allow a node to be a descendant of itself).”

Constraints:

The number of nodes in the tree is in the range [2, 10^5].
-10^9 <= Node.val <= 10^9
All Node.val are unique.
p != q
p and q will exist in the tree.
**********************************************************/
public class LowestCommonAncestor
{
    /// <summary>
    /// Since each node has a unique value and p and q are guaranteed to exist
    /// we can create a stack for p and q, then pop off the stack until we find the first shared value.
    /// </summary>
    /// <param name="root"></param>
    /// <param name="p"></param>
    /// <param name="q"></param>
    /// <returns></returns>
    public static TreeNode Original(TreeNode root, TreeNode p, TreeNode q)
    {
        var pStack = GetNodePath(root, p, new Stack<TreeNode>());

        // is q a parent of p
        var qNode = pStack.FirstOrDefault(x => x.val == q.val);
        if (qNode != null)
        {
            return qNode;
        }        

        // use the nodes in the pstack to find the one that is the parent of q
        while(pStack.Count > 0)
        {
            var node = pStack.Pop();
            var qStack = GetNodePath(node, q, new Stack<TreeNode>());
            if(qStack != null && qStack.Count > 0)
            {
                return node;
            }
        }

        return root;
    }

    public static Stack<TreeNode> GetNodePath(TreeNode node, TreeNode child, Stack<TreeNode> path)
    {
        if(node == null)
        {
            return null;
        }

        path.Push(node);
        var pathCount = path.Count;
        if(node.val == child.val)
        {
            return path;
        }

        var leftPath = GetNodePath(node.left, child, path);
        if(leftPath != null && leftPath.Count > pathCount)
        {
            return leftPath;            
        }

        var rightPath = GetNodePath(node.right, child, path);
        if(rightPath != null && rightPath.Count > pathCount)
        {
            return rightPath;
        }

        path.Pop();
        return path;
    } 
} // end class