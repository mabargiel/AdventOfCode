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
        var visited = MarkPath(guardPos, cols, rows, obstacles);

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
        var (guardPos, obstacles, rows, cols) = input;
        var originalPath = MarkPath(guardPos, cols, rows, obstacles).Except([guardPos]).ToArray();

        return originalPath.Count(point => CausesLoop(guardPos, cols, rows, obstacles, point));
    }

    private static bool CausesLoop(
        Point guardPos,
        int cols,
        int rows,
        Point[] obstacles,
        Point extraObstacle
    )
    {
        var visitedStates = new HashSet<(Point Pos, Direction)>();
        var currentDirection = Direction.Up;
        var hashedObstacles = obstacles.ToHashSet();

        while (guardPos!.X >= 0 && guardPos.X < cols && guardPos.Y >= 0 && guardPos.Y < rows)
        {
            visitedStates.Add((guardPos, currentDirection));

            var newGuardPos = currentDirection switch
            {
                Direction.Up => guardPos with { X = guardPos.X - 1 },
                Direction.Right => guardPos with { Y = guardPos.Y + 1 },
                Direction.Down => guardPos with { X = guardPos.X + 1 },
                Direction.Left => guardPos with { Y = guardPos.Y - 1 },
                _ => null,
            };

            if (hashedObstacles.Contains(newGuardPos) || newGuardPos == extraObstacle)
            {
                currentDirection = (Direction)(((int)currentDirection + 1) % 4);
            }
            else
            {
                guardPos = newGuardPos;
            }

            if (visitedStates.Contains((guardPos, currentDirection)))
            {
                return true;
            }
        }

        return false;
    }

    private static HashSet<Point> MarkPath(Point guardPos, int cols, int rows, Point[] obstacles)
    {
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
                _ => null,
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

        return visited;
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
