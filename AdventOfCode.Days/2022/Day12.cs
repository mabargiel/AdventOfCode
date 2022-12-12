using System;
using AdventOfCode.Days._2021;
using AdventOfCode.Days.Common;

namespace AdventOfCode.Days._2022;

public class Day12 : AdventDay<Input, int, int>
{
    public override Input ParseRawInput(string rawInput)
    {
        var lines = rawInput.Trim().Split(Environment.NewLine);
        var width = lines[0].Length;
        var height = lines.Length;
        var map = new int[height, width];
        Point src = null;
        Point dsc = null;

        const int asciiA = 96;
        
        for (var i = 0; i < height; i++)
        {
            for (var j = 0; j < width; j++)
            {
                var c = lines[i][j];

                switch (c)
                {
                    case 'S':
                        src = new Point(i, j);
                        map[i, j] = 'a' - asciiA;
                        break;
                    case 'E':
                        dsc = new Point(i, j);
                        map[i, j] = 'z' - asciiA;
                        break;
                    default:
                        map[i, j] = c - asciiA;
                        break;
                }
            }
        }

        return new Input(src, dsc, map);
    }

    public override int Part1(Input input)
    {
        var graph = BuildGraph(input);

        return graph.DijkstraShortestPath(input.Src.X * input.Map.GetLength(1) + input.Src.Y,
            input.Dst.X * input.Map.GetLength(1) + input.Dst.Y);
    }

    public override int Part2(Input input)
    {
        var width = input.Map.GetLength(1);
        var graph = BuildGraph(input);

        var shortestPath = int.MaxValue;

        for (var i = 0; i < input.Map.GetLength(0); i++)
        {
            for (var j = 0; j < width; j++)
            {
                if (input.Map[i, j] != 1)
                {
                    continue;
                }

                var path = graph.DijkstraShortestPath(i * width + j, input.Dst.X * width + input.Dst.Y);
                shortestPath = path < shortestPath ? path : shortestPath;
            }
        }

        return shortestPath;
    }

    private static Graph BuildGraph(Input input)
    {
        var height = input.Map.GetLength(0);
        var width = input.Map.GetLength(1);

        var graph = new Graph(width * height);

        for (var i = 0; i < height; i++)
        {
            for (var j = 0; j < width; j++)
            {
                var flatPos = i * width + j;
                if (j < width - 1 && input.Map[i, j] + 1 >= input.Map[i, j + 1])
                {
                    graph.AddEdge(flatPos, flatPos + 1);
                }

                if (j > 0 && input.Map[i, j] + 1 >= input.Map[i, j - 1])
                {
                    graph.AddEdge(flatPos, flatPos - 1);
                }

                if (i < height - 1 && input.Map[i, j] + 1 >= input.Map[i + 1, j])
                {
                    graph.AddEdge(flatPos, flatPos + width);
                }

                if (i > 0 && input.Map[i, j] + 1 >= input.Map[i - 1, j])
                {
                    graph.AddEdge(flatPos, flatPos - width);
                }
            }
        }

        return graph;
    }
}

public record Input(Point Src, Point Dst, int[,] Map);