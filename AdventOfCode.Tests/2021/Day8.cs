using AdventOfCode.Days._2021;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2021
{
    public class Day8 : AdventDayTest<Days._2021.Day8>
    {
        private static readonly object[][] _inputs =
        {
            new object[]
            {
                new SignalPattern[]
                {
                    new(
                        new[]
                        {
                            "acedgfb", "cdfbe", "gcdfa", "fbcad", "dab", "cefabd", "cdfgeb", "eafb", "cagedb", "ab"
                        },
                        new[] { "cdfeb", "fcadb", "cdfeb", "cdbaf" })
                },
                5353
            },
            new object[]
            {
                new SignalPattern[]
                {
                    new(
                        new[]
                        {
                            "be", "cfbegad", "cbdgef", "fgaecd", "cgeb", "fdcge", "agebfd", "fecdb", "fabcd", "edb"
                        },
                        new[] { "fdgacbe", "cefdb", "cefbgd", "gcbe" }),
                    new(
                        new[]
                        {
                            "edbfga", "begcd", "cbg", "gc", "gcadebf", "fbgde", "acbgfd", "abcde", "gfcbed", "gfec"
                        },
                        new[] { "fcgedb", "cgb", "dgebacf", "gc" }),
                    new(
                        new[]
                        {
                            "fgaebd", "cg", "bdaec", "gdafb", "agbcfd", "gdcbef", "bgcad", "gfac", "gcb", "cdgabef"
                        },
                        new[] { "cg", "cg", "fdcagb", "cbg" }),
                    new(
                        new[]
                        {
                            "fbegcd", "cbd", "adcefb", "dageb", "afcb", "bc", "aefdc", "ecdab", "fgdeca", "fcdbega"
                        },
                        new[] { "efabcd", "cedba", "gadfec", "cb" }),
                    new(
                        new[]
                        {
                            "aecbfdg", "fbg", "gf", "bafeg", "dbefa", "fcge", "gcbea", "fcaegb", "dgceab", "fcbdga"
                        },
                        new[] { "gecf", "egdcabf", "bgf", "bfgea" }),
                    new(
                        new[]
                        {
                            "fgeab", "ca", "afcebg", "bdacfeg", "cfaedg", "gcfdb", "baec", "bfadeg", "bafgc", "acf"
                        },
                        new[] { "gebdcfa", "ecba", "ca", "fadegcb" }),
                    new(
                        new[]
                        {
                            "dbcfg", "fgd", "bdegcaf", "fgec", "aegbdf", "ecdfab", "fbedc", "dacgb", "gdcebf", "gf"
                        },
                        new[] { "cefg", "dcbef", "fcge", "gbcadfe" }),
                    new(
                        new[]
                        {
                            "bdfegc", "cbegaf", "gecbf", "dfcage", "bdacg", "ed", "bedf", "ced", "adcbefg", "gebcd"
                        },
                        new[] { "ed", "bcgafe", "cdgba", "cbgef" }),
                    new(
                        new[]
                        {
                            "egadfb", "cdbfeg", "cegd", "fecab", "cgb", "gbdefca", "cg", "fgcdab", "egfdb", "bfceg"
                        },
                        new[] { "gbdfcae", "bgc", "cg", "cgb" }),
                    new(
                        new[]
                        {
                            "gcafb", "gcf", "dcaebfg", "ecagb", "gf", "abcdeg", "gaef", "cafbge", "fdbac", "fegbdc"
                        },
                        new[] { "fgae", "cfgab", "fg", "bagce" })
                },
                61229
            }
        };
        
        [Test]
        public override void ParseRawInputTest()
        {
            var rawInput = @"acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf
acedgfb cdfbe gcdfa fbcad dab ceffbd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbad";

            var input = _day.ParseRawInput(rawInput);

            input.ShouldBeEquivalentTo(new SignalPattern[]
            {
                new(new[] { "acedgfb", "cdfbe", "gcdfa", "fbcad", "dab", "cefabd", "cdfgeb", "eafb", "cagedb", "ab" },
                    new[] { "cdfeb", "fcadb", "cdfeb", "cdbaf" }),
                new(new[] { "acedgfb", "cdfbe", "gcdfa", "fbcad", "dab", "ceffbd", "cdfgeb", "eafb", "cagedb", "ab" },
                    new[] { "cdfeb", "fcadb", "cdfeb", "cdbad" })
            });
        }

        [Test]
        public void Part1_CountAppearanceOfDigits_1_4_7_8()
        {
            var input = (SignalPattern[]) _inputs[1][0];

            var result = _day.Part1(input);
            
            result.ShouldBe(26);
        }

        [Test]
        [TestCaseSource(nameof(_inputs))]
        public void Part2_DetermineDigits(SignalPattern[] input, int expectedResult)
        {
            var result = _day.Part2(input);
            
            result.ShouldBe(expectedResult);
        }
    }
}