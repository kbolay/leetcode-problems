using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.P443_StringCompression;

namespace LeetCode.Tests.P443_StringCompression
{
    public class UnitTests
    {
        [Theory]
        [InlineData("aabbccc", 6, "a2b2c3")]
        [InlineData("a", 1, "a")]
        [InlineData("abbbbbbbbbbbb", 4, "ab12")]
        [InlineData("aab", 3, "a2b")]
        public void Simple(string input, int expected, string expectedPrefix)
        {
            var inputArray = input.ToArray();
            var result = StringCompression.Simple(inputArray);
            Assert.Equal(expected, result);
            Assert.StartsWith(expectedPrefix, inputArray);
        }
    }
}