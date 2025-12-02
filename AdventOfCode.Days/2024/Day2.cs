using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2024;

public class Day2 : AdventDay<List<int[]>, int, int>
{
    public override List<int[]> ParseRawInput(string rawInput)
    {
        return rawInput
            .Trim()
            .Split(Environment.NewLine)
            .Select(x => x.Split(' ').Select(int.Parse).ToArray())
            .ToList();
    }

    /// <summary>
    /// Count safe reports. All reports' levels must either all increase or decrease and the difference between two levels must be at most 3.
    /// </summary>
    /// <param name="input">Parsed input.</param>
    /// <returns>Count of safe reports.</returns>
    public override int Part1(List<int[]> input)
    {
        return input.Where(IsSafe).Count();
    }

    /// <summary>
    /// Count safe reports. All reports' levels must either all increase or decrease and the difference between two levels must be at most 3.
    /// This time, one level can be removed from the report.
    /// </summary>
    /// <param name="input">Parsed input.</param>
    /// <returns>Count of safe reports.</returns>
    public override int Part2(List<int[]> input)
    {
        var safeReports = 0;
        foreach (var report in input)
        {
            if (IsSafe(report))
            {
                safeReports++;
            }
            else if (
                report
                    .Select((t, i) => report.Take(i).Concat(report.Skip(i + 1)).ToArray())
                    .Any(IsSafe)
            )
            {
                safeReports++;
            }
        }

        return safeReports;
    }

    private static bool IsSafe(int[] report)
    {
        const int lower = 1;
        const int upper = 3;

        var shouldBeIncrease = report[0] < report[1];
        for (var i = 0; i < report.Length - 1; i++)
        {
            var distance = Math.Abs(report[i] - report[i + 1]);
            if (distance is > upper or < lower)
            {
                return false;
            }

            if (shouldBeIncrease)
            {
                if (report[i] >= report[i + 1])
                {
                    return false;
                }
            }
            else
            {
                if (report[i] <= report[i + 1])
                {
                    return false;
                }
            }
        }

        return true;
    }
}
