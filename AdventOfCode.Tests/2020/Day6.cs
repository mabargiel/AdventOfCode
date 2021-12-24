using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2020;

public class Day6
{
    [Test]
    public void Part1()
    {
        const string input = @"abc

a
b
c

ab
ac

a
a
a
a

b";
        var d6 = new Days._2020._6.Day6(input);
        var result = d6.Part1();

        result.ShouldBe(11);
    }

    [Test]
    public void Part2()
    {
        const string input = @"abc

a
b
c

ab
ac

a
a
a
a

b";
        var d6 = new Days._2020._6.Day6(input);
        var result = d6.Part2();

        result.ShouldBe(6);
    }
}