using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2021;

public class Day9 : AdventDayTest<Days._2021.Day9>
{
    [Test]
    public override void ParseRawInputTest()
    {
        const string rawInput =
            @"2199943210
3987894921
9856789892
8767896789
9899965678";

        var input = _day.ParseRawInput(rawInput);

        input.ShouldBe(
            new[,]
            {
                { 2, 1, 9, 9, 9, 4, 3, 2, 1, 0 },
                { 3, 9, 8, 7, 8, 9, 4, 9, 2, 1 },
                { 9, 8, 5, 6, 7, 8, 9, 8, 9, 2 },
                { 8, 7, 6, 7, 8, 9, 6, 7, 8, 9 },
                { 9, 8, 9, 9, 9, 6, 5, 6, 7, 8 },
            }
        );
    }

    [Test]
    public void Part1_CalculateLowPoints()
    {
        var input = new[,]
        {
            { 2, 1, 9, 9, 9, 4, 3, 2, 1, 0 },
            { 3, 9, 8, 7, 8, 9, 4, 9, 2, 1 },
            { 9, 8, 5, 6, 7, 8, 9, 8, 9, 2 },
            { 8, 7, 6, 7, 8, 9, 6, 7, 8, 9 },
            { 9, 8, 9, 9, 9, 6, 5, 6, 7, 8 },
        };

        var result = _day.Part1(input);

        result.ShouldBe(15);
    }

    [Test]
    public void Part2_CalculateBasinsSize()
    {
        var input = new[,]
        {
            { 2, 1, 9, 9, 9, 4, 3, 2, 1, 0 },
            { 3, 9, 8, 7, 8, 9, 4, 9, 2, 1 },
            { 9, 8, 5, 6, 7, 8, 9, 8, 9, 2 },
            { 8, 7, 6, 7, 8, 9, 6, 7, 8, 9 },
            { 9, 8, 9, 9, 9, 6, 5, 6, 7, 8 },
        };

        var result = _day.Part2(input);

        result.ShouldBe(1134);
    }
}
