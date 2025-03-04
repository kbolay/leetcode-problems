namespace LeetCode.Problems.P1_TwoSums;

public class P1TwoSums
{
    public int[] TwoSum(int[] nums, int target) 
    {
        var result = new int[2];
        for(int i = 0; i < nums.Count(); i++) {
            result[0] = i;
            var desiredValue = target - nums[i];
            for(int j = i+1; j < nums.Count(); j++) {
                if(nums[j] == desiredValue) {
                    result[1] = j;
                    break;
                }
            }
            if(result[1] > 0) {
                break;
            }
        }

        return result;
    } // end method
} // end class