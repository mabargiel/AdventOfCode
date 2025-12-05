using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2025;

public class Day5 : AdventDay<IngredientsDb, int, long>
{
    public override IngredientsDb ParseRawInput(string rawInput)
    {
        var trimmed = rawInput.Trim();
        var split = trimmed.Split(Environment.NewLine + Environment.NewLine);
        var ranges = split[0]
            .Split(Environment.NewLine)
            .Select(x =>
            {
                var range = x.Split("-");
                return new Range(long.Parse(range[0]), long.Parse(range[1]));
            })
            .ToArray();

        var availableIngredients = split[1].Split(Environment.NewLine).Select(long.Parse).ToArray();

        return new IngredientsDb(ranges, availableIngredients);
    }

    public override int Part1(IngredientsDb input)
    {
        return input.AvailableIngredients.Count(ingredient =>
            input.Ranges.Any(range => ingredient >= range.Start && ingredient <= range.End)
        );
    }

    public override long Part2(IngredientsDb input)
    {
        var mergedRanges = MergeRanges(input.Ranges);
        return mergedRanges.Sum(range => range.End - range.Start + 1);
    }

    private static Range[] MergeRanges(Range[] inputRanges)
    {
        var sorted = inputRanges.OrderBy(r => r.Start).ToArray();
        var merged = new List<Range> { sorted[0] };

        foreach (var current in sorted.Skip(1))
        {
            var last = merged[^1];

            if (current.Start <= last.End)
            {
                merged[^1] = last with { End = Math.Max(last.End, current.End) };
            }
            else
            {
                merged.Add(current);
            }
        }

        return merged.ToArray();
    }
}

public class IngredientsDb(Range[] Ranges, long[] AvailableIngredients)
{
    public Range[] Ranges { get; } = Ranges;
    public long[] AvailableIngredients { get; } = AvailableIngredients;
}

public record Range(long Start, long End);
