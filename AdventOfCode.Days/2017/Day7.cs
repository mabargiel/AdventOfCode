using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2017;

public class Day7 : AdventDay<TowerProgram[], string, int>
{
    public override TowerProgram[] ParseRawInput(string rawInput)
    {
        return rawInput.Trim().Split(Environment.NewLine).Select(x =>
        {
            var splitInfo = x.Split(" -> ");
            var mainProgram = splitInfo[0].Split(' ');
            var dependencies = splitInfo.Length > 1 ? splitInfo[1].Split(", ") : null;
            return new TowerProgram(mainProgram[0], int.Parse(mainProgram[1].TrimStart('(').TrimEnd(')')),
                dependencies);
        }).ToArray();
    }

    public override string Part1(TowerProgram[] input)
    {
        var programsWithChildren = input.Where(x => x.ProgramsAbove != null).ToArray();
        var current = programsWithChildren.First();

        while (true)
        {
            var (name, _, _) = current;
            var parent = programsWithChildren.FirstOrDefault(program => program.ProgramsAbove.Contains(name));

            if (parent == null)
            {
                return name;
            }

            current = parent;
        }
    }

    public override int Part2(TowerProgram[] input)
    {
        var bottomProgram = input.First(x => x.Name == Part1(input));

        var tree = TransformToTree(bottomProgram, input);

        return BalanceTree(tree.ProgramsAbove);
    }

    private static int BalanceTree(ProgramTree[] programsAbove)
    {
        if (programsAbove == null)
        {
            return 0;
        }

        Dictionary<int, int> weights = new();
        foreach (var programAbove in programsAbove)
        {
            var balance = BalanceTree(programAbove.ProgramsAbove);
            if (balance != 0)
            {
                return balance;
            }

            var weight = GetWeight(programAbove);
            weights[programAbove.Weight] = weight;
        }

        var min = weights.Values.Min();
        var max = weights.Values.Max();

        if (min == max)
        {
            return 0;
        }

        //unbalanced
        var misfit = weights.First(x => x.Value == max);
        var difference = max - min;

        return misfit.Key - difference;
    }

    private static int GetWeight(ProgramTree tree)
    {
        var (_, weight, programsAbove) = tree;
        if (programsAbove == null)
        {
            return weight;
        }

        return weight + programsAbove.Sum(GetWeight);
    }

    private static ProgramTree TransformToTree(TowerProgram towerProgram, TowerProgram[] input)
    {
        var (name, weight, programsAboveNames) = towerProgram;

        var programsAbove = programsAboveNames?.Select(x => input.First(y => y.Name == x))
            .Select(x => TransformToTree(x, input)).ToArray();

        return new ProgramTree(name, weight, programsAbove);
    }
}

public record TowerProgram(string Name, int Weight, string[] ProgramsAbove = null);

public record ProgramTree(string Name, int Weight, ProgramTree[] ProgramsAbove);