using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2020._11
{
    internal class SeatsMap : Dictionary<(int, int),char>
    {
        private readonly int _maxX;
        private readonly int _maxY;

        public SeatsMap(IDictionary<(int, int), char> seatsMap)
            :base(seatsMap)
        {
            _maxX = seatsMap.Max(it => it.Key.Item1);
            _maxY = seatsMap.Max(it => it.Key.Item2);
        }
        
        public IEnumerable<char> GetFirstVisibleSeats(int x, int y)
        {
            var seen = new bool[8];

            for (var distance = 1; seen.Any(it => !it); distance++)
            {
                if (x + distance > _maxX && x - distance < 0 && y + distance > _maxY &&
                    y - distance < 0)
                    break;
                
                var n8directions = new[]
                {
                    (x + distance, y),
                    (x - distance, y),
                    (x, y + distance),
                    (x, y - distance),
                    (x - distance, y + distance),
                    (x + distance, y - distance),
                    (x + distance, y + distance),
                    (x - distance, y - distance)
                };

                for (var i = 0; i < n8directions.Length; i++)
                {
                    if (seen[i] || !TryGetValue(n8directions[i], out var v))
                        continue;

                    seen[i] = true;
                    yield return v;
                }
            }
        }

        public IEnumerable<char> GetAdjacentSeats(int x, int y)
        {
            for (var dx = -1; dx <= 1; dx++)
            for (var dy = -1; dy <= 1; dy++)
            {
                if (dx == 0 && dy == 0) continue;
                if (TryGetValue((x + dx, y + dy), out var v))
                    yield return v;
            }
        }
    }
}