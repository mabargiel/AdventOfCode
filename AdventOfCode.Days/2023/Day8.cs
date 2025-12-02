using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days._2023;

public partial class Day8 : AdventDay<NavigationMap, int, long>
{
    [GeneratedRegex(@"(?<source>\w{3}) = \((?<left>\w{3}), (?<right>\w{3})\)")]
    private static partial Regex PathRegex();

    public override NavigationMap ParseRawInput(string rawInput)
    {
        var split = rawInput.Trim().Split(Environment.NewLine + Environment.NewLine);
        var leftRight = split[0];
        var pathRegex = PathRegex();
        var paths = new Dictionary<string, LeftRight>(
            split[1]
                .Split(Environment.NewLine)
                .Select(row =>
                {
                    var match = pathRegex.Match(row);
                    return new KeyValuePair<string, LeftRight>(
                        match.Groups["source"].ToString(),
                        new LeftRight(
                            match.Groups["left"].ToString(),
                            match.Groups["right"].ToString()
                        )
                    );
                })
        );

        return new NavigationMap(leftRight, paths);
    }

    public override int Part1(NavigationMap input)
    {
        var (instructions, paths) = input;

        var steps = 0;
        var currentPlace = "AAA";

        while (currentPlace != "ZZZ")
        {
            var instructionIndex = steps % instructions.Length;
            currentPlace =
                instructions[instructionIndex] == 'L'
                    ? paths[currentPlace].Left
                    : paths[currentPlace].Right;
            steps++;
        }

        return steps;
    }

    public override long Part2(NavigationMap input)
    {
        var (instructions, paths) = input;
        var currentNodes = paths.Keys.Where(x => x.EndsWith('A')).ToArray();

        var steps = new List<long>();
        for (var i = 0; i < currentNodes.Length; i++)
        {
            var stepsPerNode = 0;
            while (!currentNodes[i].EndsWith('Z'))
            {
                var currentStep = instructions[stepsPerNode % instructions.Length];

                currentNodes[i] =
                    currentStep == 'L' ? paths[currentNodes[i]].Left : paths[currentNodes[i]].Right;

                stepsPerNode++;
            }

            steps.Add(stepsPerNode);
        }

        return Lcm(steps.ToArray());
    }

    private static long Gcd(long a, long b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    private static long Lcm(long a, long b)
    {
        return a / Gcd(a, b) * b;
    }

    private static long Lcm(params long[] numbers)
    {
        var result = numbers[0];
        for (var i = 1; i < numbers.Length; i++)
        {
            result = Lcm(result, numbers[i]);
        }

        return result;
    }
}

public record NavigationMap(string LeftRight, Dictionary<string, LeftRight> Paths);

public record LeftRight(string Left, string Right);
