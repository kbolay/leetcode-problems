namespace Bolay.LeetCode.Problems.Tests;

public class P1TwoSumsTests
{
    [Theory]
    [InlineData(new int[] {2,7,11,15}, 9, new int[] {0,1})]
    [InlineData(new int[] {3,2,4}, 6, new int[] {1,2})]
    [InlineData(new int[] {3,3}, 6, new int[] {0,1})]
    [InlineData(new int[] {4,8,3,1,9}, 17, new int[] {1,4})]
    public void TestCases(int[] nums, int target, int[] expected)
    {
        var instance = new P1TwoSums();
        var result = instance.TwoSum(nums, target);

        Assert.Equal(expected, result);
    } // end method
} // end class