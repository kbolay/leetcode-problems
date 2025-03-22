using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace LeetCode.Problems.P735_AsteroidCollision;

[MemoryDiagnoser]
public class Benchmarks
{
    public int[] _asteroids = { 10 ,2 ,-5};

    [Benchmark]
    public void Original()
    {
        _ = AsteroidCollision.Original(_asteroids);
    }

    [Benchmark]
    public void FoundSolution()
    {
        _ = AsteroidCollision.FoundSolution(_asteroids);
    }
}
