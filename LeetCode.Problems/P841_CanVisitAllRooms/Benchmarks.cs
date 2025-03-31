using BenchmarkDotNet.Attributes;

namespace LeetCode.Problems.P841_CanVisitAllRooms;

[MemoryDiagnoser]
public class Benchmarks
{
    private IList<IList<int>> _rooms = new List<IList<int>>()
    {
        new List<int>() { 1, 3 },
        new List<int>() { 3, 0, 1 },
        new List<int>() { 2 },
        new List<int>() { 0 }
    };

    [Benchmark]
    public void Original()
    {
        _ = CanVisitAllRooms.Original(_rooms);
    }

    [Benchmark]
    public void OriginalWithSpan()
    {
        _ = CanVisitAllRooms.OriginalWithSpan(_rooms);
    }
}