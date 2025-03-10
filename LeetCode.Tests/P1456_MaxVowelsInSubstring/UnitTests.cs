using LeetCode.Problems.P1456_MaxVowelsInWindow;

namespace LeetCode.Tests.P1456_MaxVowelsInSubstring
{
    public class UnitTests
    {
        [Theory]
        [InlineData("abciiidef", 3, 3)]
        [InlineData("aeiou", 2, 2)]
        [InlineData("leetcode", 3, 2)]
        [InlineData("novowels", 1, 1)]
        [InlineData("tnfazcwrryitgacaabwm", 4, 3)]
        public void Original(string s, int k, int expected)
        {
            var result = MaxVowelsInSubstring.Original(s, k);
            Assert.Equal(expected, result);
        }
    }
}