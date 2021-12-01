namespace AdventOfCode.Days
{
    public abstract class AdventDay<TIn, TOut1, TOut2> : IAdventDay
    {
        public string Part1(string rawInput)
        {
            return Part1(ParseRawInput(rawInput)).ToString();
        }

        public string Part2(string rawInput)
        {
            return Part2(ParseRawInput(rawInput)).ToString();
        }

        public abstract TIn ParseRawInput(string rawInput);
        public abstract TOut1 Part1(TIn input);
        public abstract TOut2 Part2(TIn input);
    }

    public interface IAdventDay
    {
        string Part1(string rawInput);
        string Part2(string rawInput);
    }
    
    public interface IAdventDay<out TOut1, out TOut2>
    {
        TOut1 Part1();
        TOut2 Part2();
    }
}