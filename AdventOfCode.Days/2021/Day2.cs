using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2021
{
    public class Day2 : AdventDay<List<(string direction, int distance)>, int, int>
    {
        public override List<(string direction, int distance)> ParseRawInput(string rawInput)
        {
            return rawInput.Split(Environment.NewLine).Select(x =>
            {
                var values = x.Split(' ');
                return (values[0], int.Parse(values[1]));
            }).ToList();
        }

        public override int Part1(List<(string direction, int distance)> input)
        {
            var pos = 0;
            var depth = 0;

            foreach (var (direction, distance) in input)
            {
                switch (direction)
                {
                    case "forward":
                        pos += distance;
                        break;
                    case "down":
                        depth += distance;
                        break;
                    case "up":
                        depth -= distance;
                        break;
                }
            }

            return pos * depth;
        }

        public override int Part2(List<(string direction, int distance)> input)
        {
            var pos = 0;
            var depth = 0;
            var aim = 0;

            foreach (var (direction, distance) in input)
            {
                switch (direction)
                {
                    case "forward":
                        pos += distance;
                        depth += aim * distance;
                        break;
                    case "down":
                        aim += distance;
                        break;
                    case "up":
                        aim -= distance;
                        break;
                }
            }

            return pos * depth;
        }
    }
}