using System.Collections.Generic;
using AdventOfCode.Days._2021;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2021
{
    public class Day14 : AdventDayTest<Days._2021.Day14>
    {
        [Test]
        public override void ParseRawInputTest()
        {
            const string rawInput =
                @"NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C";

            var (template, dictionary) = _day.ParseRawInput(rawInput);

            template.ShouldBe("NNCB");
            dictionary.ShouldBeEquivalentTo(
                new Dictionary<string, char>
                {
                    ["CH"] = 'B',
                    ["HH"] = 'N',
                    ["CB"] = 'H',
                    ["NH"] = 'C',
                    ["HB"] = 'C',
                    ["HC"] = 'B',
                    ["HN"] = 'C',
                    ["NN"] = 'C',
                    ["BH"] = 'H',
                    ["NC"] = 'B',
                    ["NB"] = 'B',
                    ["BN"] = 'B',
                    ["BB"] = 'N',
                    ["BC"] = 'B',
                    ["CC"] = 'N',
                    ["CN"] = 'C',
                }
            );
        }

        [Test]
        public void Part1_CalculatePolymerAfter10Steps()
        {
            var input = new PolymerRules(
                "NNCB",
                new Dictionary<string, char>
                {
                    ["CH"] = 'B',
                    ["HH"] = 'N',
                    ["CB"] = 'H',
                    ["NH"] = 'C',
                    ["HB"] = 'C',
                    ["HC"] = 'B',
                    ["HN"] = 'C',
                    ["NN"] = 'C',
                    ["BH"] = 'H',
                    ["NC"] = 'B',
                    ["NB"] = 'B',
                    ["BN"] = 'B',
                    ["BB"] = 'N',
                    ["BC"] = 'B',
                    ["CC"] = 'N',
                    ["CN"] = 'C',
                }
            );

            var result = _day.Part1(input);

            result.ShouldBe(1588);
        }

        [Test]
        public void Part2_CalculatePolymerAfter40Steps()
        {
            var input = new PolymerRules(
                "NNCB",
                new Dictionary<string, char>
                {
                    ["CH"] = 'B',
                    ["HH"] = 'N',
                    ["CB"] = 'H',
                    ["NH"] = 'C',
                    ["HB"] = 'C',
                    ["HC"] = 'B',
                    ["HN"] = 'C',
                    ["NN"] = 'C',
                    ["BH"] = 'H',
                    ["NC"] = 'B',
                    ["NB"] = 'B',
                    ["BN"] = 'B',
                    ["BB"] = 'N',
                    ["BC"] = 'B',
                    ["CC"] = 'N',
                    ["CN"] = 'C',
                }
            );

            var result = _day.Part2(input);

            result.ShouldBe(2188189693529);
        }
    }
}
