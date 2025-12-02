using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2023;

public class Day1 : AdventDay<string[], int, int>
{
    public override string[] ParseRawInput(string rawInput)
    {
        return rawInput.Split(Environment.NewLine).Select(x => x).ToArray();
    }

    public override int Part1(string[] input)
    {
        return input.Sum(line =>
        {
            var numbers = line.Where(char.IsNumber).ToArray();
            return numbers.Any() ? int.Parse($"{numbers.First()}{numbers.Last()}") : 0;
        });
    }

    public override int Part2(string[] input)
    {
        var words = new Dictionary<string, int>
        {
            { "nine", 9 },
            { "eight", 8 },
            { "seven", 7 },
            { "six", 6 },
            { "five", 5 },
            { "four", 4 },
            { "three", 3 },
            { "two", 2 },
            { "one", 1 },
            { "1", 1 },
            { "2", 2 },
            { "3", 3 },
            { "4", 4 },
            { "5", 5 },
            { "6", 6 },
            { "7", 7 },
            { "8", 8 },
            { "9", 9 },
        };

        var totalSum = 0;

        foreach (var line in input)
        {
            int? firstNum = null;
            int? lastNum = null;

            // Find the first occurence
            for (var i = 0; i < line.Length && firstNum == null; i++)
            {
                foreach (var word in words)
                {
                    if (
                        i + word.Key.Length <= line.Length
                        && line.Substring(i, word.Key.Length) == word.Key
                    )
                    {
                        firstNum = word.Value;
                        break;
                    }
                }
            }

            // Find the last occurrence
            for (var i = line.Length; i > 0 && lastNum == null; i--)
            {
                foreach (var word in words)
                {
                    if (
                        i - word.Key.Length >= 0
                        && line.Substring(i - word.Key.Length, word.Key.Length) == word.Key
                    )
                    {
                        lastNum = word.Value;
                        break;
                    }
                }
            }

            if (firstNum != null && lastNum != null)
            {
                totalSum += firstNum.Value * 10 + lastNum.Value;
            }
        }

        return totalSum;
    }
}
