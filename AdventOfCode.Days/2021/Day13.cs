using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode.Days.Common;

namespace AdventOfCode.Days._2021;

public class Day13 : AdventDay<Manual, int, string>
{
    public override Manual ParseRawInput(string rawInput)
    {
        var instructionsSplit = rawInput.Trim().Split(Environment.NewLine + Environment.NewLine);

        var dotsList = instructionsSplit[0].Split(Environment.NewLine).Select(dots => dots.Split(","))
            .Select(split => new Point(int.Parse(split[0]), int.Parse(split[1]))).ToList();

        var instructions = instructionsSplit[1].Split(Environment.NewLine).Select(instr => instr.Split("=")).Select(
            split =>
            {
                var axis = Enum.Parse<Axis>(split[0].Last().ToString().ToUpper());
                return new FoldInstruction(axis, int.Parse(split[1]));
            });

        return new Manual(dotsList, instructions.ToArray());
    }

    public override int Part1(Manual input)
    {
        var (transparentPaper, foldInstructions) = input;
        var (axis, index) = foldInstructions.First();

        var fold = new HashSet<Point>();

        foreach (var (x, y) in transparentPaper)
        {
            int foldedX;
            int foldedY;
            if (axis == Axis.X)
            {
                foldedX = x > index ? 2 * index - x : x;
                foldedY = y;
            }
            else
            {
                foldedX = x;
                foldedY = y > index ? 2 * index - y : y;
            }

            fold.Add(new Point(foldedX, foldedY));
        }

        return fold.Count;
    }

    public override string Part2(Manual input)
    {
        var (transparentPaper, foldInstructions) = input;

        var prevFold = transparentPaper.ToHashSet();

        foreach (var (axis, index) in foldInstructions)
        {
            var fold = new HashSet<Point>();
            foreach (var (x, y) in prevFold)
            {
                int foldedX;
                int foldedY;
                if (axis == Axis.X)
                {
                    foldedX = x > index ? 2 * index - x : x;
                    foldedY = y;
                }
                else
                {
                    foldedX = x;
                    foldedY = y > index ? 2 * index - y : y;
                }

                fold.Add(new Point(foldedX, foldedY));
            }

            prevFold = fold;
        }

        var width = prevFold.Select(x => x.X).Max() + 1;
        var height = prevFold.Select(x => x.Y).Max() + 1;

        StringBuilder sb = new();
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                sb.Append(prevFold.Contains(new Point(x, y)) ? '#' : '.');
            }

            sb.AppendLine();
        }

        return Environment.NewLine + sb.Remove(sb.Length - 1, 1) + Environment.NewLine;
    }
}

public record Manual(List<Point> TransparentPaper, FoldInstruction[] Instructions);

public record FoldInstruction(Axis Axis, int Index);

public enum Axis
{
    X,
    Y
}