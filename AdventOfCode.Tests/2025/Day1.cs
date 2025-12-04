using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2025;

public class Day1
{
    private Days._2025.Day1 _day1;

    [SetUp]
    public void Initialize()
    {
        _day1 = new Days._2025.Day1();
    }

    [Test]
    [TestCase(
        """
            L68
            L30
            R48
            L5
            R60
            L55
            L1
            L99
            R14
            L82
            """,
        3
    )]
    public void Part1_should_count_how_many_times_0_were_pointed_to(
        string testInput,
        int expectedResult
    )
    {
        var parsedInput = _day1.ParseRawInput(testInput);

        var result = _day1.Part1(parsedInput);

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(
        """
            L68
            L30
            R48
            L5
            R60
            L55
            L1
            L99
            R14
            L82
            """,
        6
    )]
    [TestCase(
        """
            L168
            L30
            R48
            L5
            R60
            L55
            L1
            L99
            R14
            L82
            """,
        7
    )]
    [TestCase(
        """
            L68
            L30
            R148
            L5
            R60
            L55
            L1
            L99
            R14
            L82
            """,
        7
    )]
    [TestCase(
        """
            L68
            L30
            R548
            L5
            R60
            L55
            L1
            L99
            R14
            L82
            """,
        11
    )]
    [TestCase(
        """
            L68
            L30
            R548
            L500
            R60
            L55
            L1
            L99
            R14
            L82
            """,
        14
    )]
    [TestCase(
        """
            L350
            """,
        4
    )]
    [TestCase(
        """
            R350
            """,
        4
    )]
    [TestCase(
        """
            R100
            R200
            R300
            R150
            """,
        8
    )]
    [TestCase(
        """
            L100
            L200
            L300
            L150
            """,
        8
    )]
    [TestCase(
        """
            L50
            L100
            R1
            L1
            """,
        3
    )]
    public void Part2_should_count_how_many_times_0_clicked(string testInput, int expectedResult)
    {
        var parsedInput = _day1.ParseRawInput(testInput);

        var result = _day1.Part2(parsedInput);

        result.ShouldBe(expectedResult);
    }
}
