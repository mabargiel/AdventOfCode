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
            return input.Where(layer => WouldBeDetected(layer)).Sum(layer => layer.Key * layer.Value);
        }

        public override int Part2(ImmutableDictionary<int, int> input)
        {
            var delay = -1;
            bool caught;

            do
            {
                delay++;
                caught = input.Any(layer => WouldBeDetected(layer, delay));
            } while (caught);

            return delay;
        }
        
        private static bool WouldBeDetected(KeyValuePair<int, int> layer, int delay = 0)
        {
            var (depth, range) = layer;
            return (depth + delay) % ((range - 1) * 2) == 0;
        }
    }
}