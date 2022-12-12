using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2022;

public class Day11
{
    private const string _exampleInput = @"
Monkey 0:
  Starting items: 79, 98
  Operation: new = old * 19
  Test: divisible by 23
    If true: throw to monkey 2
    If false: throw to monkey 3

Monkey 1:
  Starting items: 54, 65, 75, 74
  Operation: new = old + 6
  Test: divisible by 19
    If true: throw to monkey 2
    If false: throw to monkey 0

Monkey 2:
  Starting items: 79, 60, 97
  Operation: new = old * old
  Test: divisible by 13
    If true: throw to monkey 1
    If false: throw to monkey 3

Monkey 3:
  Starting items: 74
  Operation: new = old + 3
  Test: divisible by 17
    If true: throw to monkey 0
    If false: throw to monkey 1
";

    private Days._2022.Day11 _day11;

    [SetUp]
    public void Initialize()
    {
        _day11 = new Days._2022.Day11();
    }

    [Test]
    public void ParseRawInput_WithExampleInput_CreatesMonkeyNotes()
    {
        var input = _day11.ParseRawInput(_exampleInput);

        input.Length.ShouldBe(4);

        var firstMonkey = input[0];
        firstMonkey.Items.ShouldBe(new[] { 79L, 98 });
        firstMonkey.Operation(2).ShouldBe(2 * 19);
        firstMonkey.TestDivisibleBy.ShouldBe(23);
        firstMonkey.IfTrue.ShouldBe(2);
        firstMonkey.IfFalse.ShouldBe(3);

        input[2].Items.ShouldBe(new[] { 79L, 60, 97 });
    }

    [Test]
    public void Part1_WithExampleInput_Perform20RoundsAndFindTwoMostActiveMonkeys()
    {
        var result = _day11.Part1(_day11.ParseRawInput(_exampleInput));

        result.ShouldBe(10605);
    }

    [Test]
    public void Part2_WithExampleInput_Perform10000RoundsAndFindTwoMostActiveMonkeys()
    {
        var result = _day11.Part2(_day11.ParseRawInput(_exampleInput));

        result.ShouldBe(2713310158);
    }
}