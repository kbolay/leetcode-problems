using System.Security.AccessControl;
using Microsoft.Diagnostics.Tracing.Parsers.AspNet;

namespace LeetCode.Problems.P1004_MaxConsecutiveOnes;
public class MaxConsecutiveOnes
{
    /// <summary>
    /// Accepted - Very slow
    /// Uses a queue object to keep the relevant counts
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static int Original(int[] nums, int k)
    {
        if(k == nums.Length)
        {
            return nums.Length;
        }

        var consecutiveOnes = 0;
        var result = 0;
        if(k == 0)
        {
            for(int i = 0; i < nums.Length; i++)
            {
                if(nums[i] == 0)
                {
                    result = Math.Max(result, consecutiveOnes);
                    consecutiveOnes = 0;
                }
                else
                {
                    consecutiveOnes++;
                }
                
            }
            return Math.Max(result, consecutiveOnes);
        }

        // create a queue with length one more than k
        var slidingWindow = new Queue<int>(k);

        for(int i = 0; i < nums.Length; i++)
        {
            if(nums[i] == 1)
            {
                consecutiveOnes++;
                continue;
            }

    
            // value is a zero
            // is the queue full
            if(slidingWindow.Count() == slidingWindow.Capacity)
            {
                result = Math.Max(result, slidingWindow.Sum() + consecutiveOnes);
                _ = slidingWindow.Dequeue();
            }
            
            slidingWindow.Enqueue(consecutiveOnes + 1);
            consecutiveOnes = 0;
        }

        result = Math.Max(result, slidingWindow.Sum() + consecutiveOnes);

        return result;
    } // end method

    
    /// <summary>
    /// Solution found on LeetCode.
    /// Attempting to learn from it.
    /// </summary>
    /// <param name="nums">The input array of numbers</param>
    /// <param name="k">The number of zeros that can be replaced with ones to make the longest consecutive chain of ones.</param>
    /// <returns></returns>
    public static int Solution(int[] nums, int k)
    {
        var left = 0;
        var maxLength = 0;
        var zeroCount = 0;

        // 1. Advance the right pointer until there are more zeros in the left side than k.
        // 2. Advance the left side pointer removing zeros from the window until the number of zeros in the window is equal to k.
        // 3. Calculate the distance between the two and check to see if that is larger than the current largest result.
        for(int right = 0; right < nums.Length; right++)
        {
            if(nums[right] == 0)
            {
                zeroCount++;
            }

            while(zeroCount > k)
            {
                if(nums[left] == 0)
                {
                    zeroCount--;
                }
                left++;
            } // end while
            maxLength = Math.Max(maxLength, right-left + 1);
        } // end for

        return maxLength;
    } // end method
} // end class
