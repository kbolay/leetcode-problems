using LeetCode.Problems.P392_IsSubsequence;

namespace LeetCode.Tests.P392_IsSubsequence
{
    public class UnitTests
    {
        [Theory]
        [InlineData("abc", "ahbgdc", true)]
        [InlineData("axc", "ahbgdc", false)]
        [InlineData("ace", "eafocddde", true)]
        [InlineData("ace", "babcbb", false)]
        [InlineData("acccceeee", "123", false)]
        [InlineData("ace", "ace", true)]
        [InlineData("rjufvjafbxnbgriwgokdgqdqewn", "mjmqqjrmzkvhxlyruonekhhofpzzslupzojfuoztvzmmqvmlhgqxehojfowtrinbatjujaxekbcydldglkbxsqbbnrkhfdnpfbuaktupfftiljwpgglkjqunvithzlzpgikixqeuimmtbiskemplcvljqgvlzvnqxgedxqnznddkiujwhdefziydtquoudzxstpjjitmiimbjfgfjikkjycwgnpdxpeppsturjwkgnifinccvqzwlbmgpdaodzptyrjjkbqmgdrftfbwgimsmjpknuqtijrsnwvtytqqvookinzmkkkrkgwafohflvuedssukjgipgmypakhlckvizmqvycvbxhlljzejcaijqnfgobuhuiahtmxfzoplmmjfxtggwwxliplntkfuxjcnzcqsaagahbbneugiocexcfpszzomumfqpaiydssmihdoewahoswhlnpctjmkyufsvjlrflfiktndubnymenlmpyrhjxfdcq", false)]
        public void Simple(string subsequence, string original, bool expected)
        {
            var result = IsSubsequence.Simple(subsequence, original);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("abc", "ahbgdc", true)]
        [InlineData("axc", "ahbgdc", false)]
        [InlineData("ace", "eafocddde", true)]
        [InlineData("ace", "babcbb", false)]
        [InlineData("acccceeee", "123", false)]
        [InlineData("ace", "ace", true)]
        [InlineData("rjufvjafbxnbgriwgokdgqdqewn", "mjmqqjrmzkvhxlyruonekhhofpzzslupzojfuoztvzmmqvmlhgqxehojfowtrinbatjujaxekbcydldglkbxsqbbnrkhfdnpfbuaktupfftiljwpgglkjqunvithzlzpgikixqeuimmtbiskemplcvljqgvlzvnqxgedxqnznddkiujwhdefziydtquoudzxstpjjitmiimbjfgfjikkjycwgnpdxpeppsturjwkgnifinccvqzwlbmgpdaodzptyrjjkbqmgdrftfbwgimsmjpknuqtijrsnwvtytqqvookinzmkkkrkgwafohflvuedssukjgipgmypakhlckvizmqvycvbxhlljzejcaijqnfgobuhuiahtmxfzoplmmjfxtggwwxliplntkfuxjcnzcqsaagahbbneugiocexcfpszzomumfqpaiydssmihdoewahoswhlnpctjmkyufsvjlrflfiktndubnymenlmpyrhjxfdcq", false)]
        public void WithSpan(string subsequence, string original, bool expected)
        {
            var result = IsSubsequence.WithSpan(subsequence, original);
            Assert.Equal(expected, result);
        }
    }
}