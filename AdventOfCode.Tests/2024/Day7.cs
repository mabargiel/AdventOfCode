using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2024;

public class Day7
{
    private Days._2024.Day7 _day7;

    [SetUp]
    public void Initialize()
    {
        _day7 = new Days._2024.Day7();
    }

    [Test]
    [TestCase(
        """
            190: 10 19
            3267: 81 40 27
            83: 17 5
            156: 15 6
            7290: 6 8 6 15
            161011: 16 10 13
            192: 17 8 14
            21037: 9 7 18 13
            292: 11 6 16 20
            """,
        3749
    )]
    public void Part1_returns_sum_of_possible_test_values(string testInput, int expectedResult)
    {
        var result = _day7.Part1(_day7.ParseRawInput(testInput));

        result.ShouldBe(expectedResult);
    }
}
