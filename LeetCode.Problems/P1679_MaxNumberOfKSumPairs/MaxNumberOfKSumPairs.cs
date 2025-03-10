namespace LeetCode.Problems.P1679_MaxNumberOfKSumPairs;

/***********************************************************************
You are given an integer array nums and an integer k.

In one operation, you can pick two numbers from the array whose sum equals k and remove them from the array.

Return the maximum number of operations you can perform on the array.

 

Example 1:

Input: nums = [1,2,3,4], k = 5
Output: 2
Explanation: Starting with nums = [1,2,3,4]:
- Remove numbers 1 and 4, then nums = [2,3]
- Remove numbers 2 and 3, then nums = []
There are no more pairs that sum up to 5, hence a total of 2 operations.
Example 2:

Input: nums = [3,1,3,4,3], k = 6
Output: 1
Explanation: Starting with nums = [3,1,3,4,3]:
- Remove the first two 3's, then nums = [1,4,3]
There are no more pairs that sum up to 6, hence a total of 1 operation.
**************************************************************************/

public class MaxNumberOfKSumPairs
{
    /// <summary>
    /// My original attempt without asking AI for the answer or consulting the solutions available.
    /// There is no nice way to delete an item from an array in C#, so instead I will move the used elements to the front of the array.
    /// RESULT: TIMED OUT
    /// </summary>
    /// <param name="nums">
    // Length: 1 - 10^5
    // Values: 1 - 10^9
    // </param>
    /// <param name="k">1 <= k <= 10^9</param>
    /// <returns></returns>
    public static int Original(int[] nums, int k)
    {
        var result = 0;

        var firstPointer = 0; // start at the index after the pairs that have been moved to the front
        var secondPointer = 1;

        // loop until first pointer is at the end
        while(firstPointer < nums.Length - 1) 
        {
            if(nums[firstPointer] + nums[secondPointer] == k)
            {
                // simulate removing items from the array
                if(secondPointer > firstPointer + 1)
                {
                    // we need to swap positions
                    var valueToSwap = nums[firstPointer + 1];
                    nums[firstPointer + 1] = nums[secondPointer];
                    nums[secondPointer] = valueToSwap;                    
                }

                firstPointer += 2;
                secondPointer = firstPointer + 1;
                result++;
            }
            else if(secondPointer == nums.Length - 1)
            {
                // we are out of options for this first pointer value
                firstPointer++;
                secondPointer = firstPointer + 1;
            }
            else
            {
                // push second pointer to compare next 
                secondPointer++;
            }
        }        

        return result;
    } // end method


    /// <summary>
    /// Sorting first then using two pointers to work towards the middle.
    /// Very likely that sorting first will cause a timeout. 
    /// Still something i want to try before looking up the solution.
    /// RESULT: ACCEPTED
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static int SecondAttempt(int[] nums, int k)
    {
        var result = 0;

        var orderedNums = nums.OrderBy(x => x).ToArray();

        var minPointer = 0; // start at the index after the pairs that have been moved to the front
        var maxPointer = nums.Length - 1;

        // loop until min pointer meets max pointer
        while(minPointer < maxPointer) 
        {
            var sum = orderedNums[minPointer] + orderedNums[maxPointer];

            if(sum == k)
            {
                minPointer++;
                maxPointer--;
                result++;

                continue;
            }
            else if(sum > k)
            {
                maxPointer--;
            }
            else
            {
                minPointer++;
            }            
        }        

        return result;
    } // end method

    /// <summary>
    /// Using a dictionary to keep track of the number of any value available for making the desired sum.
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static int DictionarySolution(int[] nums, int k)
    {
        var result = 0;

        var dict = new Dictionary<int, int>();

        for(int i = 0; i < nums.Length; i++)
        {
            var value = nums[i];
            if(value > k)
            {
                continue;
            }
            
            var complement = k - value;

            if(dict.GetValueOrDefault(complement) > 0)
            {
                dict[complement]--;
                result++;
            }
            else
            {
                dict[value] = dict.GetValueOrDefault(value) + 1;
            }
        }

        return result;
    } // end method
} // end class