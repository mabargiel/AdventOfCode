using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2022;

public class Day3 : AdventDay<string[], int, int>
{
    public override string[] ParseRawInput(string rawInput)
    {
        return rawInput.Trim().Split(Environment.NewLine);
    }

    public override int Part1(string[] input)
    {
        var commonItemTypes = input.Select(rucksack =>
        {
            var compartmentSize = rucksack.Length / 2;
            var firstCompartment = rucksack[..compartmentSize];
            var secondCompartment = rucksack[compartmentSize..];

            return firstCompartment.First(item => secondCompartment.Contains(item));
        });

        return commonItemTypes.Sum(GetPriority);
    }

    public override int Part2(string[] input)
    {
        var badges = new List<char>();
        for (var i = 0; i < input.Length; i += 3)
        {
            badges.Add(
                input[i].First(item => input[i + 1].Contains(item) && input[i + 2].Contains(item))
            );
        }

        return badges.Sum(GetPriority);
    }

    private static int GetPriority(char item)
    {
        return item >= 97 && item <= 122 ? item - 96 : item - 38;
    }
}
