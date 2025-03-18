using BenchmarkDotNet.Attributes;

namespace LeetCode.Problems.P1207_UniqueNumberOfOccurrences;

[MemoryDiagnoser]
public class Benchmarks
{
    private const int MAX_ARRAY_LENGTH = 1000;
    private const int MIN_ARRAY_LENGTH = 1;
    private const int MIN_VALUE = -1000;
    private const int MAX_VALUE = 1000;

    private static Random _random = new Random();

    private int[] _nums;

    [GlobalSetup]
    public void Setup()
    {
        var arrayLength = _random.Next(MIN_ARRAY_LENGTH, MAX_ARRAY_LENGTH+1);
        _nums = new int[arrayLength];
        Enumerable.Range(0, arrayLength).Select(x => _nums[x] = _random.Next(MIN_VALUE, MAX_VALUE+1));
    }

    [Benchmark]
    public void Original()
    {
        _ = UniqueNumberOfOccurrences.Original(_nums);
    }

    [Benchmark]
    public void UsingDictionary()
    {
        _ = UniqueNumberOfOccurrences.UsingDictionary(_nums);
    }
}