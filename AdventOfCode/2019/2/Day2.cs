using System;
using System.Collections.Generic;
using System.Linq;

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
            return RunProgram(_input);
        }

        public int Part2()
        {
            for (var i = 0; i <= 99; i++)
            {
                for (var j = 0; j <= 99; j++)
                {
                    var input = (int[]) _input.Clone();
                    if (RunProgram(input) == _part2Target)
                    {
                        return 100 * _input[1] + _input[2];
                    }

                    _input[1] = i;
                    _input[2] = j;
                }
            }

            throw new ArgumentException("Could not find a noun and a verb to achieve the expected result");
        }

        private static int RunProgram(IList<int> input)
        {
            var startPosition = 0;
            while (input[startPosition] != (int) Signals.HaltProgram)
            {
                var nounPos = input[startPosition + 1];
                var verbPos = input[startPosition + 2];
                var targetPos = input[startPosition + 3];
                var inputLength = input.Count - 1;

                if (nounPos > inputLength || verbPos > inputLength || targetPos > inputLength)
                {
                    return -1;
                }

                input[targetPos] = (Signals) input[startPosition] switch
                {
                    Signals.Add => (input[nounPos] + input[verbPos]),
                    Signals.Multiply => (input[nounPos] * input[verbPos]),
                    _ => throw new ArgumentOutOfRangeException()
                };

                startPosition += 4;
            }

            return input[0];
        }

        private enum Signals
        {
            Add = 1,
            Multiply,
            HaltProgram = 99
        }
    }
}