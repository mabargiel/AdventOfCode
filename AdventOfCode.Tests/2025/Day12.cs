using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2025;

public class Day25
{
    private Days._2025.Day12 _day12;

    [SetUp]
    public void Initialize()
    {
        _day12 = new Days._2025.Day12();
    }

    [Test]
    [TestCase(
        """
            0:
            ###
            ##.
            ##.

            1:
            ###
            ##.
            .##

            2:
            .##
            ###
            ##.

            3:
            ##.
            ###
            ##.

            4:
            ###
            #..
            ###

            5:
            ###
            .#.
            ###

            4x4: 0 0 0 0 2 0
            12x5: 1 0 1 0 2 2
            12x5: 1 0 1 0 3 2
            """,
        2
    )]
    public void Part1_should_count_all_paths_from_you_to_out(string testInput, int expectedResult)
    {
        var parsedInput = _day12.ParseRawInput(testInput);

        var result = _day12.Part1(parsedInput);

        result.ShouldBe(expectedResult);
    }
}
