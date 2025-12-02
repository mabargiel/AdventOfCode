using System;
using System.Linq;

namespace AdventOfCode.Days._2022;

public class Day1 : AdventDay<int[][], int, int>
{
    public override int[][] ParseRawInput(string rawInput)
    {
        return rawInput
            .Trim()
            .Split(Environment.NewLine + Environment.NewLine)
            .Select(elfCalories =>
                elfCalories.Split(Environment.NewLine).Select(int.Parse).ToArray()
            )
            .ToArray();
    }

    public override int Part1(int[][] input)
    {
        return input.Select(elfCalories => elfCalories.Sum()).Max();
    }

    public override int Part2(int[][] input)
    {
        return input
            .Select(elfCalories => elfCalories.Sum())
            .OrderByDescending(x => x)
            .Take(3)
            .Sum();
    }
}
