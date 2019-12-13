using System.Collections.Generic;
using AdventOfCode._2019.Intcode;

namespace AdventOfCode._2019._9
{
    public class Day9 : IAdventDay<long[], long[]>
    {
        private readonly Dictionary<long, long> _instructions;
        private readonly int? _input;

        public Day9(Dictionary<long, long> instructions, int? input = null)
        {
            _instructions = instructions;
            _input = input;
        }

        public long[] Part1()
        {
            var program = new Intcode.Program(_instructions);
            if(_input != null)
                program.Buffer.Add(_input.Value);
            var computer = new IntcodeComputer(program);
            return computer.Run();
        }

        public long[] Part2()
        {
            return Part1();
        }
    }
}