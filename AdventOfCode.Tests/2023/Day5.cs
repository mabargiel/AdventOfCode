using AdventOfCode.Days._2023;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2023;

public class Day5
{
    private Days._2023.Day5 _day5;

    [SetUp]
    public void Initialize()
    {
        _day5 = new Days._2023.Day5();
    }

    [Test]
    public void ParseRawInput_IntoLogicalObject()
    {
        const string rawInput = """
            seeds: 79 14 55 13

            seed-to-soil map:
            50 98 2
            52 50 48

            soil-to-fertilizer map:
            0 15 37
            37 52 2
            39 0 15
            """;

        var input = _day5.ParseRawInput(rawInput);

        input.Seeds.ShouldBe(new[] { 79L, 14, 55, 13 });
        input.Maps.ShouldBeEquivalentTo(
            new Map[]
            {
                new(new MapRange[] { new(98, 50, 2), new(50, 52, 48) }),
                new(new MapRange[] { new(15, 0, 37), new(52, 37, 2), new(0, 39, 15) }),
            }
        );
    }

    [Test]
    [TestCase(
        """
            seeds: 79 14 55 13

            seed-to-soil map:
            50 98 2
            52 50 48

            soil-to-fertilizer map:
            0 15 37
            37 52 2
            39 0 15

            fertilizer-to-water map:
            49 53 8
            0 11 42
            42 0 7
            57 7 4

            water-to-light map:
            88 18 7
            18 25 70

            light-to-temperature map:
            45 77 23
            81 45 19
            68 64 13

            temperature-to-humidity map:
            0 69 1
            1 0 69

            humidity-to-location map:
            60 56 37
            56 93 4
            """,
        35
    )]
    public void Part1_WithExampleInput_CalculateMinLocation(string input, int expectedResult)
    {
        var parsedInput = _day5.ParseRawInput(input);

        var result = _day5.Part1(parsedInput);

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(
        """
            seeds: 79 14 55 13

            seed-to-soil map:
            50 98 2
            52 50 48

            soil-to-fertilizer map:
            0 15 37
            37 52 2
            39 0 15

            fertilizer-to-water map:
            49 53 8
            0 11 42
            42 0 7
            57 7 4

            water-to-light map:
            88 18 7
            18 25 70

            light-to-temperature map:
            45 77 23
            81 45 19
            68 64 13

            temperature-to-humidity map:
            0 69 1
            1 0 69

            humidity-to-location map:
            60 56 37
            56 93 4
            """,
        46
    )]
    [TestCase(
        """
            seeds: 79 14 55 13

            seed-to-soil map:
            50 98 2
            52 50 48

            soil-to-fertilizer map:
            0 15 37
            37 52 2
            39 0 15

            fertilizer-to-water map:
            49 53 8
            0 11 42
            42 0 7
            57 7 4

            water-to-light map:
            88 18 7
            18 25 70

            light-to-temperature map:
            45 77 23
            81 45 19
            68 64 13

            temperature-to-humidity map:
            0 69 1
            1 0 69

            humidity-to-location map:
            60 54 2
            56 93 4
            """,
        46
    )]
    public void Part2_WithExampleInput_CalculateMinLocation_ForSeedRanges(
        string input,
        int expectedResult
    )
    {
        var parsedInput = _day5.ParseRawInput(input);

        var result = _day5.Part2(parsedInput);

        result.ShouldBe(expectedResult);
    }
}
