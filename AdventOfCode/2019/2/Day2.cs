using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode._2019.Intcode;

namespace AdventOfCode._2019._2
{
    public class Day2 : IAdventDay<int, int>
    {
        private readonly int[] _input;
        private readonly int _part2Target;

        public Day2(IEnumerable<int> input, int part2Target = 0)
        {
            _part2Target = part2Target;
            _input = input.ToArray();
        }

        public int Part1()
        {
            new IntcodeComputer(_input).Run(0);

            return _input[0];
        }

        public int Part2()
        {
            for (var i = 0; i <= 99; i++)
            {
                for (var j = 0; j <= 99; j++)
                {
                    try
                    {
                        var input = (int[]) _input.Clone();
                        var computer = new IntcodeComputer(input);
                        computer.Run(0);

                        if (input[0] == _part2Target)
                        {
                            return 100 * _input[1] + _input[2];
                        }
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                    }
                    finally
                    {
                        _input[1] = i;
                        _input[2] = j;
                    }
                }
            }

            throw new ArgumentException("Could not find a noun and a verb to achieve the expected result");
        }
    }
}