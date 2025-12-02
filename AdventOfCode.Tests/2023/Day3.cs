using AdventOfCode.Days._2023;
using AdventOfCode.Days.Common;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2023;

public class Day3
{
    private Days._2023.Day3 _day3;

    [SetUp]
    public void Initialize()
    {
        _day3 = new Days._2023.Day3();
    }

    [Test]
    public void ParseRawInput_IntoLogicalObject()
    {
        const string rawInput = """
            467..114..
            ...*......
            ..35..633.
            ......#...
            617*......
            .....+.58.
            ..592.....
            ......755.
            ...$.*....
            .664.598..
            """;

        var input = _day3.ParseRawInput(rawInput);

        input.ShouldBeEquivalentTo(
            new GondolaEngine
            {
                Numbers =
                {
                    [new Point(0, 0)] = 467,
                    [new Point(0, 5)] = 114,
                    [new Point(2, 2)] = 35,
                    [new Point(2, 6)] = 633,
                    [new Point(4, 0)] = 617,
                    [new Point(5, 7)] = 58,
                    [new Point(6, 2)] = 592,
                    [new Point(7, 6)] = 755,
                    [new Point(9, 1)] = 664,
                    [new Point(9, 5)] = 598,
                },
                Symbols =
                {
                    new Point(1, 3),
                    new Point(3, 6),
                    new Point(4, 3),
                    new Point(5, 5),
                    new Point(8, 3),
                    new Point(8, 5),
                },
                Gears = { new Point(1, 3), new Point(4, 3), new Point(8, 5) },
            }
        );
    }

    [Test]
    [TestCase(
        """
            467..114..
            ...*......
            ..35..633.
            ......#...
            617*......
            .....+.58.
            ..592.....
            ......755.
            ...$.*....
            .664.598..
            """,
        4361
    )]
    public void Part1_WithExampleInput_CalculateSumOfPartNumbers(string input, int expectedResult)
    {
        var parsedInput = _day3.ParseRawInput(input);

        var result = _day3.Part1(parsedInput);

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(
        """
            467..114..
            ...*......
            ..35..633.
            ......#...
            617*......
            .....+.58.
            ..592.....
            ......755.
            ...$.*....
            .664.598..
            """,
        467_835
    )]
    public void Part2_WithExampleInput_CalculateSumOfGearPowers(string input, int expectedResult)
    {
        var parsedInput = _day3.ParseRawInput(input);

        var result = _day3.Part2(parsedInput);

        result.ShouldBe(expectedResult);
    }
}
