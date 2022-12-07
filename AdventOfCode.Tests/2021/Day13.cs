using System;
using System.Collections.Generic;
using AdventOfCode.Days._2021;
using AdventOfCode.Days.Common;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2021;

public class Day13 : AdventDayTest<Days._2021.Day13>
{
    [Test]
    public override void ParseRawInputTest()
    {
        const string rawInput = @"6,10
0,14
9,10
0,3
10,4
4,11
6,0
6,12
4,1
0,13
10,12
3,4
3,0
8,4
1,10
2,14
8,10
9,0

fold along y=7
fold along x=5";

        var (transparentPaper, instructions) = _day.ParseRawInput(rawInput);

        transparentPaper.ShouldBeEquivalentTo(new List<Point>
        {
            new(6, 10),
            new(0, 14),
            new(9, 10),
            new(0, 3),
            new(10, 4),
            new(4, 11),
            new(6, 0),
            new(6, 12),
            new(4, 1),
            new(0, 13),
            new(10, 12),
            new(3, 4),
            new(3, 0),
            new(8, 4),
            new(1, 10),
            new(2, 14),
            new(8, 10),
            new(9, 0)
        });

        instructions.ShouldBeEquivalentTo(new FoldInstruction[]
        {
            new(Axis.Y, 7),
            new(Axis.X, 5)
        });
    }

    [Test]
    public void Part1_FoldPaperOnceAndCountDots()
    {
        var paper = new List<Point>
        {
            new(6, 10),
            new(0, 14),
            new(9, 10),
            new(0, 3),
            new(10, 4),
            new(4, 11),
            new(6, 0),
            new(6, 12),
            new(4, 1),
            new(0, 13),
            new(10, 12),
            new(3, 4),
            new(3, 0),
            new(8, 4),
            new(1, 10),
            new(2, 14),
            new(8, 10),
            new(9, 0)
        };

        var instructions = new FoldInstruction[]
        {
            new(Axis.Y, 7),
            new(Axis.X, 5)
        };

        var result = _day.Part1(new Manual(paper, instructions));

        result.ShouldBe(17);
    }

    [Test]
    public void Part2_FinishFoldingAndPrintResult()
    {
        const string expectedResult = @"#####
#...#
#...#
#...#
#####";

        var paper = new List<Point>
        {
            new(6, 10),
            new(0, 14),
            new(9, 10),
            new(0, 3),
            new(10, 4),
            new(4, 11),
            new(6, 0),
            new(6, 12),
            new(4, 1),
            new(0, 13),
            new(10, 12),
            new(3, 4),
            new(3, 0),
            new(8, 4),
            new(1, 10),
            new(2, 14),
            new(8, 10),
            new(9, 0)
        };

        var instructions = new FoldInstruction[]
        {
            new(Axis.Y, 7),
            new(Axis.X, 5)
        };

        var result = _day.Part2(new Manual(paper, instructions));

        result.ShouldBe(Environment.NewLine + expectedResult + Environment.NewLine);
    }
}