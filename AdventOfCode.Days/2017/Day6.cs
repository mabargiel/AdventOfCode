using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2017
{
    public class Day6 : AdventDay<int[], int, int>
    {
        public override int[] ParseRawInput(string rawInput)
        {
            return rawInput.Split('\t').Select(int.Parse).ToArray();
        }

        public override int Part1(int[] input)
        {
            return Redistribute(input, out _, out _);
        }

        public override int Part2(int[] input)
        {
            Redistribute(input, out var memory, out var redistributions);

            var lastSeenIndex = memory.IndexOf(memory.First(x => x.SequenceEqual(memory.Last())));

            return redistributions - lastSeenIndex - 1;
        }

        private static int Redistribute(int[] input, out List<int[]> memory, out int redistributions)
        {
            memory = new List<int[]>();

            var blocksCount = input.Length;
            redistributions = 0;

            while (true)
            {
                redistributions++;

                var chosenBlock = input.Max();
                var chosenBlockIndex = Array.IndexOf(input, chosenBlock);
                input[chosenBlockIndex] = 0;

                for (var i = 0; i < chosenBlock; i++)
                {
                    chosenBlockIndex++;
                    chosenBlockIndex %= blocksCount;
                    input[chosenBlockIndex]++;
                }

                if (memory.Any(seen => seen.SequenceEqual(input)))
                {
                    memory.Add(input.ToArray());
                    return redistributions;
                }

                memory.Add(input.ToArray());
            }
        }
    }
}