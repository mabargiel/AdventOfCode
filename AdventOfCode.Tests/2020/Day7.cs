﻿using AdventOfCode.Tests.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2020;

public class Day7
{
    private static readonly object[] Part2Source =
    {
        new object[]
        {
            @"light red bags contain 1 bright white bag, 2 muted yellow bags.
                    dark orange bags contain 3 bright white bags, 4 muted yellow bags.
                    bright white bags contain 1 shiny gold bag.
                    muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
                    shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
                    dark olive bags contain 3 faded blue bags, 4 dotted black bags.
                    vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
                    faded blue bags contain no other bags.
                    dotted black bags contain no other bags.".TrimIndent(),
            32
        },

        new object[]
        {
            @"shiny gold bags contain 2 dark red bags.
                    dark red bags contain 2 dark orange bags.
                    dark orange bags contain 2 dark yellow bags.
                    dark yellow bags contain 2 dark green bags.
                    dark green bags contain 2 dark blue bags.
                    dark blue bags contain 2 dark violet bags.
                    dark violet bags contain no other bags.".TrimIndent(),
            126
        }
    };

    [Test]
    public void Part1()
    {
        const string input = @"light red bags contain 1 bright white bag, 2 muted yellow bags.
dark orange bags contain 3 bright white bags, 4 muted yellow bags.
bright white bags contain 1 shiny gold bag.
muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
dark olive bags contain 3 faded blue bags, 4 dotted black bags.
vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
faded blue bags contain no other bags.
dotted black bags contain no other bags.";

        var d7 = new Days._2020._7.Day7(input);
        var result = d7.Part1();

        result.ShouldBe(4);
    }

    [Test]
    [TestCaseSource(nameof(Part2Source))]
    public void Part2(string input, int expected)
    {
        var d7 = new Days._2020._7.Day7(input);
        var result = d7.Part2();

        result.ShouldBe(expected);
    }
}