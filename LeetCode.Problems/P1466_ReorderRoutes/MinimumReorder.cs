namespace LeetCode.Problems.P1466_ReorderRoutes;
/*******************************************************
There are n cities numbered from 0 to n - 1 and n - 1 
roads such that there is only one way to travel between 
two different cities (this network form a tree). 
Last year, The ministry of transport decided to orient the 
roads in one direction because they are too narrow.

Roads are represented by connections where 
connections[i] = [ai, bi] represents a road from city ai to city bi.

This year, there will be a big event in the capital (city 0), 
and many people want to travel to this city.

Your task consists of reorienting some roads such that each 
city can visit the city 0. Return the minimum number of edges changed.

It's guaranteed that each city can reach city 0 after reorder.

Constraints:
2 <= n <= 5 * 10^4 (50,000)
connections.length == n - 1
connections[i].length == 2
0 <= ai, bi <= n - 1
ai != bi
*******************************************************/
public class MinimumReorder
{    
    /// <summary>
    /// Clearly supposed to use a DFS algorithm here, the hint confirms this.
    /// Time Limit Exceeded
    /// </summary>
    /// <param name="n"></param>
    /// <param name="connections"></param>
    /// <returns></returns>
    public static int Original(int n, int[][] connections)
    {
        Span<bool> visitedCities = stackalloc bool[n];
        return FollowPathsOut(connections, visitedCities, 0);
    } // end method

    public static int FollowPathsOut(int[][] connections, Span<bool> visitedCities, int currentCity)
    {
        if(visitedCities[currentCity])
        {
            return 0;
        }

        var count = 0;
        visitedCities[currentCity] = true;

        for(int i = 0; i < connections.Length; i++)
        {
            if(connections[i][0] == currentCity && !visitedCities[connections[i][1]])
            {
                // the road is starting at this city and going to another city
                count++;
                count += FollowPathsOut(connections, visitedCities, connections[i][1]);
            }
            else if(connections[i][1] == currentCity)
            {
                // the road is starting at another city and going to this one
                count += FollowPathsOut(connections, visitedCities, connections[i][0]);
            }
        }

        return count;
    } // end method

    public static int OriginalUsingDict(int n, int[][] connections)
    {
        var connectionsDict = Enumerable.Range(0, n).ToDictionary(key => key, value => new List<(int, bool)>());
        for(int i = 0; i < n-1; i++)
        {
            connectionsDict[connections[i][0]].Add((connections[i][1], true));
            connectionsDict[connections[i][1]].Add((connections[i][0], false));
        } // end for

        var visitedCityFlags = new bool[n];
        return FollowPathsOut(connectionsDict, visitedCityFlags);
    } // end method

    public static int FollowPathsOut(Dictionary<int, List<(int, bool)>> dict, bool[] visitedCityFlags, int currentCity = 0) 
    {       
        visitedCityFlags[currentCity] = true;
        var cityConnections = dict[currentCity];
        var result = 0;
        
        for(int i = 0; i < cityConnections.Count(); i++)
        {
            if(!visitedCityFlags[cityConnections[i].Item1])
            {
                result += cityConnections[i].Item2 ? 1 : 0;

                result += FollowPathsOut(dict, visitedCityFlags, cityConnections[i].Item1);
            }            
        }

        return result;
    }

    public static int FoundSolution(int n, int[][] connections)
    {
        var count = 0;
        var cityConnections = new List<List<(int city, int direction)>>();
        for(int i = 0; i < n; i++)
        {
            cityConnections.Add(new List<(int, int)>());
        }

        for(int i = 0; i < n - 1; i++)
        {
            cityConnections[connections[i][0]].Add((connections[i][1], 1));
            cityConnections[connections[i][1]].Add((connections[i][0], 0));
        }

        var queue = new Queue<(int city, int lastNode)>();
        queue.Enqueue((0, -1));

        while(queue.Count > 0) 
        {
            int queueSize = queue.Count;
            for(int i = 0; i < queueSize; i++)
            {
                (int currentCity, int lastNode) = queue.Dequeue();
                for(int index = 0; index < cityConnections[currentCity].Count(); index++)
                {
                    if(cityConnections[currentCity][index].city != lastNode) {
                        count += cityConnections[currentCity][index].direction;
                        queue.Enqueue((cityConnections[currentCity][index].city, currentCity));
                    }
                }
            }
        }

        return count;
    } // end method
} // end class