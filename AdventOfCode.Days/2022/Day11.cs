using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2022;

public class Day11 : AdventDay<Monkey[], int, long>
{
    public override Monkey[] ParseRawInput(string rawInput)
    {
        var monkeysNotes = rawInput.Trim().Split(Environment.NewLine + Environment.NewLine);
        var monkeys = new List<Monkey>();

        foreach (var note in monkeysNotes)
        {
            var lines = note.Split(Environment.NewLine);
            var worryLevels = lines[1][18..].Split(", ").Select(long.Parse).ToArray();

            var operationString = lines[2].Split(" = ")[1].Split(" ");
            var opLeft = operationString[0];
            var opOperation = operationString[1];
            var opRight = operationString[2];

            long Operation(long old)
            {
                var a = opLeft == "old" ? old : long.Parse(opLeft);
                var b = opRight == "old" ? old : long.Parse(opRight);

                if (opOperation == "*")
                {
                    return a * b;
                }

                return a + b;
            }

            var divisibleBy = int.Parse(lines[3][21..]);
            var ifTrue = int.Parse(lines[4][29..]);
            var ifFalse = int.Parse(lines[5][30..]);

            monkeys.Add(new Monkey(worryLevels, Operation, divisibleBy, ifTrue, ifFalse));
        }

        return monkeys.ToArray();
    }

    public override int Part1(Monkey[] input)
    {
        var monkeysCount = input.Length;
        var inspections = new int[monkeysCount];
        for (var i = 0; i < 20; i++)
        {
            for (var j = 0; j < input.Length; j++)
            {
                var monkey = input[j];
                inspections[j] += monkey.Items.Count;
                while (monkey.Items.TryDequeue(out var item))
                {
                    var worryLevel = monkey.Operation(item) / 3;
                    var isDivisible = worryLevel % monkey.TestDivisibleBy == 0;
                    var throwToMonkey = isDivisible ? monkey.IfTrue : monkey.IfFalse;
                    input[throwToMonkey].Items.Enqueue(worryLevel);
                }
            }
        }

        return inspections.OrderDescending().Take(2).Aggregate((curr, prev) => curr * prev);
    }

    public override long Part2(Monkey[] input)
    {
        var monkeysCount = input.Length;
        var inspections = new int[monkeysCount];
        var factor = input.Aggregate(1L, (f, m) => f * m.TestDivisibleBy);

        for (var i = 0; i < 10_000; i++)
        {
            for (var j = 0; j < input.Length; j++)
            {
                var monkey = input[j];
                inspections[j] += monkey.Items.Count;
                while (monkey.Items.TryDequeue(out var item))
                {
                    var worryLevel = monkey.Operation(item) % factor;
                    var isDivisible = worryLevel % monkey.TestDivisibleBy == 0;
                    var throwToMonkey = isDivisible ? monkey.IfTrue : monkey.IfFalse;

                    input[throwToMonkey].Items.Enqueue(worryLevel);
                }
            }
        }

        return inspections.OrderDescending().Take(2).Aggregate(1L, (curr, prev) => curr * prev);
    }
}

public class Monkey
{
    public Monkey(IEnumerable<long> worryLevels, Func<long, long> operation, int testDivisibleBy, int ifTrue,
        int ifFalse)
    {
        Items = new Queue<long>(worryLevels);
        Operation = operation;
        TestDivisibleBy = testDivisibleBy;
        IfTrue = ifTrue;
        IfFalse = ifFalse;
    }

    public Queue<long> Items { get; }
    public Func<long, long> Operation { get; }
    public int TestDivisibleBy { get; }
    public int IfTrue { get; }
    public int IfFalse { get; }
}