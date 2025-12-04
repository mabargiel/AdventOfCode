using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2025;

public class Day3
{
    private Days._2025.Day3 _day3;

    [SetUp]
    public void Initialize()
    {
        _day3 = new Days._2025.Day3();
    }

    [Test]
    [TestCase(
        """
            987654321111111
            811111111111119
            234234234234278
            818181911112111
            """,
        357
    )]
    public void Part1_should_sum_joltage_2_batteries(string testInput, int expectedResult)
    {
        var parsedInput = _day3.ParseRawInput(testInput);

        var result = _day3.Part1(parsedInput);

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(
        """
            987654321111111
            811111111111119
            234234234234278
            818181911112111
            """,
        3121910778619
    )]
    [TestCase(
        """
            987654321111111
            811111111111119
            234234234234278
            818181911112111999999999999
            """,
        3232999666507
    )]
    [TestCase(
        """
            987654321111111
            811111111111119
            234234234234278
            818181911112000
            """,
        3121910778508
    )]
    public void Part2_should_sum_joltage_12_batteries(string testInput, long expectedResult)
    {
        var parsedInput = _day3.ParseRawInput(testInput);

        var result = _day3.Part2(parsedInput);

        result.ShouldBe(expectedResult);
    }
}
