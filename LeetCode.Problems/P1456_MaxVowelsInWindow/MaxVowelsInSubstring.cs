using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace LeetCode.Problems.P1456_MaxVowelsInWindow;

/******************************************************************************
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
******************************************************************************/

public class MaxVowelsInSubstring
{
    private static HashSet<char> _vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
    public static int Original(string s, int k)
    {
        var result = 0;
        var runningCount = 0;
        var vowelFlagArray = new BitArray(k);
        var lastVowelFlagArrayIndex = k-1;

        //aeiou, 2
        for(int i = 0; i < s.Length; i++)
        {
            if(_vowels.Contains(s[i]))
            {
                vowelFlagArray[lastVowelFlagArrayIndex] = true;
                runningCount++;
            }
            
            // check for a new max
            result = Math.Max(result, runningCount);
            
            // if we are beyond the first potential window and the index falling out of the window is a vowel reduce the running count
            if(i >= lastVowelFlagArrayIndex && vowelFlagArray[0])
            {
                runningCount -= 1;
            }

            if(k > 1)
            {
                // move the vowel flag array window
                // k = 3
                // 001 -> 010
                vowelFlagArray = vowelFlagArray.RightShift(1);
            }            
        }

        return result;
    } // end method


    /// <summary>
    /// This is a solution found in the leetcode solutions sections that I wanted to try out and benchmark against my original solution.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static int MultipleContains(string s, int k)
    {
        // get the first window
        var runningCount = s.Take(k).Count(x => _vowels.Contains(x));
        var result = runningCount;

        for(int i = k; i < s.Length; i++)
        {
            if(_vowels.Contains(s[i-k]))
            {
                runningCount--;
            }

            if(_vowels.Contains(s[i]))
            {
                runningCount++;
            }

            result = Math.Max(result, runningCount);
        }

        return result;
    } // end method
} // end class
