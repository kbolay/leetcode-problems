using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gee.External.Capstone.Arm64;

namespace LeetCode.Problems.P735_AsteroidCollision;

public class AsteroidCollision
{
    /**************************************************************
    We are given an array asteroids of integers representing asteroids in a row. 
    The indices of the asteriod in the array represent their relative position in space.

    For each asteroid, the absolute value represents its size, and the sign represents its direction 
    (positive meaning right, negative meaning left). Each asteroid moves at the same speed.

    Find out the state of the asteroids after all collisions. If two asteroids meet, 
    the smaller one will explode. If both are the same size, both will explode. 
    Two asteroids moving in the same direction will never meet.

    Constraints:
    2 <= asteroids.length <= 104
    -1000 <= asteroids[i] <= 1000
    asteroids[i] != 0

    Example 1:
    Input: asteroids = [5,10,-5]
    Output: [5,10]
    Explanation: The 10 and -5 collide resulting in 10. The 5 and 10 never collide.

    Example 2:
    Input: asteroids = [8,-8]
    Output: []
    Explanation: The 8 and -8 collide exploding each other.

    Example 3:
    Input: asteroids = [10,2,-5]
    Output: [10]
    Explanation: The 2 and -5 collide resulting in -5. The 10 and -5 collide resulting in 10.
    **************************************************************/

    /// <summary>
    /// First submission was wrong because I just check for different direction, rather than using right and left.
    /// Positive numbers move to the right ->
    /// Negative numbers move to the left <-
    /// </summary>
    /// <param name="asteroids"></param>
    /// <returns></returns>
    public static int[] Original(int[] asteroids)
    {
        var asteroidStack = new Stack<int>();
        var lastDirection = false;
        var lastAbsValue = 0;

        for(int i = 0; i < asteroids.Length; i++)
        {
            if(asteroidStack.Count == 0)
            {
                // the asteroid stack is empty for some reason
                // populate and go to next loop iteration
                asteroidStack.Push(asteroids[i]);
                lastDirection = asteroids[i] > 0;
                lastAbsValue = Math.Abs(asteroids[i]);

                continue;
            }

            var currentDirection = asteroids[i] > 0;
            var absValue = Math.Abs(asteroids[i]);

            if(!lastDirection || currentDirection) 
            {
                // no possibility of collision between these two asteroids
                asteroidStack.Push(asteroids[i]);
                lastDirection = currentDirection;
                lastAbsValue = absValue;

                continue;
            }

            var currentDestroyed = false;
            while(lastDirection && !currentDirection && !currentDestroyed) 
            {
                // the previous asteroid traveling towards the right (positive)
                // and the current asteroid traveling towards the left (negative)
                // and the current asteroid has a greater or equal size of the last asteroid
                // so there will be a collision and the last asteroid will be destroyed
                if(absValue >= lastAbsValue)
                {
                    asteroidStack.Pop();
                }

                if(absValue <= lastAbsValue)
                {
                    // both asteroids were the same size, so destroy the current one as well.
                    currentDestroyed = true;
                }
                
                // get the value of the last asteroid
                if(asteroidStack.TryPeek(out int lastValue))
                {                        
                    lastDirection = lastValue > 0;
                    lastAbsValue = Math.Abs(lastValue);
                }
                else
                {
                    lastDirection = false;
                    lastAbsValue = 0;
                }
            }

            if(!currentDestroyed)
            {
                asteroidStack.Push(asteroids[i]);
                lastDirection = currentDirection;
                lastAbsValue = absValue;
            }
        }

        return asteroidStack.Reverse().ToArray();
    } // end method

    public static int[] FoundSolution(int[] asteroids)
    {
        var stack = new Stack<int>();
        for(int i = 0; i < asteroids.Length; i++)
        {
            if(asteroids[i] > 0)
            {
                stack.Push(asteroids[i]);
            } else {
                
                var absValue = Math.Abs(asteroids[i]);
                while(stack.Count > 0 && stack.Peek() > 0 && stack.Peek() < absValue)
                {
                    stack.Pop();
                }

                if(stack.Count > 0 && stack.Peek() == absValue)
                {
                    stack.Pop();
                }
                else if(stack.Count == 0 || stack.Peek() < 0)
                {
                    stack.Push(asteroids[i]);
                }
            }
        }

        var result = new int[stack.Count];
        var index = stack.Count - 1;
        while(stack.Count > 0)
        {
            result[index] = stack.Pop();
            index--;
        }

        return result;
    }
} // end class
