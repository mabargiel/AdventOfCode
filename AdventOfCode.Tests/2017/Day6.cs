using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2017
{
    public class Day6
    {
        private Days._2017.Day6 _day;

        [SetUp]
        public void Initialize()
        {
            _day = new Days._2017.Day6();
        }

        [Test]
        public void ParseRawInput_IntoIntArray()
        {
            const string rawInput = "0\t2\t7\t0";

            var input = _day.ParseRawInput(rawInput);

            input.ShouldBe(new[] { 0, 2, 7, 0 });
        }

        [Test]
        public void Part1_CountRedistributionCycles()
        {
            int[] input = { 0, 2, 7, 0 };

            var result = _day.Part1(input);
            
            result.ShouldBe(5);
        }
        
        [Test]
        public void Part2_CountRedistributionCycles_OfInfiniteLoop()
        {
            int[] input = { 0, 2, 7, 0 };

            var result = _day.Part2(input);
            
            result.ShouldBe(4);
        }
    }
}