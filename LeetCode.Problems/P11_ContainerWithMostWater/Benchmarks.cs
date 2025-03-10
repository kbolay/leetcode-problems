using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace LeetCode.Problems.P11_ContainerWithMostWater
{
    [MemoryDiagnoser]
    public class Benchmarks
    {
        /*
        2 <= n <= 10^5
        0 <= height[i] <= 10^4
        */
        private const int MIN_ARRAY_ITEMS = 2;
        private const int MAX_ARRAY_ITEMS = 100_000;
        private const int MIN_VALUE = 0;
        private const int MAX_VALUE = 10_000;

        private static Random _random = new Random();

        private int[] _input;

        [GlobalSetup]
        public void Setup()
        {
            var arrayItems = _random.Next(MIN_ARRAY_ITEMS, MAX_ARRAY_ITEMS + 1);
            _input = Enumerable.Range(0, arrayItems).Select(x => _random.Next(MIN_VALUE, MAX_VALUE + 1)).ToArray();
        }

        [Benchmark]
        public void Simple()
        {
            _ = ContainerWithMostWater.Original(_input);
        }
    }
}