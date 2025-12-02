using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Days.Common;

namespace AdventOfCode.Days._2024;

public class Day6 : AdventDay<LabMap, int, int>
{
    public override LabMap ParseRawInput(string rawInput)
    {
        var map = rawInput.Trim().Split(Environment.NewLine);
        var rowsCount = map.Length;
        var colsCount = map[0].Length;
        Point guardPos = null;
        var obstacles = new List<Point>();

        for (var i = 0; i < rowsCount; i++)
        {
            for (var j = 0; j < colsCount; j++)
            {
                switch (map[i][j])
                {
                    case '#':
                        obstacles.Add(new Point(i, j));
                        break;
                    case '^':
                        guardPos = new Point(i, j);
                        break;
                }
            }
        }

        return new LabMap(guardPos, obstacles.ToArray(), rowsCount, colsCount);
    }

    public override int Part1(LabMap input)
    {
        var (guardPos, obstacles, rows, cols) = input;
        var visited = new HashSet<Point>();
        var currentDirection = Direction.Up;

        while (guardPos!.X >= 0 && guardPos.X < cols && guardPos.Y >= 0 && guardPos.Y < rows)
        {
            visited.Add(guardPos);
            var newGuardPos = currentDirection switch
            {
                Direction.Up => guardPos with { X = guardPos.X - 1 },
                Direction.Right => guardPos with { Y = guardPos.Y + 1 },
                Direction.Down => guardPos with { X = guardPos.X + 1 },
                Direction.Left => guardPos with { Y = guardPos.Y - 1 },
                _ => null
            };

            if (obstacles.Contains(newGuardPos))
            {
                currentDirection = (Direction)(((int)currentDirection + 1) % 4);
            }
            else
            {
                guardPos = newGuardPos;
            }
        }

        return visited.Count;
    }

    /*
     *
     *  #.........
        .........#
        ..........
        ..........
        ..........
        ..........
        ^.........
        ..........
        .#........
        ........#.
     */

    public override int Part2(LabMap input)
    {
        var originalPath = DrawPath(input);
        var (startingGuardPos, obstacles, rows, cols) = input;
        var loopObstacles = new HashSet<Point>();

        foreach (var pos in originalPath)
        {
            Point[] newObstacles = [..obstacles, pos];
            var lab = new Lab(new LabMap(startingGuardPos, newObstacles, rows, cols));
            var visited = new HashSet<Guard>();

            while (lab.Guard.Pos!.X >= 0 && lab.Guard.Pos.X < cols && lab.Guard.Pos.Y >= 0 && lab.Guard.Pos.Y < rows)
            {
                if (!visited.Add(lab.Guard))
                {
                    loopObstacles.Add(pos);
                    break;
                }

                lab.MoveGuard();
            }
        }

        return loopObstacles.Count;
    }

    private record Guard(Point Pos, Direction Direction);

    private class Lab(LabMap Map)
    {
        public Guard Guard { get; private set; } = new(Map.GuardPos, Direction.Up);

        public void MoveGuard()
        {
            var (guardPos, currentDirection) = Guard;
            while (true)
            {
                var newGuardPos = currentDirection switch
                {
                    Direction.Up => guardPos with { X = guardPos.X - 1 },
                    Direction.Down => guardPos with { X = guardPos.X + 1 },
                    Direction.Left => guardPos with { Y = guardPos.Y - 1 },
                    Direction.Right => guardPos with { Y = guardPos.Y + 1 },
                    _ => null
                };

                if (Map.Obstacles.Contains(newGuardPos))
                {
                    currentDirection = (Direction)(((int)currentDirection + 1) % 4);
                }
                else
                {
                    Guard = new Guard(newGuardPos, currentDirection);
                    break;
                }
            }
        }
    }

    private static List<Point> DrawPath(LabMap input)
    {
        var (startingGuardPos, obstacles, rows, cols) = input;
        var originalPath = new List<Point>();

        var lab = new Lab(new LabMap(startingGuardPos, obstacles, rows, cols));
        do
        {
            lab.MoveGuard();
            originalPath.Add(lab.Guard.Pos);
        } while (lab.Guard.Pos!.X >= 0 && lab.Guard.Pos.X < cols && lab.Guard.Pos.Y >= 0 && lab.Guard.Pos.Y < rows);

        originalPath.RemoveAt(originalPath.Count - 1);

        return originalPath;
    }

    private enum Direction
    {
        Up,
        Right,
        Down,
        Left,
    }
}

public record LabMap(Point GuardPos, Point[] Obstacles, int Rows, int Cols);
