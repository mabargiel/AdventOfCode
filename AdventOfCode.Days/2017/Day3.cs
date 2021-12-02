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
            
            var pathLength = 1;
            var (x, y) = (0, 0);
            var factors = new[] { 1, 0, -1, 0 };
            var xFactorIndex = 0;
            var yFactorIndex = 3;
            var currentValue = 1;
            
            while (true)
            {
                for (var j = 0; j < 2; j++)
                {
                    var xVect = factors[xFactorIndex];
                    var yVect = factors[yFactorIndex];
                    
                    for (var i = 0; i < pathLength; i++)
                    {
                        currentValue++;
                        x += xVect;
                        y += yVect;

                        if (currentValue == input)
                        {
                            return Math.Abs(x) + Math.Abs(y);
                        }
                    }

                    xFactorIndex++;
                    yFactorIndex++;
                    xFactorIndex %= 4;
                    yFactorIndex %= 4;
                }

                pathLength++;
            }
        }

        public override int Part2(int input)
        {
            Dictionary<(int x, int y), int> spiral = new();
            var pathLength = 1;
            var (x, y) = (0, 0);
            spiral[(0, 0)] = 1;

            var factors = new[] { 1, 0, -1, 0 };
            var xFactorIndex = 0;
            var yFactorIndex = 3;

            while (true)
            {
                int[] neighbourValues = new int[4];
                
                for (var j = 0; j < 2; j++)
                {
                    var xVect = factors[xFactorIndex];
                    var yVect = factors[yFactorIndex];
                    
                    for (var i = 0; i < pathLength; i++)
                    {
                        x += xVect;
                        y += yVect;

                        spiral.TryGetValue((x - xVect, y - yVect), out neighbourValues[0]);
                        spiral.TryGetValue((x - (xVect + yVect), y + (xVect - yVect)), out neighbourValues[2]);
                        spiral.TryGetValue((x - yVect, y +xVect), out neighbourValues[1]);
                        spiral.TryGetValue((x + (xVect - yVect), y + xVect + yVect), out neighbourValues[3]);

                        spiral[(x, y)] = neighbourValues.Sum();

                        if (spiral[(x, y)] > input) 
                        {
                            return spiral[(x, y)];
                        }
                    }

                    xFactorIndex++;
                    yFactorIndex++;
                    xFactorIndex %= 4;
                    yFactorIndex %= 4;
                }

                pathLength++;
            }
        }
    }
}