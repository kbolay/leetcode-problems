namespace LeetCode.Problems.Shared;
/// <summary>
/// Definition of ListNode provided by LeetCode
/// </summary>
public class ListNode
{
    public int val;
    public ListNode? next;
    public ListNode(int val=0, ListNode? next= null)
    {
        this.val = val;
        this.next = next;
    }

    public static ListNode? ToListNode(int[] nums)
    {
        ListNode? result = null;
        if(nums.Length > 0)
        {
            for(int i = nums.Length - 1; i >= 0; i--)
            {
                result = new ListNode(nums[i], result);
            }
        }
        return result;
    }
}

