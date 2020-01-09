using System.Collections.Generic;
using System.Linq;
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

        public void MoveTime(char[] dimensions = null)
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
            var timeDimensions = new Dictionary<char, long> { { 'X', 0 }, { 'Y', 0 }, { 'Z', 0 } };

            //for each dimension separately
            foreach (var dimension in timeDimensions.Keys.ToArray())
            {
                do
                {
                    MoveTime(new[] { dimension });
                    timeDimensions[dimension]++;
                } while (NotAtStart());
            }

            return LeastCommonMultiple(timeDimensions.Values);

            bool NotAtStart()
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

        private static long LeastCommonMultiple(IEnumerable<long> dimensions)
        {
            return dimensions.Aggregate(LeastCommonMultiple);
        }

        private static long LeastCommonMultiple(long a, long b)
        {
            if (b == 0)
            {
                return 0;
            }

            return a * b / GreatestCommonDivisor(a, b);
        }

        private static long GreatestCommonDivisor(long a, long b)
        {
            return b == 0 ? a : GreatestCommonDivisor(b, a % b);
        }

        private static void ApplyGravity(Moon m1, Moon m2, char[] dimensions)
        {
            foreach (var dimension in dimensions)
            {
                var change = m1.Position[dimension].CompareTo(m2.Position[dimension]);
                m1.Velocity[dimension] -= change;
                m2.Velocity[dimension] += change;
            }
        }

        public long TotalEnergy()
        {
            return _moons.Sum(x => x.GetEnergy());
        }
    }
}