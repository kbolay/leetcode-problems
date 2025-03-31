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
        if(nums == null || nums.Length == 0)
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

    public static TreeNode ToTreeNode(this int[] nums)
    {
        if(nums == null || nums.Length == 0)
        {
            return null;
        }
        
        var root = new TreeNode(nums[0]);
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        var counter = 1;
        while(counter < nums.Length)
        {
            var currentNode = queue.Peek();
            if(counter % 2 == 1)
            {
                currentNode.left = new TreeNode(nums[counter]);
                queue.Enqueue(currentNode.left);                
            }
            else
            {
                currentNode.right = new TreeNode(nums[counter]);
                queue.Enqueue(currentNode.right);
                queue.Dequeue();
            }
            
            counter++;
        }

        return root;
    }

    public static int?[] ToValues(this TreeNode root)
    {
        if(root == null)
        {
            return [];
        }

        var result = new List<int?>();

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while(queue.Count > 0)
        {
            var node = queue.Dequeue();

            if(node != null)
            {
                result.Add(node.val);
                if(node.left != null || node.right != null)
                {
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
            }
            else
            {
                result.Add(null);
            }
        }

        return result.ToArray();
    }

    public static int[] FromBSTTOValues(this TreeNode root)
    {
        if(root == null)
        {
            return [];
        }

        var result = new List<int>();

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while(queue.Count > 0)
        {
            var node = queue.Dequeue();

            if(node != null)
            {
                result.Add(node.val);
                if(node.left != null)
                {
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
            }
        }

        return result.ToArray();
    } // end method
} // end class