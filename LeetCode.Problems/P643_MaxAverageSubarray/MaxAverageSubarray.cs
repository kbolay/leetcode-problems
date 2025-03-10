using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode.Problems.P643_MaxAverageSubarray;

/******************************************************************************
You are given an integer array nums consisting of n elements, and an integer k.

Find a contiguous subarray whose length is equal to k that has the maximum average 
value and return this value. 
Any answer with a calculation error less than 10^-5 (0.00001) will be accepted.

Example 1:
Input: nums = [1,12,-5,-6,50,3], k = 4
Output: 12.75000
Explanation: Maximum average is (12 - 5 - 6 + 50) / 4 = 51 / 4 = 12.75

Example 2:
Input: nums = [5], k = 1
Output: 5.00000

Constraints:

n == nums.length
1 <= k <= n <= 105
-104 <= nums[i] <= 104
******************************************************************************/
public class MaxAverageSubarray
{
    /// <summary>
    /// Iterate through the array grabbing k elements and calculating their average.
    /// Keep if the average is larger than the previous average.
    /// I can keep the sum of k-1 from previous iteration to reduce operations
    /// RESULT: ACCEPTED
    /// After looking around at solutions I realized I avoid calculating average until the end, and just keep max sum.
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static double Original(int[] nums, int k)
    {
        if(nums.Length == 1)
        {
            return nums[0];
        }

        if(k == 1)
        {
            return nums.Max();
        }

        // we know that the values have a minimum value of -104
        int maxSum = int.MinValue;
        
        // a value we use in the next iteration 
        int runningSum = 0;
        for(int i = 0; i < k - 1; i++)
        {
            runningSum += nums[i];
        }

        // use the end of the window as the iterator piece
        // if k = 4 we will start with i = 3
        for(int i = k - 1; i < nums.Length; i++)
        {
            // are we on the first iteration of the loop?
            if(i - k >= 0)
            {
                // remove the item that fell out of the window
                runningSum -= nums[i-k];
            }
            
            // add the item that just entered the window
            runningSum += nums[i];

            maxSum = Math.Max(maxSum, runningSum);
        }

        return ((double)maxSum) / k;
    } // end method
} // end class