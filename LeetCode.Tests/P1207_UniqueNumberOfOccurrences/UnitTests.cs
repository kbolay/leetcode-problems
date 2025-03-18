using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.P1207_UniqueNumberOfOccurrences;

namespace LeetCode.Tests.P1207_UniqueNumberOfOccurrences
{
    public class UnitTests
    {
        /******************************************************************************
        Example 1:
        Input: arr = [1,2,2,1,1,3]
        Output: true
        Explanation: The value 1 has 3 occurrences, 2 has 2 and 3 has 1. No two values have the same number of occurrences.

        Example 2:
        Input: arr = [1,2]
        Output: false
        
        Example 3:
        Input: arr = [-3,0,1,-3,1,1,1,-3,10,0]
        Output: true
        ******************************************************************************/

        [Theory]
        [InlineData(true, 1,2,2,1,1,3)]
        [InlineData(false, 1,2)]
        [InlineData(true, -3, 0, 1, -3, 1, 1, 1, -3, 10, 0)]
        public void Original(bool expected, params int[] nums)
        {
            var result = UniqueNumberOfOccurrences.Original(nums);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, 1,2,2,1,1,3)]
        [InlineData(false, 1,2)]
        [InlineData(true, -3, 0, 1, -3, 1, 1, 1, -3, 10, 0)]
        public void UsingDictionary(bool expected, params int[] nums)
        {
            var result = UniqueNumberOfOccurrences.UsingDictionary(nums);
            Assert.Equal(expected, result);
        }
    }
}