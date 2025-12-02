using System;
using System.Linq;

namespace AdventOfCode.Days._2023;

public class Day5 : AdventDay<Almanac, long, long>
{
    public override Almanac ParseRawInput(string rawInput)
    {
        var split = rawInput.Trim().Split(Environment.NewLine + Environment.NewLine);
        var seedsString = split[0];
        var seeds = seedsString[(seedsString.IndexOf(':') + 2)..]
            .Split(' ')
            .Select(long.Parse)
            .ToArray();

        return new Almanac(
            seeds,
            split[1..]
                .Select(mapStrings => mapStrings.Split(Environment.NewLine)[1..])
                .Select(rangesStrings => new Map(
                    rangesStrings
                        .Select(rangesString =>
                            rangesString.Split(' ').Select(long.Parse).ToArray()
                        )
                        .Select(rangesInfo => new MapRange(
                            rangesInfo[1],
                            rangesInfo[0],
                            rangesInfo[2]
                        ))
                        .ToArray()
                ))
                .ToArray()
        );
    }

    public override long Part1(Almanac input)
    {
        var (seeds, maps) = input;

        foreach (var map in maps)
        {
            var ranges = map.MapRanges;

            for (var i = 0; i < seeds.Length; i++)
            {
                var currentSource = seeds[i];

                var matchingRange = ranges.FirstOrDefault(range =>
                    currentSource >= range.Source && currentSource < range.Source + range.Length
                );

                if (matchingRange != null)
                {
                    var diff = seeds[i] - matchingRange.Source;
                    seeds[i] = matchingRange.Dest + diff;
                }
            }
        }

        return seeds.Min();
    }

    public override long Part2(Almanac input)
    {
        var (seeds, maps) = input;

        var seedRanges = seeds
            .Chunk(2)
            .Select(chunk => (chunk[0], chunk[0] + chunk[1] - 1))
            .ToList();

        foreach (var map in maps)
        {
            var ranges = map.MapRanges;
            var currentSeedsCount = seedRanges.Count;

            for (var i = 0; i < currentSeedsCount; i++)
            {
                var seedRange = seedRanges[i];
                var (seedStart, seedEnd) = seedRange;

                foreach (var (sourceStart, destStart, length) in ranges)
                {
                    var sourceEnd = sourceStart + length - 1;
                    var destEnd = destStart + length - 1;

                    //No intersection
                    if (sourceStart > seedEnd || sourceEnd < seedStart)
                    {
                        continue;
                    }

                    //Whole seed inside map
                    if (sourceStart <= seedStart && sourceEnd >= seedEnd)
                    {
                        var diff = destStart - sourceStart;
                        seedRanges[i] = (seedStart + diff, seedEnd + diff);
                    }
                    //whole map inside seed
                    else if (sourceStart > seedStart && sourceEnd < seedEnd)
                    {
                        //left
                        seedRanges[i] = (seedStart, sourceStart - 1);
                        //right
                        seedRanges.Add((sourceEnd + 1, seedEnd));
                        //middle
                        seedRanges.Add((destStart, destEnd));
                    }
                    //left side intersection
                    else if (
                        seedStart < sourceStart
                        && seedEnd >= sourceStart
                        && seedEnd <= sourceEnd
                    )
                    {
                        //left
                        seedRanges[i] = (seedStart, sourceStart - 1);

                        //intersection
                        var diff = seedEnd - sourceStart;
                        seedRanges.Add((destStart, destStart + diff));
                    }
                    //right side intersection
                    else if (
                        seedStart >= sourceStart
                        && seedStart <= sourceEnd
                        && seedEnd > sourceEnd
                    )
                    {
                        //right
                        seedRanges[i] = (sourceEnd + 1, seedEnd);

                        //intersection
                        var diff = seedStart - sourceStart;
                        seedRanges.Add((destStart + diff, destEnd));
                    }
                }
            }
        }

        return seedRanges.Select(x => x.Item1).Where(x => x > 0).Min();
    }
}

public record Almanac(long[] Seeds, Map[] Maps);

public record Map(MapRange[] MapRanges);

public record MapRange(long Source, long Dest, long Length);
