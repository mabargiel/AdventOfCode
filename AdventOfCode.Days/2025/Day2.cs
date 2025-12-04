using System.Linq;
using AdventOfCode.Days.Common;

namespace AdventOfCode.Days._2025;

public class Day2 : AdventDay<IdRange[], long, long>
{
    public override IdRange[] ParseRawInput(string rawInput)
    {
        return rawInput
            .Trim()
            .Split(',')
            .Select(x =>
            {
                var parts = x.Split('-');
                return new IdRange(long.Parse(parts[0]), long.Parse(parts[1]));
            })
            .ToArray();
    }

    public override long Part1(IdRange[] input)
    {
        var result = 0L;
        foreach (var idRange in input)
        {
            for (var i = idRange.FirstId; i <= idRange.LastId; i++)
            {
                var stringify = i.ToString();
                if (stringify.Length == 1)
                    continue;

                if (stringify[..(stringify.Length / 2)] == stringify[(stringify.Length / 2)..])
                {
                    result += i;
                }
            }
        }

        return result;
    }

    public override long Part2(IdRange[] input)
    {
        var result = 0L;
        foreach (var idRange in input)
        {
            for (var i = idRange.FirstId; i <= idRange.LastId; i++)
            {
                var stringify = i.ToString();
                var checkRangeLength = stringify.Length;
                switch (checkRangeLength)
                {
                    case 1:
                        continue;
                    case 2:
                    case 3:
                        if (stringify.All(s => s == stringify[0]))
                        {
                            result += i;
                        }
                        continue;
                }

                checkRangeLength = checkRangeLength / 2 + 1;

                while (checkRangeLength >= 2)
                {
                    checkRangeLength--;
                    if (stringify.Length % checkRangeLength != 0)
                    {
                        continue;
                    }

                    var batch = stringify.Batch(checkRangeLength).ToArray();

                    if (batch.All(b => b == batch[0]))
                    {
                        result += i;
                        break;
                    }
                }
            }
        }

        return result;
    }
}

public class IdRange(long firstId, long lastId)
{
    public long FirstId { get; } = firstId;
    public long LastId { get; } = lastId;
}
