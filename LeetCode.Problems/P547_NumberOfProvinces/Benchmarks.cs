using BenchmarkDotNet.Attributes;

namespace LeetCode.Problems.P547_NumberOfProvinces;

[MemoryDiagnoser]
public class Benchmarks
{
    private int[][] _input = [
        [1, 1, 0],
        [1, 1, 0],
        [0, 0, 1]
    ];

    [Benchmark]
    public void Original()
    {
        _ = FindCircleNum.Original(_input);
    }

    [Benchmark]
    public void WithBoolSpan()
    {
        _ = FindCircleNum.WithBoolSpan(_input);
    }

    [Benchmark]
    public void FoundSolution()
    {
        _ = FindCircleNum.FoundSolution(_input);
    }

    [Benchmark]
    public void FoundSolutionBoolSpan()
    {
        _ = FindCircleNum.FoundSolutionBoolSpan(_input);
    }
}
