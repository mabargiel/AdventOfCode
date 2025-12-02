using AdventOfCode.Days._2023;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2023;

public class Day6
{
    private Days._2023.Day6 _day6;

    [SetUp]
    public void Initialize()
    {
        _day6 = new Days._2023.Day6();
    }

    [Test]
    public void ParseRawInput_IntoLogicalObject()
    {
        const string rawInput = """
            Time:      7  15   30
            Distance:  9  40  200
            """;

        var input = _day6.ParseRawInput(rawInput);

        input.ShouldBe(new Race[] { new(7, 9), new(15, 40), new(30, 200) });
    }

    [Test]
    [TestCase(
        """
            Time:      7  15   30
            Distance:  9  40  200
            """,
        288
    )]
    public void Part1_WithExampleInput_CalculateWaysOfAllRaces(string input, int expectedResult)
    {
        var parsedInput = _day6.ParseRawInput(input);

        var result = _day6.Part1(parsedInput);

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(
        """
            Time:      7  15   30
            Distance:  9  40  200
            """,
        71503
    )]
    public void Part2_WithExampleInput_CalculateAllWaysOfSingleRace(
        string input,
        int expectedResult
    )
    {
        var parsedInput = _day6.ParseRawInput(input);

        var result = _day6.Part2(parsedInput);

        result.ShouldBe(expectedResult);
    }
}
