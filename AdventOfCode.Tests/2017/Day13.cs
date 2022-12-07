using System.Collections.Generic;
using System.Collections.Immutable;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2017;

public class Day13 : AdventDayTest<Days._2017.Day13>
{
    private static object[] _inputs =
    {
        new object[]
        {
            new Dictionary<int, int>
            {
                { 0, 3 },
                { 1, 2 },
                { 4, 4 },
                { 6, 4 }
            },
            24
        },
        new object[]
        {
            new Dictionary<int, int>
            {
                { 0, 3 },
                { 1, 2 },
                { 4, 4 },
                { 6, 4 },
                { 8, 3 },
                { 12, 4 },
                { 16, 3 },
                { 18, 4 }
            },
            0 * 3 + 6 * 4 + 8 * 3 + 12 * 4 + 16 * 3 + 18 * 4
        }
    };

    [Test]
    public override void ParseRawInputTest()
    {
        const string rawInput = @"0: 3
1: 2
4: 4
6: 4";
        var input = _day.ParseRawInput(rawInput);

        input.Count.ShouldBe(4);
        input[0].ShouldBe(3);
        input[1].ShouldBe(2);
        input[4].ShouldBe(4);
        input[6].ShouldBe(4);
    }

    [Test]
    [TestCaseSource(nameof(_inputs))]
    public void Part1_CalculateTripSeverity(Dictionary<int, int> input, int expectedResult)
    {
        var result = _day.Part1(input.ToImmutableDictionary());

        result.ShouldBe(expectedResult);
    }

    [Test]
    public void Part2_CalculateDelayToBeNotCaught()
    {
        var input = new Dictionary<int, int>
        {
            { 0, 3 },
            { 1, 2 },
            { 4, 4 },
            { 6, 4 }
        }.ToImmutableDictionary();

        var result = _day.Part2(input);

        result.ShouldBe(10);
    }
}