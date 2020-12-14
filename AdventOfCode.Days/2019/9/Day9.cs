using System.Collections.Generic;
using AdventOfCode.Days._2019.Intcode;

namespace AdventOfCode.Days._2019._9
{
    public class Day9 : AdventDay<long[], long[]>
    {
        private readonly int? _input;
        private readonly long[] _instructions;

        public Day9(long[] instructions, int? input = null)
        {
            _instructions = instructions;
            _input = input;
        }

        public override long[] Part1()
        {
            var results = new List<long>();
            var computer = new IntcodeComputer(_instructions);
            computer.OnOutput += l => results.Add(l);
            if (_input != null)
            {
                computer.Input(_input.Value);
            }

            computer.StartAsync().Wait();

            return results.ToArray();
        }

        public override long[] Part2()
        {
            return Part1();
        }
    }
}
