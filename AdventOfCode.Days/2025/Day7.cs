using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2025;

public class Day7 : AdventDay<char[][], int, long>
{
    public override char[][] ParseRawInput(string rawInput)
    {
        return rawInput.Trim().Split(Environment.NewLine).Select(x => x.ToArray()).ToArray();
    }

    public override int Part1(char[][] input)
    {
        int[] laserPoints = [input[0].IndexOf('S')];
        var result = 0;

        foreach (var row in input[1..])
        {
            var newLasers = new HashSet<int>(laserPoints);
            foreach (var laserPoint in laserPoints)
            {
                if (row[laserPoint] == '^')
                {
                    result++;
                    newLasers.Remove(laserPoint);
                    newLasers.Add(laserPoint - 1);
                    newLasers.Add(laserPoint + 1);
                }
            }

            laserPoints = newLasers.ToArray();
        }

        return result;
    }

    public override long Part2(char[][] input)
    {
        var pathReachCount = new long[input[0].Length];
        pathReachCount[input[0].IndexOf('S')] = 1;

        foreach (var row in input[1..])
        {
            for (var i = 0; i < row.Length; i++)
            {
                if (row[i] == '^')
                {
                    pathReachCount[i - 1] += pathReachCount[i];
                    pathReachCount[i + 1] += pathReachCount[i];
                    pathReachCount[i] = 0;
                }
            }
        }

        return pathReachCount.Sum();
    }
}
