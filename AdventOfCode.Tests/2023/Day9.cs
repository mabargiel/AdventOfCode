using System.Collections.Generic;
using AdventOfCode.Days._2023;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2023;

public class Day9
{
    private Days._2023.Day9 _day9;

    [SetUp]
    public void Initialize()
    {
        _day9 = new Days._2023.Day9();
    }

    [Test]
    public void ParseRawInput_IntoLogicalObject()
    {
        const string rawInput = """
                                0 3 6 9 12 15
                                1 3 6 10 15 21
                                10 13 16 21 30 45
                                """;

        var input = _day9.ParseRawInput(rawInput);

        input.ShouldBeEquivalentTo(new List<List<int>>
        {
            new() { 0, 3, 6, 9, 12, 15 },
            new() { 1, 3, 6, 10, 15, 21 },
            new() { 10, 13, 16, 21, 30, 45 }
        });
    }
    
    [Test]
    [TestCase("""
              0 3 6 9 12 15
              1 3 6 10 15 21
              10 13 16 21 30 45
              """, 114)]
    public void Part1_WithExampleInput_PredictHistory(string input, int expectedResult)
    {
        var parsedInput = _day9.ParseRawInput(input);

        var result = _day9.Part1(parsedInput);

        result.ShouldBe(expectedResult);
    }
    
    [Test]
    [TestCase("""
              0 3 6 9 12 15
              1 3 6 10 15 21
              10 13 16 21 30 45
              """, 2)]
    public void Part2_WithExampleInput_PredictThePastHistory(string input, int expectedResult)
    {
        var parsedInput = _day9.ParseRawInput(input);

        var result = _day9.Part2(parsedInput);

        result.ShouldBe(expectedResult);
    }
}