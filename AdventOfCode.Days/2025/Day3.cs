using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2025;

public class Day3 : AdventDay<int[][], int, long>
{
    public override int[][] ParseRawInput(string rawInput)
    {
        return rawInput
            .Trim()
            .Split(Environment.NewLine)
            .Select(x => x.Select(s => int.Parse(s.ToString())).ToArray())
            .ToArray();
    }

    public override int Part1(int[][] input)
    {
        return (
            from bank in input
            let battery1 = bank[..^1].Max()
            let battery2 = bank[(bank.IndexOf(battery1) + 1)..].Max()
            select int.Parse(battery1 + battery2.ToString())
        ).Sum();
    }

    public override long Part2(int[][] input)
    {
        var result = 0l;

        foreach (var bank in input)
        {
            var n = bank.Length;
            var toRemove = n - 12;
            var stack = new Stack<int>();

            foreach (var digit in bank)
            {
                while (toRemove > 0 && stack.Count > 0 && stack.Peek() < digit)
                {
                    stack.Pop();
                    toRemove--;
                }

                stack.Push(digit);
            }

            while (stack.Count > 12)
                stack.Pop();

            result += long.Parse(stack.Reverse().Aggregate("", (prev, curr) => prev + curr));
        }

        return result;
    }
}
