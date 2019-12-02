using NUnit.Framework;

namespace AdventOfCode.Tests
{
    public class Day2
    {
        [Test]
        public void Part1()
        {
            var input = new[] { 1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50 };
            var d2 = new _2019._2.Day2(input);
            
            Assert.AreEqual(3500, d2.Part1());
        }

        [Test]
        public void Part2()
        {
            var input = new[] { 1, 1, 2, 3, 2, 3, 11, 0, 99, 30, 40, 50 };
            var d2 = new _2019._2.Day2(input, 3500);
            
            Assert.AreEqual(100 * 9 + 10, d2.Part2());
        }
    }
}