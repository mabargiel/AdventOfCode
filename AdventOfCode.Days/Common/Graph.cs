using System.Collections.Generic;

namespace AdventOfCode.Days.Common;

public class Graph
{
    private readonly int _vertices;
    private readonly Dictionary<int, List<(int, int)>> _adjArray;

    public Graph(int vertices)
    {
        _vertices = vertices;
        _adjArray = new Dictionary<int, List<(int, int)>>(vertices);
    }

    public void AddEdge(int src, int dst, int weight = 1)
    {
        if (_adjArray.TryGetValue(src, out var value))
        {
            value.Add((dst, weight));
        } else
        {
            _adjArray[src] = new (){(dst, weight)};
        }
    }

    public int DijkstraShortestPath(int src, int dst)
    {
        var settled = new HashSet<int>();
        var pq = new PriorityQueue<int, int>(_vertices);
        var dist = new int[_vertices];
            
        for (var i = 0; i < _vertices; i++)
        {
            dist[i] = int.MaxValue;
        }
            
        dist[src] = 0;
        pq.Enqueue(src, 0);

        while (settled.Count != _vertices)
        {
            if (pq.Count == 0)
            {
                return dist[dst];
            }

            var u = pq.Dequeue();

            if (settled.Contains(u))
            {
                continue;
            }

            settled.Add(u);
            ProcessNeighbours(u);
        }

        return dist[dst];
            
        void ProcessNeighbours(int u)
        {
            for (var i = 0; i < _adjArray[u].Count; i++)
            {
                var (node, cost) = _adjArray[u][i];
                if (settled.Contains(node))
                {
                    continue;
                }

                var newDistance = dist[u] + cost;
                if (newDistance < dist[node])
                    dist[node] = newDistance;

                // Add the current node to the queue
                pq.Enqueue(node, dist[node]);
            }
        }
    }
}