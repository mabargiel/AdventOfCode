using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2021
{
    public class Day2
    {
        private Days._2021.Day2 _day;

        [SetUp]
        public void Initialize()
        {
            _day = new Days._2021.Day2();
        }
        
        [Test]
        public void ParseRawInput_IntoSeriesOfCommandTuples()
        {
            var rawInput = 
@"forward 5
down 5
forward 8
up 3
down 8
forward 2";

            var input = _day.ParseRawInput(rawInput);
            
            input.ShouldBe(new List<(string direction, int distance)>
            {
                ("forward", 5),
                ("down", 5),
                ("forward", 8),
                ("up", 3),
                ("down", 8),
                ("forward", 2)
            });
        }

        [Test]
        public void Part1_MoveSubmarine_ReturnDepthAndPositionMultiplied()
        {
            List<(string direction, int distance)> input = new()
            {
                ("forward", 5),
                ("down", 5),
                ("forward", 8),
                ("up", 3),
                ("down", 8),
                ("forward", 2)
            };

            var result = _day.Part1(input);
            
            result.ShouldBe(15 * 10);
        }
        
        [Test]
        public void Part2_MoveSubmarine_ReturnDepthAndPositionMultiplied()
        {
            List<(string direction, int distance)> input = new()
            {
                ("forward", 5),
                ("down", 5),
                ("forward", 8),
                ("up", 3),
                ("down", 8),
                ("forward", 2)
            };

            var result = _day.Part2(input);
            
            result.ShouldBe(15 * 60);
        }
    }
}