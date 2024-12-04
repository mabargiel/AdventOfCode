using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2024;

public class Day1
{
    private Days._2024.Day1 _day1;

    [SetUp]
    public void Initialize()
    {
        _day1 = new Days._2024.Day1();
    }

    [Test]
    [TestCase("""
              3   4
              4   3
              2   5
              1   3
              3   9
              3   3
              """, 11)]
    public void Part1_should_return_sum_of_distances_between_smallest_numbers_in_order(string testInput, int expectedResult)
    {
        var parsedInput = _day1.ParseRawInput(testInput);

        var result = _day1.Part1(parsedInput);

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase("""
              3   4
              4   3
              2   5
              1   3
              3   9
              3   3
              """, 31)]
    public void Part2_should_calculate_similarity_score_between_two_lists(string testInput, int expectedResult)
    {
        var parsedInput = _day1.ParseRawInput(testInput);

        var result = _day1.Part2(parsedInput);

        result.ShouldBe(expectedResult);
    }
}
