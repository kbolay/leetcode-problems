using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace LeetCode.Problems.P1768_MergeStringsAlternately
{
    [MemoryDiagnoser]
    public class Benchmarks
    {
        private string _word1 = string.Empty;
        private string _word2 = string.Empty;

        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        private Random random;
        [GlobalSetup]
        public void Setup()
        {            
            random = new Random();
            
            _word1 = BuildWord(random);
            _word2 = BuildWord(random);
        }

        private string BuildWord(Random random)
        {
            int length = random.Next(1, 101); // Random length between 1 and 100
            var result = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }

            return result.ToString();
        }

        [Benchmark]
        public void Simple()
        {
            MergeStringsAlternately.Simple(_word1, _word2);
        }

        [Benchmark]
        public void WithStringBuilder()
        {
            MergeStringsAlternately.WithStringBuilder(_word1, _word2);
        }

        [Benchmark]
        public void WithStringBuilderWithLength()
        {
            MergeStringsAlternately.WithStringBuilderWithLength(_word1, _word2);
        }

        [Benchmark]
        public void WithSpans()
        {
            MergeStringsAlternately.WithSpans(_word1, _word2);
        }
    }
}