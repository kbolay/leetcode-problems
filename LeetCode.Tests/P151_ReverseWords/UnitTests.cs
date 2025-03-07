using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.P151_ReverseWords;

namespace LeetCode.Tests.P151_ReverseWords;

public class UnitTests
{
    [Theory]
    [InlineData("The quick brown dog", "dog brown quick The")]
    [InlineData("the sky is blue", "blue is sky the")]
    [InlineData("  hello world  ", "world hello")]
    [InlineData("  hello world", "world hello")]
    [InlineData("hello world  ", "world hello")]
    [InlineData("hello   world  ", "world hello")]
    public void Simple(string input, string expected)
    {
        var result = ReverseWords.Simple(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("The quick brown dog", "dog brown quick The")]
    [InlineData("the sky is blue", "blue is sky the")]
    [InlineData("  hello world  ", "world hello")]
    [InlineData("  hello world", "world hello")]
    [InlineData("hello world  ", "world hello")]
    [InlineData("hello   world", "world hello")]
    public void WithSpan(string input, string expected)
    {
        var result = ReverseWords.WithSpan(input);
        Assert.Equal(expected, result);
    }
} // end class
