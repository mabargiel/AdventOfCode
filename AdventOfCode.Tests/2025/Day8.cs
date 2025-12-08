using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2025;

public class Day8
{
    private Days._2025.Day8 _day8;

    [SetUp]
    public void Initialize()
    {
        _day8 = new Days._2025.Day8();
    }

    [Test]
    [TestCase(
        """
            162,817,812
            57,618,57
            906,360,560
            592,479,940
            352,342,300
            466,668,158
            542,29,236
            431,825,988
            739,650,466
            52,470,668
            216,146,977
            819,987,18
            117,168,530
            805,96,715
            346,949,466
            970,615,88
            941,993,340
            862,61,35
            984,92,344
            425,690,689
            """,
        40
    )]
    public void Part1_should_find_three_circuits_with_the_most_number_of_points(
        string testInput,
        int expectedResult
    )
    {
        var parsedInput = _day8.ParseRawInput(testInput);

        var result = _day8.Part1(parsedInput);

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(
        """
            162,817,812
            57,618,57
            906,360,560
            592,479,940
            352,342,300
            466,668,158
            542,29,236
            431,825,988
            739,650,466
            52,470,668
            216,146,977
            819,987,18
            117,168,530
            805,96,715
            346,949,466
            970,615,88
            941,993,340
            862,61,35
            984,92,344
            425,690,689
            """,
        25272
    )]
    public void Part2_should_connect_everything_in_a_single_circuit(
        string testInput,
        int expectedResult
    )
    {
        var parsedInput = _day8.ParseRawInput(testInput);

        var result = _day8.Part2(parsedInput);

        result.ShouldBe(expectedResult);
    }
}
