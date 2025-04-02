using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.P1466_ReorderRoutes;

namespace LeetCode.Tests.P1466_ReorderRoutes;
public class UnitTests
{
    [Theory]
    [InlineData(3, 6, 
        new[] { 0,1 },
        new[] { 1,3 },
        new[] { 2,3 },
        new[] { 4,0 },
        new[] { 4,5 }
    )]
    [InlineData(2, 5, 
        new[] { 1,0 },
        new[] { 1,2 },
        new[] { 3,2 },
        new[] { 3,4 }
    )]
    [InlineData(0, 3, 
        new[] { 1,0 },
        new[] { 2,0 }
    )]
    public void Original(int expected, int n, params int[][] connections)
    {
        var result = MinimumReorder.Original(n, connections);
        Assert.Equal(expected, result);
    } // end method

    [Theory]
    [InlineData(3, 6, 
        new[] { 0,1 },
        new[] { 1,3 },
        new[] { 2,3 },
        new[] { 4,0 },
        new[] { 4,5 }
    )]
    [InlineData(2, 5, 
        new[] { 1,0 },
        new[] { 1,2 },
        new[] { 3,2 },
        new[] { 3,4 }
    )]
    [InlineData(0, 3, 
        new[] { 1,0 },
        new[] { 2,0 }
    )]
    public void OriginalUsingDict(int expected, int n, params int[][] connections)
    {
        var result = MinimumReorder.OriginalUsingDict(n, connections);
        Assert.Equal(expected, result);
    } // end method

    [Theory]
    [InlineData(3, 6, 
        new[] { 0,1 },
        new[] { 1,3 },
        new[] { 2,3 },
        new[] { 4,0 },
        new[] { 4,5 }
    )]
    [InlineData(2, 5, 
        new[] { 1,0 },
        new[] { 1,2 },
        new[] { 3,2 },
        new[] { 3,4 }
    )]
    [InlineData(0, 3, 
        new[] { 1,0 },
        new[] { 2,0 }
    )]
    public void FoundSolution(int expected, int n, params int[][] connections)
    {
        var result = MinimumReorder.FoundSolution(n, connections);
        Assert.Equal(expected, result);
    } // end method
} // end class
