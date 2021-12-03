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
            var (score, _) = GetScoreAndGarbageLength(input);
            return score;
        }

        public override int Part2(IReadOnlyList<char> input)
        {
            
            var (_, garbageLength) = GetScoreAndGarbageLength(input);
            return garbageLength;
        }

        private static (int Score, int GarbageLength) GetScoreAndGarbageLength(IReadOnlyList<char> input)
        {
            var score = 0;
            var garbageLength = 0;
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
                        garbageLength += distance - 1;
                        currentPos += distance;
                        break;
                    }
                }
            }

            return (score, garbageLength);
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