using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace LeetCode.Problems.P1466_ReorderRoutes;

[MemoryDiagnoser]
public class Benchmarks
{
    public int _cities = 5;
    public int[][] _connections =
    [
        new[] { 1,0 },
        new[] { 1,2 },
        new[] { 3,2 },
        new[] { 3,4 }
    ];

    [Benchmark]
    public void Original()
    {
        _ = MinimumReorder.Original(_cities, _connections);
    }
    [Benchmark]
    public void OriginalUsingDict()
    {
        _ = MinimumReorder.OriginalUsingDict(_cities, _connections);
    }
    [Benchmark]
    public void FoundSolution()
    {
        _ = MinimumReorder.FoundSolution(_cities, _connections);
    }
} // end class