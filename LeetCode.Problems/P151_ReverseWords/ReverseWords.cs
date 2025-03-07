using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode.Problems.P151_ReverseWords;

public static class ReverseWords
{
    public static string Simple(string s)
    {
        return string.Join(' ', s.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse());
    }

    public static string WithSpan(ReadOnlySpan<char> s)
    {
        var trimmedSpan = s.Trim();
        Span<char> result = stackalloc char[trimmedSpan.Length];
        result.Fill(' ');
        var lastSpace = trimmedSpan.Length;
        var currentIndex = 0;
        for(int i = trimmedSpan.Length - 1; i >= 0; i--)
        {
            if(trimmedSpan[i] == ' ')
            {
                if(i + 1 < lastSpace) 
                {
                    // copy in the word
                    for(int j = i+1; j < lastSpace; j++)
                    {
                        result[currentIndex] = trimmedSpan[j];
                        currentIndex++;
                    }
                    currentIndex++;
                }
                lastSpace = i;
            }
        }

        for(int i = 0; i < lastSpace; i++)
        {
            result[currentIndex] = trimmedSpan[i];
            currentIndex++;
        }

        return result.Trim().ToString(); 
    }
} // end class
