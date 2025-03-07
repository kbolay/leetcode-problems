using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace LeetCode.Problems.P1071_GCDStrings;

[MemoryDiagnoser]
public class Benchmarks
{
    private string _str1 = "ABCABC";
    private string _str2 = "ABC";

    [Benchmark]
    public void WithSpans()
    {
        var gcd = GcdOfStrings.WithSpans(_str1, _str2);
    }
}
