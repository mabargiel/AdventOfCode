using System.Collections;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2021;

public class Day3
{
    private Days._2021.Day3 _day;

    [SetUp]
    public void Initialize()
    {
        _day = new Days._2021.Day3();
    }

    [Test]
    public void ParseRawInput_Into2dIntArray()
    {
        var rawInput = @"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010";
        var input = _day.ParseRawInput(rawInput);

        input.ShouldBe(new BitArray[]
        {
            new(new[] { false, false, true, false, false }),
            new(new[] { true, true, true, true, false }),
            new(new[] { true, false, true, true, false }),
            new(new[] { true, false, true, true, true }),
            new(new[] { true, false, true, false, true }),
            new(new[] { false, true, true, true, true }),
            new(new[] { false, false, true, true, true }),
            new(new[] { true, true, true, false, false }),
            new(new[] { true, false, false, false, false }),
            new(new[] { true, true, false, false, true }),
            new(new[] { false, false, false, true, false }),
            new(new[] { false, true, false, true, false })
        });
    }

    [Test]
    public void Part1_ExtractPowerConsumption()
    {
        var input = new BitArray[]
        {
            new(new[] { false, false, true, false, false }),
            new(new[] { true, true, true, true, false }),
            new(new[] { true, false, true, true, false }),
            new(new[] { true, false, true, true, true }),
            new(new[] { true, false, true, false, true }),
            new(new[] { false, true, true, true, true }),
            new(new[] { false, false, true, true, true }),
            new(new[] { true, true, true, false, false }),
            new(new[] { true, false, false, false, false }),
            new(new[] { true, true, false, false, true }),
            new(new[] { false, false, false, true, false }),
            new(new[] { false, true, false, true, false })
        };

        var result = _day.Part1(input);

        result.ShouldBe(198);
    }

    [Test]
    public void Part2_ExtractLifeSupport()
    {
        var input = new BitArray[]
        {
            new(new[] { false, false, true, false, false }),
            new(new[] { true, true, true, true, false }),
            new(new[] { true, false, true, true, false }),
            new(new[] { true, false, true, true, true }),
            new(new[] { true, false, true, false, true }),
            new(new[] { false, true, true, true, true }),
            new(new[] { false, false, true, true, true }),
            new(new[] { true, true, true, false, false }),
            new(new[] { true, false, false, false, false }),
            new(new[] { true, true, false, false, true }),
            new(new[] { false, false, false, true, false }),
            new(new[] { false, true, false, true, false })
        };

        var result = _day.Part2(input);

        result.ShouldBe(230);
    }
}