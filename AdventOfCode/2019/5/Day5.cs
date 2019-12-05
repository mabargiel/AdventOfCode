using AdventOfCode._2019.Intcode;

namespace AdventOfCode._2019._5
{
    public class Day5 : IAdventDay<int, int>
    {
        private readonly int[] _code;
        private readonly int _input;

        public Day5(int[] code, in int input)
        {
            _code = code;
            _input = input;
        }

        public int Part1()
        {
            var computer = new IntcodeComputer(_code);
            return computer.Run(_input);
        }

        public int Part2()
        {
            var computer = new IntcodeComputer(_code);
            return computer.Run(_input);
        }
    }
}