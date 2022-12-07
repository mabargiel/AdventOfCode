using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2022;

public class Day6
{
    private Days._2022.Day6 _day6;

    [SetUp]
    public void Initialize()
    {
        _day6 = new Days._2022.Day6();
    }

    [Test]
    public void ParseRawInput_WithExampleInput_SplitsItIntoPairsOfRanges()
    {
        const string rawInput = "mjqjpqmgbljsphdztnvjfqwrcgsmlb \n";

        var input = _day6.ParseRawInput(rawInput);

        input.ShouldBe("mjqjpqmgbljsphdztnvjfqwrcgsmlb");
    }

    [Test]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void Part1_WithExampleInput_FindStartPacketPos(string input, int expectedResult)
    {
        var result = _day6.Part1(input);

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    public void Part2_WithExampleInput_FindStartMessagePos(string input, int expectedResult)
    {
        var result = _day6.Part2(input);

        result.ShouldBe(expectedResult);
    }
}