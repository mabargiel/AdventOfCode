using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode._2019._3
{
    public class Day3 : IAdventDay<int, int>
    {
        private static readonly Point CentralPort = new Point(0, 0);
        private readonly string[] _wire1;
        private readonly string[] _wire2;

        public Day3(string[] wire1, string[] wire2)
        {
            _wire1 = wire1;
            _wire2 = wire2;
        }

        public int Part1()
        {
            var wire1Segments = new WireSegments(_wire1);
            var wire2Segments = new WireSegments(_wire2);

            var intersectionPoints = wire1Segments.GetIntersects(wire2Segments);

            return intersectionPoints.Select(ManhattanDistance).Min();
        }

        public int Part2()
        {
            var wire1Segments = new WireSegments(_wire1);
            var wire2Segments = new WireSegments(_wire2);

            var intersectionPoints = wire1Segments.GetIntersects(wire2Segments);

            var distances = from point in intersectionPoints
                let w1Dist = GetDistance(wire1Segments, point)
                let w2Dist = GetDistance(wire2Segments, point)
                select w1Dist + w2Dist;

            return (int) distances.Min();
        }

        private static int ManhattanDistance(Point point)
        {
            return Math.Abs(point.X - CentralPort.X) + Math.Abs(point.Y - CentralPort.Y);
        }

        private static double GetDistance(WireSegments wireSegments, Point point)
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
            foreach (var segment in wireSegments.Segments)
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

        private class WireSegments
        {
            public WireSegments(IEnumerable<string> wire)
            {
                var segmentsList = new List<Segment>();

                var pointA = CentralPort;
                foreach (var wirePoint in wire)
                {
                    var bX = pointA.X;
                    var bY = pointA.Y;

                    var (direction, distance) = (Enum.Parse<Direction>(wirePoint[0].ToString()), int.Parse(wirePoint.Substring(1, wirePoint.Length - 1)));

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

            public IEnumerable<Point> GetIntersects(WireSegments wireSegments)
            {
                var intersectingSegments = Segments.SelectMany(x => wireSegments.Segments.Select(y => y.GetIntersection(x))).Where(x => x != null).Cast<Point>();
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
    }
}