using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace LeetCode.Problems.P1341_KidsWithCandies;

[MemoryDiagnoser]
public class Benchmarks
{
    private int[] _candies;
    private int _extraCandies;

    private const int MIN_KIDS = 2;
    private const int MAX_KIDS = 100;
    private const int MAX_CANDIES = 100;
    private const int MAX_EXTRA_CANDIES = 50;
    private static Random _random = new Random();

    [GlobalSetup]
    public void Setup()
    {
        var kids = _random.Next(MIN_KIDS, MAX_KIDS + 1);
        _candies = Enumerable.Range(0, kids).Select(i => _random.Next(1, MAX_CANDIES + 1)).ToArray();
        
        _extraCandies = _random.Next(1, MAX_EXTRA_CANDIES + 1);
    } // end method

    [Benchmark]
    public void InitialImplementation()
    {
        var result = KidsWithCandies.GetMaxCandies(_candies, _extraCandies);
    }
} // end method
