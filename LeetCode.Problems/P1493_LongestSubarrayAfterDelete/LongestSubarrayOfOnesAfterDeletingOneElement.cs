using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode.Problems.P1493_LongestSubarrayAfterDelete;

public class LongestSubarrayOfOnesAfterDeletingOneElement
{
    /***********************************************************************
    Given a binary array nums, you should delete one element from it.

    Return the size of the longest non-empty subarray containing only 1's in 
    the resulting array. 
    
    Return 0 if there is no such subarray.

    Constraints:
    1 <= nums.length <= 105
    nums[i] is either 0 or 1.

    Example 1:
    Input: nums = [1,1,0,1]
    Output: 3
    Explanation: After deleting the number in position 2, [1,1,1] contains 3 numbers with value of 1's.

    Example 2:
    Input: nums = [0,1,1,1,0,1,1,0,1]
    Output: 5
    Explanation: After deleting the number in position 4, [0,1,1,1,1,1,0,1] longest subarray with value of 1's is [1,1,1,1,1].

    Example 3:
    Input: nums = [1,1,1]
    Output: 2
    Explanation: You must delete one element.
    ***********************************************************************/

    /// <summary>
    /// Adapting the found solution from P1004_MaxConsecutiveOnes
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int Original(int[] nums)
    {
        if(nums.Length == 1) {
            return 0;
        }
        
        var left = 0;
        var zeroCount = 0;
        var result = 0;
        
        for(var right = 0; right < nums.Length; right++)
        {
            if(nums[right] == 0) {
                zeroCount++;
            }

            while(zeroCount > 1)
            {
                if(nums[left] == 0) 
                {
                    zeroCount--;
                }
                left++;
            }

            result = Math.Max(result, right-left);
        }

        return result;
    } // end method
} // end class
