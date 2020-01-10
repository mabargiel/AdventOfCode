using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AdventOfCode.Days._2019.Intcode;

namespace AdventOfCode.Days._2019._11
{
    public class Day11 : IAdventDay<int, bool[][]>
    {
        private readonly IEnumerable<long> _robotCode;

        public Day11(IEnumerable<long> robotCode)
        {
            _robotCode = robotCode;
        }

        public int Part1()
        {
            return RunHullRobot(_robotCode.ToArray(), 0).Count;
        }

        public bool[][] Part2()
        {
            var paintArea = RunHullRobot(_robotCode.ToArray(), 1);

            return ToNumpyArray(paintArea);
        }

        private Dictionary<Point, bool> RunHullRobot(long[] code, long input)
        {
            var paintArea = new Dictionary<Point, bool>();
            var intcodeComputer = new IntcodeComputer(_robotCode);
            intcodeComputer.Input(input);
            var robot = new HullPaintingRobot(intcodeComputer, paintArea);

            robot.RunAsync().Wait();

            return paintArea;
        }

        private static bool[][] ToNumpyArray(Dictionary<Point, bool> paintArea)
        {
            var minY = paintArea.Min(x => x.Key.Y);
            var maxY = paintArea.Max(x => x.Key.Y);
            var minX = paintArea.Min(x => x.Key.X);
            var maxX = paintArea.Max(x => x.Key.X);

            var height = Math.Abs(minY - maxY) + 1;
            var width = Math.Abs(minX - maxX) + 1;

            var rows = new bool[height][];

            for (var i = 0; i < rows.Length; i++)
            {
                rows[i] = new bool[width];
            }

            foreach (var (key, value) in paintArea)
            {
                var rowNumber = Math.Abs(minY - key.Y);
                var colNumber = Math.Abs(minX - key.X);

                Console.WriteLine($"{rowNumber}, {colNumber}, W: {width}, H: {height}");

                rows[rowNumber][colNumber] = value;
            }

            return rows;
        }
    }
}