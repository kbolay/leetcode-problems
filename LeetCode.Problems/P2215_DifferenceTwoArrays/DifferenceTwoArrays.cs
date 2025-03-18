using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode.Problems.P2215_DifferenceTwoArrays;
public class DifferenceTwoArrays
{
    /******************************************************************************
    Given two 0-indexed integer arrays nums1 and nums2, return a list answer of size 2 where:

    answer[0] is a list of all distinct integers in nums1 which are not present in nums2.
    answer[1] is a list of all distinct integers in nums2 which are not present in nums1.
    Note that the integers in the lists may be returned in any order.

    Constraints:
    1 <= nums1.length, nums2.length <= 1000
    -1000 <= nums1[i], nums2[i] <= 1000

    Example 1:
    Input: nums1 = [1,2,3], nums2 = [2,4,6]
    Output: [[1,3],[4,6]]
    Explanation:
    For nums1, nums1[1] = 2 is present at index 0 of nums2, whereas nums1[0] = 1 and nums1[2] = 3 are not present in nums2. Therefore, answer[0] = [1,3].
    For nums2, nums2[0] = 2 is present at index 1 of nums1, whereas nums2[1] = 4 and nums2[2] = 6 are not present in nums2. Therefore, answer[1] = [4,6].

    Example 2:
    Input: nums1 = [1,2,3,3], nums2 = [1,1,2,2]
    Output: [[3],[]]
    Explanation:
    For nums1, nums1[2] and nums1[3] are not present in nums2. Since nums1[2] == nums1[3], their value is only included once and answer[0] = [3].
    Every integer in nums2 is present in nums1. Therefore, answer[1] = [].
    ******************************************************************************/
    public static IList<IList<int>> Original(int[] nums1, int[] nums2) 
    {
        var uniqueNum1s = new HashSet<int>();
        for(var i = 0; i < nums1.Length; i++)
        {
            uniqueNum1s.Add(nums1[i]);
        }

        var uniqueNum2s = new HashSet<int>();
        var removeFromHashset = new HashSet<int>();
        for(var i = 0; i < nums2.Length; i++)
        {
            if(!uniqueNum1s.Contains(nums2[i]))
            {
                uniqueNum2s.Add(nums2[i]);
            }
            else
            {
                removeFromHashset.Add(nums2[i]);
            }
        }

        foreach(var value in removeFromHashset)
        {
            uniqueNum1s.Remove(value);
        }

        return new List<IList<int>>() { uniqueNum1s.ToList(), uniqueNum2s.ToList() };
    }
} // end class