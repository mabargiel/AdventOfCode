using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days._2025;

public partial class Day6 : AdventDay<string, long, long>
{
    [GeneratedRegex(@"\s+")]
    private static partial Regex SplitRegex();

    public override string ParseRawInput(string rawInput)
    {
        return rawInput;
    }

    public override long Part1(string input)
    {
        var lines = input
            .Trim()
            .Split(Environment.NewLine)
            .Select(x => x.Trim())
            .Select(x => SplitRegex().Split(x))
            .ToArray();

        var mathProblemsLength = lines[^1].Length;
        var result = 0L;

        for (var i = 0; i < mathProblemsLength; i++)
        {
            var operation = lines[^1][i];
            var values = lines[..^1].Select(x => int.Parse(x[i]));

            result +=
                operation == "+" ? values.Sum() : values.Aggregate(1L, (prev, curr) => prev * curr);
        }

        return result;
    }

    public override long Part2(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var rows = lines.Length;
        var cols = lines.Max(x => x.Length);
        var result = 0L;

        var valuesBuffer = new List<int>();
        for (var col = cols - 1; col >= 0; col--)
        {
            var currentValue = new StringBuilder();
            for (var row = 0; row < rows; row++)
            {
                try
                {
                    currentValue.Append(lines[row][col]);
                }
                catch (IndexOutOfRangeException)
                {
                    //suppress
                }
            }

            var value = currentValue.ToString();
            if (value.EndsWith('+'))
            {
                result += valuesBuffer.Sum() + int.Parse(value[..^1]);
                valuesBuffer = [];
            }
            else if (value.EndsWith('*'))
            {
                result +=
                    valuesBuffer.Aggregate(1L, (prev, curr) => prev * curr)
                    * int.Parse(value[..^1]);
                valuesBuffer = [];
            }
            else if (!string.IsNullOrWhiteSpace(value))
            {
                valuesBuffer.Add(int.Parse(value));
            }
        }

        return result;
    }
}
