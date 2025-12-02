using System;
using System.Collections.Immutable;
using System.Linq;

namespace AdventOfCode.Days._2021.Day4;

public class Board
{
    private readonly ImmutableArray<BoardValue> _boardValues;

    public Board(string boardString)
    {
        var boardValues = new BoardValue[25];
        var rows = boardString.Split(Environment.NewLine);

        for (var i = 0; i < rows.Length; i++)
        {
            var columns = rows[i]
                .Split(' ')
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(int.Parse)
                .ToArray();

            for (var j = 0; j < columns.Length; j++)
            {
                boardValues[i * 5 + j] = new BoardValue(columns[j], i, j);
            }
        }

        _boardValues = boardValues.ToImmutableArray();
    }

    public int Score => _boardValues.Where(x => !x.IsMarked).Sum(x => x.Value);

    public void MarkNumber(int number)
    {
        var boardValue = _boardValues.FirstOrDefault(x => x.Value == number);

        if (boardValue == null || boardValue.IsMarked)
        {
            return;
        }

        boardValue.Mark();
    }

    public bool IsBingo()
    {
        var markedValues = _boardValues.Where(x => x.IsMarked).ToArray();

        if (markedValues.Length < 5)
        {
            return false;
        }

        var groupByRows = markedValues.GroupBy(x => x.Position.X);
        var groupByColumns = markedValues.GroupBy(x => x.Position.Y);

        return groupByRows.Any(x => x.Count() >= 5) || groupByColumns.Any(x => x.Count() >= 5);
    }
}
