namespace LeetCode.Problems.P547_NumberOfProvinces;
/******************************************************************************
There are n cities. Some of them are connected, while some are not. 
If city a is connected directly with city b, and city b is connected 
directly with city c, then city a is connected indirectly with city c.

A province is a group of directly or indirectly connected cities 
and no other cities outside of the group.

You are given an n x n matrix isConnected where isConnected[i][j] = 1 
if the ith city and the jth city are directly connected, 
and isConnected[i][j] = 0 otherwise.

Return the total number of provinces.

Constraints
1 <= n <= 200
n == isConnected.length
n == isConnected[i].length
isConnected[i][j] is 1 or 0.
isConnected[i][i] == 1
isConnected[i][j] == isConnected[j][i]
******************************************************************************/
public class FindCircleNum
{
    /// <summary>
    /// We are finding the number of distinct "graphs" within the input.
    /// </summary>
    /// <param name="isConnected"></param>
    /// <returns></returns>
    public static int Original(int[][] isConnected)
    {
        if(isConnected.Length == 1)
        {
            return 1;
        }

        var provinceCount = 0;
        var cityHash = new HashSet<int>();
        for(int i = 0; i < isConnected.Length; i++)
        {
            // attempt to add the city to the cache
            // if it returns true we haven't processed it yet.
            if(cityHash.Add(i))
            {
                // this is a new province
                provinceCount++;
                ProcessCity(isConnected, cityHash, i);
            }
        }

        return provinceCount;
    } // end method

    /// <summary>
    /// Process a cities connections.
    /// Uses depth first search.
    /// </summary>
    /// <param name="isConnected"></param>
    /// <param name="cityHash"></param>
    /// <param name="currentCity"></param>
    public static void ProcessCity(int[][] isConnected, HashSet<int> cityHash, int currentCity)
    {
        // get a pointer to the current city
        var city = isConnected[currentCity];

        // iterate through each element of the cities connections
        for(int i = 0; i < city.Count(); i++)
        {
            // does the city connect to a city not yet in the hash?
            if(i != currentCity && city[i] == 1 && cityHash.Add(i))
            {
                // process the city as part of the current province
                ProcessCity(isConnected, cityHash, i);
            }
        }
    } // end method

    public static int WithBoolSpan(int[][] isConnected)
    {
        if(isConnected.Length == 1)
        {
            return 1;
        }

        var provinceCount = 0;
        Span<bool> cityFlags = stackalloc bool[isConnected.Length];
        for(int i = 0; i < isConnected.Length; i++)
        {
            // attempt to add the city to the cache
            // if it returns true we haven't processed it yet.
            if(!cityFlags[i])
            {
                cityFlags[i] = true;
                // this is a new province
                provinceCount++;
                ProcessCity(isConnected, cityFlags, i);
            }
        }

        return provinceCount;
    }

    public static void ProcessCity(int[][] isConnected, Span<bool> cityFlags, int currentCity)
    {
        // get a pointer to the current city
        var city = isConnected[currentCity];

        // iterate through each element of the cities connections
        for(int i = 0; i < city.Count(); i++)
        {
            // does the city connect to a city not yet in the hash?
            if(i != currentCity && city[i] == 1 && !cityFlags[i])
            {
                cityFlags[i] = true;
                // process the city as part of the current province
                ProcessCity(isConnected, cityFlags, i);
            }
        }
    } // end method

    public static int FoundSolution(int[][] isConnected)
    {
        int cityCount = isConnected.Length;
        var isVisited = new bool[cityCount];
        int result = 0;

        for(int i = 0; i < cityCount; i++)
        {
            if(!isVisited[i])
            {
                FoundSolutionDFS(isConnected, i, isVisited);
                result++;
            }
        }

        return result;
    } // end method

    public static void FoundSolutionDFS(int[][] isConnected, int cityIndex, bool[] isVisited)
    {
        isVisited[cityIndex] = true;
        for(int i = 0; i < isConnected.Length; i++)
        {
            if(!isVisited[i] && isConnected[cityIndex][i] == 1)
            {
                FoundSolutionDFS(isConnected, i, isVisited);
            }
        }
    } // end method

    public static int FoundSolutionBoolSpan(int[][] isConnected)
    {
        int cityCount = isConnected.Length;
        Span<bool> isVisited = stackalloc bool[cityCount];
        int result = 0;

        for(int i = 0; i < cityCount; i++)
        {
            if(!isVisited[i])
            {
                FoundSolutionSpanDFS(isConnected, i, isVisited);
                result++;
            }
        }

        return result;
    } // end method

    public static void FoundSolutionSpanDFS(int[][] isConnected, int cityIndex, Span<bool> isVisited)
    {
        isVisited[cityIndex] = true;
        for(int i = 0; i < isConnected.Length; i++)
        {
            if(!isVisited[i] && isConnected[cityIndex][i] == 1)
            {
                FoundSolutionSpanDFS(isConnected, i, isVisited);
            }
        }
    } // end method
} // end class