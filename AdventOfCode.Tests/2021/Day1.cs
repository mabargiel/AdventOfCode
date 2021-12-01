using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2021
{
    public class Day1
    {
        [Test]
        public void Part1_WithExampleInput_ShouldIncrease7Times()
        {
            int[] input = { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
            var day = new Days._2021._1.Day1(input);

            var result = day.Part1();
            
            result.ShouldBe(7);
        }
        
        [Test]
        public void Part2_WithExampleInput_ShouldIncrease5Times()
        {
            int[] input = { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
            var day = new Days._2021._1.Day1(input);

            var result = day.Part2();
            
            result.ShouldBe(5);
        }
    }
}