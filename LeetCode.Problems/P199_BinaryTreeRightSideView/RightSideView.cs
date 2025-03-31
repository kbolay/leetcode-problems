using LeetCode.Problems.Shared;

namespace LeetCode.Tests.P199_BinaryTreeRightSideView;

public class RightSideView
{
    /// <summary>
    /// Wanted some help constructing the BFS walk of the tree
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static IList<int> FoundSolution(TreeNode root)
    {
        var result = new List<int>();

        if(root == null)
        {
            return result;
        }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while(queue.Count > 0)
        {
            int levelSize = queue.Count;
            for(int i = 0; i < levelSize; i++)
            {
                var node = queue.Dequeue();

                if(i == levelSize - 1) 
                {
                    result.Add(node.val);
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
