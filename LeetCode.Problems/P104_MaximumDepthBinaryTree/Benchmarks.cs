using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using LeetCode.Problems.Shared;

namespace LeetCode.Problems.P104_MaximumDepthBinaryTree;

[MemoryDiagnoser]
public class Benchmarks
{
    private int?[] _inputNums = new int?[] { 3,9,20,null,null,15,7};
    private TreeNode _root;

    [GlobalSetup]
    public void Setup()
    {
        _root = _inputNums.ToTreeNode();
    }

    [Benchmark]
    public void Original()
    {
        _ = MaximumDepth.Original(_root);
    }

    [Benchmark]
    public void FoundSolution()
    {
        _ = MaximumDepth.FoundSolution(_root);
    }
}
