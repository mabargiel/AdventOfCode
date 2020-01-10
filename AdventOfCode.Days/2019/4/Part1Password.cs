using System.Linq;

namespace AdventOfCode.Days._2019._4
{
    internal class Part1Password : Password
    {
        public Part1Password(int[] digits) : base(digits)
        {
        }

        public override bool IsValid()
        {
            return Digits.Any(digit => Digits.Count(i => i == digit) >= 2);
        }
    }
}