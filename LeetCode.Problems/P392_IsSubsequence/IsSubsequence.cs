using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode.Problems.P392_IsSubsequence;

/******************************************************************************

Given two strings s and t, return true if s is a subsequence of t, or false otherwise.

A subsequence of a string is a new string that is formed from the original string by 
deleting some (can be none) of the characters without disturbing the relative 
positions of the remaining characters. (i.e., "ace" is a subsequence of "abcde" while "aec" is not). 

Constraints:

0 <= s.length <= 100
0 <= t.length <= 104
s and t consist only of lowercase English letters.
 

Follow up: Suppose there are lots of incoming s, say s1, s2, ..., sk where k >= 109, 
and you want to check one by one to see if t has its subsequence. 
In this scenario, how would you change your code?

*******************************************************************************/
public class IsSubsequence
{
    public static bool Simple(string subsequence, string original)
    {
        if(subsequence.Length > original.Length)
        {
            return false;
        }

        if(subsequence.Length == original.Length)
        {
            return subsequence == original;
        }

        var lastCharIndex = -1;
        for(int i = 0; i < subsequence.Length; i++)
        {
            lastCharIndex = original.IndexOf(subsequence[i], lastCharIndex + 1);
            if(lastCharIndex == -1)
            {
                return false;
            }
        }

        return true;
    }

    public static bool[] FollowUp(string original, params string[] subsequences)
    {
        // This caused me to make sure I wasn't modifying the original value in any way.
        return subsequences.Select(x => Simple(x, original)).ToArray();
    }

    public static bool WithSpan(ReadOnlySpan<char> subsequence, ReadOnlySpan<char> original)
    {
        if(subsequence.Length > original.Length)
        {
            return false;
        }

        var minIndex = 0;
        for(int i = 0; i < subsequence.Length; i++)
        {
            if(minIndex >= original.Length)
            {
                return false;
            }

            var index = original.Slice(minIndex).IndexOf(subsequence[i]);
            if(index == -1)
            {
                return false;
            }

            minIndex += index + 1;            
        }

        return true;
    } // end method
}
