using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2017
{
    public class Day3 : AdventDay<int, int, int>
    {
        public override int ParseRawInput(string rawInput)
        {
            return int.Parse(rawInput);
        }

        public override int Part1(int input)
        {
            if (input == 1)
            {
                return 0;
            }
            
            var directionFactor = 1;
            var halfCycles = Math.Sqrt(input);
            var restMovements = input % (int) halfCycles;
            var (x, y) = (0, 0);

            for (var i = 1; i <= (int) halfCycles; i++)
            { 
                x += i * directionFactor;
                y -= i * directionFactor;
                directionFactor *= -1;
            }

            switch (restMovements)
            {
                case > 0 when halfCycles - (int) halfCycles > 0.5:
                    x += restMovements * directionFactor;
                    break;
                case > 0:
                    y += restMovements * directionFactor;
                    break;
            }

            return Math.Abs(x) + Math.Abs(y) - 1;
        }

        public override int Part2(int input)
        {
            Dictionary<(int x, int y), int> spiral = new();
            var pathLength = 1;
            var (x, y) = (0, 0);
            var directionFactor = 1;
            spiral[(0, 0)] = 1;

            while (true)
            {
                int[] neighbourValues = new int[4];
                for (var i = 0; i < pathLength; i++)
                {
                    x += directionFactor;

                    spiral.TryGetValue((x - directionFactor, y), out neighbourValues[0]);
                    spiral.TryGetValue((x - directionFactor, y + directionFactor), out neighbourValues[1]);
                    spiral.TryGetValue((x, y + directionFactor), out neighbourValues[2]);
                    spiral.TryGetValue((x + directionFactor, y + directionFactor), out neighbourValues[3]);

                    spiral[(x, y)] = neighbourValues.Sum();

                    if (spiral[(x, y)] > input)
                    {
                        return spiral[(x, y)];
                    }
                }
                
                for (var i = 0; i < pathLength; i++)
                {
                    y += directionFactor;

                    spiral.TryGetValue((x, y - directionFactor), out neighbourValues[0]);
                    spiral.TryGetValue((x - directionFactor, y - directionFactor), out neighbourValues[1]);
                    spiral.TryGetValue((x - directionFactor, y), out neighbourValues[2]);
                    spiral.TryGetValue((x - directionFactor, y + directionFactor), out neighbourValues[3]);
                    
                    spiral[(x, y)] = neighbourValues.Sum();
                    
                    if (spiral[(x, y)] > input)
                    {
                        return spiral[(x, y)];
                    }
                }

                pathLength++;
                directionFactor *= -1;
            }
        }

        private enum Side
        {
            BottomRightCorner,
            TopLeftCorner
        }
    }
}