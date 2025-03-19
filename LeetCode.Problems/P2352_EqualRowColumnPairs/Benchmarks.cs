using BenchmarkDotNet.Attributes;

namespace LeetCode.Problems.P2352_EqualRowColumnPairs;

[MemoryDiagnoser]
public class Benchmarks
{
    private int[][] _grid = {
        new int[] {3,1,2,2}, 
        new int[] {1,4,4,5},
        new int[] {2,4,2,2},
        new int[] {2,4,2,2}
    };

    [Benchmark]
    public void Original()
    {
        _ = EqualRowColumnPairs.Original(_grid);
    }

    [Benchmark]
    public void PolynomialHashFunction()
    {
        _ = EqualRowColumnPairs.PolynomialHashFunction(_grid);
    }
}
