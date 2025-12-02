using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2017;

public class Day2
{
    private Days._2017.Day2 _day;

    [SetUp]
    public void Initialize()
    {
        _day = new Days._2017.Day2();
    }

    [Test]
    public void ParseRawInput_IntoIntMatrix()
    {
        const string rawInput = "5\t1\t9\t5\n7\t5\t3\n2\t4\t6\t8";

        var input = _day.ParseRawInput(rawInput);

        input.ShouldBe(new[] { new[] { 5, 1, 9, 5 }, new[] { 7, 5, 3 }, new[] { 2, 4, 6, 8 } });
    }

    [Test]
    public void Part1_CalculateChecksum()
    {
        var input = new[] { new[] { 5, 1, 9, 5 }, new[] { 7, 5, 3 }, new[] { 2, 4, 6, 8 } };

        var result = _day.Part1(input);

        result.ShouldBe(18);
    }

    [Test]
    public void Part2_CalculateChecksum()
    {
        var input = new[] { new[] { 5, 9, 2, 8 }, new[] { 9, 4, 7, 3 }, new[] { 3, 8, 6, 5 } };

        var result = _day.Part2(input);

        result.ShouldBe(9);
    }
}
