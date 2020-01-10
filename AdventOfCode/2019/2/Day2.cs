using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode._2019.Intcode;
using Combinatorics.Collections;

namespace AdventOfCode._2019._2
{
    public class Day2 : IAdventDay<long, long>
    {
        private readonly IEnumerable<long> _input;
        private readonly int _part2Target;

        public Day2(IEnumerable<long> input, int part2Target = 0)
        {
            _part2Target = part2Target;
            _input = input;
        }

        public long Part1()
        {
            var intcodeComputer = new IntcodeComputer(_input);
            intcodeComputer.Input(0);
            intcodeComputer.StartAsync().Wait();

            return intcodeComputer.Program.Memory[0];
        }

        public long Part2()
        {
            var combinations = new Combinations<int>(Enumerable.Range(0, _input.Count()).ToList(), 2,
                GenerateOption.WithRepetition);

            var input = _input.ToArray();

            foreach (var combination in combinations)
            {
                var code = (long[]) input.Clone();
                var computer = new IntcodeComputer(code);
                computer.Input(0);
                computer.StartAsync().Wait();

                if (computer.Program.Memory[0] == _part2Target) return 100 * input[1] + input[2];
                
                input[1] = combination[0];
                input[2] = combination[1];
            }

            throw new ArgumentException("Could not find a noun and a verb to achieve the expected result");
        }
    }
}