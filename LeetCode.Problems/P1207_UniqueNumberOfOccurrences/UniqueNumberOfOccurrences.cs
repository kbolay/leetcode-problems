namespace LeetCode.Problems.P1207_UniqueNumberOfOccurrences;

public class UniqueNumberOfOccurrences
{
    /******************************************************************************
    Given an array of integers arr, return true if the number of occurrences of each 
    value in the array is unique or false otherwise.

    Constraints:
    1 <= arr.length <= 1000
    -1000 <= arr[i] <= 1000

    Example 1:
    Input: arr = [1,2,2,1,1,3]
    Output: true
    Explanation: The value 1 has 3 occurrences, 2 has 2 and 3 has 1. No two values have the same number of occurrences.

    Example 2:
    Input: arr = [1,2]
    Output: false
    
    Example 3:
    Input: arr = [-3,0,1,-3,1,1,1,-3,10,0]
    Output: true
    ******************************************************************************/
    /// <summary>
    /// This is the first solution that came to mind.
    /// Advantages: 1. Very functional, 2. Simple to understand 3. Performance improvements in LINQ would improve the performance here.
    /// Disadvantages: Probably "slow"
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static bool Original(int[] nums)
    {
        return !nums
            .GroupBy(number => number)
            .Select(numberGroup => new { Number =  numberGroup.Key, Count = numberGroup.Count()})
            .GroupBy(groupObject => groupObject.Count)
            .Any(countGroup => countGroup.Count() > 1);
    }

    public static bool UsingDictionary(int[] nums)
    {
        var dict = new Dictionary<int, int>();
        // walk through the numbers to populate a dictionary
        // getting a count for each unique number
        for (var i = 0; i < nums.Length; i++) 
        {
            if(dict.ContainsKey(nums[i]))
            {
                dict[nums[i]]++;
            }
            else
            {
                dict.Add(nums[i], 1);
            }            
        }

        // iterate through the dictionary
        // attempt to add the count from the dict to the hashset
        // if it already exists in the hashset then the count is not unique
        var countHash = new HashSet<int>();
        for(var i = 0; i < dict.Count; i++)
        {
            if(!countHash.Add(dict.ElementAt(i).Value))
            {
                return false;
            }
        }

        return true;
    }
}
