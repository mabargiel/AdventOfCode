using System.Linq;
using NUnit.Framework;

namespace AdventOfCode.Tests._2019
{
    public class Day5
    {
        [Test]
        [TestCase(new long[] { 3, 0, 4, 0, 99 }, 10, 10)]
        public void Part1(long[] code, int input, long output)
        {
            var d5 = new AdventOfCode._2019._5.Day5(code, input);

            Assert.AreEqual(output, d5.Part1());
        }

        [Test]
        [TestCase(new long[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 }, 7, 0)]
        [TestCase(new long[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 }, 8, 1)]
        [TestCase(new long[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 }, 9, 0)]
        [TestCase(new long[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 }, 9, 0)]
        [TestCase(new long[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 }, 8, 0)]
        [TestCase(new long[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 }, 7, 1)]
        [TestCase(new long[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 }, 7, 0)]
        [TestCase(new long[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 }, 8, 1)]
        [TestCase(new long[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 }, 9, 0)]
        [TestCase(new long[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 }, 9, 0)]
        [TestCase(new long[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 }, 8, 0)]
        [TestCase(new long[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 }, 7, 1)]
        [TestCase(new long[]
        {
            3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46,
            1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99
        }, 7, 999)]
        [TestCase(new long[]
        {
            3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46,
            1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99
        }, 8, 1000)]
        [TestCase(new long[]
        {
            3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46,
            1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99
        }, 9, 1001)]
        public void Part2(long[] code, int input, int output)
        {
            var d5 = new AdventOfCode._2019._5.Day5(code, input);

            Assert.AreEqual(output, d5.Part2());
        }
    }
}