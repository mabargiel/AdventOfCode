using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2017._1
{
    public class Day1 : IAdventDay<int, int>
    {
        private readonly string _input;

        public Day1(string input)
        {
            _input = input;
        }

        public int Part1()
        {
            var digits = _input.Select(x => (int) char.GetNumericValue(x)).ToList();

            var result = 0;
            var digitsCount = digits.Count;
            
            for (var currIndex = 0; currIndex < digits.Count; currIndex++)
            {
                var nextDigit = currIndex == digitsCount - 1 ? digits[0] : digits[currIndex + 1];
                if (digits[currIndex] == nextDigit)
                    result += digits[currIndex];
            }

            return result;
        }

        public int Part2()
        {
            throw new System.NotImplementedException();
        }
    }
}