using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Days.Common;

namespace AdventOfCode.Days._2023;

public partial class Day3 : AdventDay<GondolaEngine, int, int>
{
    [GeneratedRegex(@"\d+|[^\.]")]
    private static partial Regex ParseRegex();

    public override GondolaEngine ParseRawInput(string rawInput)
    {
        var engine = new GondolaEngine();

        var split = rawInput.Trim().Split(Environment.NewLine);
        var regex = ParseRegex();
        for (var i = 0; i < split.Length; i++)
        {
            var row = split[i];
            var matches = regex.Matches(row);

            foreach (Match match in matches)
            {
                var pos = new Point(i, match.Index);

                if (int.TryParse(match.Value, out var value))
                {
                    engine.Numbers.Add(pos, value);
                }
                else
                {
                    engine.Symbols.Add(pos);

                    if (match.Value == "*")
                    {
                        engine.Gears.Add(pos);
                    }
                }
            }
        }

        return engine;
    }

    public override int Part1(GondolaEngine input)
    {
        var result = 0;

        foreach (var (startPos, value) in input.Numbers)
        {
            var length = (int)Math.Floor(Math.Log10(value) + 1);
            var endPos = startPos with { Y = startPos.Y + length - 1 };

            if (
                input.Symbols.Any(symbol =>
                    symbol.X >= startPos.X - 1
                    && symbol.X <= endPos.X + 1
                    && symbol.Y >= startPos.Y - 1
                    && symbol.Y <= endPos.Y + 1
                )
            )
            {
                result += value;
            }
        }

        return result;
    }

    public override int Part2(GondolaEngine input)
    {
        var result = 0;
        var gearsBuffer = input.Gears.ToDictionary(x => x, _ => -1);

        foreach (var (startPos, value) in input.Numbers)
        {
            var length = (int)Math.Floor(Math.Log10(value) + 1);
            var endPos = startPos with { Y = startPos.Y + length - 1 };

            foreach (var inputGear in input.Gears)
            {
                if (
                    inputGear.X < startPos.X - 1
                    || inputGear.X > endPos.X + 1
                    || inputGear.Y < startPos.Y - 1
                    || inputGear.Y > endPos.Y + 1
                )
                {
                    continue;
                }

                var bufferedGear = gearsBuffer[inputGear];
                if (bufferedGear != -1)
                {
                    result += bufferedGear * value;
                    gearsBuffer.Remove(inputGear);
                }
                else
                {
                    gearsBuffer[inputGear] = value;
                }
            }
        }

        return result;
    }
}

//Symbols are treated as 0 number
public class GondolaEngine
{
    public List<Point> Symbols { get; } = new();

    public List<Point> Gears { get; } = new();
    public Dictionary<Point, int> Numbers { get; } = new();
}
