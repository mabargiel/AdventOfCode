using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Days._2022;

public class Day10 : AdventDay<Instruction[], int, string>
{
    public override Instruction[] ParseRawInput(string rawInput)
    {
        return rawInput
            .Trim()
            .Split(Environment.NewLine)
            .Select(x =>
            {
                var split = x.Split(' ');
                var operation = split[0];
                int? value = split.Length == 2 ? int.Parse(split[1]) : null;

                return new Instruction(operation, value);
            })
            .ToArray();
    }

    public override int Part1(Instruction[] input)
    {
        var xValuesPerEndCycle = SimulateCpu(input);

        return new[] { 20, 60, 100, 140, 180, 220 }.Sum(theCycle =>
            theCycle * xValuesPerEndCycle[theCycle - 1]
        );
    }

    public override string Part2(Instruction[] input)
    {
        const int width = 40;
        const int pixels = width * 6; //width * height
        var xValuesPerCycle = SimulateCpu(input);
        var sb = new StringBuilder();

        for (var i = 0; i < pixels; i++)
        {
            var crtDrawPos = i % width;

            if (i != 0 && crtDrawPos == 0)
            {
                sb.AppendLine();
            }

            var spritePosition = xValuesPerCycle[i];
            sb.Append(Math.Abs(spritePosition - crtDrawPos) < 2 ? '#' : '.');
        }

        return sb.ToString();
    }

    private static int[] SimulateCpu(IEnumerable<Instruction> input)
    {
        var x = 1;
        var xValuesPerEndCycle = new List<int> { x };

        foreach (var instruction in input)
        {
            xValuesPerEndCycle.Add(x);

            if (instruction.Operation == "noop")
            {
                continue;
            }

            x += instruction.Value!.Value;
            xValuesPerEndCycle.Add(x);
        }

        return xValuesPerEndCycle.ToArray();
    }
}

public record Instruction(string Operation, int? Value);
