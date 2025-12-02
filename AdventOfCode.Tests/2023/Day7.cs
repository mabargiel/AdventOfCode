using AdventOfCode.Days._2023;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2023;

public class Day7
{
    private Days._2023.Day7 _day7;

    [SetUp]
    public void Initialize()
    {
        _day7 = new Days._2023.Day7();
    }

    [Test]
    public void ParseRawInput_IntoLogicalObject()
    {
        const string rawInput = """
            32T3K 765
            T55J5 684
            KK677 28
            KTJJT 220
            QQQJA 483
            """;

        var input = _day7.ParseRawInput(rawInput);

        input.ShouldBeEquivalentTo(
            new Hand[]
            {
                new("32T3K".ToCharArray(), 765),
                new("T55J5".ToCharArray(), 684),
                new("KK677".ToCharArray(), 28),
                new("KTJJT".ToCharArray(), 220),
                new("QQQJA".ToCharArray(), 483),
            }
        );
    }

    [Test]
    [TestCase(
        """
            32T3K 765
            T55J5 684
            KK677 28
            KTJJT 220
            QQQJA 483
            """,
        6440
    )]
    public void Part1_WithExampleInput_CalculateTotalWinnings(string input, int expectedResult)
    {
        var parsedInput = _day7.ParseRawInput(input);

        var result = _day7.Part1(parsedInput);

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(
        """
            32T3K 765
            T55J5 684
            KK677 28
            KTJJT 220
            QQQJA 483
            """,
        5905
    )]
    public void Part2_WithExampleInput_CalculateTotalWinnings_IncludingJokers(
        string input,
        int expectedResult
    )
    {
        var parsedInput = _day7.ParseRawInput(input);

        var result = _day7.Part2(parsedInput);

        result.ShouldBe(expectedResult);
    }
}
