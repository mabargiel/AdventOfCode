using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode._2019.Intcode;
using Combinatorics.Collections;

namespace AdventOfCode._2019._2
{
    public class Day2 : IAdventDay<long, long>
    {
        private readonly Dictionary<long, long> _input;
        private readonly int _part2Target;

        public Day2(Dictionary<long, long> input, int part2Target = 0)
        {
            _part2Target = part2Target;
            _input = input;
        }

        public long Part1()
        {
            new IntcodeComputer(new Intcode.Program(_input, 0)).Run();

            return _input[0];
        }

        public long Part2()
        {
            var combinations = new Combinations<int>(Enumerable.Range(0, _input.Count).ToList(), 2,
                GenerateOption.WithRepetition);

            foreach (var combination in combinations)
            {
                var input = new Dictionary<long, long>(_input);
                var computer = new IntcodeComputer(new Intcode.Program(input, 0));
                computer.Run();

                if (input[0] == _part2Target) return 100 * _input[1] + _input[2];
                
                _input[1] = combination[0];
                _input[2] = combination[1];
            }

            throw new ArgumentException("Could not find a noun and a verb to achieve the expected result");
        }
    }
}