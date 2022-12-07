using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2022;

public class Day7
{
    private Days._2022.Day7 _day7;

    [SetUp]
    public void Initialize()
    {
        _day7 = new Days._2022.Day7();
    }

    [Test]
    public void ParseRawInput_WithExampleInput_SplitsItIntoPairsOfRanges()
    {
        const string rawInput = @"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k";

        var input = _day7.ParseRawInput(rawInput);

        input.ShouldBeEquivalentTo(new[]
        {
            "$ cd /",
            "$ ls",
            "dir a",
            "14848514 b.txt",
            "8504156 c.dat",
            "dir d",
            "$ cd a",
            "$ ls",
            "dir e",
            "29116 f",
            "2557 g",
            "62596 h.lst",
            "$ cd e",
            "$ ls",
            "584 i",
            "$ cd ..",
            "$ cd ..",
            "$ cd d",
            "$ ls",
            "4060174 j",
            "8033020 d.log",
            "5626152 d.ext",
            "7214296 k"
        });
    }

    [Test]
    public void Part1_WithExampleFilesystem_CalculateSumOfDirsAtMost100_000()
    {
        var input = new[]
        {
            "$ cd /",
            "$ ls",
            "dir a",
            "14848514 b.txt",
            "8504156 c.dat",
            "dir d",
            "$ cd a",
            "$ ls",
            "dir e",
            "29116 f",
            "2557 g",
            "62596 h.lst",
            "$ cd e",
            "$ ls",
            "584 i",
            "$ cd ..",
            "$ cd ..",
            "$ cd d",
            "$ ls",
            "4060174 j",
            "8033020 d.log",
            "5626152 d.ext",
            "7214296 k"
        };

        var result = _day7.Part1(input);

        result.ShouldBe(95437);
    }

    [Test]
    public void Part2_WithExampleFilesystem_CalculateMinSizeOfADirToFreeUpSpace()
    {
        var input = new[]
        {
            "$ cd /",
            "$ ls",
            "dir a",
            "14848514 b.txt",
            "8504156 c.dat",
            "dir d",
            "$ cd a",
            "$ ls",
            "dir e",
            "29116 f",
            "2557 g",
            "62596 h.lst",
            "$ cd e",
            "$ ls",
            "584 i",
            "$ cd ..",
            "$ cd ..",
            "$ cd d",
            "$ ls",
            "4060174 j",
            "8033020 d.log",
            "5626152 d.ext",
            "7214296 k"
        };

        var result = _day7.Part2(input);

        result.ShouldBe(24933642);
    }
}