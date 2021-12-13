using System;
using System.Linq;
using AdventOfCode.Days.Common;

namespace AdventOfCode.Days._2021
{
    public class Day11 : AdventDay<int[,], int, int>
    {
        public override int[,] ParseRawInput(string rawInput)
        {
            var rows = rawInput.Trim().Split(Environment.NewLine);
            var result = new int[10, 10];

            for (var y = 0; y < 10; y++)
            {
                for (var x = 0; x < 10; x++)
                {
                    result[y, x] = (int)char.GetNumericValue(rows[y][x]);
                }
            }

            return result;
        }

        public override int Part1(int[,] input)
        {
            var result = 0;
            for (var i = 0; i < 100; i++)
            {
                input = Flash(IncreaseEnergyLevel(input));
                result += input.Count(o => o == 0);
            }

            return result;
        }

        public override int Part2(int[,] input)
        {
            var result = 0;
            while (input.Any(o => o != 0))
            {
                result++;
                input = Flash(IncreaseEnergyLevel(input));
            }

            return result;
        }

        private static int[,] IncreaseEnergyLevel(int[,] octopuses)
        {
            var result = new int[10, 10];
            for (var y = 0; y < 10; y++)
            {
                for (var x = 0; x < 10; x++)
                {
                    result[y, x] = octopuses[y, x] + 1;
                }
            }

            return result;
        }

        private static int[,] Flash(int[,] octopuses)
        {
            var result = (int[,])octopuses.Clone();
            (int Y, int X)[] theyWillFLash;

            while ((theyWillFLash = result.Where(o => o > 9).ToArray()).Any())
            {
                foreach (var (y, x) in theyWillFLash)
                {
                    result[y, x] = 0;

                    foreach (var yy in Enumerable.Range(y - 1, 3))
                    {
                        if (yy is < 0 or >= 10)
                        {
                            continue;
                        }

                        foreach (var xx in Enumerable.Range(x - 1, 3))
                        {
                            if (xx is < 0 or >= 10 || result[yy, xx] == 0)
                            {
                                continue;
                            }

                            result[yy, xx]++;
                        }
                    }
                }
            }

            return result;
        }
    }
}