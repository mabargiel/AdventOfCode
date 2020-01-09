using System;
using System.Linq;
using System.Numerics;

namespace AdventOfCode._2019._12
{
    public class Moon : ICloneable, IEquatable<Moon>
    {
        public Moon(Point3 position)
        {
            Position = position;
            Velocity = new Vector3(0, 0, 0);
        }

        public Point3 Position { get; set; }
        public Vector3 Velocity { get; set; }

        public object Clone()
        {
            return new Moon((Point3) Position.Clone());
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

            return Position.Equals(other.Position) && Velocity.Equals(other.Velocity);
        }

        public void ApplyVelocity(string[] dimensions)
        {
            var positionX = dimensions.Contains("X") ? Position.X + (int) Velocity.X : Position.X;
            var positionY = dimensions.Contains("Y") ? Position.Y + (int) Velocity.Y : Position.Y;
            var positionZ = dimensions.Contains("Z") ? Position.Z + (int) Velocity.Z : Position.Z;

            Position = new Point3(positionX, positionY, positionZ);
        }

        public int GetEnergy()
        {
            var potentialEnergy = Math.Abs(Position.X) + Math.Abs(Position.Y) + Math.Abs(Position.Z);
            var kineticEnergy = (int) (Math.Abs(Velocity.X) + Math.Abs(Velocity.Y) + Math.Abs(Velocity.Z));

            return potentialEnergy * kineticEnergy;
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
            return HashCode.Combine(Position, Velocity);
        }
    }
}