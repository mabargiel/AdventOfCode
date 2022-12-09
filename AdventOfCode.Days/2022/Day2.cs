using System;
using System.Linq;

namespace AdventOfCode.Days._2022;

public class Day2 : AdventDay<char[][], int, int>
{
    public override char[][] ParseRawInput(string rawInput)
    {
        return rawInput.Trim().Split(Environment.NewLine).Select(x =>
        {
            var hands = x.Split(' ');
            return new[] { hands[0].First(), hands[1].First() };
        }).ToArray();
    }

    public override int Part1(char[][] input)
    {
        var score = 0;
        const int aAsciiCode = 65;
        const int xAsciiCode = 88;

        foreach (var round in input)
        {
            var (hisHand, theAnswer) = (round[0] - aAsciiCode, round[1] - xAsciiCode);
            score += theAnswer + 1;

            if (hisHand == theAnswer)
            {
                score += 3;
            }
            else if (theAnswer == CalculateWinAnswer(hisHand))
            {
                score += 6;
            }
        }

        return score;
    }

    public override int Part2(char[][] input)
    {
        var score = 0;
        const int relativeAAsciiCode = 65;
        foreach (var round in input)
        {
            var (hisHand, theOutcome) = (round[0] - relativeAAsciiCode, round[1]);
            switch (theOutcome)
            {
                //lose
                case 'X':
                {
                    score += CalculateWinAnswer(hisHand + 1) +
                             1; //get next possible choice and calculate win to get the loosing answer
                    break;
                }
                case 'Y':
                    score += 3 + hisHand + 1;
                    break;
                case 'Z':
                    score += 6 + CalculateWinAnswer(hisHand) + 1;
                    break;
            }
        }

        return score;
    }

    private static int CalculateWinAnswer(int hisHand)
    {
        return (hisHand + 1) % 3;
    }
}