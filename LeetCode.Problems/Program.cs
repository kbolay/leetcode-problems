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
            //var summary = BenchmarkRunner.Run<P1768_MergeStringsAlternately.Benchmarks>();
            //var summary = BenchmarkRunner.Run<P1071_GCDStrings.Benchmarks>();
            //var summary = BenchmarkRunner.Run<P1341_KidsWithCandies.Benchmarks>();
            //var summary = BenchmarkRunner.Run<P605_CanPlaceFlowers.Benchmarks>();
            //var summary = BenchmarkRunner.Run<P151_ReverseWords.Benchmarks>();
            // var summary = BenchmarkRunner.Run<P238_ProductOfArrayExceptSelf.Benchmarks>();
            // var summary = BenchmarkRunner.Run<P392_IsSubsequence.Benchmarks>();
            //var summary = BenchmarkRunner.Run<P11_ContainerWithMostWater.Benchmarks>();
            var summary = BenchmarkRunner.Run<P1456_MaxVowelsInWindow.Benchmarks>();
        }
    }
}