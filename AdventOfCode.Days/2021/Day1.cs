using System;
using System.Linq;

namespace AdventOfCode.Days._2021;

public class Day1 : AdventDay<int[], int, int>
{
    public override int[] ParseRawInput(string rawInput)
    {
        return rawInput.Split(Environment.NewLine).Select(int.Parse).ToArray();
    }

    public override int Part1(int[] input)
    {
        var result = 0;
        for (var i = 0; i < input.Length - 1; i++)
        {
            if (input[i + 1] > input[i])
            {
                result++;
            }
        }

        return result;
    }

    public override int Part2(int[] input)
    {
        var result = 0;
        for (var i = 3; i < input.Length; i++)
        {
            if (input[i - 3] < input[i])
            {
                result++;
            }
        }

        return result;
    }
}