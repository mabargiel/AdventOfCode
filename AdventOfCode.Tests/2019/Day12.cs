using NUnit.Framework;

namespace AdventOfCode.Tests._2019;

public class Day12
{
    [Test]
    [TestCase(@"<x=-1, y=0, z=2>
<x=2, y=-10, z=-7>
<x=4, y=-8, z=8>
<x=3, y=5, z=-1>", 10, 179)]
    [TestCase(@"<x=-8, y=-10, z=0>
<x=5, y=5, z=10>
<x=2, y=-7, z=3>
<x=9, y=-8, z=-3>", 100, 1940)]
    public void Part1(string input, int timesteps, int expectedResult)
    {
        var day12 = new Days._2019._12.Day12(input, timesteps);

        Assert.That(expectedResult, Is.EqualTo(day12.Part1()));
    }

    [Test]
    [TestCase(@"<x=-1, y=0, z=2>
<x=2, y=-10, z=-7>
<x=4, y=-8, z=8>
<x=3, y=5, z=-1>", 2772)]
    [TestCase(@"<x=-8, y=-10, z=0>
<x=5, y=5, z=10>
<x=2, y=-7, z=3>
<x=9, y=-8, z=-3>", 4686774924)]
    public void Part2(string input, long expectedResult)
    {
        var day12 = new Days._2019._12.Day12(input);

        Assert.That(expectedResult, Is.EqualTo(day12.Part2()));
    }
}
