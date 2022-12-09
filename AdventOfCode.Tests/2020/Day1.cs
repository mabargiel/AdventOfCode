using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2020;

public class Day1
{
    [Test]
    public void Part1_ShouldMultipleMatchingPairs()
    {
        var input = new[] { 1721, 979, 366, 299, 675, 1456 };

        var day1 = new Days._2020._1.Day1(input);
        var result = day1.Part1();

        result.ShouldBe(1721 * 299);
    }

    [Test]
    public void Part1_ShouldMultipleMatchingTriplets()
    {
        var input = new[] { 1721, 979, 366, 299, 675, 1456 };

        var day1 = new Days._2020._1.Day1(input);
        var result = day1.Part2();

        result.ShouldBe(979 * 366 * 675);
    }
}