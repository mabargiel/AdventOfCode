using System.Linq;
using NUnit.Framework;

namespace AdventOfCode.Tests._2017
{
    public class Day1
    {
        [Test]
        [TestCase("1122", 3)]
        [TestCase("1111", 4)]
        [TestCase("1234", 0)]
        [TestCase("91212129", 9)]
        public void Part1(string input, int expectedResult)
        {
            var d1 = new AdventOfCode._2017._1.Day1(input);
            
            Assert.AreEqual(expectedResult, d1.Part1());
        }
    }
}