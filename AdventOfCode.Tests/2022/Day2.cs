using AdventOfCode.Days._2022;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2022
{
    public class Day2
    {
        private Days._2022.Day2 _day2;

        [SetUp]
        public void Initialize()
        {
            _day2 = new Days._2022.Day2();
        }
        
        [Test]
        public void ParseRawInput_IntoRounds()
        {
            const string rawInput = "A Y\nB X\nC Z";

            var input = _day2.ParseRawInput(rawInput);

            input.ShouldBe(new[] { new [] {'A', 'Y'}, new [] {'B', 'X'}, new  [] {'C', 'Z'}});
        }

        [Test]
        [TestCase("A Y\nB X\nC Z", 15)]
        [TestCase("A Y\nB Y\nB Z\nB Z\nB X\nB Z\nC Y\nA Z\nC X\nC X\nB Z\nB Z\nB Z\nA X\nB Z\nB Z\nA Y\nB Z\nA Z\nB X", 130)]
        public void Part1_WithExampleInput_CalculateScore(string input, int expectedScore)
        {
            var parsedInput = _day2.ParseRawInput(input);

            var result = _day2.Part1(parsedInput);

            result.ShouldBe(expectedScore);
        }
        
        [Test]
        [TestCase("A Y\nB X\nC Z", 12)]
        [TestCase("A Y\nB Y\nB Z\nB Z\nB X\nB Z\nC Y\nA Z\nC X\nC X\nB Z\nB Z\nB Z\nA X\nB Z\nB Z\nA Y\nB Z\nA Z\nB X", 125)]
        public void Part2_WithExampleInput_CalculateCorrectScore(string input, int expectedScore)
        {
            var parsedInput = _day2.ParseRawInput(input);

            var result = _day2.Part2(parsedInput);

            result.ShouldBe(expectedScore);
        }
    }
}