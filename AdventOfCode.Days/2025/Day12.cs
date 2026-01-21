using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days._2025;

public partial class Day12 : AdventDay<PresentsMetadata, int, int>
{
    public override PresentsMetadata ParseRawInput(string rawInput)
    {
        rawInput = rawInput.Replace("\r\n", "\n").TrimEnd();
        var lines = rawInput.Split('\n');

        var shapes = new List<ShapeDef>();
        var regions = new List<RegionDef>();

        var i = 0;
        while (i < lines.Length)
        {
            if (string.IsNullOrWhiteSpace(lines[i]))
            {
                i++;
                continue;
            }

            var mRegion = RegionLine.Match(lines[i]);
            if (mRegion.Success)
            {
                var w = int.Parse(mRegion.Groups[1].Value);
                var h = int.Parse(mRegion.Groups[2].Value);
                var counts = mRegion
                    .Groups[3]
                    .Value.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                regions.Add(new RegionDef(w, h, counts));
                i++;
                continue;
            }

            var mShape = ShapeHeader.Match(lines[i]);
            if (mShape.Success)
            {
                var id = int.Parse(mShape.Groups[1].Value);
                i++;

                var grid = new List<string>();
                while (i < lines.Length && !string.IsNullOrWhiteSpace(lines[i]))
                {
                    grid.Add(lines[i].TrimEnd());
                    i++;
                }

                while (shapes.Count <= id)
                {
                    shapes.Add(new ShapeDef(shapes.Count, Array.Empty<string>()));
                }

                shapes[id] = new ShapeDef(id, grid.ToArray());
                continue;
            }

            i++;
        }

        var shapeCount = shapes.Count;

        for (var r = 0; r < regions.Count; r++)
        {
            if (regions[r].Counts.Length >= shapeCount)
            {
                continue;
            }

            var resized = new int[shapeCount];
            Array.Copy(regions[r].Counts, resized, regions[r].Counts.Length);
            regions[r] = regions[r] with { Counts = resized };
        }

        return new PresentsMetadata(shapes.ToArray(), regions.ToArray());
    }

    public override int Part1(PresentsMetadata input)
    {
        var shapeVariants = input.Shapes.Select(BuildVariants).ToArray();
        var shapeAreas = shapeVariants.Select(v => v[0].Cells.Length).ToArray();

        return (
            from region in input.Regions
            let totalFilled = region.Counts.Select((t, s) => t * shapeAreas[s]).Sum()
            where totalFilled <= region.Width * region.Height
            select region
        ).Count(region => CanPack(region, shapeVariants, shapeAreas));
    }

    public override int Part2(PresentsMetadata input)
    {
        throw new NotImplementedException();
    }

    private static bool CanPack(RegionDef region, Variant[][] shapeVariants, int[] shapeAreas)
    {
        var w = region.Width;
        var h = region.Height;
        var n = w * h;

        var counts = (int[])region.Counts.Clone();

        var blocksLen = (n + 63) >> 6;
        var occupied = new ulong[blocksLen];

        var placementsByShape = new Placement[shapeVariants.Length][];
        for (var s = 0; s < shapeVariants.Length; s++)
        {
            placementsByShape[s] = BuildPlacements(shapeVariants[s], w, h, n, blocksLen);
        }

        if (counts.Where((t, s) => t > 0 && placementsByShape[s].Length == 0).Any())
        {
            return false;
        }

        var order = Enumerable
            .Range(0, counts.Length)
            .OrderByDescending(s => shapeAreas[s])
            .ThenBy(s => placementsByShape[s].Length)
            .ToArray();

        return Dfs(counts, occupied, placementsByShape, order);
    }

    private static bool Dfs(
        int[] counts,
        ulong[] occupied,
        Placement[][] placementsByShape,
        int[] order
    )
    {
        var remaining = counts.Sum();
        if (remaining == 0)
            return true;

        var bestShape = -1;
        var bestCount = int.MaxValue;

        foreach (var s in order)
        {
            if (counts[s] <= 0)
                continue;

            var c = CountFittable(placementsByShape[s], occupied, bestCount);
            if (c == 0)
                return false;

            if (c >= bestCount)
            {
                continue;
            }

            bestCount = c;
            bestShape = s;
            if (bestCount == 1)
                break;
        }

        counts[bestShape]--;

        var placements = placementsByShape[bestShape];
        for (var i = 0; i < placements.Length; i++)
        {
            ref var p = ref placements[i];
            if (Intersects(occupied, p.Mask))
                continue;

            OrWith(occupied, p.Mask);

            if (Dfs(counts, occupied, placementsByShape, order))
            {
                AndNotWith(occupied, p.Mask);
                counts[bestShape]++;
                return true;
            }

            AndNotWith(occupied, p.Mask);
        }

        counts[bestShape]++;
        return false;
    }

    private static int CountFittable(Placement[] placements, ulong[] occupied, int cutoff)
    {
        var count = 0;

        foreach (var placement in placements)
        {
            if (Intersects(occupied, placement.Mask))
            {
                continue;
            }

            count++;
            if (count >= cutoff)
                return count;
        }

        return count;
    }

    private static Placement[] BuildPlacements(
        Variant[] variants,
        int w,
        int h,
        int n,
        int blocksLen
    )
    {
        var list = new List<Placement>(variants.Length * (w * h));

        foreach (var variant in variants)
        {
            var cells = variant.Cells;

            var maxX = 0;
            var maxY = 0;
            foreach (var cell in cells)
            {
                if (cell.X > maxX)
                    maxX = cell.X;
                if (cell.Y > maxY)
                    maxY = cell.Y;
            }

            for (var oy = 0; oy + maxY < h; oy++)
            {
                for (var ox = 0; ox + maxX < w; ox++)
                {
                    var mask = new ulong[blocksLen];

                    foreach (var cell in cells)
                    {
                        var x = ox + cell.X;
                        var y = oy + cell.Y;
                        var idx = y * w + x;
                        mask[idx >> 6] |= 1UL << (idx & 63);
                    }

                    list.Add(new Placement(mask));
                }
            }
        }

        return list.ToArray();
    }

    private static bool Intersects(ulong[] a, ulong[] b)
    {
        return a.Where((t, i) => (t & b[i]) != 0UL).Any();
    }

    private static void OrWith(ulong[] a, ulong[] b)
    {
        for (var i = 0; i < a.Length; i++)
        {
            a[i] |= b[i];
        }
    }

    private static void AndNotWith(ulong[] a, ulong[] b)
    {
        for (var i = 0; i < a.Length; i++)
        {
            a[i] &= ~b[i];
        }
    }

    private static Variant[] BuildVariants(ShapeDef shape)
    {
        var pts = new List<Cell>();

        for (var y = 0; y < shape.Grid.Length; y++)
        {
            var row = shape.Grid[y];
            for (var x = 0; x < row.Length; x++)
            {
                if (row[x] == '#')
                {
                    pts.Add(new Cell(x, y));
                }
            }
        }

        var seen = new HashSet<string>();
        var res = new List<Variant>();

        foreach (var flip in new[] { false, true })
        {
            var basePts = flip ? pts.Select(p => new Cell(-p.X, p.Y)).ToArray() : pts.ToArray();

            for (var rot = 0; rot < 4; rot++)
            {
                var rotated = new Cell[basePts.Length];
                for (var i = 0; i < basePts.Length; i++)
                {
                    rotated[i] = Rotate(basePts[i], rot);
                }

                var norm = Normalize(rotated);
                var key = Key(norm);

                if (seen.Add(key))
                {
                    res.Add(new Variant(norm));
                }
            }
        }

        return res.ToArray();
    }

    private static Cell Rotate(Cell p, int rot)
    {
        return rot switch
        {
            0 => p,
            1 => new Cell(-p.Y, p.X),
            2 => new Cell(-p.X, -p.Y),
            3 => new Cell(p.Y, -p.X),
            _ => p,
        };
    }

    private static Cell[] Normalize(Cell[] pts)
    {
        var minX = int.MaxValue;
        var minY = int.MaxValue;

        foreach (var cell in pts)
        {
            if (cell.X < minX)
                minX = cell.X;
            if (cell.Y < minY)
                minY = cell.Y;
        }

        for (var i = 0; i < pts.Length; i++)
        {
            pts[i] = new Cell(pts[i].X - minX, pts[i].Y - minY);
        }

        Array.Sort(
            pts,
            static (a, b) =>
            {
                var cy = a.Y.CompareTo(b.Y);
                return cy != 0 ? cy : a.X.CompareTo(b.X);
            }
        );

        return pts;
    }

    private static string Key(Cell[] pts)
    {
        var sb = new StringBuilder(pts.Length * 6);
        for (var i = 0; i < pts.Length; i++)
        {
            if (i != 0)
                sb.Append(';');
            sb.Append(pts[i].X);
            sb.Append(',');
            sb.Append(pts[i].Y);
        }

        return sb.ToString();
    }

    private static readonly Regex ShapeHeader = ShapeHeaderRegex();
    private static readonly Regex RegionLine = RegionLineRegex();

    private readonly record struct Cell(int X, int Y);

    private readonly record struct Variant(Cell[] Cells);

    private readonly record struct Placement(ulong[] Mask);

    [GeneratedRegex(@"^\s*(\d+)\s*:\s*$", RegexOptions.Compiled)]
    private static partial Regex ShapeHeaderRegex();

    [GeneratedRegex(@"^\s*(\d+)\s*x\s*(\d+)\s*:\s*(.*)\s*$", RegexOptions.Compiled)]
    private static partial Regex RegionLineRegex();
}

public record PresentsMetadata(ShapeDef[] Shapes, RegionDef[] Regions);

public record ShapeDef(int Id, string[] Grid);

public record RegionDef(int Width, int Height, int[] Counts);
