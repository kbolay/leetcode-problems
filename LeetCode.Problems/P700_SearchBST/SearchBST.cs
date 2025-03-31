using LeetCode.Problems.Shared;

namespace LeetCode.Problems.P700_SearchBST;
public class SearchBST
{
    public static TreeNode Original(TreeNode root, int val)
    {
        var current = root;
        while(current != null)
        {
            if(current.val == val)
            {
                return current;
            }

            if(current.val > val)
            {
                current = current.left;
            }
            else
            {
                current = current.right;
            }
        }

        return null;
    } // end method
} // end method