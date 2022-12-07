using AdventOfCode.Tests.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2020;

public class Day9
{
    private readonly string _input = @"35
                                            20
                                            15
                                            25
                                            47
                                            40
                                            62
                                            55
                                            65
                                            95
                                            102
                                            117
                                            150
                                            182
                                            127
                                            219
                                            299
                                            277
                                            309
                                            576".TrimIndent();

    [Test]
    public void Part1()
    {
        var d9 = new Days._2020._9.Day9(_input, 5);
        var result = d9.Part1();

        result.ShouldBe(127);
    }

    [Test]
    public void Part2()
    {
        var d9 = new Days._2020._9.Day9(_input, 5);
        var result = d9.Part2();

        result.ShouldBe(62);
    }
}