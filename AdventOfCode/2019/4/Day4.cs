using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2019._4
{
    public class Day4 : IAdventDay<int, int>
    {
        private readonly int _end;
        private readonly int _start;

        public Day4(in int start, in int end)
        {
            _start = start;
            _end = end;
        }

        public int Part1()
        {
            var digits = _start.ToString().Select(c => (int) char.GetNumericValue(c)).ToArray();

            var possibilities = 0;

            while (int.Parse(string.Join(string.Empty, digits)) <= _end)
            {
                if (DigitsCriteria(digits) && digits.Any(digit => digits.Count(i => i == digit) >= 2))
                    possibilities++;

                Increment(digits, digits.Length - 1);
            }

            return possibilities;
        }

        public int Part2()
        {
            var digits = _start.ToString().Select(c => (int) char.GetNumericValue(c)).ToArray();

            var possibilities = 0;

            while (int.Parse(string.Join(string.Empty, digits)) <= _end)
            {
                if (DigitsCriteria(digits) && digits.Any(digit => digits.Count(i => i == digit) == 2))
                    possibilities++;

                Increment(digits, digits.Length - 1);
            }

            return possibilities;
        }

        private static bool DigitsCriteria(IReadOnlyList<int> digits)
        {
            for (var i = 0; i < digits.Count - 1; i++)
                if (digits[i] > digits[i + 1])
                    return false;

            return true;
        }

        private static void Increment(IList<int> digits, int incrementIndex)
        {
            for (var i = incrementIndex; i >= 0; i--)
            {
                if (digits[i] == 9) continue;

                digits[i]++;
                for (var j = i + 1; j < digits.Count; j++) digits[j] = digits[i];
                break;
            }
        }
    }
}