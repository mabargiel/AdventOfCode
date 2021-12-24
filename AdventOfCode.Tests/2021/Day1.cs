using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2021;

public class Day1
{
    [Test]
    public void ParseRawInput_IntoIntArray()
    {
        const string rawInput = "100\n101\n110\n900";

        var input = new Days._2021.Day1().ParseRawInput(rawInput);

        input.ShouldBe(new[] { 100, 101, 110, 900 });
    }

    [Test]
    public void Part1_WithExampleInput_ShouldIncrease7Times()
    {
        int[] input = { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
        var day = new Days._2021.Day1();

        var result = day.Part1(input);

        result.ShouldBe(7);
    }

    [Test]
    public void Part2_WithExampleInput_ShouldIncrease5Times()
    {
        int[] input = { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
        var day = new Days._2021.Day1();

        var result = day.Part2(input);

        result.ShouldBe(5);
    }
}