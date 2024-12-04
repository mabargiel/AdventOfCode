using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2024;

public class Day1 : AdventDay<List<int[]>, int, int>
{
    public override List<int[]> ParseRawInput(string rawInput)
    {
        var parsedInput = new List<int[]>(2);

        var rows = rawInput.Trim().Split(Environment.NewLine).Select(x => x.Trim()).ToArray();
        var leftSideNumbers = new List<int>();
        var rightSideNumbers = new List<int>();

        foreach (var row in rows)
        {
            var numbers = row.Split(' ');

            leftSideNumbers.Add(int.Parse(numbers[0]));
            rightSideNumbers.Add(int.Parse(numbers[^1]));
        }

        parsedInput.Add(leftSideNumbers.ToArray());
        parsedInput.Add(rightSideNumbers.ToArray());

        return parsedInput;
    }

    /// <summary>
    /// Calculate distance between two lowest numbers in each list, then 2nd lowest and so on and so forth.
    /// </summary>
    /// <param name="input">Parsed input.</param>
    /// <returns>Sum of all distances.</returns>
    public override int Part1(List<int[]> input)
    {
        var listLength = input[0].Length;
        var sum = 0;

        var leftSorted = input[0].Order().ToArray();
        var rightSorted = input[1].Order().ToArray();

        for (var i = 0; i < listLength; i++)
        {
            sum += Math.Abs(leftSorted[i] - rightSorted[i]);
        }

        return sum;
    }

    /// <summary>
    /// Calculate similarity score between two lists by checking how often number from one list appears in the other.
    /// Multiply each number by the number of times it appears in the other list.
    /// Return the sum of all these multiplications.
    /// </summary>
    /// <param name="input">Parsed input.</param>
    /// <returns>The similarity score.</returns>
    public override int Part2(List<int[]> input)
    {
        var leftSide = input[0];
        var rightSide = input[1];

        return leftSide.Sum(number => rightSide.Count(x => x == number) * number);
    }
}
