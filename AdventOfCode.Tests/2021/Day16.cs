using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2021;

public class Day16
{
    private Days._2021.Day16 _day16;

    [SetUp]
    public void Initialize()
    {
        _day16 = new Days._2021.Day16();
    }
    
    [Test]
    [TestCase("D2FE28", new byte[] {1,1,0,1,0,0,1,0,1,1,1,1,1,1,1,0,0,0,1,0,1,0,0,0})]
    public void ParseRawInputTest(string rawInput, byte[] expectedInput)
    {
        var input = _day16.ParseRawInput(rawInput);
        input.ShouldBe(expectedInput);
    }

    [Test]
    [TestCase("D2FE28", 6)]
    [TestCase("38006F45291200", 9)]
    [TestCase("EE00D40C823060", 14)]
    [TestCase("8A004A801A8002F478", 16)]
    [TestCase("620080001611562C8802118E34", 12)]
    [TestCase("C0015000016115A2E0802F182340", 23)]
    [TestCase("A0016C880162017C3686B18A3D4780", 31)]
    public void Part1_WithExampleInput_ParseStringAndSummarizeVersionNumbers(string rawInput, int expectedResult)
    {
        var result = _day16.Part1(_day16.ParseRawInput(rawInput));
        result.ShouldBe(expectedResult);
    }
    
    [Test]
    [TestCase("0200840080", 0)]
    [TestCase("C200B40A82", 3)]
    [TestCase("04005AC33890", 54)]
    [TestCase("880086C3E88112", 7)]
    [TestCase("CE00C43D881120", 9)]
    [TestCase("D8005AC2A8F0",  1)]
    [TestCase("F600BC2D8F", 0)]
    [TestCase("9C005AC2F8F0", 0)]
    [TestCase("9C0141080250320F1802104A08", 1)]
    public void Part2_WithExampleInput_ParseStringAndExecuteBitsProgram(string rawInput, long expectedResult)
    {
        var result = _day16.Part2(_day16.ParseRawInput(rawInput));
        result.ShouldBe(expectedResult);
    }
}