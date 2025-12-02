using System.Collections.Generic;
using AdventOfCode.Days._2023;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2023;

public class Day8
{
    private Days._2023.Day8 _day8;

    [SetUp]
    public void Initialize()
    {
        _day8 = new Days._2023.Day8();
    }

    [Test]
    public void ParseRawInput_IntoLogicalObject()
    {
        const string rawInput = """
            RL

            AAA = (BBB, CCC)
            BBB = (DDD, EEE)
            CCC = (ZZZ, GGG)
            """;

        var input = _day8.ParseRawInput(rawInput);

        input.ShouldBeEquivalentTo(
            new NavigationMap(
                "RL",
                new Dictionary<string, LeftRight>
                {
                    ["AAA"] = new("BBB", "CCC"),
                    ["BBB"] = new("DDD", "EEE"),
                    ["CCC"] = new("ZZZ", "GGG"),
                }
            )
        );
    }

    [Test]
    [TestCase(
        """
            RL

            AAA = (BBB, CCC)
            BBB = (DDD, EEE)
            CCC = (ZZZ, GGG)
            DDD = (DDD, DDD)
            EEE = (EEE, EEE)
            GGG = (GGG, GGG)
            ZZZ = (ZZZ, ZZZ)
            """,
        2
    )]
    [TestCase(
        """
            LLR

            AAA = (BBB, BBB)
            BBB = (AAA, ZZZ)
            ZZZ = (ZZZ, ZZZ)
            """,
        6
    )]
    public void Part1_WithExampleInput_CalculateTotalSteps(string input, int expectedResult)
    {
        var parsedInput = _day8.ParseRawInput(input);

        var result = _day8.Part1(parsedInput);

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(
        """
            LR

            11A = (11B, XXX)
            11B = (XXX, 11Z)
            11Z = (11B, XXX)
            22A = (22B, XXX)
            22B = (22C, 22C)
            22C = (22Z, 22Z)
            22Z = (22B, 22B)
            XXX = (XXX, XXX)
            """,
        6L
    )]
    public void Part2_WithExampleInput_CalculateTotalSteps_OfAllPathsStartingAtANodeToZNode(
        string input,
        long expectedResult
    )
    {
        var parsedInput = _day8.ParseRawInput(input);

        var result = _day8.Part2(parsedInput);

        result.ShouldBe(expectedResult);
    }
}
