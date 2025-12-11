using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2024;

public class Day7 : AdventDay<Test[], long, long>
{
    public override Test[] ParseRawInput(string rawInput)
    {
        return rawInput
            .Trim()
            .Split(Environment.NewLine)
            .Select(x =>
            {
                var split = x.Split(": ");
                return new Test(
                    long.Parse(split[0]),
                    split[1].Split(" ").Select(long.Parse).ToArray()
                );
            })
            .ToArray();
    }

    public override long Part1(Test[] input)
    {
        var result = 0L;

        foreach (var test in input)
        {
            var operatorsCount = test.Numbers.Length - 1;
            var operatorCombinations = GenerateOperators(operatorsCount, ["*", "+"]);

            foreach (var operators in operatorCombinations)
            {
                var currentValue = test.Numbers[0];
                for (var i = 1; i < test.Numbers.Length; i++)
                {
                    if (currentValue > test.TestNumber)
                    {
                        goto ImpossibleTest;
                    }

                    var nextOperator = operators[i - 1];

                    if (nextOperator == "+")
                    {
                        currentValue += test.Numbers[i];
                    }
                    else
                    {
                        currentValue *= test.Numbers[i];
                    }
                }

                if (currentValue == test.TestNumber)
                {
                    result += test.TestNumber;
                    break;
                }

                ImpossibleTest:
                ;
            }
        }

        return result;
    }

    public override long Part2(Test[] input)
    {
        var result = 0L;

        foreach (var test in input)
        {
            var operatorsCount = test.Numbers.Length - 1;
            var operatorCombinations = GenerateOperators(operatorsCount, ["+", "*", "||"]);

            foreach (var operators in operatorCombinations)
            {
                var currentValue = test.Numbers[0];
                for (var i = 1; i < test.Numbers.Length; i++)
                {
                    if (currentValue > test.TestNumber)
                    {
                        goto ImpossibleTest;
                    }

                    var nextOperator = operators[i - 1];

                    switch (nextOperator)
                    {
                        case "+":
                            currentValue += test.Numbers[i];
                            break;
                        case "*":
                            currentValue *= test.Numbers[i];
                            break;
                        case "||":
                            currentValue = long.Parse(currentValue.ToString() + test.Numbers[i]);
                            break;
                    }
                }

                if (currentValue == test.TestNumber)
                {
                    result += test.TestNumber;
                    break;
                }

                ImpossibleTest:
                ;
            }
        }

        return result;
    }

    private static List<string[]> GenerateOperators(int length, string[] operators)
    {
        var results = new List<string[]>();
        var current = new string[length];

        Backtrack(0);
        return results;

        void Backtrack(int index)
        {
            if (index == length)
            {
                results.Add(current.ToArray());
                return;
            }

            foreach (var op in operators)
            {
                current[index] = op;
                Backtrack(index + 1);
            }
        }
    }
}

public class Test(long testNumber, long[] numbers)
{
    public long TestNumber { get; } = testNumber;
    public long[] Numbers { get; } = numbers;
}
