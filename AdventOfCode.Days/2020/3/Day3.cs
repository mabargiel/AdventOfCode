using System;
using System.Linq;
using MoreLinq;

namespace AdventOfCode.Days._2020._3
{
    public class Day3 : IAdventDay<int, int>
    {
        private readonly char[,] _map;

        public Day3(string input)
        {
            var rows = input.Split(Environment.NewLine);
            var map = new char[rows.Length, rows[0].Length];

            for (var i = 0; i < rows.Length; i++)
            {
                for (var j = 0; j < rows[i].Length; j++)
                {
                    map[i, j] = rows[i][j];
                }
            }

            _map = map;
        }

        public int Part1()
        {
            var trees = CalculateTreeCount(3, 1);
            return trees;
        }

        public int Part2()
        {
            return new[]
            {
                CalculateTreeCount(1, 1), 
                CalculateTreeCount(3, 1), 
                CalculateTreeCount(5, 1), 
                CalculateTreeCount(7, 1),
                CalculateTreeCount(1, 2)
            }.Aggregate(1, (prev, curr) => prev * curr);
        }

        private int CalculateTreeCount(int right, int down)
        {
            var (col, row) = (0, 0);
            var trees = 0;

            while (row < _map.GetLength(0))
            {
                if (_map[row, col] == '#')
                    trees++;

                col += right;
                row += down;
                
                if (col > _map.GetLength(1) - 1)
                {
                    col -= _map.GetLength(1);
                }
            }

            return trees;
        }
    }
}