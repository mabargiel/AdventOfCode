using AdventOfCode.Days._2022;
using AdventOfCode.Days.Common;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2022;

public class Day12 : AdventDayTest<Days._2022.Day12>
{
    [Test]
    public override void ParseRawInputTest()
    {
        const string exampleInput = @"Sabqponm
abcryxxl
accszExk
acctuvwj
abdefghi";

        var input = _day.ParseRawInput(exampleInput);

        input.ShouldBeEquivalentTo(new Input(new Point(0, 0), new Point(2, 5), new[,]
        {
            { 1, 1, 2, 17, 16, 15, 14, 13 },
            { 1, 2, 3, 18, 25, 24, 24, 12 },
            { 1, 3, 3, 19, 26, 26, 24, 11 },
            { 1, 3, 3, 20, 21, 22, 23, 10 },
            { 1, 2, 4, 5, 6, 7, 8, 9 }
        }));
    }

    [Test]
    public void Part1_WithExampleInput_FindShortestPath()
    {
        var input = new Input(new Point(0, 0), new Point(2, 5), new[,]
        {
            { 1, 1, 2, 17, 16, 15, 14, 13 },
            { 1, 2, 3, 18, 25, 24, 24, 12 },
            { 1, 3, 3, 19, 26, 26, 24, 11 },
            { 1, 3, 3, 20, 21, 22, 23, 10 },
            { 1, 2, 4, 5, 6, 7, 8, 9 }
        });

        var result = _day.Part1(input);

        result.ShouldBe(31);
    }

    [Test]
    public void Part2_WithExampleInput_FindShortestPathFroma()
    {
        var input = new Input(new Point(0, 0), new Point(2, 5), new[,]
        {
            { 1, 1, 2, 17, 16, 15, 14, 13 },
            { 1, 2, 3, 18, 25, 24, 24, 12 },
            { 1, 3, 3, 19, 26, 26, 24, 11 },
            { 1, 3, 3, 20, 21, 22, 23, 10 },
            { 1, 2, 4, 5, 6, 7, 8, 9 }
        });

        var result = _day.Part2(input);

        result.ShouldBe(29);
    }
}