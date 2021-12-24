using System;
using System.Text.RegularExpressions;

namespace AdventOfCode.Tests.Helpers;

public static class StringExtensions
{
    public static string TrimIndent(this string s)
    {
        return Regex.Replace(s, @$"{Environment.NewLine}\s+", Environment.NewLine).Trim();
    }
}