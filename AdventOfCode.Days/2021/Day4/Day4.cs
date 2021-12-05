using System;

namespace AdventOfCode.Days._2021.Day4
{
    public class Day4 : AdventDay<BingoGame, int, int>
    {
        public override BingoGame ParseRawInput(string rawInput)
        {
            return new BingoGame(rawInput);
        }

        public override int Part1(BingoGame input)
        {
            foreach (var number in input.ChosenNumbers)
            {
                var winner = input.ExecuteRoundAndFindWinner(number);

                if (winner != null)
                {
                    return winner.Score * input.LastMarkedValue;
                }
            }

            return -1;
        }

        public override int Part2(BingoGame input)
        {
            Board lastWinner = null;
            foreach (var number in input.ChosenNumbers)
            {
                var currentWinner = input.ExecuteRoundAndFindWinner(number);
                lastWinner = currentWinner ?? lastWinner;
            }

            if (lastWinner == null)
            {
                throw new InvalidOperationException("Unable to win using the input provided");
            }

            return lastWinner.Score * input.LastMarkedValue;
        }
    }
}