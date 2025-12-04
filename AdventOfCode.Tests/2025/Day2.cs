using System.Linq;
using AdventOfCode.Days;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2025;

public class Day2
{
    private Days._2025.Day2 _day2;

    [SetUp]
    public void Initialize()
    {
        _day2 = new Days._2025.Day2();
    }

    [Test]
    [TestCase(
        """
            11-22,95-115,998-1012,1188511880-1188511890,222220-222224,
            1698522-1698528,446443-446449,38593856-38593862,565653-565659,
            824824821-824824827,2121212118-2121212124
            """,
        1227775554
    )]
    public void Part1_should_sum_all_invalid_ids(string testInput, int expectedResult)
    {
        var parsedInput = _day2.ParseRawInput(testInput);

        var result = _day2.Part1(parsedInput);

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(
        """
            11-22,95-115,998-1012,1188511880-1188511890,222220-222224,
            1698522-1698528,446443-446449,38593856-38593862,565653-565659,
            824824821-824824827,2121212118-2121212124
            """,
        4174379265L
    )]
    public void Part2_should_sum_all_invalid_ids_with_at_least_one_double_sequence(
        string testInput,
        long expectedResult
    )
    {
        var parsedInput = _day2.ParseRawInput(testInput);

        var result = _day2.Part2(parsedInput);

        result.ShouldBe(expectedResult);
    }
}
