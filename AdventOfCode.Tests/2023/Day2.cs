using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2023;

public class Day2
{
    private Days._2023.Day2 _day2;

    [SetUp]
    public void Initialize()
    {
        _day2 = new Days._2023.Day2();
    }

    [Test]
    public void ParseRawInput_IntoGamesContainingTurns()
    {
        const string rawInput = """
            Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
            Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
            Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
            Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
            Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
            """;

        var input = _day2.ParseRawInput(rawInput);

        input.ShouldBe(
            new List<List<Dictionary<string, int>>>
            {
                new()
                {
                    new Dictionary<string, int> { ["blue"] = 3, ["red"] = 4 },
                    new Dictionary<string, int>
                    {
                        ["red"] = 1,
                        ["green"] = 2,
                        ["blue"] = 6,
                    },
                    new Dictionary<string, int> { ["green"] = 2 },
                },
                new()
                {
                    new Dictionary<string, int> { ["blue"] = 1, ["green"] = 2 },
                    new Dictionary<string, int>
                    {
                        ["green"] = 3,
                        ["blue"] = 4,
                        ["red"] = 1,
                    },
                    new Dictionary<string, int> { ["green"] = 1, ["blue"] = 1 },
                },
                new()
                {
                    new Dictionary<string, int>
                    {
                        ["green"] = 8,
                        ["blue"] = 6,
                        ["red"] = 20,
                    },
                    new Dictionary<string, int>
                    {
                        ["blue"] = 5,
                        ["red"] = 4,
                        ["green"] = 13,
                    },
                    new Dictionary<string, int> { ["green"] = 5, ["red"] = 1 },
                },
                new()
                {
                    new Dictionary<string, int>
                    {
                        ["green"] = 1,
                        ["red"] = 3,
                        ["blue"] = 6,
                    },
                    new Dictionary<string, int> { ["green"] = 3, ["red"] = 6 },
                    new Dictionary<string, int>
                    {
                        ["green"] = 3,
                        ["blue"] = 15,
                        ["red"] = 14,
                    },
                },
                new()
                {
                    new Dictionary<string, int>
                    {
                        ["red"] = 6,
                        ["blue"] = 1,
                        ["green"] = 3,
                    },
                    new Dictionary<string, int>
                    {
                        ["blue"] = 2,
                        ["red"] = 1,
                        ["green"] = 2,
                    },
                },
            }
        );
    }

    [Test]
    [TestCase(
        """
            Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
            Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
            Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
            Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
            Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
            """,
        8
    )]
    public void Part1_WithExampleInput_CalculateSumOfPossibleGameIds(
        string input,
        int expectedResult
    )
    {
        var parsedInput = _day2.ParseRawInput(input);

        var result = _day2.Part1(parsedInput);

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(
        """
            Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
            Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
            Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
            Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
            Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
            """,
        2286
    )]
    public void Part2_WithExampleInput_CalculateSumoOfPowersOfPossibleCubes(
        string input,
        int expectedResult
    )
    {
        var parsedInput = _day2.ParseRawInput(input);

        var result = _day2.Part2(parsedInput);

        result.ShouldBe(expectedResult);
    }
}
