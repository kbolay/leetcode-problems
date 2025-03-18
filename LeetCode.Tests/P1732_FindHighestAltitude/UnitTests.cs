using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.P1732_FindHighestAltitude;

namespace LeetCode.Tests.P1732_FindHighestAltitude;

public class UnitTests
{
    /*
    Example 1:
    Input: gain = [-5,1,5,0,-7]
    Output: 1
    Explanation: The altitudes are [0,-5,-4,1,1,-6]. The highest is 1.
    
    Example 2:
    Input: gain = [-4,-3,-2,-1,4,3,2]
    Output: 0
    Explanation: The altitudes are [0,-4,-7,-9,-10,-6,-3,-1]. The highest is 0.
    ****************************************************************/
    [Theory]
    [InlineData(1, 0, 1)]
    [InlineData(2, 0, 1, 1)]
    [InlineData(1, -5,1,5,0,-7)]
    [InlineData(0, -4,-3,-2,-1,4,3,2)]

    public void Original(int expected, params int[] gain)
    {
        var result = FindHighestAltitude.Original(gain);
        Assert.Equal(expected, result);
    } // end method
}
