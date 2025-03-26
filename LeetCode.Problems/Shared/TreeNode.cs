using Microsoft.Extensions.Logging.Abstractions.Internal;

namespace LeetCode.Problems.Shared;
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
} // end class

public static class TreeNodeExtensions
{
    public static TreeNode ToTreeNode(this int?[] nums)
    {
        if(nums == null)
        {
            return null;
        }
        
        var root = new TreeNode(nums[0].Value);
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        var counter = 1;
        while(counter < nums.Length)
        {
            var currentNode = queue.Peek();
            if(counter % 2 == 1)
            {
                if(nums[counter].HasValue)
                {
                    currentNode.left = new TreeNode(nums[counter].Value);
                    queue.Enqueue(currentNode.left);
                }                
            }
            else
            {
                if(nums[counter].HasValue)
                {
                    currentNode.right = new TreeNode(nums[counter].Value);
                    queue.Enqueue(currentNode.right);
                }
                queue.Dequeue();
            }
            
            counter++;
        }

        return root;
    }
} // end class