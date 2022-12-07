using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace AdventOfCode.Days._2021.Day4;

public class BingoGame
{
    private int _currentNumberPos;

    public BingoGame(string input)
    {
        var segments = input.Trim().Split(Environment.NewLine + Environment.NewLine);

        var randomNumbers = segments.First().Split(',').Select(int.Parse);
        ChosenNumbers = randomNumbers.ToImmutableArray();

        var boards = segments[1..].Select(boardString => new Board(boardString)).ToList();

        Boards = boards;
    }

    public ImmutableArray<int> ChosenNumbers { get; }
    public List<Board> Boards { get; }
    public int LastMarkedValue { get; private set; } = -1;

    public Board ExecuteRoundAndFindWinner(int number)
    {
        if (!Boards.Any())
        {
            return null;
        }

        LastMarkedValue = number;
        Board winner = null;
        foreach (var board in Boards.ToArray())
        {
            board.MarkNumber(number);
            if (board.IsBingo())
            {
                winner ??= board;
                Boards.Remove(board);
            }
        }

        return winner;
    }
}