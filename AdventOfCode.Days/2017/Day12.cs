using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2017
{
    public class Day12 : AdventDay<Dictionary<int, int[]>, int, int>
    {
        public override Dictionary<int, int[]> ParseRawInput(string rawInput)
        {
            return new Dictionary<int, int[]>(rawInput.Trim().Split(Environment.NewLine).Select(s =>
            {
                var split = s.Split("<->").Select(x => x.Trim()).ToArray();
                var program = int.Parse(split[0]);
                var adjacentPrograms = split[1].Split(", ").Select(int.Parse).ToArray();

                return new KeyValuePair<int, int[]>(program, adjacentPrograms);
            }));
        }

        public override int Part1(Dictionary<int, int[]> input)
        {
            var graph = new ProgramsGraph(input);

            return input.Keys.Count(program => graph.IsReachable(0, program));
        }

        public override int Part2(Dictionary<int, int[]> input)
        {
            var graph = new ProgramsGraph(input);

            return graph.GetNumberOfConnectedComponents();
        }
    }

    public class ProgramsGraph : Graph
    {
        public ProgramsGraph(Dictionary<int, int[]> programMap) : base(programMap.Count)
        {
            foreach (var (key, value) in programMap)
            {
                foreach (var adjacentProgram in value)
                {
                    AddEdge(key, adjacentProgram);
                }
            }
        }
    }

    public class Graph
    {
        private readonly List<List<int>> _adjacentList;
        private readonly int _numberOfVertices;

        protected Graph(int numberOfVertices)
        {
            _numberOfVertices = numberOfVertices;
            _adjacentList = new List<List<int>>();
            for (var i = 0; i < numberOfVertices; i++)
            {
                _adjacentList.Add(new List<int>());
            }
        }

        protected void AddEdge(int v, int w)
        {
            _adjacentList[v].Add(w);
            _adjacentList[w].Add(v);
        }

        // A BFS based function to check whether d is reachable from s.
        public bool IsReachable(int s, int d)
        {
            if (s == d)
            {
                return true;
            }

            bool[] visited = new bool[_numberOfVertices];
            for (var i = 0; i < _numberOfVertices; i++)
            {
                visited[i] = false;
            }

            Queue<int> queue = new();

            visited[s] = true;
            queue.Enqueue(s);

            while (queue.Count != 0)
            {
                s = queue.Dequeue();

                for (var i = 0; i < _adjacentList[s].Count; i++)
                {
                    if (_adjacentList[s][i] == d)
                    {
                        return true;
                    }

                    if (visited[_adjacentList[s][i]])
                    {
                        continue;
                    }

                    visited[_adjacentList[s][i]] = true;
                    queue.Enqueue(_adjacentList[s][i]);
                }
            }

            return false;
        }

        public int GetNumberOfConnectedComponents()
        {
            var result = 0;
            bool[] visited = new bool[_numberOfVertices];
            for (var v = 0; v < _numberOfVertices; ++v)
            {
                if (visited[v])
                {
                    continue;
                }

                DfsUtil(v, visited);
                result++;
            }

            return result;
        }

        private void DfsUtil(int v, IList<bool> visited)
        {
            visited[v] = true;

            foreach (var x in _adjacentList[v].Where(x => !visited[x]))
            {
                DfsUtil(x, visited);
            }
        }
    }
}