using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace AdventOfCode.Days._2021
{
    public class Day8 : AdventDay<SignalPattern[], int, int>
    {
        private readonly ImmutableDictionary<string, char> _segmentsMap = new Dictionary<string, char>
        {
            ["abcefg"] = '0',
            ["cf"] = '1',
            ["acdeg"] = '2',
            ["acdfg"] = '3',
            ["bcdf"] = '4',
            ["abdfg"] = '5',
            ["abdefg"] = '6',
            ["acf"] = '7',
            ["abcdefg"] = '8',
            ["abcdfg"] = '9'
        }.ToImmutableDictionary();

        public override SignalPattern[] ParseRawInput(string rawInput)
        {
            return rawInput.Trim().Split(Environment.NewLine).Select(x =>
            {
                var split = x.Split(" | ").Select(s => s.Split(' ').ToArray()).ToArray();
                return new SignalPattern(split[0], split[1]);
            }).ToArray();
        }

        public override int Part1(SignalPattern[] input)
        {
            return input.Sum(pattern => pattern.Output.Count(o => new[] { 2, 3, 4, 7 }.Contains(o.Length)));
        }

        public override int Part2(SignalPattern[] input)
        {
            var result = 0;
            foreach (var (uniquePatterns, output) in input)
            {
                var patternMap = TransformToPatternMap(uniquePatterns);
                result += int.Parse(string.Join(string.Empty,
                    output.Select(x => string.Join(string.Empty, x.OrderBy(c => c))).Select(o => patternMap.First(x => x.Value == o).Key)));
            }

            return result;
        }

        private static Dictionary<char, string> TransformToPatternMap(string[] uniquePatterns)
        {
            uniquePatterns = uniquePatterns.Select(x => string.Join(string.Empty, x.OrderBy(c => c))).ToArray();
            var patternMap = new Dictionary<char, string>
            {
                ['1'] = uniquePatterns.First(x => x.Length == 2),
                ['7'] = uniquePatterns.First(x => x.Length == 3),
                ['4'] = uniquePatterns.First(x => x.Length == 4),
                ['8'] = uniquePatterns.First(x => x.Length == 7)
            };

            uniquePatterns = uniquePatterns.Where(x => !new[] { 2, 3, 4, 7 }.Contains(x.Length)).ToArray();

            patternMap['9'] = uniquePatterns.First(x =>
                x.Length == 6 && patternMap['7'].All(x.Contains) && patternMap['4'].All(x.Contains));
            var sixSegmentsPatterns = uniquePatterns.Where(x => x.Length is 6 && x != patternMap['9']).ToArray();
            
            patternMap['5'] =
                uniquePatterns.First(x => x.Length is 5 && sixSegmentsPatterns.Any(ss => x.All(ss.Contains)));
            patternMap['6'] = sixSegmentsPatterns.First(x => patternMap['5'].All(x.Contains));
            patternMap['0'] = sixSegmentsPatterns.First(x => x != patternMap['6'] && x != patternMap['9']);
            patternMap['3'] = uniquePatterns.First(x => x.Length is 5 && patternMap['7'].All(x.Contains));
            patternMap['2'] =
                uniquePatterns.First(x => x.Length is 5 && x != patternMap['5'] && x != patternMap['3']);
            return patternMap;
        }
    }

    public record SignalPattern(string[] Input, string[] Output);
}