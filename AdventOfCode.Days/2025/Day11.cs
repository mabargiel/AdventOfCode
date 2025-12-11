using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Days.Common;

namespace AdventOfCode.Days._2025;

public class Day11 : AdventDay<Dictionary<string, string[]>, int, long>
{
    public override Dictionary<string, string[]> ParseRawInput(string rawInput)
    {
        return new Dictionary<string, string[]>(
            rawInput
                .Trim()
                .Split(Environment.NewLine)
                .Select(x =>
                {
                    var split = x.Split(": ");
                    return new KeyValuePair<string, string[]>(split[0], split[1].Split(" "));
                })
        );
    }

    public override int Part1(Dictionary<string, string[]> input)
    {
        var graph = BuildGraph(input);
        return (int)graph.CountAllPaths("you", "out");
    }

    public override long Part2(Dictionary<string, string[]> input)
    {
        var graph = BuildGraph(input);
        return graph.CountAllPaths("svr", "out", ["dac", "fft"]);
    }

    private static Graph<string> BuildGraph(Dictionary<string, string[]> input)
    {
        var graph = new Graph<string>();

        foreach (var (src, outputs) in input)
        {
            foreach (var output in outputs)
            {
                graph.AddEdge(src, output);
            }
        }

        return graph;
    }
}
