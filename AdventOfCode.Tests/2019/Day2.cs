using NUnit.Framework;

namespace AdventOfCode.Tests._2019;

public class Day2
{
    [Test]
    public void Part1()
    {
        var input = new long[] { 1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50 };
        var d2 = new Days._2019.Day2();

        Assert.AreEqual(3500, d2.Part1(input));
    }

    [Test]
    public void Part2()
    {
        var input = new long[] { 3500, 1, 1, 2, 3, 2, 3, 11, 0, 99, 30, 40, 50 };
        var d2 = new Days._2019.Day2();

        Assert.AreEqual(100 * 9 + 10, d2.Part2(input));
    }
}