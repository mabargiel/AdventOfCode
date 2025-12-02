using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2017;

public class Day9
{
    private Days._2017.Day9 _day;

    [SetUp]
    public void Initialize()
    {
        _day = new Days._2017.Day9();
    }

    [Test]
    public void ParseRawInput_ReturnWithoutParsingCharArray()
    {
        const string rawInput = "{{<<!>>}}";
        _day.ParseRawInput(rawInput).ShouldBeEquivalentTo(rawInput.ToCharArray());
    }

    [Test]
    [TestCase("{}", 1)]
    [TestCase("{{},{}}", 5)]
    [TestCase("{{{}}}", 6)]
    [TestCase("{{{},{},{{}}}}", 16)]
    [TestCase("{<a>,<a>,<a>,<a>}", 1)]
    [TestCase("{{<ab>},{<ab>},{<ab>},{<ab>}}", 9)]
    [TestCase("{{<!!>},{<!!>},{<!!>},{<!!>}}", 9)]
    [TestCase("{{<a!>},{<a!>},{<a!>},{<ab>}}", 3)]
    public void Part1_GetTotalScoreOfAllGroups(string input, int expectedResult)
    {
        var result = _day.Part1(input.ToCharArray());
        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase("<>", 0)]
    [TestCase("<random characters>", 17)]
    [TestCase("<<<<>", 3)]
    [TestCase("<{!>}>", 2)]
    [TestCase("<!!>", 0)]
    [TestCase("<!!!>>", 0)]
    [TestCase("<{o\"i!a,<{i<a>", 10)]
    [TestCase("{{<ab>},{<ab>},{<ab>},{<ab>}}", 8)]
    public void Part1_GetTotalGarbageLength(string input, int expectedResult)
    {
        var result = _day.Part2(input.ToCharArray());
        result.ShouldBe(expectedResult);
    }
}
