using AdventOfCode.Days._2024;
using NUnit.Framework;

namespace AdventOfCode.Tests._2024;

public class Day5
{
    private Days._2024.Day5 _day5;

    [SetUp]
    public void Initialize()
    {
        _day5 = new Days._2024.Day5();
    }

    [Test]
    public void ParseRawInput_returns_printer_pages()
    {
        const string rawInput = """
                                47|53
                                97|13
                                97|61
                                97|47
                                75|29
                                61|13
                                75|53
                                29|13
                                97|29
                                53|29
                                61|53
                                97|53
                                61|29
                                47|13
                                75|47
                                97|75
                                47|61
                                75|61
                                47|29
                                75|13
                                53|13
                                
                                75,47,61,53,29
                                97,61,53,29,13
                                75,29,13
                                75,97,47,61,53
                                61,13,29
                                97,13,75,29,47
                                """;

        (int, int)[] expectedPairs = [
            (47, 53),
            (97, 13),
            (97, 61),
            (97, 47),
            (75, 29),
            (61, 13),
            (75, 53),
            (29, 13),
            (97, 29),
            (53, 29),
            (61, 53),
            (97, 53),
            (61, 29),
            (47, 13),
            (75, 47),
            (97, 75),
            (47, 61),
            (75, 61),
            (47, 29),
            (75, 13),
            (53, 13)
        ];

        int[][] expectedPages = [
            [75, 47, 61, 53, 29],
            [97, 61, 53, 29, 13],
            [75, 29, 13],
            [75, 97, 47, 61, 53],
            [61, 13, 29],
            [97, 13, 75, 29, 47]
        ];

        var result = _day5.ParseRawInput(rawInput);

        Assert.Multiple(() =>
        {
            Assert.That(result.Rules, Is.EqualTo(expectedPairs), "Pairs do not match.");
            Assert.That(result.Update, Is.EqualTo(expectedPages), "Pages do not match.");
        });
    }

    [Test]
    [TestCase("""
              47|53
              97|13
              97|61
              97|47
              75|29
              61|13
              75|53
              29|13
              97|29
              53|29
              61|53
              97|53
              61|29
              47|13
              75|47
              97|75
              47|61
              75|61
              47|29
              75|13
              53|13
              
              75,47,61,53,29
              97,61,53,29,13
              75,29,13
              75,97,47,61,53
              61,13,29
              97,13,75,29,47
              """, 143)]
    public void Part1_should_return_sum_of_all_middle_page_numbers_in_correct_updates(string input, int expectedResult)
    {
        var parsedInput = _day5.ParseRawInput(input);

        var result = _day5.Part1(parsedInput);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    [TestCase("""
              47|53
              97|13
              97|61
              97|47
              75|29
              61|13
              75|53
              29|13
              97|29
              53|29
              61|53
              97|53
              61|29
              47|13
              75|47
              97|75
              47|61
              75|61
              47|29
              75|13
              53|13

              75,47,61,53,29
              97,61,53,29,13
              75,29,13
              75,97,47,61,53
              61,13,29
              97,13,75,29,47
              """, 123)]
    public void Part2_should_correct_invalid_updates_return_sum_of_all_their_middle_page_numbers(string input, int expectedResult)
    {
        var parsedInput = _day5.ParseRawInput(input);

        var result = _day5.Part2(parsedInput);

        Assert.That(result, Is.EqualTo(expectedResult));
    }
}
