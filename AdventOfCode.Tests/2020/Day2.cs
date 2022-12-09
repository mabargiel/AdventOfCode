using System;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2020;

public class Day2
{
    [Test]
    public void Part1_TwoOutOfThreePasswordsAreValid()
    {
        var input = "1-3 a: abcde" + Environment.NewLine +
                    "1-3 b: cdefg" + Environment.NewLine +
                    "2-9 c: ccccccccc";

        var d2 = new Days._2020._2.Day2(input);
        var result = d2.Part1();

        result.ShouldBe(2);
    }


    [Test]
    public void Part1_ThreeOutOfFourPasswordsAreValid()
    {
        var input = "1-3 a: abcde" + Environment.NewLine +
                    "1-3 b: cdefg" + Environment.NewLine +
                    "2-9 c: ccccccccc" + Environment.NewLine +
                    "2-9 c: ccccccccc";

        var d2 = new Days._2020._2.Day2(input);
        var result = d2.Part1();

        result.ShouldBe(3);
    }

    [Test]
    public void Part2_OneOutOfThreePasswordsAreValid()
    {
        var input = "1-3 a: abcde" + Environment.NewLine +
                    "1-3 b: cdefg" + Environment.NewLine +
                    "2-9 c: ccccccccc";

        var d2 = new Days._2020._2.Day2(input);
        var result = d2.Part2();

        result.ShouldBe(1);
    }
}