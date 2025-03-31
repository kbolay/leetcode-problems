using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.Shared;

namespace LeetCode.Problems.P1161_MaxLevelSumBinaryTree;

public class MaxLevelSum
{
    public static int Original(TreeNode root)
    {
        var result = 1;
        var queue = new Queue<TreeNode>();

        var maxSum = Int32.MinValue;
        queue.Enqueue(root);
        var currentLevel = 1;

        while(queue.Count > 0)
        {
            var levelCount = queue.Count;
            var levelSum = 0;
            for(int i = 0; i < levelCount; i++)
            {
                var node = queue.Dequeue();
                levelSum += node.val;

                if(i == levelCount - 1)
                {
                    if(levelSum > maxSum)
                    {
                        maxSum = levelSum;
                        result = currentLevel;
                    }
                    currentLevel++;
                }

                if(node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if(node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
        }

        return result;
    } // end method
} // end class