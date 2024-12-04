using NUnit.Framework;

namespace AdventOfCode.Tests._2019;

public class Day6
{
    [Test]
    [TestCase(new[] { "COM)B", "B)C", "C)D", "D)E", "E)F", "B)G", "G)H", "D)I", "E)J", "J)K", "K)L" }, 42)]
    public void Part1(string[] map, int expectedOrbits)
    {
        var d6 = new Days._2019._6.Day6(map);

        Assert.That(expectedOrbits, Is.EqualTo(d6.Part1()));
    }

    [Test]
    [TestCase(
        new[] { "COM)B", "B)C", "C)D", "D)E", "E)F", "B)G", "G)H", "D)I", "E)J", "J)K", "K)L", "K)YOU", "I)SAN" },
        4)]
    public void Part2(string[] map, int expectedTransfers)
    {
        var d6 = new Days._2019._6.Day6(map);

        Assert.That(expectedTransfers, Is.EqualTo(d6.Part2()));
    }
}
