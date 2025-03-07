using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Problems.P605_CanPlaceFlowers;

namespace LeetCode.Tests.P605_CanPlaceFlowers;

public class UnitTests
{
    [Theory]
    [InlineData(new int[] { 1, 0, 0, 0, 1}, 1, true)]
    [InlineData(new int[] { 1, 0, 0, 0, 0, 1}, 1, true)]
    [InlineData(new int[] { 1, 0, 0, 0, 1}, 2, false)]
    [InlineData(new int[] { 1, 0, 0, 0, 0, 1}, 2, false)]
    [InlineData(new int[] { 1, 0, 1, 0, 1}, 1, false)]
    [InlineData(new int[] {0,0,1,0,1}, 1, true)]
    [InlineData(new int[] {0,1,0,1,0,0}, 1, true)]
    [InlineData(new int[] {0,0}, 1, true)]
    [InlineData(new int[] {0}, 1, true)]
    [InlineData(new int[] {0, 0, 0}, 2, true)]
    public void TestSimple(int[] flowerBed, int newFlowers, bool expected)
    {
        var result = CanPlaceFlowers.Simple(flowerBed, newFlowers);
        Assert.Equal(expected, result);
    } // end method

    [Theory]
    [InlineData(new int[] { 1, 0, 0, 0, 1}, 1, true)]
    [InlineData(new int[] { 1, 0, 0, 0, 0, 1}, 1, true)]
    [InlineData(new int[] { 1, 0, 0, 0, 1}, 2, false)]
    [InlineData(new int[] { 1, 0, 0, 0, 0, 1}, 2, false)]
    [InlineData(new int[] { 1, 0, 1, 0, 1}, 1, false)]
    [InlineData(new int[] {0,0,1,0,1}, 1, true)]
    [InlineData(new int[] {0,1,0,1,0,0}, 1, true)]
    [InlineData(new int[] {0,0}, 1, true)]
    [InlineData(new int[] {0}, 1, true)]
    [InlineData(new int[] {0, 0, 0}, 2, true)]
    public void TestWithSpanSplit(int[] flowerBed, int newFlowers, bool expected)
    {
        var result = CanPlaceFlowers.WithSpanSplit(flowerBed, newFlowers);
        Assert.Equal(expected, result);
    } // end method
} // end class