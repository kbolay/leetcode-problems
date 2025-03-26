using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.Shared;

namespace LeetCode.Problems.P872_LeafSimilarTrees;
/******************************************************************************
Consider all the leaves of a binary tree, from left to right order, 
the values of those leaves form a leaf value sequence.

[3, 5, 1, 6, 2, null, null, 7, 4, 9, 8]
For example, in the given tree above, the leaf value sequence is (6, 7, 4, 9, 8).

Two binary trees are considered leaf-similar if their leaf value sequence is the same.

Return true if and only if the two given trees with head nodes root1 and root2 
are leaf-similar.

Constraints:
The number of nodes in each tree will be in the range [1, 200].
Both of the given trees will have values in the range [0, 200].

Example 1:
Input: 
    root1 = [3,5,1,6,2,9,8,null,null,7,4], 
    root2 = [3,5,1,6,7,4,2,null,null,null,null,null,null,9,8]
Output: true

Example 2:
Input: 
    root1 = [1,2,3], 
    root2 = [1,3,2]
Output: false
******************************************************************************/
public class LeafSimilar
{
    public static bool Original(TreeNode root1, TreeNode root2)
    {
        var root1Values = GetLeafValues(root1);
        var root2Values = GetLeafValues(root2);

        if(root1Values.Count != root2Values.Count)
        {
            return false;    
        }

        for(int i = 0; i < root1Values.Count; i++)
        {
            if(root1Values[i] != root2Values[i])
            {
                return false;
            }
        }
        return true;
    } // end method

    protected static IList<int> GetLeafValues(TreeNode root)
    {
        var result = new List<int>();
        if(root.left == null && root.right == null)
        {
            result.Add(root.val);
            return result;
        }

        if(root.left != null)
        {
            result.AddRange(GetLeafValues(root.left));
        }
        
        if(root.right != null)
        {
            result.AddRange(GetLeafValues(root.right));
        }

        return result;
    } // end method
} // end class