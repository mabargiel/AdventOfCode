using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2017;

public class Day3
{
    private Days._2017.Day3 _day;

    [SetUp]
    public void Initialize()
    {
        _day = new Days._2017.Day3();
    }

    [Test]
    public void ParseRawInput_IntoInt()
    {
        const string rawInput = "999";

        var input = _day.ParseRawInput(rawInput);

        input.ShouldBe(999);
    }

    [Test]
    [TestCase(1, 0)]
    [TestCase(12, 3)]
    [TestCase(23, 2)]
    [TestCase(1024, 31)]
    public void Part1_CalculateDistanceInSpiral(int input, int expectedResult)
    {
        var result = _day.Part1(input);

        result.ShouldBe(expectedResult);
    }

    [Test]
    public void Part2_CalculateFirstLargerValueThenInputInSpiral()
    {
        var result = _day.Part2(748);

        result.ShouldBe(806);
    }
}