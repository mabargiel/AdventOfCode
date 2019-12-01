using NUnit.Framework;

namespace AdventOfCode.Tests
{
    public class Day1
    {
        [Test]
        public void Part1()
        {
            var d1 = new _2019.Day1(new [] {12, 14, 1969, 100756});
            
            Assert.AreEqual(2 + 2 + 654 + 33583, d1.Part1());
        }

        [Test]
        public void Part2()
        {
            var d1 = new _2019.Day1(new[] {1969, 100756});

            Assert.AreEqual(966 + 50346, d1.Part2());
        }
    }
}