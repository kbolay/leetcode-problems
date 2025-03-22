using LeetCode.Problems.Shared;

namespace LeetCode.Tests.Shared;
public static class ListNodeExtensions
{
    public static void AssertEqual(this ListNode? expected, ListNode? result)
    {
        if(expected != null)
        {
            while(expected.next != null)
            {
                Assert.Equal(expected.val, result.val);
                
                if(expected.next != null)
                {
                    expected = expected.next;
                    result = result.next;
                }
                else
                {
                    Assert.Null(result.next);
                }
            }
        }
        else
        {
            Assert.Null(result);
        }
    } // end method
}