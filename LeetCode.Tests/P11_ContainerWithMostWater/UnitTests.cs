using LeetCode.Problems.P11_ContainerWithMostWater;

namespace LeetCode.Tests.P11_ContainerWithMostWater
{
    public class UnitTests
    {
        [Theory]
        [InlineData(16, 3, 4, 5, 6, 7, 8, 1, 2)]
        [InlineData(1, 1, 1)]
        [InlineData(20_000, 4, 10_000, 56, 11_000)]
        [InlineData(0, 1, 0)]
        [InlineData(0, 0, 0)]
        [InlineData(7 * 7, 1,8,6,2,5,4,8,3,7)]
        public void Original(int expected, params int[] nums)
        {
            var result = ContainerWithMostWater.Original(nums);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(16, 3, 4, 5, 6, 7, 8, 1, 2)]
        [InlineData(1, 1, 1)]
        [InlineData(20_000, 4, 10_000, 56, 11_000)]
        [InlineData(0, 1, 0)]
        [InlineData(0, 0, 0)]
        [InlineData(7 * 7, 1,8,6,2,5,4,8,3,7)]
        public void CorrectSolution(int expected, params int[] nums)
        {
            var result = ContainerWithMostWater.CorrectSolution(nums);

            Assert.Equal(expected, result);
        }
    }
}