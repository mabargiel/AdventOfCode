using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2021
{
    public class Day12 : AdventDay<Graph, int, int>
    {
        public override Graph ParseRawInput(string rawInput)
        {
            return new Graph(rawInput);
        }

        public override int Part1(Graph input)
        {
            return input.DfsToEnd();
        }

        public override int Part2(Graph input)
        {
            return input.DfsToEndVisitOneCaveTwice();
        }
    }

    public class Graph
    {
        public Graph(string input)
        {
            var adjacencyStrings = input.Trim().Split(Environment.NewLine);
            foreach (var adjacencyString in adjacencyStrings)
            {
                var split = adjacencyString.Split("-");
                AddEdge(split[0], split[1]);
            }
        }

        public Dictionary<string, HashSet<string>> AdjacentList { get; } = new();

        private void AddEdge(string v, string w)
        {
            if (!AdjacentList.ContainsKey(v))
            {
                AdjacentList[v] = new HashSet<string>();
            }

            if (!AdjacentList.ContainsKey(w))
            {
                AdjacentList[w] = new HashSet<string>();
            }

            AdjacentList[v].Add(w);
            AdjacentList[w].Add(v);
        }

        public int DfsToEnd(string vertex = "start", HashSet<string> visited = null, int pathCount = 0)
        {
            visited ??= new HashSet<string>();

            if (!IsUpper(vertex))
            {
                visited.Add(vertex);
            }

            if (vertex == "end")
            {
                pathCount++;
            }
            else
            {
                foreach (var neighbor in AdjacentList[vertex])
                {
                    if (!visited.Contains(neighbor))
                    {
                        pathCount = DfsToEnd(neighbor, visited, pathCount);
                    }
                }
            }

            visited.Remove(vertex);
            return pathCount;
        }

        public int DfsToEndVisitOneCaveTwice()
        {
            return CountPaths();
        }

        private int CountPaths(string vertex = "start", string visitedTwiceVertex = null,
            HashSet<string> visited = null,
            int pathCount = 0)
        {
            visited ??= new HashSet<string>();

            if (vertex == "end")
            {
                pathCount++;
                return pathCount;
            }

            if (visitedTwiceVertex == vertex || visitedTwiceVertex != null && visited.Contains(vertex))
            {
                return pathCount;
            }

            var visitedTwice = false;

            if (!IsUpper(vertex) && visited.Contains(vertex))
            {
                visitedTwiceVertex = vertex;
                visitedTwice = true;
            }
            else if (!IsUpper(vertex))
            {
                visited.Add(vertex);
            }

            foreach (var neighbor in AdjacentList[vertex])
            {
                if (neighbor is "start")
                {
                    continue;
                }

                pathCount = CountPaths(neighbor, visitedTwiceVertex, visited, pathCount);
            }

            if (!visitedTwice)
            {
                visited.Remove(vertex);
            }

            return pathCount;
        }

        private static bool IsUpper(string vertex)
        {
            return vertex.All(char.IsUpper);
        }
    }
}