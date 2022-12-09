using NUnit.Framework;

namespace AdventOfCode.Tests._2019;

public class Day1
{
    [Test]
    public void Part1()
    {
        var d1 = new Days._2019.Day1();

        Assert.AreEqual(2 + 2 + 654 + 33583, d1.Part1(new[] { 12, 14, 1969, 100756 }));
    }

    [Test]
    public void Part2()
    {
        var d1 = new Days._2019.Day1();

        Assert.AreEqual(966 + 50346, d1.Part2(new[] { 1969, 100756 }));
    }
}