namespace AdventOfCode.Days
{
    public interface IAdventDay<out TOut1, out TOut2>
    {
        TOut1 Part1();
        TOut2 Part2();
    }
}