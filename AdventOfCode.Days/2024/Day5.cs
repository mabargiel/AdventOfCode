using System;
using System.Linq;

namespace AdventOfCode.Days._2024;

public class Day5 : AdventDay<PrinterPages, int, int>
{
    public override PrinterPages ParseRawInput(string rawInput)
    {
        var pages = rawInput.Trim().Split(Environment.NewLine + Environment.NewLine);

        var rules = pages[0]
            .Split(Environment.NewLine)
            .Select(x =>
            {
                var split = x.Split('|');
                return (int.Parse(split[0]), int.Parse(split[1]));
            })
            .ToArray();

        var updates = pages[1]
            .Split(Environment.NewLine)
            .Select(x => x.Split(',').Select(int.Parse).ToArray())
            .ToArray();

        return new PrinterPages(rules, updates);
    }

    /// <summary>
    /// Sum middle page numbers of all valid updates, by checking if update follow ordering rules
    /// </summary>
    /// <param name="input">Parsed input</param>
    /// <returns>Sum of middle page numbers of all valid updates</returns>
    public override int Part1(PrinterPages input)
    {
        var (rules, updates) = input;
        var sumOfValidUpdates = 0;

        foreach (var update in updates)
        {
            foreach (var rule in rules)
            {
                if (!update.Contains(rule.Number) || !update.Contains(rule.AfterNumber))
                {
                    continue;
                }

                var numberIndex = Array.IndexOf(update, rule.Number);
                var afterNumberIndex = Array.IndexOf(update, rule.AfterNumber);

                if (numberIndex > afterNumberIndex)
                {
                    goto invalidUpdate;
                }
            }

            sumOfValidUpdates += update[update.Length / 2];

            invalidUpdate:
            ;
        }

        return sumOfValidUpdates;
    }

    /// <summary>
    /// Same as part 1, but if an update is invalid, swap the two numbers and check again until update becomes valid.
    /// This time sum all middle page numbers of updates needing correction.
    /// </summary>
    /// <param name="input">Parsed input</param>
    /// <returns>um of middle page numbers of all corrected updates</returns>
    public override int Part2(PrinterPages input)
    {
        var (rules, updates) = input;
        var sumOfValidUpdates = 0;

        foreach (var update in updates)
        {
            var filteredRules = rules
                .Where(rule => update.Contains(rule.Number) && update.Contains(rule.AfterNumber))
                .ToArray();

            var isInvalid = false;

            restartRuleCheck:
            foreach (var rule in filteredRules)
            {
                if (!update.Contains(rule.Number) || !update.Contains(rule.AfterNumber))
                {
                    continue;
                }

                var numberIndex = Array.IndexOf(update, rule.Number);
                var afterNumberIndex = Array.IndexOf(update, rule.AfterNumber);

                if (numberIndex <= afterNumberIndex)
                {
                    continue;
                }

                (update[numberIndex], update[afterNumberIndex]) = (
                    update[afterNumberIndex],
                    update[numberIndex]
                );
                isInvalid = true;
                goto restartRuleCheck;
            }

            sumOfValidUpdates += isInvalid ? update[update.Length / 2] : 0;
        }

        return sumOfValidUpdates;
    }
}

public record PrinterPages((int Number, int AfterNumber)[] Rules, int[][] Update);
