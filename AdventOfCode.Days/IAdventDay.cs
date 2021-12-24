﻿using System.Diagnostics;

namespace AdventOfCode.Days;

public abstract class AdventDay<TIn, TOut1, TOut2> : IAdventDay
{
    public string ExecutePart1(string rawInput)
    {
        var watch = new Stopwatch();
        watch.Start();
        var input = ParseRawInput(rawInput);
        watch.Stop();
        var inputParsingTime = watch.ElapsedMilliseconds;

        watch.Restart();
        var result = Part1(input).ToString();
        watch.Stop();
        var executionTime = watch.ElapsedMilliseconds;

        return
            $"Part 1 >\n>>> Result: {result}\n>>> Input parse time: {inputParsingTime}ms\n>>> Execution time: {executionTime}ms";
    }

    public string ExecutePart2(string rawInput)
    {
        var watch = new Stopwatch();
        watch.Start();
        var input = ParseRawInput(rawInput);
        watch.Stop();
        var inputParsingTime = watch.ElapsedMilliseconds;

        watch.Restart();
        var result = Part2(input).ToString();
        watch.Stop();
        var executionTime = watch.ElapsedMilliseconds;

        return
            $"Part 2 >\n>>> Result: {result}\n>>> Input parse time: {inputParsingTime}ms\n>>> Execution time: {executionTime}ms";
    }

    public abstract TIn ParseRawInput(string rawInput);
    public abstract TOut1 Part1(TIn input);
    public abstract TOut2 Part2(TIn input);
}

public interface IAdventDay
{
    string ExecutePart1(string rawInput);
    string ExecutePart2(string rawInput);
}

public interface IAdventDay<out TOut1, out TOut2>
{
    TOut1 Part1();
    TOut2 Part2();
}