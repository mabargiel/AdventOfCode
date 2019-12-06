using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace AdventOfCode._2019._6
{
    public class Day6 : IAdventDay<int, int>
    {
        private readonly OribitngObject[] _map;

        public Day6(string[] mapRepresentation)
        {
            _map = BuildMapTree(mapRepresentation);
        }

        private static OribitngObject[] BuildMapTree(string[] mapRepresentation)
        {
            var map = new HashSet<OribitngObject>();
            foreach (var representation in mapRepresentation)
            {
                var split = representation.Split(')');
                var right = split[1];

                var newObject = map.FirstOrDefault(x => x.Name == right) ?? CreateObject(map, mapRepresentation, representation);
                map.Add(newObject);
            }

            return map.ToArray();
        }

        private static OribitngObject CreateObject(HashSet<OribitngObject> map, string[] mapRepresentation, string representation)
        {
            if (representation == null)
                return new OribitngObject("COM", null);

            var split = representation.Split(')');
            var (left, right) = (split[0], split[1]);
            var directOribitingObject = mapRepresentation.FirstOrDefault(x => x.Substring(x.LastIndexOf(')') + 1) == left && x != representation);

            var newObject = map.FirstOrDefault(x => x.Name == right);

            if (newObject == null)
            {
                newObject = new OribitngObject(right, CreateObject(map, mapRepresentation, directOribitingObject));
                map.Add(newObject);
            }

            return newObject;
        }

        public int Part1()
        {
            var count = 0;
            foreach (var oribitngObject in _map)
            {
                var directObject = oribitngObject.OrbitsOn;

                do
                {
                    count++;
                    directObject = directObject.OrbitsOn;
                } while (directObject != null);
            }

            return count;
        }

        public int Part2()
        {
            var meObjectOrbit = _map.First(x => x.Name == "YOU").OrbitsOn;
            var santaOrbitObject = _map.First(x => x.Name == "SAN").OrbitsOn;

            var vertexes = new SortedList<OribitngObject>();
            foreach (var oribitngObject in _map.Where(x => x.Name != "YOU" && x.Name != "SAN"))
            {
                vertexes.Add(oribitngObject.Equals(meObjectOrbit) ? 0 : int.MaxValue, oribitngObject);
            }

            while (vertexes.Any())
            {
                var u = vertexes.First();
                vertexes.Remove(0);
                
                var neighbours = vertexes.Where(x => x.Value.OrbitsOn.Equals(u.Value) || x.Value.Equals(u.Value.OrbitsOn)).ToList();
                
                if (u.Value.Name == "I")
                    return u.Key;
                
                foreach (var neighbour in neighbours)
                {
                    if (u.Key + 1 < neighbour.Key)
                    {
                        vertexes.Remove(neighbour);
                        neighbour.Key = u.Key + 1;
                        vertexes.Add(neighbour);
                    }
                }
            }

            return -1;
        }
    }

    public class Vertex : IComparable<Vertex>
    {
        public OribitngObject OribitngObject { get; }
        public int Cost { get; set; }

        public Vertex(OribitngObject oribitngObject, int cost)
        {
            OribitngObject = oribitngObject;
            Cost = cost;
        }

        public int CompareTo(Vertex other)
        {
            return Cost.CompareTo(other.Cost);
        }
    }

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