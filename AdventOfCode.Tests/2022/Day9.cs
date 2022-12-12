using AdventOfCode.Days._2022;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2022;

public class Day9
{
    private Days._2022.Day9 _day9;

    [SetUp]
    public void Initialize()
    {
        _day9 = new Days._2022.Day9();
    }

    [Test]
    public void ParseRawInput_WithExampleInput_CreatesMoveStepsArray()
    {
        var rawInput = @"R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 22";

        var input = _day9.ParseRawInput(rawInput);
        input.ShouldBe(new Motion[]
        {
            new('R', 4),
            new('U', 4),
            new('L', 3),
            new('D', 1),
            new('R', 4),
            new('D', 1),
            new('L', 5),
            new('R', 22)
        });
    }

    [Test]
    public void Part1_ExampleInput_FollowStepsAndReturnAllPosVisitedByShortTail()
    {
        var input = new Motion[]
        {
            new('R', 4),
            new('U', 4),
            new('L', 3),
            new('D', 1),
            new('R', 4),
            new('D', 1),
            new('L', 5),
            new('R', 2)
        };

        var result = _day9.Part1(input);

        result.ShouldBe(13);
    }

    [Test]
    public void Part2_ExampleInput_FollowStepsAndReturnAllPosVisitedByLongTail()
    {
        var input = new Motion[]
        {
            new('R', 5),
            new('U', 8),
            new('L', 8),
            new('D', 3),
            new('R', 17),
            new('D', 10),
            new('L', 25),
            new('U', 20)
        };

        var result = _day9.Part2(input);

        result.ShouldBe(36);
    }
}