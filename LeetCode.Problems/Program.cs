using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;

namespace LeetCode.Problems
{
    public class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<P1768_MergeStringsAlternately.Benchmarks>();
        }
    }
}