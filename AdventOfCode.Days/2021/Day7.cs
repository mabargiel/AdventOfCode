using System;
using System.Linq;

namespace AdventOfCode.Days._2021
{
    public class Day7 : AdventDay<int[], int, int>
    {
        public override int[] ParseRawInput(string rawInput)
        {
            return rawInput.Split(',').Select(int.Parse).ToArray();
        }

        public override int Part1(int[] input)
        {
            var sorted = input.OrderBy(x => x).ToArray();
            var position = sorted[input.Length / 2];

            return input.Sum(x => Math.Abs(position - x));
        }

        public override int Part2(int[] input)
        {
            var mean = input.Average();
            var positions = new[] { Math.Floor(mean), Math.Ceiling(mean) };

            return positions.Min(p =>
            {
                return input.Sum(x =>
                {
                    var count = Math.Abs(p - x);
                    return (int)((1 + count) / 2d * count);
                });
            });
        }
    }
}