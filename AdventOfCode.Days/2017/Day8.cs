using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Enum;

namespace AdventOfCode.Days._2017
{
    public class Day8 : AdventDay<Instruction[], int, int>
    {
        public override Instruction[] ParseRawInput(string rawInput)
        {
            var instructionRegex =
                new Regex(
                    @"(?<registerName>[a-z]+) (?<operation>inc|dec) (?<value>-?[0-9]+) if (?<conditionRegisterName>[a-z]+) (?<conditionType>==|>=|<=|>|<|!=) (?<conditionValue>-?[0-9]+)");
            
            return rawInput.Trim().Split(Environment.NewLine).Select(x =>
            {
                var match = instructionRegex.Match(x);
                var instructionMatched = TryParse(match.Groups["operation"].ToString().ToUpper(), out Operation operation);

                if (!instructionMatched)
                {
                    throw new ArgumentException("Could not parse input", nameof(rawInput));
                }

                var conditionTypeString = match.Groups["conditionType"].ToString();
                var conditionType = ToConditionType(conditionTypeString);

                return new Instruction(match.Groups["registerName"].ToString(), operation,
                    int.Parse(match.Groups["value"].ToString()),
                    new Condition(match.Groups["conditionRegisterName"].ToString(), conditionType,
                        int.Parse(match.Groups["conditionValue"].ToString())));
            }).ToArray();
        }

        public override int Part1(Instruction[] input)
        {
            var (_, regexes) = ExecuteInstructions(input);
            return regexes.Values.Max();
        }

        public override int Part2(Instruction[] input)
        {
            var (maxValue, _) = ExecuteInstructions(input);
            return maxValue;
        }

        private static (int MaxValue, Dictionary<string, int> Regexes) ExecuteInstructions(Instruction[] input)
        {
            Dictionary<string, int> regexes = new();
            var maxValue = 0;

            foreach (var instruction in input)
            {
                if (!regexes.ContainsKey(instruction.RegisterName))
                {
                    regexes[instruction.RegisterName] = 0;
                }

                if (!regexes.ContainsKey(instruction.Condition.RegisterName))
                {
                    regexes[instruction.Condition.RegisterName] = 0;
                }

                var conditionPassed = IsConditionSuccess(instruction.Condition.RegisterName,
                    instruction.Condition.ConditionType, instruction.Condition.ConditionValue, regexes);

                if (!conditionPassed)
                {
                    continue;
                }

                regexes[instruction.RegisterName] +=
                    instruction.Operation == Operation.INC ? instruction.Value : -instruction.Value;

                maxValue = maxValue > regexes[instruction.RegisterName] ? maxValue : regexes[instruction.RegisterName];
            }

            return (maxValue, regexes);
        }

        private static bool IsConditionSuccess(string registerName, ConditionType conditionType, int conditionValue, Dictionary<string,int> regexes) => conditionType switch
        {
            ConditionType.Equals => regexes[registerName] ==
                                    conditionValue,
            ConditionType.NotEquals => regexes[registerName] !=
                                       conditionValue,
            ConditionType.GreaterThan => regexes[registerName] >
                                         conditionValue,
            ConditionType.LessThan => regexes[registerName] <
                                      conditionValue,
            ConditionType.GreaterThanOrEqualTo => regexes[registerName] >=
                                                  conditionValue,
            ConditionType.LessThanOrEqualTo => regexes[registerName] <=
                                               conditionValue,
            _ => throw new ArgumentOutOfRangeException(nameof(conditionType))
        };

        private static ConditionType ToConditionType(string conditionTypeString) => conditionTypeString switch
        {
            "==" => ConditionType.Equals,
            "!=" => ConditionType.NotEquals,
            ">" => ConditionType.GreaterThan,
            "<" => ConditionType.LessThan,
            ">=" => ConditionType.GreaterThanOrEqualTo,
            "<=" => ConditionType.LessThanOrEqualTo,
            _ => throw new ArgumentOutOfRangeException(nameof(conditionTypeString))
        };
    }

    public record Instruction(string RegisterName, Operation Operation, int Value, Condition Condition);

    public record Condition(string RegisterName, ConditionType ConditionType, int ConditionValue);

    public enum ConditionType
    {
        Equals,
        NotEquals,
        GreaterThan,
        LessThan,
        GreaterThanOrEqualTo,
        LessThanOrEqualTo
    }
    
    public enum Operation
    {
        INC,
        DEC
    }
}