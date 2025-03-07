namespace LeetCode.Problems.P283_MoveZeros;
public class MoveZeros
{
    /*
    Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

    Note that you must do this in-place without making a copy of the array.

    Constraints:

    1 <= nums.length <= 104
    -231 <= nums[i] <= 231 - 1
    */
    public static void Simple(int[] nums)
    {
        var writeToIndex = 0;
        for(int i = 0; i < nums.Length; i++)
        {
            if(nums[i] == 0)
            {
                continue;
            }
            
            if(i > writeToIndex)
            {
                nums[writeToIndex] = nums[i];
                nums[i] = 0;
            }

            writeToIndex++;
        }
    }
} // end class