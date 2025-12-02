using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2022;

public class Day6 : AdventDay<string, int, int>
{
    public override string ParseRawInput(string rawInput)
    {
        return rawInput.Trim();
    }

    public override int Part1(string input)
    {
        return FindMarker(input, 4);
    }

    public override int Part2(string input)
    {
        return FindMarker(input, 14);
    }

    private static int FindMarker(string input, int markerLength)
    {
        var window = new List<char>(input[..markerLength]);

        for (var i = markerLength; i < input.Length; i++)
        {
            if (window.Distinct().Count() == markerLength)
            {
                return i;
            }

            window.Add(input[i]);
            window.RemoveAt(0);
        }

        throw new ArgumentException(
            $"Could not find the marker of length {markerLength} in the given input"
        );
    }
}
