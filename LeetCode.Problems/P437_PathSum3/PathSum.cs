using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.Shared;

namespace LeetCode.Problems.P437_PathSum3;

/**************************************************************
Given the root of a binary tree and an integer targetSum, 
return the number of paths where the sum of the values along 
the path equals targetSum.

The path does not need to start or end at the root or a leaf, 
but it must go downwards (i.e., traveling only from parent nodes to child nodes).

Example 1;
Input: root = [10,5,-3,3,2,null,11,3,-2,null,1], targetSum = 8
Output: 3
Explanation: The paths that sum to 8 are shown.

Example 2:
Input: root = [5,4,8,11,null,13,4,7,2,null,null,5,1], targetSum = 22
Output: 3

Constraints:

The number of nodes in the tree is in the range [0, 1000].
-10^9 <= Node.val <= 10^9
-1000 <= targetSum <= 1000
**************************************************************/
public class PathSum
{
    private static IList<int> pathValues = new List<int>();
    public static int Original(TreeNode root, int targetSum)
    {
        if(root == null)
        {
            return 0;
        }

        var result = root.val == targetSum ? 1 : 0;
        long sum = root.val;        
        for(int i = pathValues.Count - 1; i >= 0; i--)
        {
            if(sum + pathValues[i] == targetSum)
            {
                result++;
            }
            sum += pathValues[i];
        }

        // add the value to the path
        pathValues.Add(root.val);

        result += Original(root.left, targetSum);
        result += Original(root.right, targetSum);

        // take the value out of the path
        pathValues = pathValues.Take(pathValues.Count - 1).ToList();

        return result;
    } // end method

    public static int FoundSolution(TreeNode root, int targetSum)
    {
        var prefixSumCounts = new Dictionary<long, int>()
        {
            { 0, 1 }
        };

        return FoundSolutionDFS(root, 0, targetSum, prefixSumCounts);
    }

    private static int FoundSolutionDFS(
        TreeNode root, 
        long currentSum, 
        int target, 
        Dictionary<long, int> prefixSumCounts)
    {
        if(root == null)
        {
            return 0;
        }

        // add the node value ot the currentSum
        currentSum += root.val;

        // get the number of prefix sums that are equal to the difference between the current sum and the target
        int result = prefixSumCounts.GetValueOrDefault(currentSum - target, 0);

        // make sure the current sum is in the dictionary and add 1
        prefixSumCounts[currentSum] = prefixSumCounts.GetValueOrDefault(currentSum, 0) + 1;

        // call the right and left node with the prefix sums
        result += FoundSolutionDFS(root.left, currentSum, target, prefixSumCounts) + FoundSolutionDFS(root.right, currentSum, target, prefixSumCounts);

        // reduce the count of the current sum to remove this node from the path
        prefixSumCounts[currentSum]--;
        return result;
    } // end method
} // end class