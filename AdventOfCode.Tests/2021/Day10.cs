using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2021
{
    public class Day10 : AdventDayTest<Days._2021.Day10>
    {
        [Test]
        public override void ParseRawInputTest()
        {
            const string rawInput = @"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(";

            var input = _day.ParseRawInput(rawInput);

            input.ShouldBe(new[] { "[({(<(())[]>[[{[]{<()<>>", "[(()[<>])]({[<{<<[]>>(" });
        }

        [Test]
        public void Part1_CalculateCorruptedLinesScore()
        {
            var input = new[]
            {
                "[({(<(())[]>[[{[]{<()<>>",
                "[(()[<>])]({[<{<<[]>>(",
                "{([(<{}[<>[]}>{[]{[(<()>",
                "(((({<>}<{<{<>}{[]{[]{}",
                "[[<[([]))<([[{}[[()]]]",
                "[{[{({}]{}}([{[{{{}}([]",
                "{<[[]]>}<{[{[{[]{()[[[]",
                "[<(<(<(<{}))><([]([]()",
                "<{([([[(<>()){}]>(<<{{",
                "<{([{{}}[<[[[<>{}]]]>[]]"
            };

            var result = _day.Part1(input);

            result.ShouldBe(26397);
        }

        [Test]
        public void Part2_CalculateIncompleteLinesScore()
        {
            var input = new[]
            {
                "[({(<(())[]>[[{[]{<()<>>",
                "[(()[<>])]({[<{<<[]>>(",
                "{([(<{}[<>[]}>{[]{[(<()>",
                "(((({<>}<{<{<>}{[]{[]{}",
                "[[<[([]))<([[{}[[()]]]",
                "[{[{({}]{}}([{[{{{}}([]",
                "{<[[]]>}<{[{[{[]{()[[[]",
                "[<(<(<(<{}))><([]([]()",
                "<{([([[(<>()){}]>(<<{{",
                "<{([{{}}[<[[[<>{}]]]>[]]"
            };

            var result = _day.Part2(input);

            result.ShouldBe(288957);
        }
    }
}