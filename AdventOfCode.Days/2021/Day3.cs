using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2021
{
    public class Day3 : AdventDay<BitArray[], int, int>
    {
        public override BitArray[] ParseRawInput(string rawInput)
        {
            var rows = rawInput.Trim().Split(Environment.NewLine);
            var result = new BitArray[rows.Length];

            for (var i = 0; i < rows.Length; i++)
            {
                var columns = rows[i].Select(x => (int) char.GetNumericValue(x)).ToArray();
                result[i] = new BitArray(columns.Select(x => x == 1).ToArray());
            }

            return result;
        }

        public override int Part1(BitArray[] input)
        {
            var height = input.Length;
            var width = input.First().Length;
            var gamma = new BitArray(width);
            
            for (var i = 0; i < width; i++)
            {
                var positiveByteCount = CountPositiveBytes(input, height, i);

                gamma[i] = positiveByteCount > height / 2.0;
            }

            var epsilon = ((BitArray) gamma.Clone()).Not();

            return GetIntFromBitArray(gamma) * GetIntFromBitArray(epsilon);
        }

        public override int Part2(BitArray[] input)
        {
            var oxygenRating = GetRating(input, true);
            var co2Rating = GetRating(input, false);
            
            return GetIntFromBitArray(oxygenRating) * GetIntFromBitArray(co2Rating);
        }

        private static BitArray GetRating(IReadOnlyList<BitArray> input, bool criteria, int column = 0)
        {
            if (input.Count == 1)
            {
                return input[0];
            }
            
            var height = input.Count;
            var positiveBytesCount = CountPositiveBytes(input, height, column);
            var mostCommonByte = positiveBytesCount >= height / 2.0;

            mostCommonByte = criteria ? mostCommonByte : !mostCommonByte;

            var next = input.Where(x => x[column] == mostCommonByte).ToArray();
            return GetRating(next, criteria, ++column);
        }

        private static int CountPositiveBytes(IReadOnlyList<BitArray> input, int height, int column)
        {
            var byteCount = 0;
            for (var j = 0; j < height; j++)
            {
                if (input[j][column])
                {
                    byteCount++;
                }
            }

            return byteCount;
        }

        private static int GetIntFromBitArray(BitArray bitArray)
        {
            Reverse(bitArray);
            
            if (bitArray == null)
                throw new ArgumentNullException("binary");
            if (bitArray.Length > 32)
                throw new ArgumentException("must be at most 32 bits long");

            var result = new int[1];
            bitArray.CopyTo(result, 0);
            return result[0];
        }

        private static void Reverse(BitArray array)
        {
            var length = array.Length;
            var mid = length / 2;

            for (var i = 0; i < mid; i++)
            {
                (array[i], array[length - i - 1]) = (array[length - i - 1], array[i]);
            }
        }
    }
}