using AdventOfCode.Days._2017;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2017
{
    public class Day8
    {
        private Days._2017.Day8 _day;

        [SetUp]
        public void Initialize()
        {
            _day = new Days._2017.Day8();
        }

        [Test]
        public void ParseRawInput_IntoInstructionsArray()
        {
            var rawInput = @"b inc 5 if a > 1
a inc 1 if b < 5
c dec -10 if a >= 1
c inc -20 if c == 10";

            var input = _day.ParseRawInput(rawInput);
             
            input.ShouldBeEquivalentTo(new Instruction[]
            {
                new("b", Operation.INC, 5, new("a", ConditionType.GreaterThan, 1)),
                new("a", Operation.INC, 1, new("b", ConditionType.LessThan, 5)),
                new("c", Operation.DEC, -10, new("a", ConditionType.GreaterThanOrEqualTo, 1)),
                new("c", Operation.INC, -20, new("c", ConditionType.Equals, 10)),
            });
        }

        [Test]
        public void Part1_ExecuteInstruction_GetLargestValueInAnyRegister()
        {
            var input = new Instruction[]
            {
                new("b", Operation.INC, 5, new("a", ConditionType.GreaterThan, 1)),
                new("a", Operation.INC, 1, new("b", ConditionType.LessThan, 5)),
                new("c", Operation.DEC, -10, new("a", ConditionType.GreaterThanOrEqualTo, 1)),
                new("c", Operation.INC, -20, new("c", ConditionType.Equals, 10)),
            };

            var result = _day.Part1(input);
            
            result.ShouldBe(1);
        }
        
        [Test]
        public void Part2_ExecuteInstruction_GetLargestValueEverAppearedInRegisters()
        {
            var input = new Instruction[]
            {
                new("b", Operation.INC, 5, new("a", ConditionType.GreaterThan, 1)),
                new("a", Operation.INC, 1, new("b", ConditionType.LessThan, 5)),
                new("c", Operation.DEC, -10, new("a", ConditionType.GreaterThanOrEqualTo, 1)),
                new("c", Operation.INC, -20, new("c", ConditionType.Equals, 10)),
            };

            var result = _day.Part2(input);
            
            result.ShouldBe(10);
        }
    }
}