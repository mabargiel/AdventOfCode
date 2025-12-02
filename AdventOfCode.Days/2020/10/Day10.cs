using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2020._10;

public class Day10 : IAdventDay<int, long>
{
    private readonly IReadOnlyList<int> _adapters;

    public Day10(string input)
    {
        _adapters = input.Split(Environment.NewLine).Select(int.Parse).OrderBy(it => it).ToList();
    }

    public int Part1()
    {
        var differences = new Dictionary<int, int>
        {
            [1] = 0,
            [2] = 0,
            [3] = 1,
        };

        differences[_adapters[0]]++;

        for (var i = 1; i < _adapters.Count; i++)
        {
            differences[_adapters[i] - _adapters[i - 1]]++;
        }

        return differences[1] * differences[3];
    }

    public long Part2()
    {
        var result = 1L;

        var fullAdaptersList = new List<int>(_adapters);
        fullAdaptersList.Insert(0, 0);

        for (var i = 0; i < fullAdaptersList.Count - 1; i++)
        {
            var currentNumber = fullAdaptersList[i];
            var subsetCount = fullAdaptersList.Count(adapter =>
                adapter > currentNumber && adapter - currentNumber <= 3
            );

            if (subsetCount == 1)
            {
                continue;
            }

            result *=
                fullAdaptersList[i + subsetCount + 1] - currentNumber > 4
                    ? (int)Math.Pow(2, subsetCount - 1)
                    : (int)Math.Pow(2, subsetCount) - 1;

            i += subsetCount;
        }

        return result;
    }
}
