using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.P2352_EqualRowColumnPairs;

public class EqualRowColumnPairs
{
    /***********************************************************************
    Given a 0-indexed n x n integer matrix grid, return the number of pairs 
    (ri, cj) such that row ri and column cj are equal.

    A row and column pair is considered equal if they contain the same elements 
    in the same order (i.e., an equal array).

    Constraints:
    n == grid.length == grid[i].length
    1 <= n <= 200
    1 <= grid[i][j] <= 105

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
    
    /// <summary>
    /// A row must pair with a column.
    /// Since there can be up to 200 numbers, and the numbers could be between 1 and 105
    /// I will use strings in a dictionary.
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public static int Original(int[][] grid)
    {
        var result = 0;

        // group by initial number, and capture the row or column index
        var rowDict = new Dictionary<string, int>();
        for(var i = 0; i < grid.Length; i++)
        {
            var rowKeyBuilder = new StringBuilder();
            for(int j = 0; j < grid.Length; j++)
            {
                rowKeyBuilder.Append(grid[i][j]).Append(',');
            }

            var rowKey = rowKeyBuilder.ToString();
            if(rowDict.ContainsKey(rowKey))
            {
                rowDict[rowKey]++;
            }
            else
            {
                rowDict[rowKey] = 1;
            }
        }

        for(var i = 0; i < grid.Length; i++)
        {
            var colKeyBuilder = new StringBuilder();
            for(int j = 0; j < grid.Length; j++)
            {
                colKeyBuilder.Append(grid[j][i]).Append(',');
            }
            var colKey = colKeyBuilder.ToString();
            if(rowDict.ContainsKey(colKey))
            {
                result += rowDict[colKey];
            }
        }

        return result;
    } // end method

    /// <summary>
    /// Found solutions using a polynomial hash function.
    /// This is my personal spin on it.
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public static int PolynomialHashFunction(int[][] grid)
    {
        var result = 0;

        var basePower = GetBasePower(grid.Length);
        var modulo = GetModulo(grid.Length);

        var rowDict = new Dictionary<long, int>();
        for(var i = 0; i < grid.Length; i++)
        {
            var rowKey = GetHash(grid[i], basePower, modulo);
            if(rowDict.ContainsKey(rowKey))
            {
                rowDict[rowKey]++;
            }
            else
            {
                rowDict[rowKey] = 1;
            }
        }

        for(var i = 0; i < grid.Length; i++)
        {
            var colPieces = new int[grid.Length];
            for(int j = 0; j < grid.Length; j++)
            {
                colPieces[j] = grid[j][i];
            }

            var colKey = GetHash(colPieces, basePower, modulo);
            if(rowDict.ContainsKey(colKey))
            {
                result += rowDict[colKey];
            }
        }

        return result;
    } // end method

    protected static int GetBasePower(int length)
    {
        if (length <= 100) return 31;
        else if (length <= 200) return 53;
        else if (length <= 500) return 97;
        else if (length <= 1000) return 233;
        else return 1009; // For very large input
    }

    public static int GetModulo(int length)
    {
        return 1000000007;
    }

    public static long GetHash(int[] data, int power, int modulo)
    {
        long result = 0;

        for(var i = 0; i < data.Length; i++)
        {
            result = (result + (long) power * data[i])%modulo;
            power = (power * 179) % modulo; 
        }

        return result;
    }
} // end class