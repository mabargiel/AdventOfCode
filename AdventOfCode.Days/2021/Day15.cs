using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2021;

public class Day15 : AdventDay<int[,], int, int>
{
    public override int[,] ParseRawInput(string rawInput)
    {
        var split = rawInput.Trim().Split(Environment.NewLine);
        var height = split.Length;
        var width = split[0].Length;
        var result = new int [height, width];

        for (var i = 0; i < height; i++)
        {
            for (var j = 0; j < width; j++)
            {
                result[i, j] = (int)char.GetNumericValue(split[i][j]);
            }
        }

        return result;
    }

    public override int Part1(int[,] input)
    {
        return ShortestPathLength(input);
    }

    public override int Part2(int[,] input)
    {
        var height = input.GetLength(0);
        var width = input.GetLength(1);
        var newInput = new int[height * 5, width * 5];

        for (var i = 0; i < 5; i++)
        {
            for (var j = 0; j < 5; j++)
            {
                for (var k = 0; k < height; k++)
                {
                    for (var l = 0; l < width; l++)
                    {
                        var newValue = input[k, l] + i + j;
                        
                        if (newValue > 9)
                        {
                            newValue = (newValue % 10) + 1;
                        }
                        
                        newInput[i * height + k, j * width + l] = newValue;
                    }
                }
            }
        }

        return ShortestPathLength(newInput);
    }

    private static int ShortestPathLength(int[,] input)
    {
        var height = input.GetLength(0);
        var width = input.GetLength(1);
        var graph = new Graph(input.Length);

        for (var i = 0; i < height; i++)
        {
            for (var j = 0; j < width; j++)
            {
                var flatPos = i * width + j;
                if (j < width - 1)
                {
                    graph.AddEdge(flatPos, flatPos + 1, input[i, j + 1]);
                }

                if (j > 0)
                {
                    graph.AddEdge(flatPos, flatPos - 1, input[i, j - 1]);
                }

                if (i < height - 1)
                {
                    graph.AddEdge(flatPos, flatPos + width, input[i + 1, j]);
                }

                if (i > 0)
                {
                    graph.AddEdge(flatPos, flatPos - width, input[i - 1, j]);
                }
            }
        }

        return graph.GetShortestPathLength(0, width * height - 1);
    }
}

    public class Graph
    {
        private readonly int _vertices;
        private readonly Dictionary<int, List<(int, int)>> _adjArray;
        private readonly int[] _dist;
        private readonly HashSet<int> _settled;
        private readonly PriorityQueue<int, int> _pq;

        public Graph(int vertices)
        {
            _vertices = vertices;
            _dist = new int[vertices];
            _settled = new HashSet<int>();
            _pq = new PriorityQueue<int, int>(vertices);
            _adjArray = new Dictionary<int, List<(int, int)>>(vertices);
        }

        public void AddEdge(int src, int dst, int weight)
        {
            if (_adjArray.TryGetValue(src, out var value))
            {
                value.Add((dst, weight));
            } else
            {
                _adjArray[src] = new (){(dst, weight)};
            }
        }

        public int GetShortestPathLength(int src, int dst)
        {
            if (_dist.Contains(dst))
            {
                return _dist[dst];
            }
            
            for (var i = 0; i < _vertices; i++)
            {
                _dist[i] = int.MaxValue;
            }
            
            _dist[src] = 0;
            _pq.Enqueue(src, 0);

            while (_settled.Count != _vertices)
            {
                if (_pq.Count == 0)
                {
                    return _dist[dst];
                }

                var u = _pq.Dequeue();

                if (_settled.Contains(u))
                {
                    continue;
                }

                _settled.Add(u);
                ProcessNeighbours(u);
            }

            return _dist[dst];
        }
        
        private void ProcessNeighbours(int u)
        {
            for (var i = 0; i < _adjArray[u].Count; i++)
            {
                var (node, cost) = _adjArray[u][i];
                if (_settled.Contains(node))
                {
                    continue;
                }

                var newDistance = _dist[u] + cost;
                if (newDistance < _dist[node])
                    _dist[node] = newDistance;

                // Add the current node to the queue
                _pq.Enqueue(node, _dist[node]);
            }
        }
    }