using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2023;

public class Day9 : AdventDay<List<List<int>>, int, int>
{
    public override List<List<int>> ParseRawInput(string rawInput)
    {
        return rawInput
            .Trim()
            .Split(Environment.NewLine)
            .Select(x => x.Split(' ').Select(int.Parse).ToList())
            .ToList();
    }

    public override int Part1(List<List<int>> input)
    {
        return input.Sum(historyEntry => Extrapolate(historyEntry.ToArray()));
    }

    public override int Part2(List<List<int>> input)
    {
        return input.Sum(historyEntry => ExtrapolateBackwards(historyEntry.ToArray()));
    }

    private static int Extrapolate(IReadOnlyList<int> historyEntry)
    {
        if (historyEntry.All(x => x == 0))
        {
            return 0;
        }

        var newSequence = new int[historyEntry.Count - 1];

        for (var i = 1; i < historyEntry.Count; i++)
        {
            newSequence[i - 1] = historyEntry[i] - historyEntry[i - 1];
        }

        return historyEntry[^1] + Extrapolate(newSequence);
    }

    private static int ExtrapolateBackwards(IReadOnlyList<int> historyEntry)
    {
        if (historyEntry.All(x => x == 0))
        {
            return 0;
        }

        var newSequence = new int[historyEntry.Count - 1];

        for (var i = 1; i < historyEntry.Count; i++)
        {
            newSequence[i - 1] = historyEntry[i] - historyEntry[i - 1];
        }

        return historyEntry[0] - ExtrapolateBackwards(newSequence);
    }
}
