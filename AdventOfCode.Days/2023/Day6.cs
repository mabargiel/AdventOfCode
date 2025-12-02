using System;
using System.Linq;

namespace AdventOfCode.Days._2023;

public class Day6 : AdventDay<Race[], int, int>
{
    public override Race[] ParseRawInput(string rawInput)
    {
        var split = rawInput.Trim().Split(Environment.NewLine);
        var durationsString = split[0];
        var currentRecordsString = split[1];

        var durations = durationsString[(durationsString.IndexOf(':') + 2)..]
            .Trim()
            .Split(' ')
            .Where(x => !string.IsNullOrEmpty(x))
            .Select(int.Parse)
            .ToArray();

        var currentRecords = currentRecordsString[(currentRecordsString.IndexOf(':') + 2)..]
            .Trim()
            .Split(' ')
            .Where(x => !string.IsNullOrEmpty(x))
            .Select(int.Parse)
            .ToArray();

        var races = new Race[durations.Length];

        for (var i = 0; i < durations.Length; i++)
        {
            races[i] = new Race(durations[i], currentRecords[i]);
        }

        return races;
    }

    public override int Part1(Race[] input)
    {
        return input
            .Select(race => CountWaysToWin(race.Duration, race.CurrentRecord))
            .Aggregate(1, (current, waysToBeatARecord) => current * waysToBeatARecord);
    }

    public override int Part2(Race[] input)
    {
        var duration = long.Parse(string.Join(string.Empty, input.Select(x => x.Duration)));
        var currentRecord = long.Parse(
            string.Join(string.Empty, input.Select(x => x.CurrentRecord))
        );

        var result = CountWaysToWin(duration, currentRecord);

        return result;
    }

    private static int CountWaysToWin(long duration, long currentRecord)
    {
        var mid = duration / 2.0;
        var floor = (int)Math.Floor(mid);
        var firstWinnableIndex = -1;

        for (var i = 1; i <= floor; i++)
        {
            if (i * (duration - i) > currentRecord)
            {
                firstWinnableIndex = i;
                break;
            }
        }

        var result =
            duration % 2 == 0
                ? 2 * (floor - firstWinnableIndex) + 1
                : 2 * (floor - firstWinnableIndex + 1);

        return result;
    }
}

public record Race(int Duration, int CurrentRecord);
