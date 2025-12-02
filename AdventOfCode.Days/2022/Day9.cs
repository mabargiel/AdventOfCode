using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Days.Common;

namespace AdventOfCode.Days._2022;

public class Day9 : AdventDay<Motion[], int, int>
{
    public override Motion[] ParseRawInput(string rawInput)
    {
        return rawInput
            .Trim()
            .Split(Environment.NewLine)
            .Select(x => new Motion(x.First(), int.Parse(x[(x.IndexOf(' ') + 1)..])))
            .ToArray();
    }

    public override int Part1(Motion[] input)
    {
        return VisitedCount(input, 1);
    }

    public override int Part2(Motion[] input)
    {
        return VisitedCount(input, 9);
    }

    private static int VisitedCount(IEnumerable<Motion> input, int tailLength)
    {
        var head = new Point(0, 0);
        var tail = new List<Point>(Enumerable.Range(0, tailLength).Select(x => new Point(0, 0)));
        var visited = new HashSet<Point> { new(0, 0) };

        foreach (var motion in input)
        {
            Func<Point, Point> move = motion.Direction switch
            {
                'U' => p => p with { Y = p.Y + 1 },
                'D' => p => p with { Y = p.Y - 1 },
                'L' => p => p with { X = p.X - 1 },
                'R' => p => p with { X = p.X + 1 },
                _ => p => p,
            };

            for (var i = 0; i < motion.Steps; i++)
            {
                head = motion.Direction switch
                {
                    'U' => head with { Y = head.Y + 1 },
                    'D' => head with { Y = head.Y - 1 },
                    'L' => head with { X = head.X - 1 },
                    'R' => head with { X = head.X + 1 },
                    _ => head,
                };

                var curr = head;
                for (var j = 0; j < tailLength; j++)
                {
                    var tailPart = tail[j];
                    var xDiff = curr.X - tailPart.X;
                    var yDiff = curr.Y - tailPart.Y;
                    var xDistance = Math.Abs(xDiff);
                    var yDistance = Math.Abs(yDiff);

                    if (xDistance > 1 || yDistance > 1)
                    {
                        xDiff +=
                            xDistance > 1
                                ? curr.X < tailPart.X
                                    ? 1
                                    : -1
                                : 0;
                        yDiff +=
                            yDistance > 1
                                ? curr.Y < tailPart.Y
                                    ? 1
                                    : -1
                                : 0;
                        tail[j] = new Point(tailPart.X + xDiff, tailPart.Y + yDiff);
                    }
                    else
                    {
                        break;
                    }

                    curr = tail[j];
                }

                visited.Add(tail[tailLength - 1]);
            }
        }

        return visited.Count;
    }
}

public record Motion(char Direction, int Steps);
