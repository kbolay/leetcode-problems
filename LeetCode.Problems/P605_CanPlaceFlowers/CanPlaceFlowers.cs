using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode.Problems.P605_CanPlaceFlowers;
public static class CanPlaceFlowers
{
    public static bool Simple(int[] flowerBed, int newFlowers)
    {
        if(flowerBed.Length == 1 && flowerBed[0] == 0 && newFlowers == 1) 
        {
            return true;
        }

        var emptySpaceCounter = 0;
        var lastFlowerIndex = -1;
        var currentIndex = 0;
        while(newFlowers > 0 && currentIndex < flowerBed.Length)
        {
            if(flowerBed[currentIndex] == 1) 
            {
                if(lastFlowerIndex == -1 && emptySpaceCounter >= 2)
                {
                    newFlowers -= emptySpaceCounter / 2;
                }
                else if(emptySpaceCounter > 2)
                {
                    // we are on an odd number
                    // reduce the number of new flowers needed
                    newFlowers -= (emptySpaceCounter-1) / 2;
                }

                if(newFlowers <= 0) 
                {
                    return true;
                }

                // reset the empty space counter
                emptySpaceCounter = 0;
                lastFlowerIndex = currentIndex;
            }
            else
            {
                emptySpaceCounter++;
            }

            currentIndex++;
        }

        if(emptySpaceCounter >= 2)
        {
            if(lastFlowerIndex > - 1)
            {
                newFlowers -= emptySpaceCounter / 2;
            }
            else
            {
                newFlowers -= (emptySpaceCounter + 1) / 2;
            }            
        }

        return newFlowers <= 0;
    } // end method

    public static bool WithSpanSplit(ReadOnlySpan<int> flowerBed, int newFlowers)
    {
        if(flowerBed.Length == 1 && flowerBed[0] == 0 && newFlowers == 1) 
        {
            return true;
        }

        var newFlowersLeft = newFlowers;
        foreach(var emptyFlowerBedSection in flowerBed.Split(1))
        {
            var distance = emptyFlowerBedSection.End.Value - emptyFlowerBedSection.Start.Value;
            if((emptyFlowerBedSection.Start.Value == 0 || emptyFlowerBedSection.End.Value == flowerBed.Length)
                && distance >= 2)
            {
                var addend = emptyFlowerBedSection.Start.Value == 0 && emptyFlowerBedSection.End.Value == flowerBed.Length ? 1 : 0;
                newFlowersLeft -= (distance + addend) / 2;
            }
            else if(distance > 2)
            {
                newFlowersLeft -= (distance - 1) / 2;                
            }

            if(newFlowersLeft <= 0) 
            {
                return true;
            }
        }

        return newFlowersLeft <= 0;
    } // end method
} // end class