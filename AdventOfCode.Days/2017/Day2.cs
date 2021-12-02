using System;
using System.Linq;

namespace AdventOfCode.Days._2017
{
    public class Day2 : AdventDay<int[][], int, int>
    {
        public override int[][] ParseRawInput(string rawInput)
        {
            return rawInput.Split(Environment.NewLine).Select(x => x.Split('\t').Select(int.Parse).ToArray()).ToArray();
        }

        public override int Part1(int[][] input)
        {
            return input.Sum(row => row.Max() - row.Min());
        }

        public override int Part2(int[][] input)
        {
            return input.Sum(row =>
            {
                Array.Sort(row);
                Array.Reverse(row);
                for (var i = 0; i < row.Length - 1; i++)
                {
                    for (var j = i + 1; j < row.Length; j++)
                    {
                        if (row[i] % row[j] == 0)
                        {
                            return row[i] / row[j];
                        }
                    }
                }

                throw new ArgumentException("Could not find two numbers that can be evenly divided by themselves");
            });
        }
    }
}