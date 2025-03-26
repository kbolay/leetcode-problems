using BenchmarkDotNet.Attributes;
using LeetCode.Problems.Shared;

namespace LeetCode.Problems.P437_PathSum3;
[MemoryDiagnoser]
public class Benchmarks
{
    private int?[] _treeNums = new int?[] { 5,4,8,11,null,13,4,7,2,null,null,5,1 };
    private TreeNode _root;
    private int _targetSum = 22;

    [GlobalSetup]
    public void Setup()
    {
        _root = _treeNums.ToTreeNode();
    }

    [Benchmark]
    public void Original()
    {
        _ = PathSum.Original(_root, _targetSum);
    } // end method

    [Benchmark]
    public void FoundSolution()
    {
        _ = PathSum.FoundSolution(_root, _targetSum);
    } // end method
} // end class