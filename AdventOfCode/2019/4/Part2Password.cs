using System.Linq;

namespace AdventOfCode._2019._4
{
    internal class Part2Password : Password
    {
        public Part2Password(int[] digits) : base(digits)
        {
        }

        public override bool IsValid()
        {
            return Digits.Any(digit => Digits.Count(i => i == digit) == 2);
        }
    }
}