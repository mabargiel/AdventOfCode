using NUnit.Framework;

namespace AdventOfCode.Tests._2019
{
    public class Day4
    {
        [Test]
        [TestCase(357, 699, 31)]
        [TestCase(2889, 3479, 40)]
        [TestCase(277777, 347999, 347)]
        [TestCase(353096, 843212, 579)]
        public void Part1(int start, int end, int expectedPossibilities)
        {
            var d4 = new Days._2019._4.Day4(start, end);

            Assert.AreEqual(expectedPossibilities, d4.Part1());
        }

        [Test]
        [TestCase(357, 699, 28)]
        [TestCase(2889, 3479, 31)]
        [TestCase(277777, 347999, 250)]
        [TestCase(353096, 843212, 358)]
        public void Part2(int start, int end, int expectedPossibilities)
        {
            var d4 = new Days._2019._4.Day4(start, end);

            Assert.AreEqual(expectedPossibilities, d4.Part2());
        }
    }
}