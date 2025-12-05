using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2025;

public class Day5
{
    private Days._2025.Day5 _day5;

    [SetUp]
    public void Initialize()
    {
        _day5 = new Days._2025.Day5();
    }

    [Test]
    [TestCase(
        """
            3-5
            10-14
            16-20
            12-18

            1
            5
            8
            11
            17
            32
            """,
        3
    )]
    public void Part1_should_count_fresh_ingredients(string testInput, int expectedResult)
    {
        var parsedInput = _day5.ParseRawInput(testInput);

        var result = _day5.Part1(parsedInput);

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(
        """
            3-5
            10-14
            16-20
            12-18

            1
            5
            8
            11
            17
            32
            """,
        14
    )]
    public void Part1_should_count_possible_fresh_ingredients(string testInput, int expectedResult)
    {
        var parsedInput = _day5.ParseRawInput(testInput);

        var result = _day5.Part2(parsedInput);

        result.ShouldBe(expectedResult);
    }
}
