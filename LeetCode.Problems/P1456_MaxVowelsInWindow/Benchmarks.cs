using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace LeetCode.Problems.P1456_MaxVowelsInWindow;

[MemoryDiagnoser]
public class Benchmarks
{
    private string _input = "tnfazcwrryitgacaabwm";
    private int _windowLength = 4;

    [Benchmark]
    public void Original()
    {
        _ = MaxVowelsInSubstring.Original(_input, _windowLength);
    }

    [Benchmark]
    public void MultipleContains()
    {
        _ = MaxVowelsInSubstring.MultipleContains(_input, _windowLength);
    }
} // end class
