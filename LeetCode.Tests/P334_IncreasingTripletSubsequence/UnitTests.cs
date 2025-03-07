using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.P334_IncreasingTripletSubsequence;

namespace LeetCode.Tests.P334_IncreasingTripletSubsequence
{
    public class UnitTests
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, true)]
        [InlineData(new int[] { 5, 4, 3, 2, 1 }, false)]
        [InlineData(new int[] { 2, 1, 5, 0, 4, 6 }, true)]
        [InlineData(new int[] { 1, 2 }, false)]
        [InlineData(new int[] {20,100,10,12,5,13}, true)]
        //[InlineData(new int[] {1,5,0,4,1,3}, true)]
        public void Simple(int[] nums, bool expected)
        {
            var result = IncreasingTripletSubsequence.SimpleAndWrong(nums);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, true)]
        [InlineData(new int[] { 5, 4, 3, 2, 1 }, false)]
        [InlineData(new int[] { 2, 1, 5, 0, 4, 6 }, true)]
        [InlineData(new int[] { 1, 2 }, false)]
        [InlineData(new int[] {20,100,10,12,5,13}, true)]
        [InlineData(new int[] {1,5,0,4,1,3}, true)]
        public void CorrectSolution(int[] nums, bool expected)
        {
            var result = IncreasingTripletSubsequence.CorrectSolution(nums);
            Assert.Equal(expected, result);
        }
    }
}