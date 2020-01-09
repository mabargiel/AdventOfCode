using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode._2019._12
{
    public class Moon : ICloneable, IEquatable<Moon>
    {
        public Moon(long x, long y, long z)
        {
            Position = new Dictionary<char, long> { { 'X', x }, { 'Y', y }, { 'Z', z } };
            Velocity = new Dictionary<char, long> { { 'X', 0 }, { 'Y', 0 }, { 'Z', 0 } };
        }

        public Dictionary<char, long> Position { get; }
        public Dictionary<char, long> Velocity { get; }

        public object Clone()
        {
            return new Moon(Position['X'], Position['Y'], Position['Z']);
        }

        public void ApplyVelocity(char[] dimensions)
        {
            foreach (var dimension in dimensions)
            {
                Position[dimension] += Velocity[dimension];
            }
        }

        public long GetEnergy()
        {
            var potentialEnergy = Position.Sum(pair => Math.Abs(pair.Value));
            var kineticEnergy = Velocity.Sum(pair => Math.Abs(pair.Value));

            return potentialEnergy * kineticEnergy;
        }

        public bool Equals(Moon other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Position.All(pair => other.Position[pair.Key] == pair.Value) && Velocity.All(pair => other.Velocity[pair.Key] == pair.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((Moon) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Position.Values, Velocity.Values);
        }
    }
}