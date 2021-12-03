using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2017
{
    public class Day10 : AdventDayTest<Days._2017.Day10>
    {
        [Test]
        public override void ParseRawInputTest()
        {
            const string rawInput = "3,4,1,5";

            var input = _day.ParseRawInput(rawInput);

            input.ShouldBe(new[] { 256, 3, 4, 1, 5 });
        }

        [Test]
        [TestCase(new[] { 5, 3, 4, 1, 5 }, 3 * 4)]
        [TestCase(new[] { 5, 3, 4, 2, 2 }, 12)]
        [TestCase(new[] { 10, 8, 10 }, 6)]
        [TestCase(new[] { 11, 11 }, 90)]
        [TestCase(new[] { 256, 120, 93, 0, 90, 5, 80, 129, 74, 1, 165, 204, 255, 254, 2, 50, 113 }, 826)]
        [TestCase(new[] { 5, 1, 4 }, 0)]
        [TestCase(new[] { 5, 3, 4, 0, 2 }, 12)]
        public void Part1_TieAKnot_ReturnTwoFirstNumbersMultiplied(int[] input, int expectedResult)
        {
            var result = _day.Part1(input);

            result.ShouldBe(expectedResult);
        }
    }
}