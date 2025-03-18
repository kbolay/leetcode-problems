using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.P1493_LongestSubarrayAfterDelete;

namespace LeetCode.Tests.P1493_LongestSubarrayAfterDelete
{
    public class UnitTests
    {
        /**********************************************************************************************
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
        [Theory]
        [InlineData(3, 1,1,0,1)]
        [InlineData(5, 0,1,1,1,0,1,1,0,1)]
        [InlineData(2, 1,1,1)]
        [InlineData(0, 0,0,0)]
        [InlineData(1, 0,1,0)]
        [InlineData(0, 1)]
        [InlineData(0, 0)]
        public void Original(int expected, params int[] nums)
        {
            var result = LongestSubarrayOfOnesAfterDeletingOneElement.Original(nums);
            Assert.Equal(expected, result);
        }
    }
}