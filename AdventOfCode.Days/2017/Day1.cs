using System.Linq;

namespace AdventOfCode.Days._2017;

public class Day1 : AdventDay<int[], int, int>
{
    public override int[] ParseRawInput(string rawInput)
    {
        return rawInput.Select(x => (int)char.GetNumericValue(x)).ToArray();
    }

    public override int Part1(int[] input)
    {
        var result = 0;
        var digitsCount = input.Length;

        for (var currIndex = 0; currIndex < input.Length; currIndex++)
        {
            var nextDigit = currIndex == digitsCount - 1 ? input[0] : input[currIndex + 1];
            if (input[currIndex] == nextDigit)
            {
                result += input[currIndex];
            }
        }

        return result;
    }

    public override int Part2(int[] input)
    {
        var result = 0;
        var steps = input.Length / 2;
        for (var i = 0; i < input.Length; i++)
        {
            var pairIndex = i + steps >= input.Length ? i + steps - input.Length : i + steps;
            if (input[i] == input[pairIndex])
            {
                result += input[i];
            }
        }

        return result;
    }
}