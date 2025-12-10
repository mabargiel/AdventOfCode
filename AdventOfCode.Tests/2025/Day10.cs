using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2025;

public class Day10
{
    private Days._2025.Day10 _day10;

    [SetUp]
    public void Initialize()
    {
        _day10 = new Days._2025.Day10();
    }

    [Test]
    [TestCase(
        """
            [.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}
            [...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}
            [.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}
            """,
        7
    )]
    public void Part1_should_find_smallest_number_of_button_presses_to_configure_indicators(
        string testInput,
        int expectedResult
    )
    {
        var parsedInput = _day10.ParseRawInput(testInput);

        var result = _day10.Part1(parsedInput);

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(
        """
            [.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}
            [...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}
            [.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}
            """,
        33
    )]
    public void Part2_should_find_smallest_number_of_button_presses_to_configure_joltage(
        string testInput,
        int expectedResult
    )
    {
        var parsedInput = _day10.ParseRawInput(testInput);

        var result = _day10.Part2(parsedInput);

        result.ShouldBe(expectedResult);
    }
}
