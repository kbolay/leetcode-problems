using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode.Problems.P1071_GCDStrings;
public static class GcdOfStrings
{
    public static string WithSpans(string str1, string str2)
    {
        var str1Span = str1.AsSpan();
        var str2Span = str2.AsSpan();
        for(int i = Math.Min(str1Span.Length, str2Span.Length); i > 0; i--)
        {
            if(str1Span.Length % i > 0 || str2Span.Length % i > 0)
            {
                continue;
            }
            
            // we are dealing with an common denominator
            var pattern = str1Span.Slice(0, i).ToString();

            // is str1 made up of only the pattern repeated
            var str1Pieces = str1.Split(pattern, StringSplitOptions.RemoveEmptyEntries);

            if(str1Pieces.Length > 0)
            {
                continue;
            }            

            // is str2 made up of only the pattern repeated
            var str2Pieces = str2.Split(pattern, StringSplitOptions.RemoveEmptyEntries);

            if(str2Pieces.Length == 0)
            {
                return pattern;
            }
        }

        return string.Empty;
    } // end method
} // end class
