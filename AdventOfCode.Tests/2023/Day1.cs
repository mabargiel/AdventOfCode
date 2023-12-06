using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2023;

public class Day1
{
    private Days._2023.Day1 _day1;

    [SetUp]
    public void Initialize()
    {
        _day1 = new Days._2023.Day1();
    }

    [Test]
    public void ParseRawInput_Into2dIntArray()
    {
        const string rawInput = """
                                1ab
                                pq
                                """;

        var input = _day1.ParseRawInput(rawInput);

        input.ShouldBe(new[] { "1ab", "pq" });
    }

    [Test]
    [TestCase("""
              1abc2
              pqr3stu8vwx
              a1b2c3d4e5f
              treb7uchet
              """, 142)]
    public void Part1_WithExampleInput_CalculateSumOfInputs(string input, int expectedResult)
    {
        var parsedInput = _day1.ParseRawInput(input);

        var result = _day1.Part1(parsedInput);

        result.ShouldBe(expectedResult);
    }

    [Test]
    [TestCase("""
              two1nine
              eightwothree
              abcone2threexyz
              xtwone3four
              4nineeightseven2
              zoneight234
              7pqrstsixteen
              onetwone
              2p
              2
              p2
              two
              eighthree
              sevenabc1twothree9
              onetwothreefourfivesixseveneightnine
              9eight7six5four3two1one
              a1b2c3d4e5f6g7h8i9
              nine8seven6five4three2one
              abc4defghijklmno1pqr
              sixsixsixsixsixsixsixsixsix
              123456789
              987654321
              one7six2four3eight5nine
              twotwotwotwo
              fourseveneightninetwothreeonesixfive
              1a2b3c4d5e6f7g8h9i
              seven3eight4one5two6
              ninenine8eight7seven6six
              onetwo3four5sixseveneightnine
              abcdefghi4jklmnopqr5stuvwx6yz
              seveneightnine123456
              1two3four5six7eight9
              nine8seven6five4three2one0
              0
              """, 1507)]
    public void Part2_WithExampleInput_CalculateSumOfInputs(string input, int expectedResult)
    {
        var parsedInput = _day1.ParseRawInput(input);

        var result = _day1.Part2(parsedInput);

        result.ShouldBe(expectedResult);
    }
}