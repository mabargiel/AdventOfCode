using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode.Days._2019;

public class Day3 : AdventDay<(string[], string[]), int, int>
{
    private static readonly Point CentralPort = new(0, 0);

    public override (string[], string[]) ParseRawInput(string rawInput)
    {
        var wires = rawInput.Trim().Split(Environment.NewLine);
        return (wires[0].Split(",").ToArray(), wires[1].Split(","));
    }

    public override int Part1((string[], string[]) input)
    {
        var (wire1, wire2) = input;
        
        int ManhattanDistance(Point point)
        {
            return Math.Abs(point.X - CentralPort.X) + Math.Abs(point.Y - CentralPort.Y);
        }

        var wire1Segments = new Wire(wire1);
        var wire2Segments = new Wire(wire2);

        var intersectionPoints = wire1Segments.GetIntersects(wire2Segments);

        return intersectionPoints.Select(ManhattanDistance).Min();
    }

    public override int Part2((string[], string[]) input)
    {
        var (wire1, wire2) = input;
        var wire1Segments = new Wire(wire1);
        var wire2Segments = new Wire(wire2);

        var intersectionPoints = wire1Segments.GetIntersects(wire2Segments);

        var distances = from point in intersectionPoints
            let w1Dist = GetDistance(wire1Segments, point)
            let w2Dist = GetDistance(wire2Segments, point)
            select w1Dist + w2Dist;

        return (int)distances.Min();
    }

    private static double GetDistance(Wire wire, Point point)
    {
        double Distance(Point x, Point y)
        {
            return Math.Sqrt(Math.Pow(x.X - y.X, 2) + Math.Pow(x.Y - y.Y, 2));
        }

        bool IsBetween(Point a, Point b, Point cBetween)
        {
            return Math.Abs(Distance(a, cBetween) + Distance(cBetween, b) - Distance(a, b)) < 0.1;
        }

        double distance = 0;
        foreach (var segment in wire.Segments)
        {
            if (!IsBetween(segment.Start, segment.End, point))
            {
                distance += Distance(segment.Start, segment.End);
            }
            else
            {
                distance += Distance(segment.Start, point);
                break;
            }
        }

        return distance;
    }

    private class Wire
    {
        public Wire(IEnumerable<string> wire)
        {
            var segmentsList = new List<Segment>();

            var pointA = CentralPort;
            foreach (var wirePoint in wire)
            {
                var bX = pointA.X;
                var bY = pointA.Y;

                var (direction, distance) = (Enum.Parse<Direction>(wirePoint[0].ToString()),
                    int.Parse(wirePoint.Substring(1, wirePoint.Length - 1)));

                switch (direction)
                {
                    case Direction.U:
                        bY += distance;
                        break;
                    case Direction.D:
                        bY -= distance;
                        break;
                    case Direction.R:
                        bX += distance;
                        break;
                    case Direction.L:
                        bX -= distance;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                var pointB = new Point(bX, bY);
                segmentsList.Add(new Segment(pointA, pointB));
                pointA.X = pointB.X;
                pointA.Y = pointB.Y;
            }

            Segments = segmentsList.ToArray();
        }

        public Segment[] Segments { get; }

        public IEnumerable<Point> GetIntersects(Wire wire)
        {
            var intersectingSegments = Segments.SelectMany(x => wire.Segments.Select(y => y.GetIntersection(x)))
                .Where(x => x != null).Cast<Point>();
            return intersectingSegments;
        }

        private enum Direction
        {
            U,
            D,
            R,
            L
        }
    }
    
    private class Segment
    {
        public Segment(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public Point Start { get; }
        public Point End { get; }

        public Point? GetIntersection(Segment segment)
        {
            if (Equals(segment) || Start.Equals(segment.End) || End.Equals(segment.Start) ||
                Start.Equals(segment.Start) || End.Equals(segment.End))
            {
                return null;
            }

            return Intersects(this, segment);
        }

        public override string ToString()
        {
            return $"{Start.ToString()} -> {End.ToString()}";
        }

        private static Point? Intersects(Segment ab, Segment cd)
        {
            var dx1 = ab.End.X - ab.Start.X;
            var dx2 = cd.End.X - cd.Start.X;
            var dy1 = ab.End.Y - ab.Start.Y;
            var dy2 = cd.End.Y - cd.Start.Y;
            var denom = dy2 * dx1 - dx2 * dy1;

            if (denom == 0)
            {
                return null;
            }

            var ua = (dx2 * (ab.Start.Y - cd.Start.Y) - dy2 * (ab.Start.X - cd.Start.X)) / (double)denom;
            var ub = (dx1 * (ab.Start.Y - cd.Start.Y) - dy1 * (ab.Start.X - cd.Start.X)) / (double)denom;

            if (ua < 0 || ua > 1 || ub < 0 || ub > 1)
            {
                return null;
            }

            var ix = ab.Start.X + ua * (ab.End.X - ab.Start.X);
            var iy = ab.Start.Y + ua * (ab.End.Y - ab.Start.Y);

            return new Point((int)Math.Round(ix), (int)Math.Round(iy));
        }
    }
}