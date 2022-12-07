using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2022;

public class Day3
{
    private Days._2022.Day3 _day3;

    [SetUp]
    public void Initialize()
    {
        _day3 = new Days._2022.Day3();
    }

    [Test]
    public void ParseRawInput_WithExampleInput_SplitsItIntoStringArrayByLines()
    {
        const string rawInput = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";

        var input = _day3.ParseRawInput(rawInput);

        input.ShouldBe(new[]
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg",
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw"
        });
    }

    [Test]
    [TestCase(new[]
    {
        "vJrwpWtwJgWrhcsFMMfFFhFp",
        "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
        "PmmdzqPrVvPwwTWBwg",
        "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
        "ttgJtRGJQctTZtZT",
        "CrZsJsPPZsGzwwsLwLmpwMDw"
    }, 157)]
    public void Part1_WithExampleInput_CalculatesSumOfCommonItemPriorities(string[] input, int expectedSum)
    {
        var result = _day3.Part1(input);

        result.ShouldBe(expectedSum);
    }

    [Test]
    [TestCase(new[]
    {
        "vJrwpWtwJgWrhcsFMMfFFhFp",
        "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
        "PmmdzqPrVvPwwTWBwg",
        "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
        "ttgJtRGJQctTZtZT",
        "CrZsJsPPZsGzwwsLwLmpwMDw"
    }, 70)]
    public void Part1_WithExampleInput_CalculatesGroupBadgesPriorities(string[] input, int expectedSum)
    {
        var result = _day3.Part2(input);

        result.ShouldBe(expectedSum);
    }
}