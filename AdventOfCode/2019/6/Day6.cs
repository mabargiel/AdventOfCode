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

            var vertexes = new OrderedBag<Vertex>();
            foreach (var oribitngObject in _map.Where(x => x.Name != "YOU" && x.Name != "SAN"))
            {
                vertexes.Add(new Vertex(oribitngObject, oribitngObject.Equals(meObjectOrbit) ? 0 : int.MaxValue));
            }

            while (vertexes.Any())
            {
                var u = vertexes.RemoveFirst();
                var neighbours = vertexes.Where(x =>
                    (x.OribitngObject.OrbitsOn.Equals(u.OribitngObject) || x.OribitngObject.Equals(u.OribitngObject.OrbitsOn)) && u.Cost + 1 < x.Cost).ToList();
                
                if (u.OribitngObject.Equals(santaOrbitObject))
                    return u.Cost;
                
                foreach (var neighbour in neighbours.Where(neighbour => u.Cost + 1 < neighbour.Cost))
                {
                    neighbour.Cost = u.Cost + 1;
                }
                
                vertexes = new OrderedBag<Vertex>(vertexes);
            }

            return -1;
        }
    }
}