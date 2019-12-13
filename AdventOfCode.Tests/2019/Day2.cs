using System.Linq;
using NUnit.Framework;

namespace AdventOfCode.Tests._2019
{
    public class Day2
    {
        [Test]
        public void Part1()
        {
            var input = new long[] { 1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50 };
            var instructions = input.Select((x, i) => (x, (long) i)).ToDictionary(x => x.Item2, x => x.x);
            var d2 = new AdventOfCode._2019._2.Day2(instructions);

            Assert.AreEqual(3500, d2.Part1());
        }

        [Test]
        public void Part2()
        {
            var input = new long[] { 1, 1, 2, 3, 2, 3, 11, 0, 99, 30, 40, 50 };
            var instructions = input.Select((x, i) => (x, (long) i)).ToDictionary(x => x.Item2, x => x.x);
            var d2 = new AdventOfCode._2019._2.Day2(instructions, 3500);

            Assert.AreEqual(100 * 9 + 10, d2.Part2());
        }
    }
}