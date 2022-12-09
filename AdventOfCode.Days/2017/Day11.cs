using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace AdventOfCode.Days._2017;

public class Day11 : AdventDay<Direction[], int, int>
{
    public override Direction[] ParseRawInput(string rawInput)
    {
        return rawInput.Trim().Split(',').Select(x => (Direction)Enum.Parse(typeof(Direction), x.ToUpper()))
            .ToArray();
    }

    public override int Part1(Direction[] input)
    {
        var position = new CubeCoords(0, 0, 0);

        position = input.Aggregate(position, (current, direction) => HexagonalGrid.Move(current, direction));

        return HexagonalGrid.Distance(position, new CubeCoords(0, 0, 0));
    }

    public override int Part2(Direction[] input)
    {
        var position = new CubeCoords(0, 0, 0);

        var result = 0;

        foreach (var direction in input)
        {
            position = HexagonalGrid.Move(position, direction);
            var distance = HexagonalGrid.Distance(position, new CubeCoords(0, 0, 0));
            if (distance > result)
            {
                result = distance;
            }
        }

        return result;
    }
}

public enum Direction
{
    // ReSharper disable InconsistentNaming
    N,
    NE,
    SE,
    S,
    SW,
    NW
}

// Solution from https://www.redblobgames.com/grids/hexagons
public record CubeCoords(int Q, int R, int S);

public static class HexagonalGrid
{
    private static readonly ImmutableDictionary<Direction, CubeCoords> _directionVectors =
        new Dictionary<Direction, CubeCoords>
        {
            [Direction.N] = new(0, -1, 1),
            [Direction.NE] = new(1, -1, 0),
            [Direction.SE] = new(1, 0, -1),
            [Direction.S] = new(0, 1, -1),
            [Direction.SW] = new(-1, 1, 0),
            [Direction.NW] = new(-1, 0, 1)
        }.ToImmutableDictionary();

    public static CubeCoords Move(CubeCoords position, Direction direction)
    {
        var (q, r, s) = position;
        var (vq, vr, vs) = _directionVectors[direction];
        return new CubeCoords(q + vq, r + vr, s + vs);
    }

    public static int Distance(CubeCoords a, CubeCoords b)
    {
        var (q, r, s) = CubeSubtract(a, b);
        return (Math.Abs(q) + Math.Abs(r) + Math.Abs(s)) / 2;
    }

    private static CubeCoords CubeSubtract(CubeCoords a, CubeCoords b)
    {
        var (aq, ar, aas) = a;
        var (bq, br, bs) = b;
        return new CubeCoords(aq - bq, ar - br, aas - bs);
    }
}