using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2017
{
    public class Day9 : AdventDay<IReadOnlyList<char>, int, int>
    {
        public override IReadOnlyList<char> ParseRawInput(string rawInput)
        {
            return rawInput.ToCharArray();
        }

        public override int Part1(IReadOnlyList<char> input)
        {
            var score = 0;
            var currentNesting = 1;

            var cleanedInput = RemoveIgnoredCharacters(input).ToArray();

            for (var currentPos = 0; currentPos < cleanedInput.Length; currentPos++)
            {
                switch (cleanedInput[currentPos])
                {
                    case '{':
                        score += currentNesting;
                        currentNesting++;
                        break;
                    case '}':
                        currentNesting--;
                        break;
                    case '<':
                    {
                        var closingTagIndex = Array.IndexOf(cleanedInput, '>', currentPos);
                        var distance = closingTagIndex - currentPos;
                        currentPos += distance;
                        break;
                    }
                }
            }

            return score;
        }

        public override int Part2(IReadOnlyList<char> input)
        {
            var garbageLength = 0;

            var cleanedInput = RemoveIgnoredCharacters(input).ToArray();

            for (var currentPos = 0; currentPos < cleanedInput.Length; currentPos++)
            {
                if (cleanedInput[currentPos] != '<')
                {
                    continue;
                }

                var closingTagIndex = Array.IndexOf(cleanedInput, '>', currentPos);
                var distance = closingTagIndex - currentPos;
                garbageLength += distance - 1;
                currentPos += distance;
            }

            return garbageLength;
        }

        private static IEnumerable<char> RemoveIgnoredCharacters(IReadOnlyList<char> input)
        {
            for (var i = 0; i < input.Count; i++)
            {
                if (input[i] == '!')
                {
                    i ++;
                    continue;
                }

                yield return input[i];
            }
        }
    }
}