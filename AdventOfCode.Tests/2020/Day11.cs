using AdventOfCode.Tests.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2020
{
    public class Day11
    {
        private static object[] seatMapInputs =
        {
            new object[]
            {
                @"L.LL.LL.LL
                LLLLLLL.LL
                L.L.L..L..
                LLLL.LL.LL
                L.LL.LL.LL
                L.LLLLL.LL
                ..L.L.....
                LLLLLLLLLL
                L.LLLLLL.L
                L.LLLLL.LL".TrimIndent(),
                37, 26
            }
        };

        [Test]
        [TestCaseSource(nameof(seatMapInputs))]
        public void Part1(string input, int expected, int _)
        {
            var d11 = new Days._2020._11.Day11(input);
            var result = d11.Part1();

            result.ShouldBe(expected);
        }

        [Test]
        [TestCaseSource(nameof(seatMapInputs))]
        public void Part2(string input, int _, int expected)
        {
            var d11 = new Days._2020._11.Day11(input);
            var result = d11.Part2();

            result.ShouldBe(expected);
        }
    }
}