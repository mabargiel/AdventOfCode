using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2024;

public class Day2
{
    private Days._2024.Day2 _day2;

    [SetUp]
    public void Initialize()
    {
        _day2 = new Days._2024.Day2();
    }

    [Test]
    [TestCase(
        """
            7 6 4 2 1
            1 2 7 8 9
            9 7 6 2 1
            1 3 2 4 5
            8 6 4 4 1
            1 3 6 7 9
            """,
        2
    )]
    public void Part1_should_count_number_of_safe_reports(string testInput, int expectedResult)
    {
        var parsedInput = _day2.ParseRawInput(testInput);

        var result = _day2.Part1(parsedInput);

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(
        """
            7 6 4 2 1
            1 2 7 8 9
            9 7 6 2 1
            1 3 2 4 5
            8 6 4 4 1
            1 3 6 7 9
            """,
        4
    )]
    public void Part2_should_calculate_similarity_score_between_two_lists(
        string testInput,
        int expectedResult
    )
    {
        var parsedInput = _day2.ParseRawInput(testInput);

        var result = _day2.Part2(parsedInput);

        result.ShouldBe(expectedResult);
    }
}
