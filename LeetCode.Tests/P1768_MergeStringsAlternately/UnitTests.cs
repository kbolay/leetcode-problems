using LeetCode.Problems.P1768_MergeStringsAlternately;

namespace LeetCode.Tests.P1768_MergeStringsAlternately;

public class UnitTests
{
    [Theory]
    [InlineData("abc", "def", "adbecf")]
    [InlineData("abc", "de", "adbec")]
    [InlineData("abc", "defghi", "adbecfghi")]
    public void TestSimple(string word1, string word2, string expected)
    {
        var result = MergeStringsAlternately.Simple(word1, word2);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("abc", "def", "adbecf")]
    [InlineData("abc", "de", "adbec")]
    [InlineData("abc", "defghi", "adbecfghi")]
    public void TestStringBuilder(string word1, string word2, string expected)
    {
        var result = MergeStringsAlternately.WithStringBuilder(word1, word2);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("abc", "def", "adbecf")]
    [InlineData("abc", "de", "adbec")]
    [InlineData("abc", "defghi", "adbecfghi")]
    public void TestSpans(string word1, string word2, string expected)
    {
        var result = MergeStringsAlternately.WithSpans(word1, word2);
        Assert.Equal(expected, result);
    }
}
