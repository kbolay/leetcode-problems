using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LeetCode.Problems.P334_IncreasingTripletSubsequence;

public class IncreasingTripletSubsequence
{
    /// <summary>
    /// No simple solution for this one because I missed the condition allowing me to use the max of int32.
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static bool CorrectSolution(int[] nums)
    {
        if(nums.Length < 3)
        {
            return false;
        }

        var first = Int32.MaxValue;
        var second = Int32.MaxValue;

        for(int i = 0; i < nums.Length; i++)
        {
            if(nums[i] <= first)
            {
                first = nums[i];
            }
            else if(nums[i] <= second)
            {
                second = nums[i];
            }
            else
            {
                return true;
            }
        }

        return false;
    }
    public static bool SimpleAndWrong(int[] nums)
    {        
        if(nums.Length < 3)
        {
            return false;
        }

        // create a triplet to hold numbers
        var triplet = new int?[3];
        // assign the last piece of the triplet with the last number, we will be working backwards
        triplet[2] = nums[nums.Length - 1];

        // start with the second to last number and work backwards
        for(int i = nums.Length - 2; i >= 0; i--) 
        {
            // shortcircuit if three numbers in a row meet the conditions.
            if(i > 1 && nums[i] > nums[i-1] && nums[i-1] > nums[i-2])
            {
                return true;
            }

            // iterate through the triplet to see if this number is belongs in it
            for(int j = 0; j < 3; j++)
            {
                // does the index of the triplet contain a value currently?
                if(triplet[j].HasValue)
                {
                    // compare the value
                    if(nums[i] > triplet[j].Value)
                    {
                        // the number is larger that the current triplet value
                        if(j == 2)
                        {
                            // we are in the last triplet index, set the new largest
                            triplet[j] = nums[i];
                            break;
                        }
                        else
                        {
                            // we are not in the last piece of the triplet so set it to null
                            triplet[j] = null;
                            continue;
                        }
                    }
                    else if(j > 0 && nums[i] < triplet[j].Value)
                    {
                        // the value is less than the current triplet and we are not in the lowest position.
                        // assign to the triplet position below this one.
                        triplet[j-1] = nums[i];
                        break;
                    }
                }
            }

            if(triplet[0].HasValue && triplet[2] > triplet[1] && triplet[1] > triplet[0])
            {
                return true;
            }
        }

        return false;
    } // end method
} // end class
