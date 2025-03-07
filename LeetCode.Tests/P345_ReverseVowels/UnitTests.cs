using LeetCode.Problems.P345_ReverseVowels;

namespace LeetCode.Tests.P345_ReverseVowels
{
    public class UnitTests
    {
        [Theory]
        [InlineData("IceCreAm", "AceCreIm")]
        [InlineData("leetcode", "leotcede")]
        [InlineData("abc", "abc")]
        [InlineData("abcdi", "ibcda")]
        [InlineData("a", "a")]
        [InlineData("aAbeEciIdoOfuU", "UubOocIidEefAa")]
        public void Simple(string input, string expected)
        {
            var result = ReverseVowelsOfAString.Simple(input);

            Assert.Equal(expected, result);
        }
    }
}