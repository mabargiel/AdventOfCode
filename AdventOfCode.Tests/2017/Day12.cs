using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2017;

public class Day12 : AdventDayTest<Days._2017.Day12>
{
    [Test]
    public override void ParseRawInputTest()
    {
        var rawInput =
            @"0 <-> 2
1 <-> 1
2 <-> 0, 3, 4
3 <-> 2, 4
4 <-> 2, 3, 6
5 <-> 6
6 <-> 4, 5";

        var input = _day.ParseRawInput(rawInput);

        input[0].ShouldBe(new[] { 2 });
        input[1].ShouldBe(new[] { 1 });
        input[2].ShouldBe(new[] { 0, 3, 4 });
        input[3].ShouldBe(new[] { 2, 4 });
        input[4].ShouldBe(new[] { 2, 3, 6 });
        input[5].ShouldBe(new[] { 6 });
        input[6].ShouldBe(new[] { 4, 5 });
    }

    [Test]
    public void Part1_CountProgramsNotConnectedToProgram0()
    {
        var input = new Dictionary<int, int[]>
        {
            [0] = new[] { 2 },
            [1] = new[] { 7 },
            [2] = new[] { 0, 3, 4 },
            [3] = new[] { 2, 4 },
            [4] = new[] { 2, 3, 6 },
            [5] = new[] { 6 },
            [6] = new[] { 4, 5 },
            [7] = new[] { 1, 8 },
            [8] = new[] { 7, 1, 9 },
            [9] = new[] { 7, 8 },
        };

        var result = _day.Part1(input);

        result.ShouldBe(6);
    }

    [Test]
    public void Part2_CountProgramGroups()
    {
        var input = new Dictionary<int, int[]>
        {
            [0] = new[] { 2 },
            [1] = new[] { 7 },
            [2] = new[] { 0, 3, 4 },
            [3] = new[] { 2, 4 },
            [4] = new[] { 2, 3, 6 },
            [5] = new[] { 6 },
            [6] = new[] { 4, 5 },
            [7] = new[] { 1, 8 },
            [8] = new[] { 7, 1, 9 },
            [9] = new[] { 7, 8 },
        };

        var result = _day.Part2(input);

        result.ShouldBe(2);
    }
}
