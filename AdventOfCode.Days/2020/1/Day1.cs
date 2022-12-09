using System;
using System.Collections.Generic;
using System.Linq;
using Combinatorics.Collections;

namespace AdventOfCode.Days._2020._1;

public class Day1 : IAdventDay<int, int>
{
    private readonly IEnumerable<int> _input;

    public Day1(IEnumerable<int> input)
    {
        _input = input;
    }

    public int Part1()
    {
        return MultipleMatchingValues(2);
    }

    public int Part2()
    {
        return MultipleMatchingValues(3);
    }

    private int MultipleMatchingValues(int valuesCount)
    {
        if (valuesCount < 1)
        {
            throw new ArgumentException("Value cannot be less than 1", nameof(valuesCount));
        }

        var topMinimums = (from number in _input
            orderby number
            select number).Distinct().Take(valuesCount - 1);

        var max = 2020 - topMinimums.Sum();
        var possibleValues = _input.Where(v => v <= max).ToList();

        var siblings = new Combinations<int>(possibleValues, valuesCount);

        return siblings.First(x => x.Sum() == 2020).Aggregate(1, (a, b) => a * b);
        ;
    }
}