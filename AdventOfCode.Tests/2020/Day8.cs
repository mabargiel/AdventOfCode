using AdventOfCode.Tests.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2020;

public class Day8
{
    private static object[] Codes =
    {
        new object[]
        {
            @"nop +0
                    acc +1
                    jmp +4
                    acc +3
                    jmp -3
                    acc -99
                    acc +1
                    jmp -4
                    acc +6".TrimIndent(),
            5,
        },
        new object[]
        {
            @"nop +0
                    acc +100
                    jmp +4
                    acc +3
                    jmp -3
                    acc -99
                    acc +1
                    jmp -4
                    acc +6".TrimIndent(),
            104,
        },
    };

    [Test]
    [TestCaseSource(nameof(Codes))]
    public void Part1(string input, int expected)
    {
        var d8 = new Days._2020._8.Day8(input);
        var result = d8.Part1();

        result.ShouldBe(expected);
    }

    [Test]
    public void Part2()
    {
        var input = @"nop +0
                    acc +1
                    jmp +4
                    acc +3
                    jmp -3
                    acc -99
                    acc +1
                    jmp -4
                    acc +6".TrimIndent();

        var d8 = new Days._2020._8.Day8(input);
        var result = d8.Part2();

        result.ShouldBe(8);
    }
}
