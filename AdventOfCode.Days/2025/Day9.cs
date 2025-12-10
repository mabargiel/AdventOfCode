using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Days.Common;

namespace AdventOfCode.Days._2025;

public class Day9 : AdventDay<Point[], long, long>
{
    public override Point[] ParseRawInput(string rawInput)
    {
        return rawInput
            .Trim()
            .Split(Environment.NewLine)
            .Select(x =>
            {
                var split = x.Split(',');
                return new Point(int.Parse(split[0]), int.Parse(split[1]));
            })
            .ToArray();
    }

    public override long Part1(Point[] input)
    {
        long biggestArea = 0;
        for (var i = 0; i < input.Length; i++)
        {
            for (var j = i + 1; j < input.Length; j++)
            {
                var squareArea =
                    (Math.Abs(input[i].X - input[j].X) + 1)
                    * (long)(Math.Abs(input[i].Y - input[j].Y) + 1);

                if (squareArea > biggestArea)
                {
                    biggestArea = squareArea;
                }
            }
        }

        return biggestArea;
    }

    /// <summary>
    /// This took me too much time to figure out, but the only thing we need to check is if there are any walls inside the rectangle.
    /// If there is at least one wall inside the rectangle -> it's not part of the polygon
    /// </summary>
    public override long Part2(Point[] input)
    {
        long biggestArea = 0;
        var vWalls = new List<(int x, int y1, int y2)>();
        var hWalls = new List<(int y, int x1, int x2)>();

        BuildWalls(input, vWalls, hWalls);

        for (var i = 0; i < input.Length; i++)
        {
            for (var j = i + 1; j < input.Length; j++)
            {
                //rectangle
                var x1 = Math.Min(input[i].X, input[j].X);
                var x2 = Math.Max(input[i].X, input[j].X);
                var y1 = Math.Min(input[i].Y, input[j].Y);
                var y2 = Math.Max(input[i].Y, input[j].Y);

                if (x1 == x2 || y1 == y2) // "height == 1" rectangle
                    continue;

                if (vWalls.Any(e => e.x > x1 && e.x < x2 && e.y1 < y2 && e.y2 > y1)) //any vertical wall inside rectangle
                    continue;

                if (hWalls.Any(e => e.y > y1 && e.y < y2 && e.x1 < x2 && e.x2 > x1)) //any horizontal wall inside rectangle
                    continue;

                var area = (x2 - x1 + 1) * (long)(y2 - y1 + 1);
                if (area > biggestArea)
                    biggestArea = area;
            }
        }

        return biggestArea;
    }

    private static void BuildWalls(
        Point[] input,
        List<(int x, int y1, int y2)> vertical,
        List<(int y, int x1, int x2)> horizontal
    )
    {
        for (var i = 0; i < input.Length; i++)
        {
            var a = input[i];
            var b = input[(i + 1) % input.Length];

            if (a.X == b.X)
            {
                var y1 = Math.Min(a.Y, b.Y);
                var y2 = Math.Max(a.Y, b.Y);
                vertical.Add((a.X, y1, y2));
            }
            else
            {
                var x1 = Math.Min(a.X, b.X);
                var x2 = Math.Max(a.X, b.X);
                horizontal.Add((a.Y, x1, x2));
            }
        }
    }
}
