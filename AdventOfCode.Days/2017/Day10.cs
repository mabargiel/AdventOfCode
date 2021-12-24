using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace AdventOfCode.Days._2017;

public class Day10 : AdventDay<(string InputString, int Size), int, string>
{
    public override (string, int) ParseRawInput(string rawInput)
    {
        return (rawInput.Trim(), 256);
    }

    public override int Part1((string InputString, int Size) input)
    {
        var (inputString, size) = input;
        var lengths = inputString.Trim().Split(',').Select(int.Parse);

        var numbers = Enumerable.Range(0, size).ToArray();
        var currentPosition = 0;
        var skipSize = 0;

        TieAKnot(lengths, size, numbers, ref currentPosition, ref skipSize);

        return numbers[0] * numbers[1];
    }

    public override string Part2((string InputString, int Size) input)
    {
        var (inputString, size) = input;
        var lengths = inputString.Select(c => (int)c).Concat(new[] { 17, 31, 73, 47, 23 }).ToImmutableArray();
        var sparseHash = Enumerable.Range(0, size).ToArray();
        var currentPosition = 0;
        var skipSize = 0;

        for (var i = 0; i < 64; i++)
        {
            TieAKnot(lengths, size, sparseHash, ref currentPosition, ref skipSize);
        }

        var denseHash = new int[16];
        for (var i = 0; i < 16; i++)
        {
            var block = sparseHash[(i * 16)..(16 + i * 16)];
            denseHash[i] = block.Aggregate((curr, prev) => prev ^ curr);
        }

        return string.Join("", denseHash.Select(x => x.ToString("X2"))).ToLower();
    }

    private static void TieAKnot(IEnumerable<int> lengths, int size, IList<int> numbers, ref int currentPosition,
        ref int skipSize)
    {
        foreach (var length in lengths)
        {
            var localPos = currentPosition;
            for (var i = 0; i < (int)Math.Ceiling(length / 2.0); i++)
            {
                var swapPosition = (localPos + (length - i * 2 - 1)) % size;

                if (localPos != swapPosition)
                {
                    (numbers[localPos], numbers[swapPosition]) =
                        (numbers[swapPosition], numbers[localPos]);
                }

                localPos++;
                localPos %= size;
            }

            currentPosition += length + skipSize;
            currentPosition %= size;
            skipSize++;
        }
    }
}