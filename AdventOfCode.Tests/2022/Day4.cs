using System;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2022;

public class Day4
{
    private Days._2022.Day4 _day4;

    [SetUp]
    public void Initialize()
    {
        _day4 = new Days._2022.Day4();
    }

    [Test]
    public void ParseRawInput_WithExampleInput_SplitsItIntoPairsOfRanges()
    {
        const string rawInput = @"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8";

        var input = _day4.ParseRawInput(rawInput);

        input.ShouldBe(new[]
        {
            new Range[] { new(2, 4), new(6, 8) },
            new Range[] { new(2, 3), new(4, 5) },
            new Range[] { new(5, 7), new(7, 9) },
            new Range[] { new(2, 8), new(3, 7) },
            new Range[] { new(6, 6), new(4, 6) },
            new Range[] { new(2, 6), new(4, 8) }
        });
    }

    [Test]
    public void Part1_WithExampleInput_ReturnsNumberOfFullyOverlappingPairs()
    {
        var input = new[]
        {
            new Range[] { new(2, 4), new(6, 8) },
            new Range[] { new(2, 3), new(4, 5) },
            new Range[] { new(5, 7), new(7, 9) },
            new Range[] { new(2, 8), new(3, 7) },
            new Range[] { new(6, 6), new(4, 6) },
            new Range[] { new(2, 6), new(4, 8) }
        };

        var result = _day4.Part1(input);

        result.ShouldBe(2);
    }

    [Test]
    public void Part2_WithExampleInput_ReturnsNumberOfOverlappingPairs()
    {
        var input = new[]
        {
            new Range[] { new(2, 4), new(6, 8) },
            new Range[] { new(2, 3), new(4, 5) },
            new Range[] { new(5, 7), new(7, 9) },
            new Range[] { new(2, 8), new(3, 7) },
            new Range[] { new(6, 6), new(4, 6) },
            new Range[] { new(2, 6), new(4, 8) }
        };

        var result = _day4.Part2(input);

        result.ShouldBe(4);
    }
}