using System.Collections;
using LeetCode.Problems.P841_CanVisitAllRooms;

namespace LeetCode.Tests.P841_CanVisitAllRooms;
public class UnitTests
{
    [Theory]
    [ClassData(typeof(CanVisitAllRoomsTestData))]
    public void Original(bool expected, IList<IList<int>> rooms)
    {
        var result = CanVisitAllRooms.Original(rooms);
        Assert.Equal(expected, result);
    } // end method

    [Theory]
    [ClassData(typeof(CanVisitAllRoomsTestData))]
    public void OriginalWithSpan(bool expected, IList<IList<int>> rooms)
    {
        var result = CanVisitAllRooms.OriginalWithSpan(rooms);
        Assert.Equal(expected, result);
    } // end method
} // end class

public class CanVisitAllRoomsTestData : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new List<object[]>
    {
        new object[] {
            true,
            new List<IList<int>>() {
                new List<int>() { 1 },
                new List<int>() { 2 },
                new List<int>() { 3 },
                new List<int>() { }
            }
        },
        new object[] {
            false,
            new List<IList<int>>() {
                new List<int>() { 1, 3 },
                new List<int>() { 3, 0, 1 },
                new List<int>() { 2 },
                new List<int>() { 0 }
            }
        },
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}