using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Days._2019.Intcode;
using Combinatorics.Collections;

namespace AdventOfCode.Days._2019;

public class Day2 : AdventDay<long[], long, long>
{
    public override long[] ParseRawInput(string rawInput)
    {
        return rawInput.Trim().Select(c => (long)char.GetNumericValue(c)).ToArray();
    }

    public override long Part1(long[] input)
    {
        var intcodeComputer = new IntcodeComputer(input);
        intcodeComputer.Input(0);
        intcodeComputer.StartAsync().Wait();

        return intcodeComputer.Program.Memory[0];
    }

    public override long Part2(long[] input)
    {
        var target = input[0];
        var computerInput = input[1..];
        var combinations = new Combinations<int>(
            Enumerable.Range(0, computerInput.Length).ToList(),
            2,
            GenerateOption.WithRepetition
        );

        foreach (var combination in combinations)
        {
            var code = (long[])computerInput.Clone();
            var computer = new IntcodeComputer(code);
            computer.Input(0);
            computer.StartAsync().Wait();

            if (computer.Program.Memory[0] == target)
            {
                return 100 * computerInput[1] + computerInput[2];
            }

            computerInput[1] = combination[0];
            computerInput[2] = combination[1];
        }

        throw new ArgumentException(
            "Could not find a noun and a verb to achieve the expected result"
        );
    }
}
