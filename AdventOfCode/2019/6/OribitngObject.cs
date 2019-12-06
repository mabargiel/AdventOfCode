using System;

namespace AdventOfCode._2019._6
{
    public class OribitngObject : IEquatable<OribitngObject>
    {
        public string Name { get; }
        public OribitngObject OrbitsOn { get; }

        public OribitngObject(string name, OribitngObject orbitsOn)
        {
            Name = name;
            OrbitsOn = orbitsOn;
        }

        public bool Equals(OribitngObject other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Name == other.Name;
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

            return obj.GetType() == GetType() && Equals((OribitngObject) obj);
        }

        public override int GetHashCode()
        {
            return Name != null ? Name.GetHashCode() : 0;
        }
    }
}