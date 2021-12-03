using AdventOfCode.Days._2017;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2017
{
    public class Day7
    {
        private Days._2017.Day7 _day;

        private static object[] _inputs = {
            new object[] {
                new TowerProgram[]
                {
                    new("pbga", 66),
                    new("xhth", 57),
                    new("ebii", 61),
                    new("havc", 66),
                    new("ktlj", 57),
                    new("fwft", 72, new[] { "ktlj", "cntj", "xhth" }),
                    new("qoyq", 66),
                    new("padx", 45, new[] { "pbga", "havc", "qoyq" }),
                    new("tknk", 41, new[] { "ugml", "padx", "fwft" }),
                    new("jptl", 61),
                    new("ugml", 68, new[] { "gyxo", "ebii", "jptl" }),
                    new("gyxo", 61),
                    new("cntj", 57),
                }, 60},
            new object[] {
                new TowerProgram[]
                {
                    new("pbga", 66),
                    new("xhth", 57),
                    new("ebii", 61),
                    new("havc", 23, new []{"dupa", "dupa1"}),
                    new("ktlj", 57),
                    new("fwft", 72, new[] { "ktlj", "cntj", "xhth" }),
                    new("qoyq", 66),
                    new("padx", 45, new[] { "pbga", "havc", "qoyq" }),
                    new("tknk", 41, new[] { "ugml", "padx", "fwft" }),
                    new("jptl", 61),
                    new("ugml", 60, new[] { "gyxo", "ebii", "jptl" }),
                    new("gyxo", 61),
                    new("cntj", 57),
                    new("dupa", 22),
                    new("dupa1", 22)
                }, 22
            }
        };

        [SetUp]
        public void Initialize()
        {
            _day = new Days._2017.Day7();
        }

        [Test]
        public void ParseRawInput_ReturnsBottomProgramTree()
        {
            var rawInput = @"pbga (66)
xhth (57)
ebii (61)
havc (66)
ktlj (57)
fwft (72) -> ktlj, cntj, xhth
qoyq (66)
padx (45) -> pbga, havc, qoyq
tknk (41) -> ugml, padx, fwft
jptl (61)
ugml (68) -> gyxo, ebii, jptl
gyxo (61)
cntj (57)";

            var input = _day.ParseRawInput(rawInput);
            
            input.ShouldBeEquivalentTo(new TowerProgram[]
            {
                new("pbga", 66),
                new("xhth", 57),
                new("ebii", 61),
                new("havc", 66),
                new("ktlj", 57),
                new("fwft", 72, new []{"ktlj", "cntj","xhth"}),
                new("qoyq", 66),
                new("padx", 45, new []{"pbga", "havc", "qoyq"}),
                new("tknk", 41, new []{"ugml", "padx", "fwft"}),
                new("jptl", 61),
                new("ugml", 68, new []{"gyxo", "ebii", "jptl"}),
                new("gyxo", 61),
                new("cntj", 57),
            });
        }

        [Test]
        public void Part1_FindBottomProgram()
        {
            var input = new TowerProgram[]
            {
                new("pbga", 66),
                new("xhth", 57),
                new("ebii", 61),
                new("havc", 66),
                new("ktlj", 57),
                new("fwft", 72, new[] { "ktlj", "cntj", "xhth" }),
                new("qoyq", 66),
                new("padx", 45, new[] { "pbga", "havc", "qoyq" }),
                new("tknk", 41, new[] { "ugml", "padx", "fwft" }),
                new("jptl", 61),
                new("ugml", 68, new[] { "gyxo", "ebii", "jptl" }),
                new("gyxo", 61),
                new("cntj", 57),
            };

            var result = _day.Part1(input);
            
            result.ShouldBe("tknk");
        }
        
        [Test]
        [TestCaseSource(nameof(_inputs))]
        public void Part2_FindCorrectWeightForUnbalancedProgram(TowerProgram[] input, int expectedValue)
        {
            var result = _day.Part2(input);
            
            result.ShouldBe(expectedValue);
        }
    }
}