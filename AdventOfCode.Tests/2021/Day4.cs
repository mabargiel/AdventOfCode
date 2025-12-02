using AdventOfCode.Days._2021.Day4;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2021;

public class Day4 : AdventDayTest<Days._2021.Day4.Day4>
{
    [Test]
    public override void ParseRawInputTest()
    {
        const string rawInput =
            @"7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1

22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19

 3 15  0  2 22
 9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6

14 21 17 24  4
10 16 15  9 19
18  8 23 26 20
22 11 13  6  5
 2  0 12  3  7";

        var input = _day.ParseRawInput(rawInput);

        input.ChosenNumbers.ShouldBe(
            new[]
            {
                7,
                4,
                9,
                5,
                11,
                17,
                23,
                2,
                0,
                14,
                21,
                24,
                10,
                16,
                13,
                6,
                15,
                25,
                12,
                22,
                18,
                20,
                8,
                19,
                3,
                26,
                1,
            }
        );

        input.Boards.Count.ShouldBe(3);
        input.LastMarkedValue.ShouldBe(-1);

        input.Boards[0].Score.ShouldBe(300);
        input.Boards[1].Score.ShouldBe(324);
        input.Boards[2].Score.ShouldBe(325);
    }

    [Test]
    public void Part1_SimulateGame_3rdBoardWinsWithValidScore()
    {
        var input = new BingoGame(
            @"7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1

22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19

 3 15  0  2 22
 9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6

14 21 17 24  4
10 16 15  9 19
18  8 23 26 20
22 11 13  6  5
 2  0 12  3  7"
        );

        var result = _day.Part1(input);

        result.ShouldBe(4512);
    }

    [Test]
    public void Part2_SimulateGame_2rdBoardWinsLastWithValidScore()
    {
        var input = new BingoGame(
            @"7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1

22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19

 3 15  0  2 22
 9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6

14 21 17 24  4
10 16 15  9 19
18  8 23 26 20
22 11 13  6  5
 2  0 12  3  7"
        );

        var result = _day.Part2(input);

        result.ShouldBe(1924);
    }
}

public class Day4_BoardTests
{
    [Test]
    [TestCase(22, 300 - 22)]
    [TestCase(0, 300)]
    [TestCase(30, 300)]
    [TestCase(6, 300 - 6)]
    public void MarkValue_WhenExists_ReduceScore(int valueToBeMarked, int expectedScore)
    {
        var board = new Board(
            @"22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19"
        );

        board.MarkNumber(valueToBeMarked);

        board.Score.ShouldBe(expectedScore);
    }

    [Test]
    [TestCase(
        new[] { 21, 9, 16, 3, 12, 14, 16, 18, 7 },
        300 - (21 + 9 + 16 + 3 + 12 + 14 + 18 + 7)
    )]
    [TestCase(new[] { 8, 21, 6, 1, 22 }, 300 - (8 + 21 + 6 + 1 + 22))]
    public void MarkValue_WhenRowOrColumnMarked_IsBingo(
        int[] valuesMarkingSimulation,
        int expectedBingoScore
    )
    {
        var board = new Board(
            @"22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19"
        );

        foreach (var value in valuesMarkingSimulation)
        {
            board.MarkNumber(value);
        }

        board.IsBingo().ShouldBe(true);
        board.Score.ShouldBe(expectedBingoScore);
    }
}
