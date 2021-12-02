using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2017
{
    public class Day4 : AdventDay<List<List<string>>, int, int>
    {
        public override List<List<string>> ParseRawInput(string rawInput)
        {
            return rawInput.Split(Environment.NewLine).Select(x => x.Split(' ').ToList()).ToList();
        }

        public override int Part1(List<List<string>> input)
        {
            return input.Count(words => new HashSet<string>(words).Count == words.Count);
        }

        public override int Part2(List<List<string>> input)
        {
            return input.Count(words =>
                new HashSet<string>(words.Select(x => string.Concat(x.OrderBy(y => y)))).Count == words.Count);
        }
    }
}