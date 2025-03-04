using Xunit;
using LeetCode.Problems.P2_AddTwoNumbers;

namespace LeetCode.Tests.P2_AddTwoNumbers
{
    public class P2AddTwoNumbersTests
    {
        private ListNode? BuildListNode(int[] nums)
        {
            ListNode? result = null;
            foreach(var number in nums.Reverse())
            {
                result = new ListNode(number, result);
            }

            return result;
        } // end method

        private int[] ReadListNode(ListNode listNode)
        {
            List<int> result = new List<int>();

            result.Add(listNode.val);
            if(listNode.next != null)
            {
                result.AddRange(ReadListNode(listNode.next));
            }

            return result.ToArray();
        }

        [Theory]
        [InlineData(new int[] { 2,4,3 }, new int[] { 5,6,4 }, new int[] { 7,0,8 })]
        [InlineData(new int[] { 0 }, new int[] { 0 }, new int[] { 0 })]
        [InlineData(new int[] { 9,9,9,9,9,9,9 }, new int[] { 9,9,9,9 }, new int[] { 8,9,9,9,0,0,0,1 })]
        public void RunTests(int[] l1Nums, int[] l2Nums, int[] expected)
        {
            var l1 = BuildListNode(l1Nums);
            var l2 = BuildListNode(l2Nums);

            var instance = new P2AddTwoNumbers();
            var resultListNode = instance.AddTwoNumbers(l1!, l2!);

            var result = ReadListNode(resultListNode);

            Assert.Equal(expected, result);
        }
    } // end class
} // end namespace