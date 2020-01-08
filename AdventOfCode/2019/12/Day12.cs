using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using Combinatorics.Collections;

namespace AdventOfCode._2019._12
{
    public class Day12 : IAdventDay<int, int>
    {
        private readonly int _timesteps;
        private readonly JupiterSpace _jupiterSpace;

        public Day12(string input, int timesteps)
        {
            _timesteps = timesteps;
            _jupiterSpace = new JupiterSpace(ParseMoons(input).ToArray());
        }

        public int Part1()
        {
            for (int i = 0; i < _timesteps; i++)
            {
                _jupiterSpace.MoveTime();
            }

            return _jupiterSpace.TotalEnergy();
        }

        public int Part2()
        {
            throw new System.NotImplementedException();
        }

        private static IEnumerable<Moon> ParseMoons(string input)
        {
            var regex = new Regex(@"\<x=(?<x>(-)?\d+), y=(?<y>(-)?\d+), z=(?<z>(-)?\d+)\>");

            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                var x = int.Parse(match.Groups["x"].ToString());
                var y = int.Parse(match.Groups["y"].ToString());
                var z = int.Parse(match.Groups["z"].ToString());
                
                yield return new Moon(new Point3(x, y, z));
            }
        }
    }

    public class JupiterSpace
    {
        private readonly Moon[] _moons;
        private Combinations<Moon> _moonPairs;

        public JupiterSpace(Moon[] moons)
        {
            _moons = moons;
            _moonPairs = new Combinations<Moon>(moons, 2, GenerateOption.WithoutRepetition);
        }

        public void MoveTime()
        {
            foreach (var pair in _moonPairs)
            {
                var m1 = pair[0];
                var m2 = pair[1];

                ApplyGravity(m1, m2);
            }

            foreach (var moon in _moons)
            {
                moon.ApplyVelocity();
            }
        }

        private static void ApplyGravity(Moon m1, Moon m2)
        {
            var xChange = m1.Position.X.CompareTo(m2.Position.X);
            var yChange = m1.Position.Y.CompareTo(m2.Position.Y);
            var zChange = m1.Position.Z.CompareTo(m2.Position.Z);

            var x1 = (int) m1.Velocity.X;
            var y1 = (int) m1.Velocity.Y;
            var z1 = (int) m1.Velocity.Z;
            var x2 = (int) m1.Velocity.X;
            var y2 = (int) m1.Velocity.Y;
            var z2 = (int) m1.Velocity.Z;

            if (xChange != 0)
            {
                var change = xChange > 0 ? -1 : 1;
                x1 += change;
                x2 -= change;
            }

            if (yChange != 0)
            {
                var change = yChange > 0 ? -1 : 1;
                y1 += change;
                y2 -= change;
            }

            if (zChange != 0)
            {
                var change = zChange > 0 ? -1 : 1;
                z1 += change;
                z2 -= change;
            }

            m1.Velocity = new Vector3(x1, y1, z1);
            m2.Velocity = new Vector3(x2, y2, z2);
        }

        public int TotalEnergy()
        {
            return _moons.Sum(x => x.GetEnergy());
        }
    }

    public class Moon
    {
        public Point3 Position { get; set; }
        public Vector3 Velocity { get; set; }

        public Moon(Point3 position)
        {
            Position = position;
            Velocity = new Vector3(0, 0, 0);
        }

        public void ApplyVelocity()
        {
            Position = new Point3(Position.X + (int) Velocity.X, Position.Y + (int) Velocity.Y, Position.Z + (int) Velocity.Z);
        }

        public int GetEnergy()
        {
            var potentialEnergy = Math.Abs(Position.X) + Math.Abs(Position.Y) + Math.Abs(Position.Z);
            var kineticEnergy = (int) (Math.Abs(Velocity.X) + Math.Abs(Velocity.Y) + Math.Abs(Velocity.Z));

            return potentialEnergy * kineticEnergy;
        }
    }

    public struct Point3
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public Point3(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}