using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode.Problems.P649_Dota2Senate;

/******************************************************************************
In the world of Dota2, there are two parties: the Radiant and the Dire.

The Dota2 senate consists of senators coming from two parties. 
Now the Senate wants to decide on a change in the Dota2 game. 
The voting for this change is a round-based procedure. 
In each round, each senator can exercise one of the two rights:

Ban one senator's right: A senator can make another senator lose all his rights 
in this and all the following rounds.

Announce the victory: If this senator found the senators who still have rights 
to vote are all from the same party, he can announce the victory and decide on the change in the game.

Given a string senate representing each senator's party belonging. 
The character 'R' and 'D' represent the Radiant party and the Dire party. 
Then if there are n senators, the size of the given string will be n.

The round-based procedure starts from the first senator to the last 
senator in the given order. This procedure will last until the end of voting. 
All the senators who have lost their rights will be skipped during the procedure.

Suppose every senator is smart enough and will play the best strategy for his own party. 
Predict which party will finally announce the victory and change the Dota2 game. 
The output should be "Radiant" or "Dire".

Example 1:
Input: senate = "RD"
Output: "Radiant"
Explanation: 
The first senator comes from Radiant and he can just ban the next senator's right in round 1. 
And the second senator can't exercise any rights anymore since his right has been banned. 
And in round 2, the first senator can just announce the victory since he is the only guy in the 
senate who can vote.

Example 2:
Input: senate = "RDD"
Output: "Dire"
Explanation: 
The first senator comes from Radiant and he can just ban the next senator's right in round 1. 
And the second senator can't exercise any rights anymore since his right has been banned. 
And the third senator comes from Dire and he can ban the first senator's right in round 1. 
And in round 2, the third senator can just announce the victory since he is the only guy in the 
senate who can vote. 

Constraints:
n == senate.length
1 <= n <= 104
senate[i] is either 'R' or 'D'.
******************************************************************************/
public class PredictPartyVictory
{
    public static string Original(string senate)
    {
        var queue = new Queue<bool>(senate.Length);
        var rCount = 0;
        var dCount = 0;
        // r is negative, d is positive
        int banVector = 0;

        for(int i = 0; i < senate.Length; i++)
        {
            if(senate[i] == 'R')
            {
                rCount++;
            }
            else
            {
                dCount++;
            }
            queue.Enqueue(senate[i] == 'R');
        }

        while(rCount > 0 && dCount > 0)
        {
            var currentSenator = queue.Dequeue();
            if(currentSenator)
            {                
                if(banVector >= 0)
                {
                    // this radiant senator applies a ban
                    queue.Enqueue(currentSenator);
                }
                else
                {
                    // this Radiant senator was banned
                    rCount--;
                }
                banVector++;
            }
            else
            {                
                if(banVector <= 0)
                {
                    // this Dire senator applies a ban and is enqueued
                    queue.Enqueue(currentSenator);
                }
                else
                {
                    // this Dire senator was banned
                    dCount--;
                }
                banVector--;            
            }
        }

        if(rCount > 0)
        {
            return "Radiant";
        }
        
        return "Dire";
    } // end method
} // end class