namespace LeetCode.Problems.P238_ProductOfArrayExceptSelf;

public class ProductOfArrayExceptSelf
{
    // TOO SLOW
    public static int[] Simple(int[] nums)
    {
        return Enumerable.Range(0, nums.Length).Select(index => {
            int sum = 1;
            var makeNegative = false;
            for(int i = 0; i < nums.Length; i++)
            {
                if(i != index)
                {
                    if(nums[i] < 0)
                    {
                        makeNegative = !makeNegative;
                    }

                    var number = Math.Abs(nums[i]);

                    if(number != 1)
                    {
                        sum *= number;
                    }
                }

                if(sum == 0)
                {
                    return 0;
                }
            }

            return !makeNegative ? sum : sum * -1;
        }).ToArray();
    } // end method

    public static int[] CorrectSolution(int[] nums)
    {
        // looks for ways to short circuit
        // create a results array
        // iterate forward through nums to populate the results array with the left multiplicand, 
        // using the previous left value in the results array to avoid duplicate processing
        // first index in the results array gets a value of 0
        // create a right int to hold the current multiplier value, starting value of 1
        // iterate backward through the nums array, updating results by multiplying the current result index (left) with the the right multiplier 
        // update the right multiplier with right *= num[i]
        
        var zeroCounter = 0;
        var results = new int[nums.Length];
        results[0] = 1;
        for(int i = 1; i < nums.Length; i++)
        {
            results[i] = results[i-1] * nums[i-1];

            if(nums[i-1] == 0)
            {
                zeroCounter++;

                if(zeroCounter > 1)
                {
                    // return an array of zeros
                    return new int[nums.Length];
                }
            }
        }

        var right = nums[nums.Length - 1];
        for(int i = nums.Length-2; i >= 0; i--)
        {
            results[i] = results[i] * right;
            right *= nums[i];
        }

        return results;
    } // end method

    public static int[] CorrectSolutionWithSpans(ReadOnlySpan<int> nums)
    {       
        var zeroCounter = 0;
        Span<int> results = stackalloc int[nums.Length];
        
        results[0] = 1;
        for(int i = 1; i < nums.Length; i++)
        {
            results[i] = results[i-1] * nums[i-1];

            if(nums[i-1] == 0)
            {
                zeroCounter++;

                if(zeroCounter > 1)
                {
                    // return an array of zeros
                    results.Fill(0);
                    return results.ToArray();
                }
            }
        }

        var right = nums[nums.Length - 1];
        for(int i = nums.Length-2; i >= 0; i--)
        {
            results[i] = results[i] * right;
            right *= nums[i];
        }

        return results.ToArray();
    }
} // end class
