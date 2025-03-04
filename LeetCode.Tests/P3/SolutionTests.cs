// using Xunit;
// using P3Solution = LeetCode.Problems.P3.Solution;

// namespace LeetCode.Problems.P3
// {
//     public class SolutionTests
//     {
//         [Theory]
//         [InlineData("abcabcbb", 3)]
//         [InlineData("bbbbb", 1)]
//         [InlineData("pwwkew", 3)]
//         [InlineData("abcdef", 6)]
//         [InlineData("aab", 2)]
//         [InlineData("", 0)]
//         [InlineData("cdd", 2)]
//         [InlineData("abcb", 3)]
//         public void Tester(string input, int expected)
//         {
//             var instance = new P3Solution();
//             var result = instance.LengthOfLongestSubstring(input);

//             Assert.Equal(expected, result);
//         } // end method
//     } // end class
// } // end namespace