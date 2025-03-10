using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode.Problems.P11_ContainerWithMostWater;

/// <summary>
/// Given an array of numbers find the greatest area.
/// Width = distance between two numbers in the array.
/// Height = lower value of the 2 numbers with distance being calculated
/// </summary>
public class ContainerWithMostWater
{
    public static int Original(int[] height)
    {
        var result = 0;

        // iterate from the start up to the second to last index of the array
        for(int i = 0; i < height.Length - 1; i++)
        {
            // attempt to short circuit this iteration
            var maxPotential = height[i] * (height.Length - 1 - i);
            if(maxPotential <= result)
            {
                continue;
            }

            // work backwards from end of array to attempt to find largest values first
            for(int j = height.Length - 1; j > i; j--)
            {
                var smallerNumber = height[j] >= height[i] ? height[i] : height[j];
                var area = smallerNumber * (j - i);

                if(area > result)
                {
                    result = area;
                }
            }
        }

        return result;
    } // end method

    public static int CorrectSolution(int[] height)
    {
        var leftIndex = 0;
        var rightIndex = height.Length - 1;

        var result = 0;

        while(leftIndex < rightIndex)
        {
            var area = Math.Min(height[leftIndex], height[rightIndex]) * (rightIndex - leftIndex);
            result = Math.Max(result, area);

            if(height[leftIndex] < height[rightIndex])
            {
                // the left side is shorter than the right side so bump forward on the left
                leftIndex++;
            }
            else
            {
                // the right side is shorter or equal to the left side, so bump down the right
                rightIndex--;
            }
        }

        return result;
    }
} // end class
