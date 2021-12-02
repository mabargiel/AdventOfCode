using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2020
{
    public class Day3
    {
        [Test]
        public void Part1_Goes3_1_Hits7Trees()
        {
            const string input = @"..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#";

            var d3 = new Days._2020._3.Day3(input);
            var result = d3.Part1();

            result.ShouldBe(7);
        }

        [Test]
        public void Part1_TraversesMapMultipleTimesAsExpected_ReturnsMultipliedResult()
        {
            const string input = @"..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#";

            var d3 = new Days._2020._3.Day3(input);
            var result = d3.Part2();

            result.ShouldBe(336);
        }
    }
}