using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Days._2020._11
{
    public class Day11 : IAdventDay<int, int>
    {
        private readonly Dictionary<(int, int), char> _seatsMap;

        public Day11(string input)
        {
            var rows = input.Split(Environment.NewLine);
            var seatsMap = new Dictionary<(int, int), char>();

            for (var i = 0; i < rows.Length; i++)
            {
                var row = rows[i];
                for (var j = 0; j < row.Length; j++)
                {
                    if (row[j] == '.')
                        continue;

                    seatsMap[(i, j)] = row[j];
                }
            }

            _seatsMap = seatsMap;
        }

        public int Part1()
        {
            var curr = new Dictionary<(int, int), char>(_seatsMap);
            Dictionary<(int, int), char> prev;

            do
            {
                prev = new Dictionary<(int, int), char>(curr);
                Parallel.ForEach(prev.ToList(), item =>
                {
                    var ((x, y), value) = item;
                    var adjacentSeats = GetAdjacentSeats(prev, (x, y));

                    curr[(x, y)] = value switch
                    {
                        'L' when adjacentSeats.All(it => it != '#') => '#',
                        '#' when adjacentSeats.Count(it => it == '#') >= 4 => 'L',
                        _ => prev[(x, y)]
                    };
                });
            } while (curr.Any(it => prev[it.Key] != it.Value));

            return curr.Count(it => it.Value == '#');
        }

        public int Part2()
        {
            var curr = new Dictionary<(int, int), char>(_seatsMap);
            Dictionary<(int, int), char> prev;
            var maxX = curr.Max(it => it.Key.Item1);
            var maxY = curr.Max(it => it.Key.Item2);

            do
            {
                prev = new Dictionary<(int, int), char>(curr);
                Parallel.ForEach(prev.ToList(), item =>
                {
                    var ((x, y), value) = item;
                    var adjacentSeats = GetFirstVisibleSeats(prev, (x, y), maxX, maxY).ToList();

                    curr[(x, y)] = value switch
                    {
                        'L' when adjacentSeats.All(it => it != '#') => '#',
                        '#' when adjacentSeats.Count(it => it == '#') >= 5 => 'L',
                        _ => prev[(x, y)]
                    };
                });
            } while (curr.Any(it => prev[it.Key] != it.Value));

            return curr.Count(it => it.Value == '#');
        }

        private static IEnumerable<char> GetFirstVisibleSeats(IReadOnlyDictionary<(int, int), char> prev,
            (int, int) pos, int maxX, int maxY)
        {
            var (x, y) = pos;
            var seen = new bool[8];

            for (var distance = 1; seen.Any(it => !it); distance++)
            {
                if (x + distance > maxX && x - distance < 0 && y + distance > maxY &&
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
                    if (seen[i] || !prev.TryGetValue(n8directions[i], out var v))
                        continue;

                    seen[i] = true;
                    yield return v;
                }
            }
        }

        private static IEnumerable<char> GetAdjacentSeats(IReadOnlyDictionary<(int, int), char> prev, (int, int) pos)
        {
            var (x, y) = pos;

            for (var dx = -1; dx <= 1; dx++)
            for (var dy = -1; dy <= 1; dy++)
            {
                if (dx == 0 && dy == 0) continue;
                if (prev.TryGetValue((x + dx, y + dy), out var v))
                    yield return v;
            }
        }
    }
}