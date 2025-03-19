using LeetCode.Problems.P1657_AreTwoStringsClose;

namespace LeetCode.Tests.P1657_AreTwoStringsClose;

public class UnitTests
{
    /******************************************************************************
    Example 1:
    Input: word1 = "abc", word2 = "bca"
    Output: true
    Explanation: You can attain word2 from word1 in 2 operations.
    Apply Operation 1: "abc" -> "acb"
    Apply Operation 1: "acb" -> "bca"
    
    Example 2:
    Input: word1 = "a", word2 = "aa"
    Output: false
    Explanation: It is impossible to attain word2 from word1, or vice versa, in any number of operations.
    
    Example 3:
    Input: word1 = "cabbba", word2 = "abbccc"
    Output: true
    Explanation: You can attain word2 from word1 in 3 operations.
    Apply Operation 1: "cabbba" -> "caabbb"
    Apply Operation 2: "caabbb" -> "baaccc"
    Apply Operation 2: "baaccc" -> "abbccc"
    ******************************************************************************/

    [Theory]
    [InlineData(true, "abc", "bca")]
    [InlineData(false, "a", "aa")]
    [InlineData(true, "cabbba", "abbccc")]
    [InlineData(false, "cabbba", "aabbss")]
    [InlineData(false, "uau", "ssx")]
    public void Original(bool expected, string word1, string word2)
    {
        var result = AreTwoStringsClose.Original(word1, word2);
        Assert.Equal(expected, result);
    }
}
