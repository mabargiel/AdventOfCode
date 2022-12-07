using System;
using System.Linq;

namespace AdventOfCode.Days._2017;

public class Day5 : AdventDay<int[], int, int>
{
    public override int[] ParseRawInput(string rawInput)
    {
        return rawInput.Trim().Split(Environment.NewLine).Select(int.Parse).ToArray();
    }

    public override int Part1(int[] input)
    {
        var i = 0;
        var result = 0;
        while (i >= 0 && i < input.Length)
        {
            var j = i;
            i += input[i];
            input[j]++;
            result++;
        }

        return result;
    }

    public override int Part2(int[] input)
    {
        var i = 0;
        var result = 0;
        while (i >= 0 && i < input.Length)
        {
            var j = i;
            i += input[i];
            input[j] += input[j] >= 3 ? -1 : 1;
            result++;
        }

        return result;
    }
}