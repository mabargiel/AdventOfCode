using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2025;

public class Day6
{
    private Days._2025.Day6 _day6;

    [SetUp]
    public void Initialize()
    {
        _day6 = new Days._2025.Day6();
    }

    [Test]
    [TestCase(
        """
            123 328  51 64 
             45 64  387 23 
              6 98  215 314
            *   +   *   +  
            """,
        4277556
    )]
    public void Part1_should_sum_math_problem_solutions(string testInput, int expectedResult)
    {
        var parsedInput = _day6.ParseRawInput(testInput);

        var result = _day6.Part1(parsedInput);

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(
        """
            123 328  51 64 
             45 64  387 23 
              6 98  215 314
            *   +   *   +  
            """,
        3263827
    )]
    public void Part2_should_sum_math_problem_solutions_right_to_left(
        string testInput,
        int expectedResult
    )
    {
        var parsedInput = _day6.ParseRawInput(testInput);

        var result = _day6.Part2(parsedInput);

        result.ShouldBe(expectedResult);
    }
}
