using System;
using NUnit.Framework;

namespace AdventOfCode.Tests._2019;

public class Day8
{
    [Test]
    [TestCase("123456789012", 3U, 2U, 1)]
    [TestCase("102111789002", 3U, 2U, 4)]
    [TestCase("102111729002123123", 3U, 3U, 8)]
    public void Part1(string imageData, uint width, uint height, int expectedOutput)
    {
        var d8 = new Days._2019._8.Day8(imageData, width, height);

        Assert.AreEqual(expectedOutput, d8.Part1());
    }

    [Test]
    [TestCase(3U, 4U)]
    [TestCase(10U, 10U)]
    [TestCase(6U, 6U)]
    public void Part1_CorruptedData(uint width, uint height)
    {
        Assert.Throws<ArgumentException>(() => new Days._2019._8.Day8("102111729002123123", width, height));
    }

    [Test]
    [TestCase("0222112222120000", 2U, 2U, "0110")]
    [TestCase("022211222212000000000000000", 3U, 3U, "010011000")]
    public void Part2(string imageData, uint width, uint height, string expectedOutput)
    {
        var d8 = new Days._2019._8.Day8(imageData, width, height);

        Assert.AreEqual(expectedOutput, d8.Part2());
    }
}