using System;
using System.Drawing;

namespace AdventOfCode._2019._10
{
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