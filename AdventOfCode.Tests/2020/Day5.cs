using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2020;

public class Day5
{
    [Test]
    public void Part1()
    {
        const string input =
            @"BFFFBBFRRR
FFFBBBFRRR
BBFFBBFRLL";

        var d5 = new Days._2020._5.Day5(input);
        var result = d5.Part1();

        result.ShouldBe(820);
    }
}
