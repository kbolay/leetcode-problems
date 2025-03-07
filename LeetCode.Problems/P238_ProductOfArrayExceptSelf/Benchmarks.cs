using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace LeetCode.Problems.P238_ProductOfArrayExceptSelf;

[MemoryDiagnoser]
public class Benchmarks
{
    private const int MAX_VALUE = 30;
    private const int MIN_VALUE = -30;
    private const int MAX_VALUES = 100;
    private static Random _random = new Random();
    private int[] _input;

    [GlobalSetup]
    public void Setup()
    {
        var arrayLength = _random.Next(1, MAX_VALUES+1);
        _input = Enumerable.Range(0, arrayLength).Select(x => _random.Next(MIN_VALUE, MAX_VALUE+1)).ToArray();        
    }

    [Benchmark]
    public void Simple()
    {
        ProductOfArrayExceptSelf.Simple(_input);
    }

    [Benchmark]
    public void CorrectSolution()
    {
        ProductOfArrayExceptSelf.CorrectSolution(_input);
    }

    [Benchmark]
    public void CorrectSolutionWithSpans()
    {
        ProductOfArrayExceptSelf.CorrectSolutionWithSpans(_input);
    }
}
