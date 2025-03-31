using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.Shared;

namespace LeetCode.Problems.P450_DeleteNodeBST;

/******************************************************************************
Given a root node reference of a BST and a key, delete the node with the given key in the BST. Return the root node reference (possibly updated) of the BST.

Basically, the deletion can be divided into two stages:

Search for a node to remove.
If the node is found, delete the node.

Constraints:
The number of nodes in the tree is in the range [0, 104].
-105 <= Node.val <= 105
Each node has a unique value.
root is a valid binary search tree.
-105 <= key <= 105
******************************************************************************/
public class DeleteNode
{
    public static TreeNode Original(TreeNode root, int key)
    {
        TreeNode? parent = null;
        bool isRight = false;
        var current = root;

        while(current != null)
        {
            if(current.val == key)
            {
                break;
            }

            parent = current;
            if(current.val > key)
            {
                // move to the left
                isRight = false;
                current = current.left;
            }
            else
            {
                // move to the right
                isRight = true;
                current = current.right;
            }
        }

        if(current != null)
        {
            // we found the node to delete
            if(parent == null)
            {
                // we are deleting the root
                root = CombineTrees(current.left, current.right);
            }
            else if(isRight)
            {
                parent.right = CombineTrees(current.left, current.right);
            }
            else
            {
                parent.left = CombineTrees(current.left, current.right);
            }
        }

        return root;
    } // end method

    public static TreeNode CombineTrees(TreeNode left, TreeNode right)
    {
        if(left == null && right == null)
        {
            return null;
        }

        if(right != null)
        {
            // attach the left to the bottom left of the right tree node        
            var currentRight = right;
            while(currentRight.left != null)
            {
                currentRight = currentRight.left;
            }

            currentRight.left = left;
            return right;
        }
        
        return left;        
    }
} // end class