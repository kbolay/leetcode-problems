using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using LeetCode.Problems.P283_MoveZeros;

namespace LeetCode.Tests.P283_MoveZeros
{
    public class UnitTests
    {
        /*
        Example 1:

Input: nums = [0,1,0,3,12]
Output: [1,3,12,0,0]
Example 2:

Input: nums = [0]
Output: [0]
*/
        [Theory]
        [InlineData(new int[] { 0,1,0,3,12}, new int[] { 1,3,12,0,0})]
        [InlineData(new int[] { 0 }, new int[] { 0 })]
        [InlineData(new int[] { 2, 1 }, new int[] { 2, 1 })]
        [InlineData(new int[] { 1, 2 }, new int[] { 1, 2 })]
        [InlineData(new int[] { 1, 1, 3 }, new int[] { 1, 1, 3 })]
        public void Simple(int[] input, int[] expected)
        {
            MoveZeros.Simple(input);
            Assert.Equal(expected, input);
        }
    }
}