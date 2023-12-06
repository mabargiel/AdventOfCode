using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2023;

public class Day2 : AdventDay<List<List<Dictionary<string, int>>>, int, int>
{
    public override List<List<Dictionary<string, int>>> ParseRawInput(string rawInput)
    {
        var rawGameStrings = rawInput.Trim().Split(Environment.NewLine);

        return (from rawGameString in rawGameStrings
                let game = new Dictionary<string, int>()
                select rawGameString[(rawGameString.IndexOf(':') + 1)..]
                    .Split(';')
                    .Select(turn => turn.Split(',')
                        .Select(x => x.Trim().Split(" "))
                        .ToDictionary(x => x[1], x => int.Parse(x[0]))).ToList()
            ).ToList();
    }

    public override int Part1(List<List<Dictionary<string, int>>> input)
    {
        Dictionary<string, int> maxPerColor = new()
        {
            ["red"] = 12,
            ["green"] = 13,
            ["blue"] = 14
        };

        var result = 0;

        for (var i = 0; i < input.Count; i++)
        {
            var game = input[i];
            if (game.Any(turn => turn.Any(cubes => cubes.Value > maxPerColor[cubes.Key])))
            {
                continue;
            }

            result += i + 1;
        }

        return result;
    }

    public override int Part2(List<List<Dictionary<string, int>>> input)
    {
        var result = 0;

        foreach (var game in input)
        {
            Dictionary<string, int> maxPerCurrentGame = new()
            {
                ["red"] = 0,
                ["green"] = 0,
                ["blue"] = 0
            };

            foreach (var turn in game)
            {
                foreach (var (color, count) in turn)
                {
                    if (maxPerCurrentGame[color] < count)
                    {
                        maxPerCurrentGame[color] = count;
                    }
                }
            }

            result += maxPerCurrentGame.Values.Aggregate((curr, prev) => curr * prev);
        }

        return result;
    }
}