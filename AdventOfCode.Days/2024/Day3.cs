using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days._2024;

public partial class Day3 : AdventDay<string, int, int>
{
    [GeneratedRegex(@"mul\((?<num1>\d+),(?<num2>\d+)\)")]
    private static partial Regex MulRegex();

    public override string ParseRawInput(string rawInput)
    {
        return rawInput.Trim();
    }

    public override int Part1(string input)
    {
        var mulRegex = MulRegex();
        var matches = mulRegex.Matches(input);

        return SumMuls(matches);
    }

    public override int Part2(string input)
    {
        const string Do = "do()";
        const string Dont = "don't()";
        var mulRegex = MulRegex();
        var currentIndex = 0;
        var result = 0;

        while (currentIndex < input.Length)
        {
            var dontIndex = input.IndexOf(Dont, currentIndex, StringComparison.Ordinal);
            var doIndex = dontIndex != -1
                ? input.IndexOf(Do, dontIndex + Dont.Length, StringComparison.Ordinal)
                : -1;

            var endIndex = dontIndex != -1 ? dontIndex : input.Length;
            var enabledSubstring = input[currentIndex..endIndex];
            result += SumMuls(mulRegex.Matches(enabledSubstring));

            currentIndex = doIndex != -1 ? doIndex + Do.Length : input.Length;
        }

        return result;
    }

    private static int SumMuls(MatchCollection matches)
    {
        return matches.Sum(match => int.Parse(match.Groups["num1"].ToString()) * int.Parse(match.Groups["num2"].ToString()));
    }
}
