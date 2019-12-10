using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode._2019.Intcode;

namespace AdventOfCode._2019._2
{
    public class Day2 : IAdventDay<long, long>
    {
        private readonly long[] _input;
        private readonly int _part2Target;

        public Day2(IEnumerable<long> input, int part2Target = 0)
        {
            _part2Target = part2Target;
            _input = input.ToArray();
        }

        public long Part1()
        {
            new IntcodeComputer(new Intcode.Program(_input, 0)).Run();

            return _input[0];
        }

        public long Part2()
        {
            for (var i = 0; i <= 99; i++)
            {
                for (var j = 0; j <= 99; j++)
                {
                    try
                    {
                        var input = (long[]) _input.Clone();
                        var computer = new IntcodeComputer(new Intcode.Program(input, 0));
                        computer.Run();

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