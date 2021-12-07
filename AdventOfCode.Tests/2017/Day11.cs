using AdventOfCode.Days._2017;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2017
{
    public class Day11 : AdventDayTest<Days._2017.Day11>
    {
        [Test]
        public override void ParseRawInputTest()
        {
            const string rawInput = "se,sw,se,sw,sw,n,s,nw,ne";

            var input = _day.ParseRawInput(rawInput);

            input.ShouldBe(new[]
            {
                Direction.SE, Direction.SW, Direction.SE, Direction.SW, Direction.SW, Direction.N, Direction.S,
                Direction.NW, Direction.NE
            });
        }

        [Test]
        [TestCase(new[] { Direction.NE, Direction.NE, Direction.NE }, 3)]
        [TestCase(new[] { Direction.NE, Direction.NE, Direction.SW, Direction.SW }, 0)]
        [TestCase(new[] { Direction.NE, Direction.NE, Direction.S, Direction.S }, 2)]
        [TestCase(new[] { Direction.SE, Direction.SW, Direction.SE, Direction.SW, Direction.SW }, 3)]
        public void Part1_DetermineTheFewestStepsToFindChild(Direction[] input, int expectedSteps)
        {
            var result = _day.Part1(input);

            result.ShouldBe(expectedSteps);
        }

        [Test]
        [TestCase(new[] { Direction.NE, Direction.NE, Direction.SW, Direction.SW }, 2)]
        public void Part2_DetermineTheFurthestTheChildWent(Direction[] input, int expectedSteps)
        {
            var result = _day.Part2(input);

            result.ShouldBe(expectedSteps);
        }
    }
}