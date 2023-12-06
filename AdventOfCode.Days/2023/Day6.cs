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

        var durations = durationsString[(durationsString.IndexOf(':') + 2)..].Trim().Split(' ')
            .Where(x => !string.IsNullOrEmpty(x)).Select(int.Parse).ToArray();

        var currentRecords = currentRecordsString[(currentRecordsString.IndexOf(':') + 2)..].Trim().Split(' ')
            .Where(x => !string.IsNullOrEmpty(x)).Select(int.Parse).ToArray();

        var races = new Race[durations.Length];

        for (var i = 0; i < durations.Length; i++)
        {
            races[i] = new Race(durations[i], currentRecords[i]);
        }

        return races;
    }

    public override int Part1(Race[] input)
    {
        var result = 1;

        foreach (var race in input)
        {
            var waysToBeatARecord = 0;

            for (var i = 1; i <= race.Duration; i++)
            {
                if (i * (race.Duration - i) > race.CurrentRecord)
                {
                    waysToBeatARecord++;
                }
            }

            result *= waysToBeatARecord;
        }

        return result;
    }

    public override int Part2(Race[] input)
    {
        var duration = long.Parse(string.Join(string.Empty, input.Select(x => x.Duration)));
        var currentRecord = long.Parse(string.Join(string.Empty, input.Select(x => x.CurrentRecord)));

        var mid = duration / 2.0;
        var floor = (int)Math.Floor(mid);
        var ceiling = (int)Math.Ceiling(mid);
        var firstWinnableIndex = -1;

        for (var i = 1; i <= floor; i++)
        {
            if (i * (duration - i) >= currentRecord)
            {
                firstWinnableIndex = i;
                break;
            }
        }

        var result = 2 * (ceiling - firstWinnableIndex);

        if (duration % 2 == 0)
        {
            result++;
        }

        return result;
    }
}

public record Race(int Duration, int CurrentRecord);