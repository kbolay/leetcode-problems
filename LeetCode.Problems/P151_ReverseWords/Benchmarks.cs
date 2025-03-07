using BenchmarkDotNet.Attributes;

namespace LeetCode.Problems.P151_ReverseWords;

[MemoryDiagnoser]
public class Benchmarks
{
    private string _input = "  hello world  ";

    [Benchmark]
    public void Simple()
    {
        ReverseWords.Simple(_input);
    } // end method

    [Benchmark]
    public void WithSpan()
    {
        ReverseWords.WithSpan(_input);
    } // end method
} // end class
