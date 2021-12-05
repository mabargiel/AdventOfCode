using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace AdventOfCode.Days._2021
{
    public class Day5 : AdventDay<ImmutableArray<Line>, int, int>
    {
        public override ImmutableArray<Line> ParseRawInput(string rawInput)
        {
            return rawInput.Trim().Split(Environment.NewLine).Select(x =>
            {
                var points = x.Split("->");
                var pointA = points[0].Trim().Split(',').Select(int.Parse).ToArray();
                var pointB = points[1].Trim().Split(',').Select(int.Parse).ToArray();

                return new Line(new Point(pointA[0], pointA[1]), new Point(pointB[0], pointB[1]));
            }).ToImmutableArray();
        }

        public override int Part1(ImmutableArray<Line> input)
        {
            var horizontalOrVertical = input.Where(l => l.A.X == l.B.X || l.A.Y == l.B.Y);
            return CountIntersects(horizontalOrVertical);
        }

        public override int Part2(ImmutableArray<Line> input)
        {
            return CountIntersects(input);
        }

        private static int CountIntersects(IEnumerable<Line>? horizontalOrVertical)
        {
            Dictionary<Point, int> lineMap = new();

            foreach (var line in horizontalOrVertical)
            {
                var points = line.GetPoints();

                foreach (var point in points)
                {
                    if (!lineMap.ContainsKey(point))
                    {
                        lineMap[point] = 1;
                        continue;
                    }

                    lineMap[point]++;
                }
            }

            return lineMap.Values.Count(x => x > 1);
        }
    }

    public record Line(Point A, Point B)
    {
        public IEnumerable<Point> GetPoints()
        {
            var n = GCD(Math.Abs(B.X - A.X), Math.Abs(B.Y - A.Y));
            var dx = (B.X - A.X) / n;
            var dy = (B.Y - A.Y) / n;

            for (var i = 0; i < n + 1; i++)
            {
                yield return new Point(A.X + dx * i, A.Y + dy * i);
            }
        }

        private static int GCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }

            return a | b;
        }
    }

    public record Point(int X, int Y);
}