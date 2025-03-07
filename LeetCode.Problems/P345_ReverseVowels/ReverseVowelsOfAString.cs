namespace LeetCode.Problems.P345_ReverseVowels;

public class ReverseVowelsOfAString
{
    public static string Simple(string s)
    {
        if(s.Length == 1)
        {
            return s;
        }
        
        char[] vowels = { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U' };
        int forwardIndex = 0;
        int reverseIndex = s.Length - 1;

        char? forwardVowel = null;
        char? backVowel = null;

        Span<char> result = stackalloc char[s.Length];

        while(forwardIndex < reverseIndex)
        {
            // find next vowels to swap
            while(!forwardVowel.HasValue && forwardIndex < reverseIndex) 
            {
                if(!vowels.Contains(s[forwardIndex]))
                {
                    result[forwardIndex] = s[forwardIndex];
                    forwardIndex++;
                }
                else
                {
                    forwardVowel = s[forwardIndex];
                }
            }

            while(!backVowel.HasValue && reverseIndex > forwardIndex)
            {
                if(!vowels.Contains(s[reverseIndex]))
                {
                    result[reverseIndex] = s[reverseIndex];
                    reverseIndex--;
                }
                else
                {
                    backVowel = s[reverseIndex];
                }
            }

            if(forwardVowel.HasValue && backVowel.HasValue)
            {
                result[forwardIndex] = backVowel.Value;
                result[reverseIndex] = forwardVowel.Value;

                forwardIndex++;
                reverseIndex--;

                backVowel = null;
                forwardVowel = null;
            }

            if(forwardIndex == reverseIndex) 
            {
                result[forwardIndex] = s[forwardIndex];
            }
        }

        return result.ToString();
    } // end method
} // end class
