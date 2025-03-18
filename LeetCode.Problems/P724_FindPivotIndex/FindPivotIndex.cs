using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode.Problems.P724_FindPivotIndex;

public class FindPivotIndex
{
    /**************************************************************
    Given an array of integers nums, calculate the pivot index of this array.

    The pivot index is the index where the sum of all the numbers strictly to the 
    left of the index is equal to the sum of all the numbers strictly to the index's right.

    If the index is on the left edge of the array, then the left sum is 0 because 
    there are no elements to the left. This also applies to the right edge of the array.

    Return the leftmost pivot index. If no such index exists, return -1.

    Constraints:
    1 <= nums.length <= 104
    -1000 <= nums[i] <= 1000

    Example 1:
    Input: nums = [1,7,3,6,5,6]
    Output: 3
    Explanation:
    The pivot index is 3.
    Left sum = nums[0] + nums[1] + nums[2] = 1 + 7 + 3 = 11
    Right sum = nums[4] + nums[5] = 5 + 6 = 11
    
    Example 2:
    Input: nums = [1,2,3]
    Output: -1
    Explanation:
    There is no index that satisfies the conditions in the problem statement.
    
    Example 3:
    Input: nums = [2,1,-1]
    Output: 0
    Explanation:
    The pivot index is 0.
    Left sum = 0 (no elements to the left of index 0)
    Right sum = nums[1] + nums[2] = 1 + -1 = 0
    **************************************************************/
    public static int Original(int[] nums)
    {
        var rightSumPrefixes = new int[nums.Length];
        
        // work backwards, skipping last because it is zero
        // populating the rightSumPrefixes array
        // [1,7,3,6,5,6] => [27,20,17,11,6,0]
        for(var i = nums.Length - 2; i >= 0; i--)
        {
            rightSumPrefixes[i] = rightSumPrefixes[i + 1] + nums[i + 1];
        }

        var currentLeftSum = 0;
        if(rightSumPrefixes[0] == 0)
        {
            return 0;
        }

        // right sum prefixes =  [27,20,17,11,6,0]
        // running left sum
        // 0    1   2   3   4   5 - indices
        // 1    7   3   6   5   6 - original
        // 27   20  17  11  6   0 - right prefix
        // 0    1   8   11
        for(int i = 1; i < nums.Length; i++) 
        {
            currentLeftSum += nums[i-1];

            if(currentLeftSum == rightSumPrefixes[i])
            {
                return i;
            }
        }

        return -1;
    } // end method
} // end class
