using System.Collections.Generic;
using AdventOfCode.Days._2022;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2022;

public class Day5
{
    private Days._2022.Day5 _day5;

    [SetUp]
    public void Initialize()
    {
        _day5 = new Days._2022.Day5();
    }

    [Test]
    public void ParseRawInput_WithExampleInput_SplitsItIntoPairsOfRanges()
    {
        const string rawInput =
            @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2";

        var input = _day5.ParseRawInput(rawInput);

        input.Containers.Length.ShouldBe(3);
        input.Actions.Length.ShouldBe(4);

        input.Containers.ShouldBe(
            new[]
            {
                new Stack<char>(new[] { 'Z', 'N' }),
                new Stack<char>(new[] { 'M', 'C', 'D' }),
                new Stack<char>(new[] { 'P' }),
            }
        );

        input.Actions.ShouldBe(
            new[]
            {
                new ContainerCraneAction(1, 2, 1),
                new ContainerCraneAction(3, 1, 3),
                new ContainerCraneAction(2, 2, 1),
                new ContainerCraneAction(1, 1, 2),
            }
        );
    }

    [Test]
    public void Part1_WithGivenExample_ReturnsTopContainers()
    {
        var input = (
            new[]
            {
                new Stack<char>(new[] { 'Z', 'N' }),
                new Stack<char>(new[] { 'M', 'C', 'D' }),
                new Stack<char>(new[] { 'P' }),
            },
            new[]
            {
                new ContainerCraneAction(1, 2, 1),
                new ContainerCraneAction(3, 1, 3),
                new ContainerCraneAction(2, 2, 1),
                new ContainerCraneAction(1, 1, 2),
            }
        );

        var result = _day5.Part1(input);

        result.ShouldBe("CMZ");
    }

    [Test]
    public void Part2_WithGivenExample_ReturnsTopContainers()
    {
        var input = (
            new[]
            {
                new Stack<char>(new[] { 'Z', 'N' }),
                new Stack<char>(new[] { 'M', 'C', 'D' }),
                new Stack<char>(new[] { 'P' }),
            },
            new[]
            {
                new ContainerCraneAction(1, 2, 1),
                new ContainerCraneAction(3, 1, 3),
                new ContainerCraneAction(2, 2, 1),
                new ContainerCraneAction(1, 1, 2),
            }
        );

        var result = _day5.Part2(input);

        result.ShouldBe("MCD");
    }
}
