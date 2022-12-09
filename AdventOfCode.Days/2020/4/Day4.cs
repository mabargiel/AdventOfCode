using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days._2020._4;

public class Day4 : IAdventDay<int, int>
{
    private readonly List<Dictionary<string, string>> _batchFiles;

    public Day4(string input)
    {
        _batchFiles = new List<Dictionary<string, string>>();

        foreach (var passport in input.Split(Environment.NewLine + Environment.NewLine))
        {
            var keyValues = Regex.Split(passport, @"[ \n\r]");
            _batchFiles.Add(keyValues.Where(it => !string.IsNullOrEmpty(it)).Select(it => it.Split(':'))
                .ToDictionary(strings => strings[0], strings => strings[1]));
        }
    }

    public int Part1()
    {
        var validPassports = PreValidate();
        return validPassports.Count();
    }

    public int Part2()
    {
        var validPasswords = PreValidate().Where(passport =>
            int.Parse(passport["byr"]) is >= 1920 and <= 2002 &&
            int.Parse(passport["iyr"]) is >= 2010 and <= 2020 &&
            int.Parse(passport["eyr"]) is >= 2020 and <= 2030 &&
            ((passport["hgt"].EndsWith("cm") &&
              int.Parse(passport["hgt"].Substring(0, passport["hgt"].Length - 2)) is >= 150 and <= 193) ||
             (passport["hgt"].EndsWith("in") &&
              int.Parse(passport["hgt"].Substring(0, passport["hgt"].Length - 2)) is >= 59 and <= 76)) &&
            Regex.IsMatch(passport["hcl"], @"^\#[a-f0-9]{6}$") &&
            new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(passport["ecl"]) &&
            Regex.IsMatch(passport["pid"], @"^\d{9}$"));

        return validPasswords.Count();
    }

    private IEnumerable<Dictionary<string, string>> PreValidate()
    {
        var validPassports =
            _batchFiles.Where(it => it.Keys.Count == 8 || (it.Keys.Count == 7 && !it.ContainsKey("cid")));
        return validPassports;
    }
}