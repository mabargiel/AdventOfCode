using System.Linq;
using NUnit.Framework;

namespace AdventOfCode.Tests._2019;

public class Day3
{
    [Test]
    [TestCase(new object[] { "R8", "U5", "L5", "D3" }, new object[] { "U7", "R6", "D4", "L4" }, 6)]
    [TestCase(new object[] { "R75", "D30", "R83", "U83", "L12", "D49", "R71", "U7", "L72" },
        new object[] { "U62", "R66", "U55", "R34", "D71", "R55", "D58", "R83" },
        159)]
    [TestCase(new object[] { "R98", "U47", "R26", "D63", "R33", "U87", "L62", "D20", "R33", "U53", "R51" },
        new object[] { "U98", "R91", "D20", "R16", "D67", "R40", "U7", "R15", "U6", "R7" }, 135)]
    public void Part1(object[] wire1, object[] wire2, int expectedDistance)
    {
        var d3 = new Days._2019.Day3();
        Assert.That(expectedDistance, Is.EqualTo(d3.Part1((wire1.Cast<string>().ToArray(), wire2.Cast<string>().ToArray()))));
    }

    [Test]
    [TestCase(new object[] { "R8", "U5", "L5", "D3" }, new object[] { "U7", "R6", "D4", "L4" }, 30)]
    [TestCase(new object[] { "R75", "D30", "R83", "U83", "L12", "D49", "R71", "U7", "L72" },
        new object[] { "U62", "R66", "U55", "R34", "D71", "R55", "D58", "R83" },
        610)]
    [TestCase(new object[] { "R98", "U47", "R26", "D63", "R33", "U87", "L62", "D20", "R33", "U53", "R51" },
        new object[] { "U98", "R91", "D20", "R16", "D67", "R40", "U7", "R15", "U6", "R7" }, 410)]
    public void Part2(object[] wire1, object[] wire2, int expectedDistance)
    {
        var d3 = new Days._2019.Day3();

        Assert.That(expectedDistance, Is.EqualTo(d3.Part2((wire1.Cast<string>().ToArray(), wire2.Cast<string>().ToArray()))));
    }
}
