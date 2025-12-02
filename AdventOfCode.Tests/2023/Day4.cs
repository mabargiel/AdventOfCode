using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2023;

public class Day4
{
    private Days._2023.Day4 _day4;

    [SetUp]
    public void Initialize()
    {
        _day4 = new Days._2023.Day4();
    }

    [Test]
    public void ParseRawInput_IntoLogicalObject()
    {
        const string rawInput = """
            Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
            Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
            """;

        var input = _day4.ParseRawInput(rawInput);

        input[0].WinningNumbers.ShouldBe(new[] { 41, 48, 83, 86, 17 });
        input[0].NumbersIHave.ShouldBe(new[] { 83, 86, 6, 31, 17, 9, 48, 53 });
        input[1].WinningNumbers.ShouldBe(new[] { 13, 32, 20, 16, 61 });
        input[1].NumbersIHave.ShouldBe(new[] { 61, 30, 68, 82, 17, 32, 24, 19 });
    }

    [Test]
    [TestCase(
        """
            Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
            Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
            Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
            Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
            Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
            Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11
            """,
        13
    )]
    public void Part1_WithExampleInput_CalculateSumWinningScores(string input, int expectedResult)
    {
        var parsedInput = _day4.ParseRawInput(input);

        var result = _day4.Part1(parsedInput);

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(
        """
            Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
            Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
            Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
            Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
            Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
            Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11
            """,
        30
    )]
    [TestCase(
        """
            Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
            Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
            Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
            Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
            Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
            Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11
            Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
            Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
            Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
            Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
            Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
            Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11
            """,
        60
    )]
    public void Part2_WithExampleInput_CalculateSumWinningScores_IncludingWonCopies(
        string input,
        int expectedResult
    )
    {
        var parsedInput = _day4.ParseRawInput(input);

        var result = _day4.Part2(parsedInput);

        result.ShouldBe(expectedResult);
    }
}
