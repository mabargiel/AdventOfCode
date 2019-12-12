using AdventOfCode._2019.Intcode;

namespace AdventOfCode._2019._5
{
    public class Day5 : IAdventDay<long, long>
    {
        private readonly long[] _code;
        private readonly long? _initialInput;

        public Day5(long[] code, in long? initialInput)
        {
            _code = code;
            _initialInput = initialInput;
        }

        public long Part1()
        {
            var computer = new IntcodeComputer(new Intcode.Program(_code, _initialInput));
            return computer.Run();
        }

        public long Part2()
        {
            var computer = new IntcodeComputer(new Intcode.Program(_code, _initialInput));
            return computer.Run();
        }
    }
}