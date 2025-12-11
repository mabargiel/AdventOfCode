using System;
using AdventOfCode.Days.Common;

namespace AdventOfCode.Days._2021;

public class Day15 : AdventDay<int[,], int, int>
{
    public override int[,] ParseRawInput(string rawInput)
    {
        var split = rawInput.Trim().Split(Environment.NewLine);
        var height = split.Length;
        var width = split[0].Length;
        var result = new int[height, width];

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
                            newValue = newValue % 10 + 1;
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
        var graph = new Graph<int>(input.Length);

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

        return graph.DijkstraShortestPath(0, width * height - 1);
    }
}
