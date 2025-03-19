using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode.Problems.P1657_AreTwoStringsClose;

public class AreTwoStringsClose
{
    /******************************************************************************
    Two strings are considered close if you can attain one from the other using the following operations:

    Operation 1: Swap any two existing characters.
    For example, abcde -> aecdb

    Operation 2: Transform every occurrence of one existing character into another existing character, 
    and do the same with the other character.
    For example, aacabb -> bbcbaa (all a's turn into b's, and all b's turn into a's)
    
    You can use the operations on either string as many times as necessary.

    Given two strings, word1 and word2, return true if word1 and word2 are close, and false otherwise.    

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
 
    Constraints:
    1 <= word1.length, word2.length <= 105
    word1 and word2 contain only lowercase English letters.
    ******************************************************************************/
    public static bool Original(string word1, string word2)
    {
        if(word1.Length != word2.Length)
        {
            return false;
        }

        const int lowestChar = (int)'a';
        var word1Chars = new int[26];
        var word2Chars = new int[26];

        for(int i = 0; i < word1.Length; i++)
        {
            word1Chars[((int)word1[i])-lowestChar]++;
            word2Chars[((int)word2[i])-lowestChar]++;
        }

        for(int i = 0; i < 26; i++)
        {
            var foundMatch = false;
            if(word1Chars[i] == 0)
            {
                // no count for this character
                continue; 
            }

            if(word2Chars[i] == 0)
            {
                return false;
            }

            if(word1Chars[i] == word2Chars[i])
            {
                // the same letter exists in the same count in both words
                word1Chars[i] = 0;
                word2Chars[i] = 0;
                continue;
            }

            // look for characters to swap with
            for(var j = i+1; j < 26; j++)
            {
                if(word2Chars[j] > 0 && word1Chars[j] == 0)
                {
                    return false;
                }
                // is swapping worth it?
                // the count of the char in word1 is the same of the count of some other char in word 2
                // and the other char in word2 also exists in word 1
                // c    a   b   b   b   a -> [a] = 2, [b] = 3, c = 1
                // a    b   b   c   c   c -> [a] = 1, [b] = 2, c = 3
                // w1[a] == w2[b] && w1[b] > 0 -> true
                // b    a   a   c   c   c -> [a] = 0(2), [b] = 1, [c] = 3
                // w1[b] == w2[c] && w1[c] > 0 -> true
                // c    a   a   b   b   b -> [a] = 0(2), [b] = 0(3), [c] = 1
                if(word1Chars[i] == word2Chars[j])
                {
                    // perform a swap
                    word2Chars[j] = word2Chars[i];
                    word1Chars[i] = 0;
                    word2Chars[i] = 0;
                    
                    foundMatch = true;
                    break;
                }
            }

            if(!foundMatch)
            {
                return false;
            }
        }

        return true;
    } // end method
} // end class
