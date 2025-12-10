using System;
using System.Collections.Generic;
using System.Linq;
using Google.OrTools.Sat;

namespace AdventOfCode.Days._2025;

public class Day10 : AdventDay<Machine[], int, long>
{
    public override Machine[] ParseRawInput(string rawInput)
    {
        return rawInput
            .Trim()
            .Split(Environment.NewLine)
            .Select(x =>
            {
                var split = x.Split(' ');
                var indicators = split[0][1..^1].Select(x => x == '#').ToArray();
                var vectorLength = indicators.Length;
                var buttons = split[1..^1]
                    .Select(x =>
                    {
                        var rawButton = x[1..^1];
                        var split = rawButton.Split(',').Select(int.Parse);
                        var vector = new bool[vectorLength];
                        foreach (var toggleIndex in split)
                        {
                            vector[toggleIndex] = true;
                        }
                        return vector;
                    })
                    .ToArray();
                var joltage = split.Last()[1..^1].Split(",").Select(int.Parse).ToArray();

                return new Machine(indicators, buttons, joltage);
            })
            .ToArray();
    }

    public override int Part1(Machine[] input)
    {
        return input.Sum(machine =>
            FindFewestPressesForIndicators(machine.ButtonVectors, machine.Indicators)
        );
    }

    public override long Part2(Machine[] input)
    {
        return input.Sum(machine =>
            FindFewestPressesForJoltage(machine.ButtonVectors, machine.Joltage)
        );
    }

    private static int FindFewestPressesForIndicators(bool[][] buttons, bool[] indicators)
    {
        var buttonCount = buttons.Length;
        var indicatorCount = indicators.Length;

        var bestCost = int.MaxValue;

        var combinations = 1 << buttonCount;

        for (var mask = 0; mask < combinations; mask++)
        {
            var accum = new bool[indicatorCount];

            for (var b = 0; b < buttonCount; b++)
            {
                if (((mask >> b) & 1) == 1)
                    XOR(accum, buttons[b]);
            }

            if (!SameVector(accum, indicators))
            {
                continue;
            }

            var cost = CountBits(mask);

            if (cost >= bestCost)
            {
                continue;
            }

            bestCost = cost;
        }

        return bestCost;

        void XOR(bool[] v1, bool[] v2)
        {
            for (var i = 0; i < v1.Length; i++)
                v1[i] ^= v2[i];
        }

        bool SameVector(bool[] a, bool[] b)
        {
            return !a.Where((t, i) => t != b[i]).Any();
        }

        int CountBits(int x)
        {
            var count = 0;
            while (x > 0)
            {
                count += x & 1;
                x >>= 1;
            }
            return count;
        }
    }

    private static long FindFewestPressesForJoltage(bool[][] buttons, int[] joltage)
    {
        var buttonsLength = buttons.Length;
        var joltageLength = joltage.Length;

        var model = new CpModel();
        var x = new IntVar[buttonsLength];
        for (var b = 0; b < buttonsLength; b++)
            x[b] = model.NewIntVar(0, 1_000_000, $"x{b}");

        for (var i = 0; i < joltageLength; i++)
        {
            List<IntVar> vars = [];
            List<int> coeffs = [];

            for (var b = 0; b < buttonsLength; b++)
            {
                if (!buttons[b][i])
                {
                    continue;
                }

                vars.Add(x[b]);
                coeffs.Add(1);
            }

            model.Add(LinearExpr.WeightedSum(vars, coeffs) == joltage[i]);
        }

        model.Minimize(LinearExpr.Sum(x));

        var solver = new CpSolver();
        solver.Solve(model);

        var total = 0;
        for (var b = 0; b < buttonsLength; b++)
            total += (int)solver.Value(x[b]);

        return total;
    }
}

public readonly struct Machine(bool[] indicators, bool[][] buttonVectors, int[] joltage)
{
    public bool[] Indicators { get; } = indicators;
    public bool[][] ButtonVectors { get; } = buttonVectors;
    public int[] Joltage { get; } = joltage;
}
