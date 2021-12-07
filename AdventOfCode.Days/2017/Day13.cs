using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace AdventOfCode.Days._2017
{
    public class Day13 : AdventDay<ImmutableDictionary<int, int>, int, int>
    {
        public override ImmutableDictionary<int, int> ParseRawInput(string rawInput)
        {
            return rawInput.Trim().Split(Environment.NewLine).Select(x =>
            {
                var split = x.Split(": ");
                return new KeyValuePair<int, int>(int.Parse(split[0]), int.Parse(split[1]));
            }).ToImmutableDictionary();
        }

        public override int Part1(ImmutableDictionary<int, int> input)
        {
            return input.Keys.Where(layer => layer % ((input[layer] - 1) * 2) == 0).Sum(layer => layer * input[layer]);
        }

        public override int Part2(ImmutableDictionary<int, int> input)
        {
            var delay = -1;
            bool caught;

            do
            {
                delay++;
                caught = input.Keys.Any(layer => (layer + delay) % ((input[layer] - 1) * 2) == 0);
            } while (caught);

            return delay;
        }
    }
}