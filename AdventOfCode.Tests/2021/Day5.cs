using System.Collections.Immutable;
using AdventOfCode.Days._2021;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2021
{
    public class Day5 : AdventDayTest<Days._2021.Day5>
    {
        [Test]
        public override void ParseRawInputTest()
        {
            const string rawInput = @"0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
0,0 -> 8,8";

            var input = _day.ParseRawInput(rawInput);

            input.ShouldBe(new Line[]
            {
                new(new Point(0, 9), new Point(5, 9)),
                new(new Point(8, 0), new Point(0, 8)),
                new(new Point(9, 4), new Point(3, 4)),
                new(new Point(0, 0), new Point(8, 8))
            }.ToImmutableArray());
        }

        [Test]
        public void Part1_OnlyVerticalAndHorizontal_CountOverlappingPoints()
        {
            var input = new Line[]
            {
                new(new Point(0, 9), new Point(5, 9)),
                new(new Point(8, 0), new Point(0, 8)),
                new(new Point(9, 4), new Point(3, 4)),
                new(new Point(2, 2), new Point(2, 1)),
                new(new Point(7, 0), new Point(7, 4)),
                new(new Point(6, 4), new Point(2, 0)),
                new(new Point(0, 9), new Point(2, 9)),
                new(new Point(3, 4), new Point(1, 4)),
                new(new Point(0, 0), new Point(8, 8)),
                new(new Point(5, 5), new Point(8, 2))
            }.ToImmutableArray();

            var result = _day.Part1(input);

            result.ShouldBe(5);
        }

        [Test]
        public void Part2_IncludeDiagonal_CountOverlappingPoints()
        {
            var input = new Line[]
            {
                new(new Point(0, 9), new Point(5, 9)),
                new(new Point(8, 0), new Point(0, 8)),
                new(new Point(9, 4), new Point(3, 4)),
                new(new Point(2, 2), new Point(2, 1)),
                new(new Point(7, 0), new Point(7, 4)),
                new(new Point(6, 4), new Point(2, 0)),
                new(new Point(0, 9), new Point(2, 9)),
                new(new Point(3, 4), new Point(1, 4)),
                new(new Point(0, 0), new Point(8, 8)),
                new(new Point(5, 5), new Point(8, 2))
            }.ToImmutableArray();

            var result = _day.Part2(input);

            result.ShouldBe(12);
        }
    }
}