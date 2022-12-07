using System;
using System.Diagnostics;

namespace AdventOfCode.Days;

public abstract class AdventDay<TIn, TOut1, TOut2> : IAdventDay
{
    public string ExecutePart1(string rawInput)
    {
        return ExecutePart(rawInput, "Part 1", input => Part1(input).ToString());
    }

    public string ExecutePart2(string rawInput)
    {
        return ExecutePart(rawInput, "Part 2", input => Part2(input).ToString());
    }

    private string ExecutePart(string rawInput, string name, Func<TIn, string> part)
    {
        var watch = new Stopwatch();
        watch.Start();
        var input = ParseRawInput(rawInput);
        watch.Stop();
        var inputParsingTime = watch.Elapsed.TotalMilliseconds;
        
        watch.Restart();
        var result = part(input);
        watch.Stop();
        var executionTime = watch.Elapsed.TotalMilliseconds;
        
        return
            $"{name} >\n>>> Result: {result}\n>>> Input parse time: {inputParsingTime:F2} ms\n>>> Execution time: {executionTime:F2} ms";
    }

    public abstract TIn ParseRawInput(string rawInput);
    public abstract TOut1 Part1(TIn input);
    public abstract TOut2 Part2(TIn input);
}