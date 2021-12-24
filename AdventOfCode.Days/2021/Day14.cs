using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2021
{
    public class Day14 : AdventDay<Rules, int, long>
    {
        public override Rules ParseRawInput(string rawInput)
        {
            var split = rawInput.Trim().Split(Environment.NewLine + Environment.NewLine);
            var template = split[0];
            Dictionary<string, char> insertions = new(split[1].Split(Environment.NewLine).Select(s =>
            {
                var adjacency = s.Split(" -> ");
                return new KeyValuePair<string, char>(adjacency[0], adjacency[1].First());
            }));

            return new Rules(template, insertions);
        }

        public override int Part1(Rules input)
        {
            var charCounts = input.Template.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var current = input.Template;
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < current.Length - 1; j += 2)
                {
                    var first = current[j];
                    var second = current[j + 1];
                    var middle = input.Insertions[$"{first}{second}"];
                    if (!charCounts.ContainsKey(middle))
                    {
                        charCounts[middle] = 1;
                    }
                    else
                    {
                        charCounts[middle]++;
                    }

                    current = current.Insert(j + 1, middle.ToString());
                }
            }

            var values = charCounts.Values;

            return values.Max() - values.Min();
        }

        public override long Part2(Rules input)
        {
            throw new NotImplementedException();
        }
    }

    public record Rules(string Template, Dictionary<string, char> Insertions);
}