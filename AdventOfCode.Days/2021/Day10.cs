using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2021;

public class Day10 : AdventDay<string[], int, long>
{
    private readonly Dictionary<char, int> _corruptedScoring = new()
    {
        [')'] = 3,
        [']'] = 57,
        ['}'] = 1197,
        ['>'] = 25137
    };

    private readonly Dictionary<char, int> _incompleteScoring = new()
    {
        [')'] = 1,
        [']'] = 2,
        ['}'] = 3,
        ['>'] = 4
    };

    private readonly Dictionary<char, char> _tagMap = new()
    {
        ['('] = ')',
        ['['] = ']',
        ['{'] = '}',
        ['<'] = '>'
    };

    public override string[] ParseRawInput(string rawInput)
    {
        return rawInput.Trim().Split(Environment.NewLine).ToArray();
    }

    public override int Part1(string[] input)
    {
        var result = 0;

        foreach (var line in input)
        {
            var expectedTags = new Stack<char>();

            foreach (var tag in line)
            {
                if (_tagMap.ContainsKey(tag))
                {
                    expectedTags.Push(_tagMap[tag]);
                    continue;
                }

                var expectedTag = expectedTags.Pop();
                result += tag != expectedTag ? _corruptedScoring[tag] : 0;
            }
        }

        return result;
    }

    public override long Part2(string[] input)
    {
        var result = new List<long>();

        foreach (var line in input)
        {
            var expectedTags = new Stack<char>();

            foreach (var tag in line)
            {
                if (_tagMap.ContainsKey(tag))
                {
                    expectedTags.Push(_tagMap[tag]);
                    continue;
                }

                var expectedTag = expectedTags.Pop();
                if (tag != expectedTag)
                {
                    goto nextLine;
                }
            }

            var score = expectedTags.Select(x => (long)_incompleteScoring[x])
                .Aggregate(0L, (prev, curr) => prev * 5 + curr);
            result.Add(score);

            nextLine: ;
        }

        var sorted = result.OrderBy(x => x);
        return sorted.ToArray()[result.Count / 2];
    }
}