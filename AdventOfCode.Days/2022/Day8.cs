using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2022;

public class Day8 : AdventDay<int[,], int, int>
{
    public override int[,] ParseRawInput(string rawInput)
    {
        var lines = rawInput.Trim().Split(Environment.NewLine);
        var width = lines[0].Length;
        var height = lines.Length;

        var result = new int[height, width];

        for (var i = 0; i < height; i++)
        {
            for (var j = 0; j < width; j++)
            {
                result[i, j] = (int)char.GetNumericValue(lines[i][j]);
            }
        }

        return result;
    }

    public override int Part1(int[,] input)
    {
        var width = input.GetLength(1);
        var height = input.GetLength(0);
        var result = 2 * width + 2 * height - 4;

        for (var i = 1; i < height - 1; i++)
        {
            for (var j = 1; j < width - 1; j++)
            {
                var column = GetColumn(input, j, height);
                var row = GetRow(input, i, width);
                var treeHeight = input[i, j];

                if (
                    column[..i].All(v => v < treeHeight)
                    || column[(i + 1)..].All(v => v < treeHeight)
                    || row[..j].All(v => v < treeHeight)
                    || row[(j + 1)..].All(v => v < treeHeight)
                )
                {
                    result++;
                }
            }
        }

        return result;
    }

    public override int Part2(int[,] input)
    {
        var width = input.GetLength(1);
        var height = input.GetLength(0);
        var result = 0;

        for (var i = 1; i < height - 1; i++)
        {
            for (var j = 1; j < width - 1; j++)
            {
                var column = GetColumn(input, j, height);
                var row = GetRow(input, i, width);
                var treeHeight = input[i, j];

                var treesPerDirection = new[]
                {
                    column[(i + 1)..],
                    ((IEnumerable<int>)column[..i]).Reverse().ToArray(),
                    row[(j + 1)..],
                    ((IEnumerable<int>)row[..j]).Reverse().ToArray(),
                };

                var viewDistances = treesPerDirection
                    .Select(x =>
                    {
                        var firstHigherTree = x.FirstOrDefault(y => y >= treeHeight);
                        return firstHigherTree == 0
                            ? x.Length
                            : Array.IndexOf(x, firstHigherTree) + 1;
                    })
                    .ToArray();
                var scenicScore = viewDistances.Aggregate((curr, prev) => curr * prev);
                result = result < scenicScore ? scenicScore : result;
            }
        }

        return result;
    }

    private static int[] GetColumn(int[,] grid, int columnNumber, int height)
    {
        return Enumerable.Range(0, height).Select(x => grid[x, columnNumber]).ToArray();
    }

    private static int[] GetRow(int[,] grid, int rowNumber, int width)
    {
        return Enumerable.Range(0, width).Select(x => grid[rowNumber, x]).ToArray();
    }
}
