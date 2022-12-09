using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2021;

public class Day7 : AdventDayTest<Days._2021.Day7>
{
    [Test]
    public override void ParseRawInputTest()
    {
        const string rawInput = @"16,1,2,0,4,2,7,1,2,14";

        var input = _day.ParseRawInput(rawInput);

        input.ShouldBe(new[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 });
    }

    [Test]
    public void Part1_FindTheCheapestWayToAlignCrabs()
    {
        var input = new[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };

        var result = _day.Part1(input);

        result.ShouldBe(37);
    }

    [Test]
    public void Part2_FindTheCheapestWayToAlignCrabs()
    {
        var input = new[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };

        var result = _day.Part2(input);

        result.ShouldBe(168);
    }
}