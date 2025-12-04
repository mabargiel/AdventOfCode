using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2025;

public class Day4
{
    private Days._2025.Day4 _day4;

    [SetUp]
    public void Initialize()
    {
        _day4 = new Days._2025.Day4();
    }

    [Test]
    [TestCase(
        """
            ..@@.@@@@.
            @@@.@.@.@@
            @@@@@.@.@@
            @.@@@@..@.
            @@.@@@@.@@
            .@@@@@@@.@
            .@.@.@.@@@
            @.@@@.@@@@
            .@@@@@@@@.
            @.@.@@@.@.
            """,
        13
    )]
    public void Part1_should_count_accessible_paper_rolls(string testInput, int expectedResult)
    {
        var parsedInput = _day4.ParseRawInput(testInput);

        var result = _day4.Part1(parsedInput);

        result.ShouldBe(expectedResult);
    }

    [TestCase(
        """
            ..@@.@@@@.
            @@@.@.@.@@
            @@@@@.@.@@
            @.@@@@..@.
            @@.@@@@.@@
            .@@@@@@@.@
            .@.@.@.@@@
            @.@@@.@@@@
            .@@@@@@@@.
            @.@.@@@.@.
            """,
        43
    )]
    public void Part2_should_count_accessible_paper_rolls_after_removing_previous_accessible_rolls(
        string testInput,
        int expectedResult
    )
    {
        var parsedInput = _day4.ParseRawInput(testInput);

        var result = _day4.Part2(parsedInput);

        result.ShouldBe(expectedResult);
    }
}
