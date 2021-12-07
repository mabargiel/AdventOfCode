using System;
using System.Collections.Generic;
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
            var minPos = input.Min();
            var maxPos = input.Max();

            var totalFuels = new SortedSet<int>();

            for (var i = minPos; i <= maxPos; i++)
            {
                var fuelUsed = input.Sum(x => Math.Abs(i - x));

                totalFuels.Add(fuelUsed);
            }

            return totalFuels.Min();
        }

        public override int Part2(int[] input)
        {
            var minPos = input.Min();
            var maxPos = input.Max();

            var totalFuels = new SortedSet<int>();

            for (var i = minPos; i <= maxPos; i++)
            {
                var fuelUsed = input.Sum(x =>
                {
                    var count = Math.Abs(i - x);
                    return (int)((1 + count) / 2d * count);
                });

                totalFuels.Add(fuelUsed);
            }

            return totalFuels.Min();
        }
    }
}