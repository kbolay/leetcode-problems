using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.P649_Dota2Senate;

namespace LeetCode.Tests.P649_Dota2Senate;

public class UnitTests
{
    [Theory]
    [InlineData("Radiant", "RD")]
    [InlineData("Dire", "RDD")]
    [InlineData("Radiant", "RDRD")]
    [InlineData("Dire", "DRRD")]
    [InlineData("Dire", "DDRRR")]
    public void Original(string expected, string input)
    {
        var result = PredictPartyVictory.Original(input);
        Assert.Equal(expected, result);
    }
}
