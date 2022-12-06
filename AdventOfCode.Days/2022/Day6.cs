using System;
using System.Collections.Generic;

namespace AdventOfCode.Days._2022
{
    public class Day6 : AdventDay<string, int, int>
    {
        public override string ParseRawInput(string rawInput)
        {
            return rawInput.Trim();
        }

        public override int Part1(string input)
        {
            return FindMarker(input, 4);
        }

        public override int Part2(string input)
        {
            return FindMarker(input, 14);
        }

        private static int FindMarker(string input, int length)
        {
            var window = new List<char>(length);

            for (var i = 0; i < input.Length - length; i++)
            {
                window.Add(input[i]);
                if (new HashSet<char>(window).Count == length)
                {
                    return i + 1;
                }

                if (i >= length - 1)
                    window.RemoveAt(0);
            }

            throw new ArgumentException($"Could not find the marker of length {length} in the given input");
        }
    }
}