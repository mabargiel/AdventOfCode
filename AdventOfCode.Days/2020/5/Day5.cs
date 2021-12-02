using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2020._5
{
    public class Day5 : IAdventDay<int, int>
    {
        private readonly List<string> _boardingPasses;
        private readonly int _cols;
        private readonly int _rows;

        public Day5(string input)
        {
            _rows = 128;
            _cols = 8;
            _boardingPasses = input.Split(Environment.NewLine).ToList();
        }

        public int Part1()
        {
            return Decode(.._rows, .._cols).Max();
        }

        public int Part2()
        {
            var sorted = Decode(.._rows, .._cols).OrderBy(seatId => seatId).ToList();

            for (var i = 1; i < sorted.Count; i++)
            {
                if (sorted[i] - sorted[i - 1] == 2)
                {
                    return sorted[i] - 1;
                }
            }

            throw new InvalidOperationException();
        }

        private IEnumerable<int> Decode(Range rowsRange, Range colsRange)
        {
            var ids = _boardingPasses.Select(s =>
            {
                var row = Decode(s.Substring(0, 7), rowsRange);
                var col = Decode(s.Substring(7, 3), colsRange);

                return GetId(row, col);
            });

            return ids;
        }

        private static int Decode(string s, Range range)
        {
            var lowIndex = range.Start.Value;
            var highIndex = range.End.Value - 1;

            foreach (var op in s)
            {
                switch (op)
                {
                    case 'F':
                    case 'L':
                        highIndex = lowIndex + (highIndex - lowIndex) / 2;
                        break;
                    case 'B':
                    case 'R':
                        lowIndex += (highIndex - lowIndex) / 2 + 1;
                        break;
                }
            }

            return highIndex;
        }

        private static int GetId(in int row, in int col)
        {
            return row * 8 + col;
        }
    }
}