using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace LeetCode.Problems.P2390_RemovingStarsFromString;

[MemoryDiagnoser]
public class Benchmarks
{
    private string _input = "leet**cod*e";

    [Benchmark]
    public void Original()
    {
        _ = RemovingStarsFromString.Original(_input);
    }

    [Benchmark]
    public void LoopBackwards()
    {
        _ = RemovingStarsFromString.LoopBackwards(_input);
    }
}
