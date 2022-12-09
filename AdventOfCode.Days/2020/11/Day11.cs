using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Days._2020._11;

public class Day11 : IAdventDay<int, int>
{
    private readonly SeatsMap _seatsMap;

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
                {
                    continue;
                }

                seatsMap[(i, j)] = row[j];
            }
        }

        _seatsMap = new SeatsMap(seatsMap);
    }

    public int Part1()
    {
        var curr = new Dictionary<(int, int), char>(_seatsMap);
        SeatsMap prev;

        do
        {
            prev = new SeatsMap(curr);
            Parallel.ForEach(prev.ToList(), item =>
            {
                var ((x, y), value) = item;
                var adjacentSeats = prev.GetAdjacentSeats(x, y);

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
        SeatsMap prev;

        do
        {
            prev = new SeatsMap(curr);
            Parallel.ForEach(prev.ToList(), item =>
            {
                var ((x, y), value) = item;
                var adjacentSeats = prev.GetFirstVisibleSeats(x, y).ToList();

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
}