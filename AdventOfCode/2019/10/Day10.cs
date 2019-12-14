using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using Combinatorics.Collections;
using MoreLinq.Extensions;

namespace AdventOfCode._2019._10
{
    public class Day10 : IAdventDay<int, int>
    {
        private readonly Asteroid[] _asteroids;
        private readonly int _bet;

        public Day10(string asteroidsMap, int bet = 0)
        {
            _bet = bet;
            _asteroids = ParseAsteroidsMap(asteroidsMap).ToArray();
        }

        public int Part1()
        {
            var visibilityMap = CalculateVisibility(_asteroids);

            return visibilityMap.Values.Max();
        }

        public int Part2()
        {
            var station = CalculateVisibility(_asteroids).MaxBy(x => x.Value).First().Key;
            var asteroids = _asteroids.Except(new[] {station}).ToList();
            var originPoint = station.Point;
            var edgePoint = new Point(station.Point.X, 0);
            var edgePoints = new LinkedList<Point>(GenerateEdgePoints());
            var laseredCount = 0;

            Asteroid current = null;
            
            while (laseredCount < _bet)
            {
                var asteroidsOnLaser = asteroids.Where(a => IsBetween(originPoint,
                    edgePoint,
                    a.Point
                )).ToArray();

                    if (asteroidsOnLaser.Any())
                    {
                        var closest = asteroidsOnLaser.MinBy(asteroid =>
                                new Vector2(asteroid.Point.X - originPoint.X, asteroid.Point.Y - originPoint.Y)
                                    .Length())
                            .First();
                        asteroids.Remove(closest);
                        current = closest;
                        laseredCount++;
                    }

                    RotateLaser(edgePoints, ref edgePoint);
            }

            if (current == null)
                return -1;
            
            return 100 * current.Point.X + current.Point.Y;

            Point[] GenerateEdgePoints()
            {
                var cornerX = _asteroids.Select(x => x.Point.X).Max();
                var cornerY = _asteroids.Select(x => x.Point.Y).Max();

                var top = Enumerable.Range(0, cornerX).Select(x => new Point(x, 0));
                var right = Enumerable.Range(0, cornerY).Select(y => new Point(cornerX, y));
                var bottom = Enumerable.Range(cornerX, 0).Select(x => new Point(x, cornerY));
                var left = Enumerable.Range(cornerY, 0).Select(x => new Point(0, cornerY));
                var topSplit = top.Split(edgePoint).ToArray();

                return new[] {edgePoint}.Concat(topSplit[1]).Concat(right).Concat(bottom).Concat(left)
                    .Concat(topSplit[0].Reverse()).ToArray();
            }
        }

        private static void RotateLaser(LinkedList<Point> edgePoints, ref Point edgePoint)
        {
            var linkedListNode = edgePoints.Find(edgePoint);
            edgePoint = linkedListNode?.Next?.Value ?? edgePoints.First.Value;
        }

        private static Dictionary<Asteroid, int> CalculateVisibility(Asteroid[] asteroids)
        {
            var combinations = new Combinations<Asteroid>(asteroids.ToList(), 2, GenerateOption.WithoutRepetition);
            var visibilityMap = asteroids.ToDictionary(x => x, x => 0);
        
            foreach (var pair in combinations)
            {
                if (asteroids.Except(pair).Any(asteroid => IsBetween(pair[0].Point, pair[1].Point, asteroid.Point)))
                    continue;
        
                visibilityMap[pair[0]]++;
                visibilityMap[pair[1]]++;
            }
        
            return visibilityMap;
        }

        private static bool IsBetween(Point a, Point b, Point p)
        {
            var xy = new Vector2(b.X - a.X, b.Y - a.Y);
            var zy = new Vector2(b.X - p.X, b.Y - p.Y);

            return IsSameDirection(xy, zy);
        }

        private static bool IsSameDirection(Vector2 xy, Vector2 zy)
        {
            return zy.Length() < xy.Length() && Math.Abs(Vector2.Normalize(zy).X - Vector2.Normalize(xy).X) < 0.001 && Math.Abs(Vector2.Normalize(zy).Y - Vector2.Normalize(xy).Y) < 0.00001;
        }

        private static IEnumerable<Asteroid> ParseAsteroidsMap(string asteroidsMap)
        {
            var rows = asteroidsMap.Split(Environment.NewLine).Select(x => x.Trim()).ToArray();

            for (var i = 0; i < rows.Length; i++)
            {
                var points = rows[i].Select((c, index) => (c, Index: index)).Where(c => c.c == '#');
                foreach (var point in points)
                {
                    yield return new Asteroid(point.Index, i);
                }
            }
        }
    }

    public class Asteroid : IEquatable<Asteroid>
    {
        public Point Point { get; }

        public Asteroid(in int x, in int y)
        {
            Point = new Point(x, y);
        }

        public bool Equals(Asteroid other)
        {
            if (ReferenceEquals(null, other)) return false;
            return ReferenceEquals(this, other) || Point.Equals(other.Point);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Asteroid) obj);
        }

        public override int GetHashCode()
        {
            return Point.GetHashCode();
        }
    }
}