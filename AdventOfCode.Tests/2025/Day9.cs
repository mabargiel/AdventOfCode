using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2025;

public class Day9
{
    private Days._2025.Day9 _day9;

    [SetUp]
    public void Initialize()
    {
        _day9 = new Days._2025.Day9();
    }

    [Test]
    [TestCase(
        """
            7,1
            11,1
            11,7
            9,7
            9,5
            2,5
            2,3
            7,3
            """,
        50
    )]
    public void Part1_should_find_the_biggest_rectangle_using_red_corners(
        string testInput,
        int expectedResult
    )
    {
        var parsedInput = _day9.ParseRawInput(testInput);

        var result = _day9.Part1(parsedInput);

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(
        """
            7,1
            11,1
            11,7
            9,7
            9,5
            2,5
            2,3
            7,3
            """,
        24
    )]
    public void Part2_should_find_the_biggest_rectangle_with_red_and_green_tiles(
        string testInput,
        int expectedResult
    )
    {
        var parsedInput = _day9.ParseRawInput(testInput);

        var result = _day9.Part2(parsedInput);

        result.ShouldBe(expectedResult);
    }
}
