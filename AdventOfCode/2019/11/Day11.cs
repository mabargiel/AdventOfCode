using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using AdventOfCode._2019.Intcode;
using MoreLinq;
using MoreLinq.Extensions;

namespace AdventOfCode._2019._11
{
    public class Day11 : IAdventDay<int, bool[][]>
    {
        private readonly Dictionary<long, long> _robotCode;

        public Day11(IEnumerable<long> robotCode)
        {
            _robotCode = robotCode.Select((x, i) => (x, (long) i)).ToDictionary(x => x.Item2, x => x.x);
        }
        
        public int Part1()
        {
            var program = new Intcode.Program(_robotCode);
            program.Buffer.Add(0);
            
            return RunHullRobot(program).Count;
        }

        public bool[][] Part2()
        {
            var program = new Intcode.Program(_robotCode);
            program.Buffer.Add(1);
            
            var paintArea = RunHullRobot(program);

            return ToNumpyArray(paintArea);
        }

        private static Dictionary<Point, bool> RunHullRobot(Intcode.Program program)
        {
            var paintArea = new Dictionary<Point, bool>();
            var robot = new HullPaintingRobot(new IntcodeComputer(program), paintArea);

            robot.Run().Wait();

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