using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.P643_MaxAverageSubarray;

namespace LeetCode.Tests.P643_MaxAverageSubarray
{
    public class UnitTests
    {
        /******************************************************************************
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

        [Theory]
        [InlineData(12.75000, 4, 1, 12, -5, -6, 50, 3)]
        [InlineData(5.0000, 1, 5)]
        [InlineData(2.00000, 4, 0, 1, 1, 3, 3)]
        public void Original(double expected, int k, params int[] nums)
        {
            var result = MaxAverageSubarray.Original(nums, k);
            Assert.Equal(expected, result);
        } // end method
    } // end class
} // end namespace