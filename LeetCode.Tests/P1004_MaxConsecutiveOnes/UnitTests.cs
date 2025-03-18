using LeetCode.Problems.P1004_MaxConsecutiveOnes;

namespace LeetCode.Tests.P1004_MaxConsecutiveOnes
{
    public class UnitTests
    {
        [Theory]
        [InlineData(1, 0, 0, 1, 0)]
        [InlineData(2, 0, 0, 1, 1)]
        [InlineData(2, 1, 0, 1, 0)]
        [InlineData(3, 1, 0, 1, 0, 1, 0)]
        [InlineData(6, 2, 1,1,1,0,0,0,1,1,1,1,0)]
        [InlineData(10, 3, 0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1)]
        [InlineData(4, 1, 0, 1, 0, 1, 1)]
        [InlineData(3, 2, 1, 0, 1)]
        public void Original(int expected, int allowedAdditions, params int[] nums)
        {
            var result = MaxConsecutiveOnes.Original(nums, allowedAdditions);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 0, 0, 1, 0)]
        [InlineData(2, 0, 0, 1, 1)]
        [InlineData(2, 1, 0, 1, 0)]
        [InlineData(3, 1, 0, 1, 0, 1, 0)]
        [InlineData(6, 2, 1,1,1,0,0,0,1,1,1,1,0)]
        [InlineData(10, 3, 0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1)]
        [InlineData(4, 1, 0, 1, 0, 1, 1)]
        [InlineData(3, 2, 1, 0, 1)]
        public void Solution(int expected, int allowedAdditions, params int[] nums)
        {
            var result = MaxConsecutiveOnes.Solution(nums, allowedAdditions);
            Assert.Equal(expected, result);
        }
    }
}