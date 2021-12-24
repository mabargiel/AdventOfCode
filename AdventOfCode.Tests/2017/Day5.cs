using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2017;

public class Day5
{
    private Days._2017.Day5 _day;

    [SetUp]
    public void Initialize()
    {
        _day = new Days._2017.Day5();
    }

    [Test]
    public void ParseRawInput_IntoIntArray()
    {
        const string rawInput = "1\n10\n-3\n99\n-47";

        var input = _day.ParseRawInput(rawInput);

        input.ShouldBe(new[] { 1, 10, -3, 99, -47 });
    }

    [Test]
    public void Part1_EscapeTheMaze_CalculateSteps()
    {
        var input = new[] { 0, 3, 0, 1, -3 };

        var result = _day.Part1(input);

        result.ShouldBe(5);
    }

    [Test]
    public void Part2_EscapeTheMaze_CalculateSteps()
    {
        var input = new[] { 0, 3, 0, 1, -3 };

        var result = _day.Part2(input);

        result.ShouldBe(10);
    }
}