using AdventOfCode.Tests.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2020;

public class Day10
{
    private static object[] Examples =
    {
        new object[]
        {
            @"16
                            10
                            15
                            5
                            1
                            11
                            7
                            19
                            6
                            12
                            4".TrimIndent(),
            7 * 5,
            8,
        },
        new object[]
        {
            @"28
                            33
                            18
                            42
                            31
                            14
                            46
                            20
                            48
                            47
                            24
                            23
                            49
                            45
                            19
                            38
                            39
                            11
                            1
                            32
                            25
                            35
                            8
                            17
                            7
                            9
                            4
                            2
                            34
                            10
                            3".TrimIndent(),
            22 * 10,
            19_208,
        },
    };

    [Test]
    [TestCaseSource(nameof(Examples))]
    public void Part1(string input, int expected, int _)
    {
        var d10 = new Days._2020._10.Day10(input);
        var result = d10.Part1();

        result.ShouldBe(expected);
    }

    [Test]
    [TestCaseSource(nameof(Examples))]
    public void Part2(string input, int _, int expected)
    {
        var d10 = new Days._2020._10.Day10(input);
        var result = d10.Part2();

        result.ShouldBe(expected);
    }
}
