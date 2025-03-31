using System.Collections;

namespace LeetCode.Problems.P841_CanVisitAllRooms;
/******************************************************************************
There are n rooms labeled from 0 to n - 1 and all the rooms are locked except 
for room 0. Your goal is to visit all the rooms. However, you cannot enter a 
locked room without having its key.

When you visit a room, you may find a set of distinct keys in it. Each key has 
a number on it, denoting which room it unlocks, and you can take all of them 
with you to unlock the other rooms.

Given an array rooms where rooms[i] is the set of keys that you can obtain 
if you visited room i, return true if you can visit all the rooms, 
or false otherwise.

Constraints:
n == rooms.length
2 <= n <= 1000
0 <= rooms[i].length <= 1000
1 <= sum(rooms[i].length) <= 3000
0 <= rooms[i][j] < n
All the values of rooms[i] are unique.
******************************************************************************/
public class CanVisitAllRooms
{
    /// <summary>
    /// Simple approach with BitArray
    /// </summary>
    /// <param name="rooms"></param>
    /// <returns></returns>
    public static bool Original(IList<IList<int>> rooms)
    {
        var roomBits = new BitArray(rooms.Count);
        roomBits.Set(0, true);

        DepthFirstSearch(rooms, roomBits);

        return roomBits.HasAllSet();
    } // end method

    public static void DepthFirstSearch(IList<IList<int>> rooms, BitArray roomBits, int currentRoom = 0)
    {
        for(int i = 0; i < rooms[currentRoom].Count; i++)
        {
            if(!roomBits.Get(rooms[currentRoom][i]))
            {
                roomBits.Set(rooms[currentRoom][i], true);
                DepthFirstSearch(rooms, roomBits, rooms[currentRoom][i]);
            }
        }
    }

    public static bool OriginalWithSpan(IList<IList<int>> rooms)
    {
        Span<bool> roomBits = stackalloc bool[rooms.Count];
        roomBits[0] = true;

        DepthFirstSearch(rooms, roomBits);

        if(roomBits.IndexOf(false) > -1)
        {
            return false;
        }

        return true;
    }

    public static void DepthFirstSearch(IList<IList<int>> rooms, Span<bool> roomBits, int currentRoom = 0)
    {
        for(int i = 0; i < rooms[currentRoom].Count; i++)
        {
            if(!roomBits[rooms[currentRoom][i]])
            {
                roomBits[rooms[currentRoom][i]] = true;
                DepthFirstSearch(rooms, roomBits, rooms[currentRoom][i]);
            }
        }
    }
} // end class
