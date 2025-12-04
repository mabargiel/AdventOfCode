using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Days.Common;

namespace AdventOfCode.Days._2025;

public class Day4 : AdventDay<char[,], int, int>
{
    public override char[,] ParseRawInput(string rawInput)
    {
        var trimmed = rawInput.Trim();
        var rows = trimmed.Split(Environment.NewLine);
        var colsCount = rows[0].Length;
        var rowsCount = rows.Length;

        var result = new char[rowsCount, colsCount];

        for (var i = 0; i < rowsCount; i++)
        {
            for (var j = 0; j < colsCount; j++)
            {
                result[i, j] = rows[i][j];
            }
        }

        return result;
    }

    public override int Part1(char[,] input)
    {
        var count = 0;
        for (var i = 0; i < input.GetLength(0); i++)
        {
            for (var j = 0; j < input.GetLength(1); j++)
            {
                if (input[i, j] != '@')
                {
                    continue;
                }

                if (CountPapersAround(input, i, j) < 4)
                {
                    count++;
                }
            }
        }

        return count;
    }

    public override int Part2(char[,] input)
    {
        var posToRemove = new List<Point>();
        var count = 0;
        do
        {
            posToRemove = [];
            for (var i = 0; i < input.GetLength(0); i++)
            {
                for (var j = 0; j < input.GetLength(1); j++)
                {
                    if (input[i, j] != '@')
                    {
                        continue;
                    }

                    if (CountPapersAround(input, i, j) < 4)
                    {
                        count++;
                        posToRemove.Add(new Point(i, j));
                    }
                }
            }
            posToRemove.ForEach(p => input[p.X, p.Y] = '.');
        } while (posToRemove.Count != 0);

        return count;
    }

    private static int CountPapersAround(char[,] input, int i, int j)
    {
        Point[] positions =
        [
            new(-1, -1),
            new(0, -1),
            new(1, -1),
            new(1, 0),
            new(1, 1),
            new(0, 1),
            new(-1, 1),
            new(-1, 0),
        ];

        return (
            from position in positions
            let checkPosX = i + position.X
            let checkPosY = j + position.Y
            where
                checkPosX >= 0
                && checkPosX < input.GetLength(0)
                && checkPosY >= 0
                && checkPosY < input.GetLength(1)
            where input[checkPosX, checkPosY] == '@'
            select checkPosX
        ).Count();
    }
}
