# Benchmarks

| Method           | Mean     | Error   | StdDev   | Median   | Gen0   | Allocated |
|----------------- |---------:|--------:|---------:|---------:|-------:|----------:|
| Original         | 158.1 ns | 4.91 ns | 14.39 ns | 153.1 ns | 0.0038 |      32 B |
| MultipleContains | 176.4 ns | 3.76 ns | 10.80 ns | 176.6 ns | 0.0105 |      88 B |

# Summary

Given a string s and an integer k, return the maximum number of vowel letters in any substring of s with length k.

Vowel letters in English are 'a', 'e', 'i', 'o', and 'u'. 

Example 1:

Input: s = "abciiidef", k = 3
Output: 3
Explanation: The substring "iii" contains 3 vowel letters.
Example 2:

Input: s = "aeiou", k = 2
Output: 2
Explanation: Any substring of length 2 contains 2 vowels.
Example 3:

Input: s = "leetcode", k = 3
Output: 2
Explanation: "lee", "eet" and "ode" contain 2 vowels.
 

Constraints:

1 <= s.length <= 105
s consists of lowercase English letters.
1 <= k <= s.length