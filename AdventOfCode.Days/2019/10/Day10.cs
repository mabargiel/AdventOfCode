using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using Combinatorics.Collections;

namespace AdventOfCode.Days._2019._10;

public class Day10 : IAdventDay<int, IEnumerable<Point>>
{
    private readonly Asteroid[] _asteroids;

    public Day10(string asteroidsMap)
    {
        _asteroids = ParseAsteroidsMap(asteroidsMap).ToArray();

        static IEnumerable<Asteroid> ParseAsteroidsMap(string asteroidsMap)
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

    public int Part1()
    {
        var visibilityMap = CalculateVisibility(_asteroids);

        return visibilityMap.Values.Max();
    }

    public IEnumerable<Point> Part2()
    {
        var station = CalculateVisibility(_asteroids).MaxBy(pair => pair.Value).Key;
        var asteroids = _asteroids.Except(new[] { station }).ToList();

        var possibleLaserVectors = new LinkedList<Vector2>(asteroids
            .Select(asteroid => new Vector2(asteroid.Point.X - station.Point.X, asteroid.Point.Y - station.Point.Y))
            .DistinctBy(Vector2.Normalize).OrderBy(Angle)
            .ToList());

        var vaporizedAsteroids = new Queue<Asteroid>();

        var currentLaser = possibleLaserVectors.First;

        while (true)
        {
            if (!asteroids.Any())
            {
                break;
            }

            var laser = currentLaser.Value;
            var toBeVaporized = asteroids.FirstOrDefault(asteroid =>
            {
                var asteroidLineOfView = new Vector2(asteroid.Point.X - station.Point.X,
                    asteroid.Point.Y - station.Point.Y);
                return IsOnLaserLine(laser, asteroidLineOfView) && asteroids.Except(new[] { station, asteroid })
                    .All(asteroid1 => !IsBetween(station.Point, asteroid.Point, asteroid1.Point));
            });

            if (toBeVaporized != null && !vaporizedAsteroids.Contains(toBeVaporized))
            {
                vaporizedAsteroids.Enqueue(toBeVaporized);
                yield return toBeVaporized.Point;
            }

            if (currentLaser.Next == null)
            {
                while (vaporizedAsteroids.Any())
                {
                    asteroids.Remove(vaporizedAsteroids.Dequeue());
                }
            }

            currentLaser = currentLaser.Next ?? possibleLaserVectors.First;
        }

        static double Angle(Vector2 v)
        {
            var u = new Vector2(0, -1);
            var vNorm = Vector2.Normalize(v);
            var relativeRadians = (float)Math.Atan2(vNorm.Y, vNorm.X) - (float)Math.Atan2(u.Y, u.X);
            return relativeRadians >= 0 ? relativeRadians : 2 * (float)Math.PI + relativeRadians;
        }

        static bool IsOnLaserLine(Vector2 laser, Vector2 v)
        {
            return Vector2.Normalize(v) == Vector2.Normalize(laser);
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
}