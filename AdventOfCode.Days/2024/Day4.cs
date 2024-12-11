using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2024;

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

    /// <summary>
    /// Search for all occurrences of the word XMAS on the matrix in any direction.
    /// </summary>
    /// <param name="input">Parsed input</param>
    /// <returns>Count of XMAS word</returns>
    public override int Part1(char[,] input)
    {
        char[] xmasWord = ['X', 'M', 'A', 'S'];
        var rows = input.GetLength(0);
        var cols = input.GetLength(1);
        var wordCount = 0;

        var directions = new (int row, int col)[]
        {
            (0, -1),  // Top
            (-1, -1), // Top-left
            (-1, 0),  // Left
            (-1, 1),  // Bottom-left
            (0, 1),   // Bottom
            (1, 1),   // Bottom-right
            (1, 0),   // Right
            (1, -1)   // Top-right
        };

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                wordCount += directions.Count(direction => MatchesWord(i, j, direction));
            }
        }

        return wordCount;

        bool MatchesWord(int startRow, int startCol, (int row, int col) direction)
        {
            for (var k = 0; k < xmasWord.Length; k++)
            {
                var newRow = startRow + k * direction.row;
                var newCol = startCol + k * direction.col;

                if (newRow < 0 || newRow >= rows || newCol < 0 || newCol >= cols || input[newRow, newCol] != xmasWord[k])
                    return false;
            }
            return true;
        }
    }

    /// <summary>
    /// Search for all occurrences of the word MAS shaped as an X
    /// For example:
    /// M.S
    /// .A.
    /// M.S
    /// </summary>
    /// <param name="input">Parsed input</param>
    /// <returns>Count of X-shaped MAS</returns>
    public override int Part2(char[,] input)
    {
        var rows = input.GetLength(0);
        var cols = input.GetLength(1);

        var xShapedMasCount = 0;

        for (var i = 0; i < rows - 2; i++)
        {
            for (var j = 0; j < cols - 2; j++)
            {
                var firstDiagonal = $"{input[i, j]}{input[i + 1, j + 1]}{input[i + 2, j + 2]}";
                var secondDiagonal = $"{input[i + 2, j]}{input[i + 1, j + 1]}{input[i, j + 2]}";

                if (firstDiagonal is "MAS" or "SAM" && secondDiagonal is "MAS" or "SAM")
                {
                    xShapedMasCount++;
                }
            }
        }

        return xShapedMasCount;
    }
}
