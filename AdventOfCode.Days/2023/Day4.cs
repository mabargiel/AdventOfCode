using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2023;

public class Day4 : AdventDay<List<(int[] WinningNumbers, int[] NumbersIHave)>, int, int>
{
    public override List<(int[] WinningNumbers, int[] NumbersIHave)> ParseRawInput(string rawInput)
    {
        var split = rawInput.Trim().Split(Environment.NewLine);

        return (from row in split
            select row[(row.IndexOf(':') + 1)..].Split('|').Select(x => x.Trim()).ToArray()
            into numbers
            let winningNumbers = ParseNumbers(numbers[0]).ToArray()
            let numbersIHave = ParseNumbers(numbers[1]).ToArray()
            select (winningNumbers, numbersIHave)).ToList();

        IEnumerable<int> ParseNumbers(string numbersString)
        {
            return numbersString.Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(x => int.Parse(x.Trim()));
        }
    }

    public override int Part1(List<(int[] WinningNumbers, int[] NumbersIHave)> input)
    {
        var result = 0;

        foreach (var (winningNumbers, numbersIHave) in input)
        {
            var matches = winningNumbers.Count(winningNumber => numbersIHave.Contains(winningNumber));

            if (matches == 0)
            {
                continue;
            }

            result += (int)Math.Pow(2, matches - 1);
        }

        return result;
    }

    public override int Part2(List<(int[] WinningNumbers, int[] NumbersIHave)> input)
    {
        var matchesArray = new int[input.Count];
        var scratchCardCopies = new int[input.Count];

        for (var i = 0; i < scratchCardCopies.Length; i++)
        {
            scratchCardCopies[i] = 1;
        }

        for (var i = 0; i < input.Count; i++)
        {
            var (winningNumbers, numbersIHave) = input[i];
            var matches = winningNumbers.Count(winningNumber => numbersIHave.Contains(winningNumber));
            matchesArray[i] = matches;
        }

        for (var i = 0; i < scratchCardCopies.Length; i++)
        {
            var matches = matchesArray[i];

            for (var j = 1; j <= matches; j++)
            {
                scratchCardCopies[i + j] += scratchCardCopies[i];
            }
        }

        return scratchCardCopies.Sum();
    }
}