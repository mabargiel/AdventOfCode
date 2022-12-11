using System;
using System.Collections.Generic;

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

        return graph.Dijkstra(0, width * height - 1);
    }

    private class Graph
    {
        private readonly int _vertices;
        private readonly Dictionary<(int, int), int> _adjArray;

        public Graph(int vertices)
        {
            _vertices = vertices;
            _adjArray = new Dictionary<(int, int), int>();
        }

        public void AddEdge(int src, int dst, int weight)
        {
            _adjArray[(src, dst)] = weight;
        }

        private int MinDistance(IReadOnlyList<int> dist, IReadOnlyList<bool> sptSet)
        {
            int min = int.MaxValue, minIndex = -1;

            for (var v = 0; v < _vertices; v++)
            {
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        public int Dijkstra(int from, int to)
        {
            //var unvisited = new PriorityQueue<int, int>();
            var dist = new int[_vertices];
            var sptSet = new bool[_vertices];
            for (var i = 0; i < _vertices; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
                //unvisited.Enqueue(i, int.MaxValue);
            }
            
            dist[from] = 0;
            //unvisited.Enqueue(src, 0);

            for (var count = 0; count < _vertices; count++)
            {
                var u = MinDistance(dist, sptSet);
                sptSet[u] = true;
                for (var v = 0; v < _vertices; v++)
                {
                    if (!_adjArray.ContainsKey((u, v)))
                    {
                        continue;
                    }
                    
                    if (!sptSet[v] && _adjArray[(u, v)] != 0 &&
                        dist[u] != int.MaxValue && dist[u] + _adjArray[(u, v)] < dist[v])
                    {
                        dist[v] = dist[u] + _adjArray[(u, v)];
                    }
                }
            }

            return dist[to];
        }
    }
}