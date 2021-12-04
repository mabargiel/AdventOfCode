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

            input.ShouldBe(("3,4,1,5", 256));
        }

        [Test]
        [TestCase("3,4,1,5", 5, 3 * 4)]
        [TestCase("3,4,2,2", 5, 12)]
        [TestCase("8,10", 10, 6)]
        [TestCase("11", 11, 90)]
        [TestCase("120,93,0,90,5,80,129,74,1,165,204,255,254,2,50,113", 256, 826)]
        [TestCase("1,4", 5, 0)]
        [TestCase("3,4,0,2", 5, 12)]
        public void Part1_TieAKnot_ReturnTwoFirstNumbersMultiplied(string input, int size, int expectedResult)
        {
            var result = _day.Part1((input, size));

            result.ShouldBe(expectedResult);
        }

        [Test]
        [TestCase("", "a2582a3a0e66e6e86e3812dcb672a272")]
        [TestCase("AoC 2017", "33efeb34ea91902bb2f59c9920caa6cd")]
        [TestCase("1,2,3", "3efbe78a8d82f29979031a4aa0b16a9d")]
        [TestCase("1,2,4", "63960835bcdc130f0b66d7ff4f6a5a8e")]
        public void Part2_CalculateHexadecimalHash(string input, string expectedResult)
        {
            var result = _day.Part2((input, 256));

            result.ShouldBe(expectedResult);
        }
    }
}