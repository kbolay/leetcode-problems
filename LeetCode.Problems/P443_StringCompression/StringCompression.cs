using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.P443_StringCompression
{
    /// <summary>
    /// Constraints:
    /// 1 <= chars.length <= 2000
    /// chars[i] is a lowercase English letter, uppercase English letter, digit, or symbol.
    /// </summary>
    public class StringCompression
    {
        public static int Simple(char[] chars)
        {
            int result = 1;

            var charStartIndex = 0;
            for(int i = 1; i < chars.Length; i++)
            {
                if(chars[charStartIndex] != chars[i])
                {
                    var repititions = i - charStartIndex;
                    if(repititions > 1)
                    {
                        // write the repitition number to the input char array
                        foreach(var numberChar in repititions.ToString())
                        {
                            chars[result] = numberChar;
                            result++;
                        }
                    }

                    chars[result] = chars[i];
                    result++;
                    
                    charStartIndex = i;                    
                }
            }

            var lastCharReps = chars.Length - charStartIndex;
            if(lastCharReps > 1)
            {
                // write the repitition number to the input char array
                foreach(var numberChar in lastCharReps.ToString())
                {
                    chars[result] = numberChar;
                    result++;
                }
            }

            return result;
        }
    }
}