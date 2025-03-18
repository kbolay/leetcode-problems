using BenchmarkDotNet.Attributes;

namespace LeetCode.Problems.P1004_MaxConsecutiveOnes;

[MemoryDiagnoser]
public class Benchmarks
{
    private int[] _nums = { 0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1 };
    private int _k = 3;

    [Benchmark]
    public void Original()
    {
        _ = MaxConsecutiveOnes.Original(_nums, _k);
    }

    [Benchmark]
    public void Solution()
    {
        _ = MaxConsecutiveOnes.Solution(_nums, _k);
    }
} // end class