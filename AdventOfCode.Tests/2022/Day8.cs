using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2022;

public class Day8
{
    private Days._2022.Day8 _day8;

    [SetUp]
    public void Initialize()
    {
        _day8 = new Days._2022.Day8();
    }

    [Test]
    public void ParseRawInput_WithExampleInput_SplitsItIntoAGridOfHeights()
    {
        var rawInput =
            @"30373
25512
65332
33549
35390";

        var input = _day8.ParseRawInput(rawInput);
        input.ShouldBe(
            new[,]
            {
                { 3, 0, 3, 7, 3 },
                { 2, 5, 5, 1, 2 },
                { 6, 5, 3, 3, 2 },
                { 3, 3, 5, 4, 9 },
                { 3, 5, 3, 9, 0 },
            }
        );
    }

    [Test]
    public void Part1_WithExampleInput_CountVisibleTrees()
    {
        var input = new[,]
        {
            { 3, 0, 3, 7, 3 },
            { 2, 5, 5, 1, 2 },
            { 6, 5, 3, 3, 2 },
            { 3, 3, 5, 4, 9 },
            { 3, 5, 3, 9, 0 },
        };

        var result = _day8.Part1(input);

        result.ShouldBe(21);
    }

    [Test]
    public void Part1_WithExampleSquareInput_FindBestSpotToBuildAHouse()
    {
        var input = new[,]
        {
            { 3, 0, 3, 7, 3 },
            { 2, 5, 5, 1, 2 },
            { 6, 5, 3, 3, 2 },
            { 3, 3, 5, 4, 9 },
            { 3, 5, 3, 9, 0 },
        };

        var result = _day8.Part2(input);

        result.ShouldBe(8);
    }

    [Test]
    public void Part1_WithExampleInput_FindBestSpotToBuildAHouse()
    {
        var input = new[,]
        {
            { 9, 8, 7, 6, 5, 4 },
            { 8, 5, 5, 1, 2, 2 },
            { 7, 5, 3, 3, 2, 8 },
            { 6, 3, 5, 4, 9, 1 },
            { 5, 5, 3, 9, 0, 7 },
        };

        var result = _day8.Part2(input);

        result.ShouldBe(12);
    }
}
