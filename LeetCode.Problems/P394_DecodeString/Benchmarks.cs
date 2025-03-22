using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace LeetCode.Problems.P394_DecodeString;

[MemoryDiagnoser]
public class Benchmarks
{
    private string _input = "3[a2[c]b]abc4[ac]";

    [Benchmark]
    public void Original()
    {
        _ = DecodeString.Original(_input);
    }  

    [Benchmark]
    public void FoundSolution()
    {
        _ = DecodeString.FoundSolution(_input);
    }
}
