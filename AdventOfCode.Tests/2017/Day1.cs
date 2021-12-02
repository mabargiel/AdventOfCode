using System.Reflection;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2017
{
    public class Day1
    {
        private Days._2017.Day1 _day;

        [SetUp]
        public void Initialize()
        {
            _day = new Days._2017.Day1();
        }
        
        [Test]
        public void ParseRawInput_IntoIntArray()
        {
            const string rawInput = "91212129";

            var input = _day.ParseRawInput(rawInput);
            
            input.ShouldBe(new [] {9,1,2,1,2,1,2,9});
        }
        
        [Test]
        [TestCase(new [] {1,1,2,2}, 3)]
        [TestCase(new [] {1,1,1,1}, 4)]
        [TestCase(new [] {1,2,3,4}, 0)]
        [TestCase(new [] {9,1,2,1,2,1,2,9}, 9)]
        public void Part1(int[] input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, _day.Part1(input));
        }

        [Test]
        [TestCase(new[] { 1, 2, 1, 2 }, 6)]
        [TestCase(new[] { 1, 2, 2, 1 }, 0)]
        [TestCase(new[] { 1, 2, 3, 4, 2, 5 }, 4)]
        [TestCase(new[] { 1, 2, 3, 1, 2, 3 }, 12)]
        [TestCase(new[] { 1, 2, 1, 3, 1, 4, 1, 5 }, 4)]
        public void Part2(int[] input, int expectedResult)
        {
            Assert.AreEqual(expectedResult, _day.Part2(input));
        }
    }
}