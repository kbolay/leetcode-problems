using LeetCode.Problems.P1071_GCDStrings;

namespace LeetCode.Tests.P1071_GCDStrings
{
    public class GcdOfStringsTests
    {
        [Theory]
        [InlineData("ABCABC", "ABC", "ABC")]
        [InlineData("ABABAB", "ABAB", "AB")]
        [InlineData("LEET", "CODE", "")]
        [InlineData("ABCDEF", "ABC", "")]
        public void WithSpans(string str1, string str2, string expected)
        {
            var gcd = GcdOfStrings.WithSpans(str1, str2);
            Assert.Equal(expected, gcd);
        }

        [Fact]
        public void SpanEqualsTest()
        {
            var str1 = "ABCABC".AsSpan();

            var pattern = str1.Slice(0, 3);

            var pieces = str1.ToString().Split(pattern.ToString(), StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(0, pieces.Length);
        }
    }
}