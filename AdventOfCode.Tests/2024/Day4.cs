using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2024;

public class Day4
{
    private Days._2024.Day4 _day4;

    private static readonly char[,] Input = new[,]
    {
        { 'M', 'M', 'M', 'S', 'X', 'X', 'M', 'A', 'S', 'M' },
        { 'M', 'S', 'A', 'M', 'X', 'M', 'S', 'M', 'S', 'A' },
        { 'A', 'M', 'X', 'S', 'X', 'M', 'A', 'A', 'M', 'M' },
        { 'M', 'S', 'A', 'M', 'A', 'S', 'M', 'S', 'M', 'X' },
        { 'X', 'M', 'A', 'S', 'A', 'M', 'X', 'A', 'M', 'M' },
        { 'X', 'X', 'A', 'M', 'M', 'X', 'X', 'A', 'M', 'A' },
        { 'S', 'M', 'S', 'M', 'S', 'A', 'S', 'X', 'S', 'S' },
        { 'S', 'A', 'X', 'A', 'M', 'A', 'S', 'A', 'A', 'A' },
        { 'M', 'A', 'M', 'M', 'M', 'X', 'M', 'M', 'M', 'M' },
        { 'M', 'X', 'M', 'X', 'A', 'X', 'M', 'A', 'S', 'X' },
    };

    private static object[] _part1 = [new object[] { Input, 18 }];

    private static object[] _part2 = [new object[] { Input, 9 }];

    [SetUp]
    public void Initialize()
    {
        _day4 = new Days._2024.Day4();
    }

    [Test]
    public void ParseRawInput_returns_2d_array_of_word_matrix()
    {
        const string rawInput = """
            MMMSXXMASM
            MSAMXMSMSA
            AMXSXMAAMM
            MSAMASMSMX
            XMASAMXAMM
            XXAMMXXAMA
            SMSMSASXSS
            SAXAMASAAA
            MAMMMXMMMM
            MXMXAXMASX
            """;

        var input = _day4.ParseRawInput(rawInput);

        input.ShouldBe(
            new[,]
            {
                { 'M', 'M', 'M', 'S', 'X', 'X', 'M', 'A', 'S', 'M' },
                { 'M', 'S', 'A', 'M', 'X', 'M', 'S', 'M', 'S', 'A' },
                { 'A', 'M', 'X', 'S', 'X', 'M', 'A', 'A', 'M', 'M' },
                { 'M', 'S', 'A', 'M', 'A', 'S', 'M', 'S', 'M', 'X' },
                { 'X', 'M', 'A', 'S', 'A', 'M', 'X', 'A', 'M', 'M' },
                { 'X', 'X', 'A', 'M', 'M', 'X', 'X', 'A', 'M', 'A' },
                { 'S', 'M', 'S', 'M', 'S', 'A', 'S', 'X', 'S', 'S' },
                { 'S', 'A', 'X', 'A', 'M', 'A', 'S', 'A', 'A', 'A' },
                { 'M', 'A', 'M', 'M', 'M', 'X', 'M', 'M', 'M', 'M' },
                { 'M', 'X', 'M', 'X', 'A', 'X', 'M', 'A', 'S', 'X' },
            }
        );
    }

    [Test]
    [TestCaseSource(nameof(_part1))]
    public void Part1_calculates_all_occurrences_of_xmas_word_any_direction(
        char[,] parsedInput,
        int expectedResult
    )
    {
        var result = _day4.Part1(parsedInput);

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCaseSource(nameof(_part2))]
    public void Part2_calculates_all_occurrences_of_x_shaped_mas_word(
        char[,] parsedInput,
        int expectedResult
    )
    {
        var result = _day4.Part2(parsedInput);

        result.ShouldBe(expectedResult);
    }
}
