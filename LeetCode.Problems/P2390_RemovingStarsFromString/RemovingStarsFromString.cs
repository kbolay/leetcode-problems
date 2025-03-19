using System.Text;

namespace LeetCode.Problems.P2390_RemovingStarsFromString;

public class RemovingStarsFromString
{
    /***************************************************************************
    You are given a string s, which contains stars *.

    In one operation, you can:

    Choose a star in s.
    Remove the closest non-star character to its left, as well as remove the star itself.
    Return the string after all stars have been removed.

    Note:

    The input will be generated such that the operation is always possible.
    It can be shown that the resulting string will always be unique.
    
    Constraints:
    1 <= s.length <= 105
    s consists of lowercase English letters and stars *.
    The operation above can be performed on s.

    Example 1:
    Input: s = "leet**cod*e"
    Output: "lecoe"
    Explanation: Performing the removals from left to right:
    - The closest character to the 1st star is 't' in "leet**cod*e". s becomes "lee*cod*e".
    - The closest character to the 2nd star is 'e' in "lee*cod*e". s becomes "lecod*e".
    - The closest character to the 3rd star is 'd' in "lecod*e". s becomes "lecoe".
    There are no more stars, so we return "lecoe".

    Example 2:
    Input: s = "erase*****"
    Output: ""
    Explanation: The entire string is removed, so we return an empty string.    
    ***************************************************************************/

    /// <summary>
    /// I did see this problem was associated with Stacks.
    /// A stack makes a lot of sense here.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string Original(string s)
    {
        var stack = new Stack<char>();
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i] == '*')
            {
                stack.Pop();
                continue;
            }

            stack.Push(s[i]);
        }

        return new string(stack.Reverse().ToArray());
    } // end method

    /// <summary>
    /// A second original idea to solve this problem.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string LoopBackwards(string s)
    {
        Span<char> result = stackalloc char[s.Length];
        result.Fill(' ');
        var index = s.Length - 1;
        var starCounter = 0;
        while(index >= 0)
        {
            if(s[index] == '*')
            {
                starCounter++;
            }
            else if(starCounter > 0)
            {
                starCounter--;
            }
            else
            {
                result[index] = s[index];
            }            
            
            index--;
        }

        return result.ToString().Replace(" ", string.Empty);
    }
} // end class