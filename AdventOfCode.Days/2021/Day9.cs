using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2021;

public class Day9 : AdventDay<int[,], int, int>
{
    public override int[,] ParseRawInput(string rawInput)
    {
        var rows = rawInput.Trim().Split(Environment.NewLine);
        var width = rows[0].Length;
        var result = new int[rows.Length, width];
        for (var y = 0; y < rows.Length; y++)
        {
            for (var x = 0; x < width; x++)
            {
                result[y, x] = (int)char.GetNumericValue(rows[y][x]);
            }
        }

        return result;
    }

    public override int Part1(int[,] input)
    {
        var result = 0;

        foreach (var (x, y) in GetAllLowPointsPos(input))
        {
            result += input[y, x] + 1;
        }

        return result;
    }

    public override int Part2(int[,] input)
    {
        var rows = input.GetLength(0);
        var cols = input.GetLength(1);
        var basins = new List<int>();

        foreach (var (x, y) in GetAllLowPointsPos(input))
        {
            var points = new HashSet<(int, int)>();
            GetFlowingPoints(input, rows, cols, x, y, points);
            basins.Add(points.Count);
        }

        return basins.OrderByDescending(x => x).Take(3).Aggregate(1, (curr, prev) => curr * prev);
    }

    private void GetFlowingPoints(int[,] input, int rows, int cols, int x, int y, HashSet<(int, int)> points)
    {
        var current = input[y, x];

        if (current == 9)
        {
            return;
        }

        points.Add((y, x));

        var neighbours = new List<(int, int)>();

        if (y + 1 < rows && input[y + 1, x] > current)
        {
            neighbours.Add((y + 1, x));
        }

        //check top
        if (y - 1 >= 0 && input[y - 1, x] > current)
        {
            neighbours.Add((y - 1, x));
        }

        //check right
        if (x + 1 < cols && input[y, x + 1] > current)
        {
            neighbours.Add((y, x + 1));
        }

        //check left
        if (x - 1 >= 0 && input[y, x - 1] > current)
        {
            neighbours.Add((y, x - 1));
        }

        foreach (var neighbour in neighbours)
        {
            GetFlowingPoints(input, rows, cols, neighbour.Item2, neighbour.Item1, points);
        }
    }

    private static IEnumerable<(int X, int Y)> GetAllLowPointsPos(int[,] input)
    {
        var rows = input.GetLength(0);
        var cols = input.GetLength(1);
        for (var y = 0; y < rows; y++)
        {
            for (var x = 0; x < cols; x++)
            {
                var current = input[y, x];
                //check bottom
                if (IsLowPoint(input, x, y, rows, cols, current))
                {
                    yield return (x, y);
                }
            }
        }
    }

    private static bool IsLowPoint(int[,] input, int x, int y, int rows, int cols, int current)
    {
        if (current == 9)
        {
            return false;
        }

        return !((y + 1 < rows && input[y + 1, x] <= current) || (y - 1 >= 0 && input[y - 1, x] <= current) ||
                 (x + 1 < cols && input[y, x + 1] <= current) || (x - 1 >= 0 && input[y, x - 1] <= current));
    }
}