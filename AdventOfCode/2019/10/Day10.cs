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
            var asteroids = _asteroids.Except(new[] { station }).ToList();

            var possibleLaserVectors = new LinkedList<Vector2>(asteroids.Select(asteroid => Vector2.Normalize(new Vector2(asteroid.Point.X - station.Point.X, asteroid.Point.Y - station.Point.Y)))
                .OrderBy(Angle).ToList()); //TODO Vectors must be distinct

            var currentLaser = possibleLaserVectors.First;
            
            while (true)
            {
                var currentAsteroid = currentLaser.Value;
                var wasVaporized = asteroids.Where(asteroid => //TODO CROSS = 0).MnBy;
                //TODO Calculate cross, if 0 then point in line, then get the closest one and vaporize

                if (wasVaporized)
                {
                    possibleLaserVectors.Remove(currentAsteroid);

                    if (_asteroids.Length - possibleLaserVectors.Count == _bet + 1)
                    {
                        return 100 * currentAsteroid.Point.X + currentAsteroid.Point.Y;
                    }
                }

                currentLaser = currentLaser.Next ?? possibleLaserVectors.First;
            }

            static double Angle(Vector2 v)
            {
                var u = new Vector2(0, -1);
                var relativeRadians = Math.Atan2(v.Y, v.X) - Math.Atan2(u.Y, u.X);
                return relativeRadians >= 0 ? relativeRadians : 2 * Math.PI + relativeRadians;
            }
        }

        private static Dictionary<Asteroid, int> CalculateVisibility(Asteroid[] asteroids)
        {
            var combinations = new Combinations<Asteroid>(asteroids.ToList(), 2, GenerateOption.WithoutRepetition);
            var visibilityMap = asteroids.ToDictionary(x => x, x => 0);

            foreach (var pair in combinations)
            {
                if (asteroids.Except(pair).Any(asteroid => IsBetween(pair[0].Point, pair[1].Point, asteroid.Point)))
                {
                    continue;
                }

                visibilityMap[pair[0]]++;
                visibilityMap[pair[1]]++;
            }

            return visibilityMap;
        }

        private static bool IsBetween(Point a, Point b, Point p)
        {
            var xy = new Vector2(b.X - a.X, b.Y - a.Y);
            var zy = new Vector2(b.X - p.X, b.Y - p.Y);

            return zy.Length() < xy.Length() && Math.Abs(Vector2.Normalize(zy).X - Vector2.Normalize(xy).X) < 0.001 &&
                   Math.Abs(Vector2.Normalize(zy).Y - Vector2.Normalize(xy).Y) < 0.001;
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
}