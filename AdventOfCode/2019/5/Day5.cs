using AdventOfCode._2019.Intcode;

namespace AdventOfCode._2019._5
{
    public class Day5 : IAdventDay<int?, int?>
    {
        private readonly int[] _code;
        private readonly int? _initialInput;

        public Day5(int[] code, in int? initialInput)
        {
            _code = code;
            _initialInput = initialInput;
        }

        public int? Part1()
        {
            var computer = new IntcodeComputer(new Intcode.Program(_code, _initialInput));
            return computer.Run();
        }

        public int? Part2()
        {
            var computer = new IntcodeComputer(new Intcode.Program(_code, _initialInput));
            return computer.Run();
        }
    }
}