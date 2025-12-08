using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Days.Common;

namespace AdventOfCode.Days._2025;

public class Day8 : AdventDay<Point3[], int, int>
{
    public override Point3[] ParseRawInput(string rawInput)
    {
        return rawInput
            .Trim()
            .Split(Environment.NewLine)
            .Select(x =>
            {
                var pointRaw = x.Split(",");
                return new Point3(
                    int.Parse(pointRaw[0]),
                    int.Parse(pointRaw[1]),
                    int.Parse(pointRaw[2])
                );
            })
            .ToArray();
    }

    public override int Part1(Point3[] input)
    {
        var pairsOrdered = GetAllDistances(input)
            .OrderBy(x => x.Value)
            .Take(input.Length == 20 ? 10 : 1000);

        var circuits = new List<HashSet<Point3>>();
        foreach (var (pair, _) in pairsOrdered)
        {
            var p1 = pair.P1;
            var p2 = pair.P2;

            var relatedCircuits = circuits.Where(c => c.Contains(p1) || c.Contains(p2)).ToList();

            if (relatedCircuits.Count == 0)
            {
                circuits.Add([p1, p2]);
            }
            else
            {
                var merged = new HashSet<Point3> { p1, p2 };

                foreach (var c in relatedCircuits)
                {
                    merged.UnionWith(c);
                    circuits.Remove(c);
                }

                circuits.Add(merged);
            }
        }
        return circuits
            .Select(x => x.Count)
            .OrderDescending()
            .Take(3)
            .Aggregate(1, (prev, curr) => prev * curr);
    }

    public override int Part2(Point3[] input)
    {
        var pairsOrdered = GetAllDistances(input).OrderBy(x => x.Value);

        var circuits = new List<HashSet<Point3>>();
        foreach (var (pair, distance) in pairsOrdered)
        {
            var p1 = pair.P1;
            var p2 = pair.P2;

            var relatedCircuits = circuits.Where(c => c.Contains(p1) || c.Contains(p2)).ToList();

            if (relatedCircuits.Count == 0)
            {
                circuits.Add([p1, p2]);
            }
            else
            {
                var merged = new HashSet<Point3> { p1, p2 };

                foreach (var c in relatedCircuits)
                {
                    merged.UnionWith(c);
                    circuits.Remove(c);
                }

                circuits.Add(merged);
            }

            if (circuits.Count == 1 && circuits[0].Count == input.Length)
            {
                return p1.X * p2.X;
            }
        }

        return -1;
    }

    private static Dictionary<PointPair, double> GetAllDistances(Point3[] input)
    {
        var distances = new Dictionary<PointPair, double>();
        for (var i = 0; i < input.Length; i++)
        {
            for (var j = i + 1; j < input.Length; j++)
            {
                var p1 = input[i];
                var p2 = input[j];

                if (p1 == p2)
                {
                    continue;
                }

                var distance = Distance3D(p1, p2);
                distances.Add(new PointPair(p1, p2), distance);
            }
        }

        return distances;
    }

    private static double Distance3D(Point3 Point1, Point3 Point2)
    {
        long dx = Point2.X - Point1.X;
        long dy = Point2.Y - Point1.Y;
        long dz = Point2.Z - Point1.Z;

        return Math.Sqrt(dx * dx + dy * dy + dz * dz);
    }

    private class PointPair(Point3 p1, Point3 p2)
    {
        public Point3 P1 { get; } = p1;
        public Point3 P2 { get; } = p2;

        public override bool Equals(object obj)
        {
            if (obj is not PointPair pointPair)
            {
                return false;
            }

            return pointPair.P1 == P1 && pointPair.P2 == P2
                || pointPair.P1 == P2 && pointPair.P2 == P1;
        }
    }
}
