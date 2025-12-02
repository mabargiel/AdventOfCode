using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days._2020._2;

public class Day2 : IAdventDay<int, int>
{
    private readonly PasswordsDatabase _database;

    public Day2(string input)
    {
        _database = ParseInput(input);
    }

    public int Part1()
    {
        return (
            from policy in _database
            let characterCount = policy.Password.Count(c => c == policy.PolicyCharacter)
            where policy.Min <= characterCount && characterCount <= policy.Max
            select policy.Password
        ).Count();
    }

    public int Part2()
    {
        return _database
            .Where(entry =>
            {
                var lowIndexChar = entry.Password[entry.Min - 1];
                var highIndexChar = entry.Password[entry.Max - 1];
                return (lowIndexChar == entry.PolicyCharacter)
                    ^ (highIndexChar == entry.PolicyCharacter);
            })
            .Count();
    }

    private static PasswordsDatabase ParseInput(string input)
    {
        var database = new PasswordsDatabase();

        var entryRegex = new Regex(
            @"^(?<min>\d+)-(?<max>\d+) (?<policyCharacter>[a-z]): (?<password>.*)$"
        );
        database.AddRange(
            from entry in input.Split(Environment.NewLine)
            select entryRegex.Match(entry) into match
            let min = int.Parse(match.Groups["min"].Value)
            let max = int.Parse(match.Groups["max"].Value)
            let policyCharacter = match.Groups["policyCharacter"].Value[0]
            let password = match.Groups["password"].ToString()
            select new PasswordPolicy(min, max, policyCharacter, password)
        );

        return database;
    }
}
