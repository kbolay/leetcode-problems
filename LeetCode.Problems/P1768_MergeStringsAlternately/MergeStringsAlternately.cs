using System.Text;

namespace LeetCode.Problems.P1768_MergeStringsAlternately;

public static class MergeStringsAlternately
{
    public static string Simple(string word1, string word2)
    {
        var maxLength = word1.Length >= word2.Length ? word1.Length : word2.Length;
        var result = string.Empty;

        for(int i = 0; i < maxLength; i++)
        {
            if(i < word1.Length) 
            {
                result += word1[i];
            }

            if(i < word2.Length)
            {
                result += word2[i];
            }            
        }

        return result;
    }

    public static string WithStringBuilder(string word1, string word2) 
    {
        var maxLength = word1.Length >= word2.Length ? word1.Length : word2.Length;
        var resultBuilder = new StringBuilder();

        for(int i = 0; i < maxLength; i++)
        {
            if(i < word1.Length) 
            {
                resultBuilder.Append(word1[i]);
            }

            if(i < word2.Length)
            {
                resultBuilder.Append(word2[i]);
            }            
        }

        return resultBuilder.ToString();
    } // end method

    public static string WithStringBuilderWithLength(string word1, string word2) 
    {
        var maxLength = word1.Length >= word2.Length ? word1.Length : word2.Length;
        var resultBuilder = new StringBuilder(word1.Length + word2.Length);

        for(int i = 0; i < maxLength; i++)
        {
            if(i < word1.Length) 
            {
                resultBuilder.Append(word1[i]);
            }

            if(i < word2.Length)
            {
                resultBuilder.Append(word2[i]);
            }            
        }

        return resultBuilder.ToString();
    } // end method

    public static string WithSpans(ReadOnlySpan<char> word1, ReadOnlySpan<char> word2)
    {
        Span<char> result = stackalloc char[word1.Length + word2.Length];

        int currentIndex = 0;
        for(int i = 0; i < Math.Max(word1.Length, word2.Length); i++)
        {
            if(i < word1.Length) 
            {
                result[currentIndex] = word1[i];
                currentIndex++;
            }

            if(i < word2.Length)
            {
                result[currentIndex] = word2[i];
                currentIndex++;
            }
        }

        return result.ToString();
    } // end method
} // end class
