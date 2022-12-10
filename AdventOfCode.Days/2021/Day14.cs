using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2021
{
    public class Day14 : AdventDay<PolymerRules, int, long>
    {
        public override PolymerRules ParseRawInput(string rawInput)
        {
            var split = rawInput.Trim().Split(Environment.NewLine + Environment.NewLine);
            var template = split[0];
            Dictionary<string, char> insertions = new(split[1].Split(Environment.NewLine).Select(s =>
            {
                var adjacency = s.Split(" -> ");
                return new KeyValuePair<string, char>(adjacency[0], adjacency[1].First());
            }));

            return new PolymerRules(template, insertions);
        }

        public override int Part1(PolymerRules input)
        {
            const int steps = 10;
            return (int) Solve(input, steps);
        }

        public override long Part2(PolymerRules input)
        {
            const int steps = 40;
            return Solve(input, steps);
        }

        private static long Solve(PolymerRules input, int steps)
        {
            var moleculeCount = new Dictionary<string, long>();
            for (var i = 0; i < input.Polymer.Length - 1; i++)
            {
                var molecule = input.Polymer.Substring(i, 2);
                moleculeCount[molecule] = moleculeCount.GetValueOrDefault(molecule) + 1;
            }

            for (var i = 0; i < steps; i++)
            {
                var updated = new Dictionary<string, long>();
                foreach (var (molecule, count) in moleculeCount)
                {
                    var between = input.Insertions[molecule];
                    var (ai, ib) = (molecule[0].ToString() + between, between + molecule[1].ToString());
                    updated[ai] = count + updated.GetValueOrDefault(ai);
                    updated[ib] = count + updated.GetValueOrDefault(ib);
                }

                moleculeCount = updated;
            }

            var elementCounts = new Dictionary<char, long>();
            foreach (var (molecule, count) in moleculeCount)
            {
                var a = molecule[0];
                elementCounts[a] = elementCounts.GetValueOrDefault(a) + count;
            }
            
            elementCounts[input.Polymer.Last()]++;

            return elementCounts.Values.Max() - elementCounts.Values.Min();
        }
    }

    public record PolymerRules(string Polymer, Dictionary<string, char> Insertions);
}