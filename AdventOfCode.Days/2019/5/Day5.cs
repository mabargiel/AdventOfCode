using AdventOfCode.Days._2019.Intcode;

namespace AdventOfCode.Days._2019._5
{
    public class Day5 : IAdventDay<long, long>
    {
        private readonly long[] _code;
        private readonly long _initialInput;

        public Day5(long[] code, in long initialInput)
        {
            _code = code;
            _initialInput = initialInput;
        }

        public long Part1()
        {
            var computer = new IntcodeComputer(_code);
            computer.Input(_initialInput);
            long result = -1;

            computer.OnOutput += l => result = l;
            computer.StartAsync().Wait();

            return result;
        }

        public long Part2()
        {
            return Part1();
        }
    }
}