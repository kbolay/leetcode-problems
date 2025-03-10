using System.Collections;

namespace LeetCode.Problems.P1456_MaxVowelsInWindow;

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
