using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.P933_NumberOfRecentCalls;

namespace LeetCode.Tests.P933_RecentCounter;

public class UnitTests
{
    /*
    ["RecentCounter", "ping", "ping", "ping", "ping"]
[[], [1], [100], [3001], [3002]]
Output
[null, 1, 2, 3, 3]
    */
    [Theory]
    [InlineData(new int[] {1,2,3,3}, 1,100,3001,3002)]
    [InlineData(new int[] {1, 2, 3, 4, 5, 1}, 500, 1000, 1500, 2000, 2500, 5501)]
    public void Original(int[] expectedResults, params int[] pings)
    {
        var recentCounter = new RecentCounter();
        foreach(var index in Enumerable.Range(0, expectedResults.Length))
        {
            var result = recentCounter.Ping(pings[index]);
            Assert.Equal(expectedResults[index], result);
        } //
    } // end methdo
}