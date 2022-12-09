using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2022;

public class Day1
{
    private Days._2022.Day1 _day1;

    [SetUp]
    public void Initialize()
    {
        _day1 = new Days._2022.Day1();
    }

    [Test]
    public void ParseRawInput_Into2dIntArray()
    {
        const string rawInput = "1000\n2000\n\n3000\n4000";

        var input = _day1.ParseRawInput(rawInput);

        input.ShouldBe(new[] { new[] { 1000, 2000 }, new[] { 3000, 4000 } });
    }

    [Test]
    [TestCase("1000\n2000\n3000\n\n4000\n\n5000\n6000\n\n7000\n8000\n9000\n\n10000")]
    public void Part1_WithExampleInput_FindElfWithMostCalories(string input)
    {
        var parsedInput = _day1.ParseRawInput(input);

        var result = _day1.Part1(parsedInput);

        result.ShouldBe(24_000);
    }

    [Test]
    [TestCase("1000\n2000\n3000\n\n4000\n\n5000\n6000\n\n7000\n8000\n9000\n\n10000")]
    public void Part1_WithExampleInput_FindTop3ElfsWithMostCalories(string input)
    {
        var parsedInput = _day1.ParseRawInput(input);

        var result = _day1.Part2(parsedInput);

        result.ShouldBe(45_000);
    }
}