using System;
using System.Linq;

namespace AdventOfCode.Days._2017
{
    public class Day10 : AdventDay<int[], int, int>
    {
        public override int[] ParseRawInput(string rawInput)
        {
            var ints = rawInput.Trim().Split(',').Select(int.Parse).ToList();
            ints.Insert(0, 256);
            return ints.ToArray();
        }

        public override int Part1(int[] input)
        {
            var size = input[0];
            var numbers = Enumerable.Range(0, size).ToArray();
            var currentPosition = 0;
            var skipSize = 0;
            var lengths = input[1..].ToArray();

            foreach (var length in lengths)
            {
                var localPos = currentPosition;
                for (var i = 0; i < (int)Math.Ceiling(length / 2.0); i++)
                {
                    var swapPosition = (localPos + (length - i * 2 - 1)) % size;

                    if (localPos != swapPosition)
                    {
                        (numbers[localPos], numbers[swapPosition]) =
                            (numbers[swapPosition], numbers[localPos]);
                    }

                    localPos++;
                    localPos %= size;
                }

                currentPosition += length + skipSize;
                currentPosition %= size;
                skipSize++;
            }

            return numbers[0] * numbers[1];
        }

        public override int Part2(int[] input)
        {
            throw new NotImplementedException();
        }
    }
}