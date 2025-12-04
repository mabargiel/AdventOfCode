using System;
using System.Linq;

namespace AdventOfCode.Days._2025;

public class Day1 : AdventDay<string[], int, int>
{
    public override string[] ParseRawInput(string rawInput)
    {
        return rawInput.Trim().Split(Environment.NewLine);
    }

    public override int Part1(string[] input)
    {
        var count = 0;
        var dialPoint = 50;
        foreach (var line in input)
        {
            var direction = line[0];
            var number = int.Parse(line[1..]);
            var change = direction == 'L' ? -number : number;

            dialPoint = ((dialPoint + change) % 100 + 100) % 100;

            if (dialPoint == 0)
            {
                count++;
            }
        }

        return count;
    }

    public override int Part2(string[] input)
    {
        var count = 0;
        var current = 50;
        foreach (var line in input)
        {
            var direction = line[0];
            var number = int.Parse(line[1..]);
            var change = direction == 'L' ? -number : number;
            var unwrapped = current + change;

            switch (unwrapped)
            {
                case <= 0:
                    count += Math.Abs(unwrapped) / 100 + (current == 0 ? 0 : 1);
                    break;
                case > 99:
                    count += Math.Abs(unwrapped) / 100;
                    break;
            }

            current = (unwrapped % 100 + 100) % 100;
        }

        return count;
    }
}
