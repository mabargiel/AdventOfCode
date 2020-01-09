using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Combinatorics.Collections;

namespace AdventOfCode._2019._12
{
    public class JupiterSpace
    {
        private readonly Combinations<Moon> _moonPairs;

        public JupiterSpace(Moon[] moons)
        {
            _moons = moons;
            _moonPairs = new Combinations<Moon>(moons, 2, GenerateOption.WithoutRepetition);
        }

        private readonly Moon[] _moons;

        public void MoveTime(string[] dimensions = null)
        {
            foreach (var pair in _moonPairs)
            {
                var m1 = pair[0];
                var m2 = pair[1];

                ApplyGravity(m1, m2, dimensions);
            }

            foreach (var moon in _moons)
            {
                moon.ApplyVelocity(dimensions);
            }
        }

        public long MoveTimeUntilRepeat()
        {
            var initialMoons = _moons.Select(x => x.Clone()).ToArray();
            var timeDimensions = new long[] { 0, 0, 0 };

            foreach (var dimension in new[] { "X", "Y", "Z" })
            {
                do
                {
                    MoveTime(new[] { dimension });
                    switch (dimension)
                    {
                        case "X":
                            timeDimensions[0]++;
                            break;
                        case "Y":
                            timeDimensions[1]++;
                            break;
                        case "Z":
                            timeDimensions[2]++;
                            break;
                    }
                } while (NotSame());
            }

            return Lcm(timeDimensions);

            bool NotSame()
            {
                for (var i = initialMoons.Length - 1; i >= 0; i--)
                {
                    if (!initialMoons[i].Equals(_moons[i]))
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        private static long Lcm(IEnumerable<long> dimensions)
        {
            return dimensions.Aggregate(Lcm);
        }

        private static long Lcm(long a, long b)
        {
            if (b == 0)
            {
                return 0;
            }

            return a * b / Gcd(a, b);
        }

        private static long Gcd(long a, long b)
        {
            return b == 0 ? a : Gcd(b, a % b);
        }

        private static void ApplyGravity(Moon m1, Moon m2, string[] dimensions)
        {
            var xChange = m1.Position.X.CompareTo(m2.Position.X);
            var yChange = m1.Position.Y.CompareTo(m2.Position.Y);
            var zChange = m1.Position.Z.CompareTo(m2.Position.Z);

            var x1 = (int) m1.Velocity.X;
            var y1 = (int) m1.Velocity.Y;
            var z1 = (int) m1.Velocity.Z;
            var x2 = (int) m2.Velocity.X;
            var y2 = (int) m2.Velocity.Y;
            var z2 = (int) m2.Velocity.Z;

            if (xChange != 0 && dimensions.Contains("X"))
            {
                var change = xChange > 0 ? -1 : 1;
                x1 += change;
                x2 -= change;
            }

            if (yChange != 0 && dimensions.Contains("Y"))
            {
                var change = yChange > 0 ? -1 : 1;
                y1 += change;
                y2 -= change;
            }

            if (zChange != 0 && dimensions.Contains("Z"))
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
}