using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace LeetCode.Problems.P605_CanPlaceFlowers;

[MemoryDiagnoser]
public class Benchmarks
{
    private int[] _flowerBed = { 1, 0, 0, 0, 1};
    private int _newFlowers = 1;

    [Benchmark]
    public void Simple()
    {
        CanPlaceFlowers.Simple(_flowerBed, _newFlowers);
    } // end method

    [Benchmark]
    public void WithSpanSplit()
    {
        CanPlaceFlowers.WithSpanSplit(_flowerBed, _newFlowers);
    } // end method
} // end class
