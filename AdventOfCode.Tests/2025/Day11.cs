using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2025;

public class Day11
{
    private Days._2025.Day11 _day11;

    [SetUp]
    public void Initialize()
    {
        _day11 = new Days._2025.Day11();
    }

    [Test]
    [TestCase(
        """
            aaa: you hhh
            you: bbb ccc
            bbb: ddd eee
            ccc: ddd eee fff
            ddd: ggg
            eee: out
            fff: out
            ggg: out
            hhh: ccc fff iii
            iii: out
            """,
        5
    )]
    public void Part1_should_count_all_paths_from_you_to_out(string testInput, int expectedResult)
    {
        var parsedInput = _day11.ParseRawInput(testInput);

        var result = _day11.Part1(parsedInput);

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase(
        """
            svr: aaa bbb
            aaa: fft
            fft: ccc
            bbb: tty
            tty: ccc
            ccc: ddd eee
            ddd: hub
            hub: fff
            eee: dac
            dac: fff
            fff: ggg hhh
            ggg: out
            hhh: out
            """,
        2
    )]
    public void Part2_should_count_all_paths_from_svr_to_out_with_dac_ffs_through(
        string testInput,
        int expectedResult
    )
    {
        var parsedInput = _day11.ParseRawInput(testInput);

        var result = _day11.Part2(parsedInput);

        result.ShouldBe(expectedResult);
    }
}
