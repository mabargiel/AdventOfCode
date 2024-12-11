using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2024;

public class Day3
{
    private Days._2024.Day3 _day3;

    [SetUp]
    public void Initialize()
    {
        _day3 = new Days._2024.Day3();
    }

    [Test]
    [TestCase("xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))", 161)]
    public void Part1_should_parse_corrupted_memory_and_return_sum_of_multiplications(string testInput, int expectedResult)
    {
        var result = _day3.Part1(testInput);

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))", 48)]
    [TestCase("xmul(2,4)&do()mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5)do()mul(1,1)do()mul(1,1)", 50)]
    public void Part2_should_parse_corrupted_memory_and_return_sum_of_multiplications_with_enablements(string testInput, int expectedResult)
    {
        var result = _day3.Part2(testInput);

        result.ShouldBe(expectedResult);
    }
}
