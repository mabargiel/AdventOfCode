using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2021
{
    public class Day6 : AdventDayTest<Days._2021.Day6>
    {
        [Test]
        public override void ParseRawInputTest()
        {
            const string rawInput = @"3,4,3,1,2";

            var (input, days) = _day.ParseRawInput(rawInput);

            input.ShouldBe(new[] { 3, 4, 3, 1, 2 });
            days.ShouldBe(0);
        }

        [Test]
        [TestCase(new[] { 3, 4, 3, 1, 2 }, 18, 26)]
        [TestCase(new[] { 3, 4, 3, 1, 2 }, 80, 5934)]
        public void Part1_CountFishAfterNDays(int[] initialSchool, int days, int expectedFishCount)
        {
            var result = _day.Part1((initialSchool, days));

            result.ShouldBe(expectedFishCount);
        }

        [Test]
        [TestCase(new[] { 3, 4, 3, 1, 2 }, 18, 26)]
        [TestCase(new[] { 1 }, 18, 7)]
        [TestCase(new[] { 3, 4, 3, 1, 2 }, 256, 26984457539)]
        public void Part2_CountFishAfter256Days_LargeValueReturned(int[] initialSchool, int days,
            long expectedFishCount)
        {
            var result = _day.Part2((initialSchool, days));

            result.ShouldBe(expectedFishCount);
        }
    }
}