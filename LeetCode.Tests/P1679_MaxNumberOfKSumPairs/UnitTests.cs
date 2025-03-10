using LeetCode.Problems.P1679_MaxNumberOfKSumPairs;

namespace LeetCode.Tests.P1679_MaxNumberOfKSumPairs
{
    public class UnitTests
    {
        [Theory]
        [InlineData(2, 5, 1, 2, 3, 4)]
        [InlineData(1, 6, 3, 1, 3, 4, 3)]
        public void Original(int expected, int sum, params int[] numbers)
        {
            var result = MaxNumberOfKSumPairs.Original(numbers, sum);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2, 5, 1, 2, 3, 4)]
        [InlineData(1, 6, 3, 1, 3, 4, 3)]
        public void SecondAttempt(int expected, int sum, params int[] numbers)
        {
            var result = MaxNumberOfKSumPairs.SecondAttempt(numbers, sum);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2, 5, 1, 2, 3, 4)]
        [InlineData(1, 6, 3, 1, 3, 4, 3)]
        public void DictionarySolution(int expected, int sum, params int[] numbers)
        {
            var result = MaxNumberOfKSumPairs.DictionarySolution(numbers, sum);
            Assert.Equal(expected, result);
        }
    }
}