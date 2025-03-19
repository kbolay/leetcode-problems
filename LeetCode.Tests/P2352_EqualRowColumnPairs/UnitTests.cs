using LeetCode.Problems.P2352_EqualRowColumnPairs;

namespace LeetCode.Tests.P2352_EqualRowColumnPairs;

public class UnitTests
{
    /******************************************************************************
    Example 1:
    3   2   1
    1   7   6
    2   7   7
    Input: grid = [[3,2,1],[1,7,6],[2,7,7]]
    Output: 1
    Explanation: There is 1 equal row and column pair:
    - (Row 2, Column 1): [2,7,7]

    Example 2:
    3   1   2   2
    1   4   4   5
    2   4   2   2
    2   4   2   2
    Input: grid = [[3,1,2,2],[1,4,4,5],[2,4,2,2],[2,4,2,2]]
    Output: 3
    Explanation: There are 3 equal row and column pairs:
    - (Row 0, Column 0): [3,1,2,2]
    - (Row 2, Column 2): [2,4,2,2]
    - (Row 3, Column 2): [2,4,2,2]
    ***********************************************************************/

    [Theory]
    [InlineData(1, 
        new int[] {3, 2, 1}, 
        new int[] {1, 7, 6},
        new int[] {2, 7, 7})]
    [InlineData(3, 
        new int[] {3,1,2,2}, 
        new int[] {1,4,4,5},
        new int[] {2,4,2,2},
        new int[] {2,4,2,2})]
    [InlineData(2, 
        new int[] {11,1}, 
        new int[] {1,11})]
    public void Original(int expected, params int[][] grid)
    {
        var result = EqualRowColumnPairs.Original(grid);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1, 
        new int[] {3, 2, 1}, 
        new int[] {1, 7, 6},
        new int[] {2, 7, 7})]
    [InlineData(3, 
        new int[] {3,1,2,2}, 
        new int[] {1,4,4,5},
        new int[] {2,4,2,2},
        new int[] {2,4,2,2})]
    [InlineData(2, 
        new int[] {11,1}, 
        new int[] {1,11})]
    public void PolynomialHashFunction(int expected, params int[][] grid)
    {
        var result = EqualRowColumnPairs.PolynomialHashFunction(grid);
        Assert.Equal(expected, result);
    }
}