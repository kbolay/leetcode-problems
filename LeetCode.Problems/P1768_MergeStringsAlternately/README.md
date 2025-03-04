# Benchmark Results
| Method                      | Mean       | Error    | StdDev   | Gen0   | Allocated |
|---------------------------- |-----------:|---------:|---------:|-------:|----------:|
| Simple                      | 2,261.5 ns | 44.17 ns | 76.19 ns | 2.5406 |   21256 B |
| WithStringBuilder           |   291.4 ns |  5.85 ns | 14.47 ns | 0.1450 |    1216 B |
| WithStringBuilderWithLength |   134.6 ns |  2.69 ns |  6.51 ns | 0.0572 |     480 B |
| WithSpans                   |   131.8 ns |  2.31 ns |  2.84 ns | 0.0257 |     216 B |

# Problem 1768. Merge Strings Alternately - Easy

You are given two strings word1 and word2. Merge the strings by adding letters in alternating order, starting with word1. If a string is longer than the other, append the additional letters onto the end of the merged string.

Return the merged string. 

## Example 1:

Input: word1 = "abc", word2 = "pqr"
Output: "apbqcr"
Explanation: The merged string will be merged as so:
word1:  a   b   c
word2:    p   q   r
merged: a p b q c r

## Example 2:

Input: word1 = "ab", word2 = "pqrs"
Output: "apbqrs"
Explanation: Notice that as word2 is longer, "rs" is appended to the end.
word1:  a   b 
word2:    p   q   r   s
merged: a p b q   r   s

## Example 3:

Input: word1 = "abcd", word2 = "pq"
Output: "apbqcd"
Explanation: Notice that as word1 is longer, "cd" is appended to the end.
word1:  a   b   c   d
word2:    p   q 
merged: a p b q c   d
 

Constraints:

1 <= word1.length, word2.length <= 100
word1 and word2 consist of lowercase English letters.