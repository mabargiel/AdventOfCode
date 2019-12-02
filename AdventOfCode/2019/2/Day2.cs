using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2019._2
{
    public class Day2 : IAdventDay<int, int>
    {
        private readonly int _part2Target;
        private readonly int[] _input;

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
            for (int i = 0; i <= 99; i++)
            {
                for (int j = 0; j <= 99; j++)
                {
                    var input = (int[]) _input.Clone();
                    if (RunProgram(input) == _part2Target)
                    {
                        goto result;
                    }

                    _input[1] = i;
                    _input[2] = j;
                }
            }
            result: return 100 * _input[1] + _input[2];
        }

        private static int RunProgram(int[] input)
        {
            var startPosition = 0;
            while (input[startPosition] != (int) Signals.HaltProgram)
            {
                var aPos = input[startPosition + 1];
                var bPos = input[startPosition + 2];
                var targetPos = input[startPosition + 3];
                var inputLength = input.Length - 1;
                
                if (aPos > inputLength || bPos > inputLength || targetPos > inputLength)
                {
                    return -1;
                }

                switch ((Signals) input[startPosition])
                {
                    case Signals.Add:
                        input[targetPos] = input[aPos] + input[bPos];
                        break;
                    case Signals.Multiply:
                        input[targetPos] = input[aPos] * input[bPos];
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

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