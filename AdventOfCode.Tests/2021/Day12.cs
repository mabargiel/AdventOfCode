using System.Collections.Generic;
using AdventOfCode.Days._2021;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2021;

public class Day12 : AdventDayTest<Days._2021.Day12>
{
    [Test]
    public override void ParseRawInputTest()
    {
        const string rawInput = @"start-A
start-b
A-c
A-b
b-d
A-end
b-end";

        var input = _day.ParseRawInput(rawInput);

        input.ShouldBe(rawInput);
    }

    [Test]
    [TestCase(@"start-A
start-b
A-c
A-b
b-d
A-end
b-end", 10)]
    [TestCase(@"dc-end
HN-start
start-kj
dc-start
dc-HN
LN-dc
HN-end
kj-sa
kj-HN
kj-dc", 19)]
    [TestCase(@"fs-end
he-DX
fs-he
start-DX
pj-DX
end-zg
zg-sl
zg-pj
pj-he
RW-he
fs-DX
pj-RW
zg-RW
start-pj
he-WI
zg-he
pj-fs
start-RW", 226)]
    public void Part1_FindUniquePathsCount(string input, int expectedResult)
    {
        var result = _day.Part1(input);

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(@"start-A
start-b
A-c
A-b
b-d
A-end
b-end", 36)]
    [TestCase(@"dc-end
HN-start
start-kj
dc-start
dc-HN
LN-dc
HN-end
kj-sa
kj-HN
kj-dc", 103)]
    [TestCase(@"fs-end
he-DX
fs-he
start-DX
pj-DX
end-zg
zg-sl
zg-pj
pj-he
RW-he
fs-DX
pj-RW
zg-RW
start-pj
he-WI
zg-he
pj-fs
start-RW", 3509)]
    public void Part2_FindUniquePathsWithVisitingSmallCaveTwiceCount(string input, int expectedResult)
    {
        var result = _day.Part2(input);

        result.ShouldBe(expectedResult);
    }
}