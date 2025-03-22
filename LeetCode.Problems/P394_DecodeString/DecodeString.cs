using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.P394_DecodeString;
public class DecodeString
{
    /******************************************************************************
    Given an encoded string, return its decoded string.

    The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets 
    is being repeated exactly k times. Note that k is guaranteed to be a positive integer.

    You may assume that the input string is always valid; there are no extra white spaces, 
    square brackets are well-formed, etc. Furthermore, you may assume that the original 
    data does not contain any digits and that digits are only for those repeat numbers, k. 
    For example, there will not be input like 3a or 2[4].

    The test cases are generated so that the length of the output will never exceed 105.

    Example 1:
    Input: s = "3[a]2[bc]"
    Output: "aaabcbc"

    Example 2:
    Input: s = "3[a2[c]]"
    Output: "accaccacc"
    
    Example 3:
    Input: s = "2[abc]3[cd]ef"
    Output: "abcabccdcdcdef"

    Constraints:
    1 <= s.length <= 30
    s consists of lowercase English letters, digits, and square brackets '[]'.
    s is guaranteed to be a valid input.
    All the integers in s are in the range [1, 300].
    ************************************************************************************/
    public static string Original(string s)
    {
        var stack = new Stack<char>(105);

        for(var i = 0; i < s.Length; i++)
        {
            if(s[i] != ']')
            {
                stack.Push(s[i]);
                continue;
            }

            // get the characters between the square brackets
            var partialBuilder = new StringBuilder();
            while(stack.Peek() != '[') 
            {
                partialBuilder.Insert(0, stack.Pop());
            }
            var partialString = partialBuilder.ToString();
            stack.Pop(); // pop off the opening square bracket
            
            // get the number of times to print the string
            var iterationBuilder = new StringBuilder();
            while(stack.Count > 0 && char.IsDigit(stack.Peek()))
            {
                iterationBuilder.Insert(0, stack.Pop());
            }
            var iterations = int.Parse(iterationBuilder.ToString());

            // push the results back on to the stack
            for(int x = 0; x < iterations; x++)
            {
                for(int y = 0; y < partialString.Length; y++)
                {
                    stack.Push(partialString[y]);
                }
            }
        }

        var resultBuilder = new StringBuilder();
        while(stack.Count > 0)
        {
            resultBuilder.Insert(0, stack.Pop());            
        }

        return resultBuilder.ToString();
    } // end method

    public static string FoundSolution(string s)
    {
        var iterationsStack = new Stack<int>();
        var stringsStack = new Stack<StringBuilder>();
        var currentNumber = 0;
        var stringBuilder = new StringBuilder();

        for(int i = 0; i < s.Length; i++)
        {
            if(char.IsDigit(s[i]))
            {
                // when current number is not zero we need to add the new number on the end.
                currentNumber = currentNumber * 10 + (s[i] - '0');
            }
            else if(s[i] == '[')
            {
                // put the current number on the iterations stack
                iterationsStack.Push(currentNumber);
                // reset the current number
                currentNumber = 0;
                // push any existing string into the strings stack
                stringsStack.Push(stringBuilder);                
                // get a new string builder
                stringBuilder = new StringBuilder();
            }
            else if(s[i] == ']')
            {
                // get the number of iterations to apply to the substring
                int iterations = iterationsStack.Pop();
                // assign the current string builder to temp.
                StringBuilder temp = stringBuilder;

                // set the current string builder to the previous one
                stringBuilder = stringsStack.Pop();

                // append to the string builder with the correct number of iterations
                while (iterations-- > 0) {
                    stringBuilder.Append(temp);
                }
            }
            else
            {
                // append to the string builder
                stringBuilder.Append(s[i]);
            }
        }

        return stringBuilder.ToString();
    }
} // end class